using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsFinishedProductsPresentationExit : Form
    {
        string[] father = new string[3];
        DataSet ds = new DataSet();
        private DataTable dtDetail = new DataTable();
        SerialPortHelper s = null;
        double balanceValue = 0;
        private bool readPort = true;
        public SlpsFinishedProductsPresentationExit()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InitForm()
        {
            try
            {
                readPort = Common.GetReadPortFlag();
                if (readPort)
                {
                    textBoxGross.ReadOnly = true;
                }
                else
                {
                    textBoxGross.ReadOnly = false;
                }
                Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                this.textBoxFactory.Text = sysSetting.WERKS;
                this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                this.textBoxExitTime.Text = Common.GetServerDate();
                s = new SerialPortHelper(ref serialPort);
                this.textBoxPrompt.Text = Common.GetHelpStr("成品免费赠送出厂");
                this.timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "FinishedProductsPresentation");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                this.textBoxCar.Text = father[0].ToString();
                this.textBoxRSNUM.Text = father[1].ToString();
                Sdl_FinishedProductsPresentationTitle fppt = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                if (!CheckDB(fppt))
                {
                    return;
                }
                this.textBoxDBNum.Text = fppt.DBNUM;
                this.textBoxTare.Text = fppt.TARE.ToString();
                InitDetailsDataBind();
            }
        }

        private bool CheckDB(Sdl_FinishedProductsPresentationTitle fppt)
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = fppt.DBNUM;
            if (enterDB != exitDB)
            {
                DialogResult dr = MessageBox.Show(this, "入厂地磅与出厂地磅不同，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        private void InitDetailsDataBind()
        {
            try
            {
                ListDictionary la = new ListDictionary();
                la.Add("RSNUM", TypeConverter.ToDBC(textBoxRSNUM.Text));
                la.Add("WERKS", textBoxFactory.Text);
                ListDictionary lt = new ListDictionary();
                lt.Add("ZRESB", "RSNUM,RSPOS,MATNR,MAKTX,BDMNG");
                ListDictionary lr = new ListDictionary();
                ds = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_RESB_RC", la, lt, ref lr);

                dtDetail = ds.Tables[0];
                dtDetail.Columns.Add("LEFTNUM");
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    double overNum = Sdl_FinishedProductsPresentationAdapter.GetSdl_FinishedProductsPresentationOverNum(" WHERE RSNUM = '" + dtDetail.Rows[i]["RSNUM"].ToString() + "' and RSPOS='" + dtDetail.Rows[i]["RSPOS"].ToString() + "' ");
                    dtDetail.Rows[i]["LEFTNUM"] = (double.Parse(dtDetail.Rows[i]["BDMNG"].ToString()) + overNum).ToString();
                }


                DataTable dtGv = new DataSetHelper().GetNewDataTable(dtDetail, " 1=1 ", "");

                dtGv.Columns.Add("OVERNUM");
                dtGv.Columns.Add("REALMENGE");
                dtGv.Columns.Add("SFIMG");
                dtGv.Columns.Add("SGTXT");
                dtGv.Columns.Add("WERKS");
                dtGv.Columns.Add("LGORT");

                for (int i = 0; i < dtGv.Rows.Count; i++)
                {
                    double overNum = Sdl_FinishedProductsPresentationAdapter.GetSdl_FinishedProductsPresentationOverNum(" WHERE RSNUM = '" + dtGv.Rows[i]["RSNUM"].ToString() + "' and RSPOS='" + dtGv.Rows[i]["RSPOS"].ToString() + "' ");
                    dtGv.Rows[i]["OVERNUM"] = overNum.ToString();
                }

                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dtGv;

                for (int i = 0; i < dataGridViewDetails.Columns.Count; i++)
                {
                    if (i == 8)
                        break;
                    dataGridViewDetails.Columns[i].ReadOnly = true;
                }


                DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where ( lgort like '1%' or  lgort like '3%' ) and werks='" + textBoxFactory.Text + "' ").Tables[0];
                DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();
                cmbColumnPro.DataPropertyName = "lgort";
                cmbColumnPro.DataSource = dtCombox;
                cmbColumnPro.ValueMember = "lgort";
                cmbColumnPro.DisplayMember = "lgobe";

                this.dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
                dataGridViewDetails.Columns.Remove("LGORT");
                cmbColumnPro.Name = "LGORT";
                cmbColumnPro.HeaderText = "发货仓库";

                DataTable dtPackWeight = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
                DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[8];
                cbcpw.DataPropertyName = "pweight";
                cbcpw.DataSource = dtPackWeight;
                cbcpw.ValueMember = "包重";
                cbcpw.DisplayMember = "说明";
                cbcpw.Name = "PWEIGHT";
                cbcpw.HeaderText = "包重";

                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private bool ValidateControl(DataTable dt)
        {
            try
            {

                if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
                {
                    MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(textBoxSgtxt.Text))
                {
                    MessageBox.Show(this, "领料人不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    string realNum = dataGridViewDetails.Rows[i].Cells["REALMENGE"].Value.ToString();
                    if (!ValidateHelper.IsNumber(realNum))
                    {
                        MessageBox.Show(this, "请输入实发件数,实发件数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    string realfimg = dataGridViewDetails.Rows[i].Cells["SFIMG"].Value.ToString();
                    if (!ValidateHelper.IsNumber(realfimg) && !ValidateHelper.IsDecimal(realfimg))
                    {
                        MessageBox.Show(this, "请输入实发吨数,实发吨数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    if (string.IsNullOrEmpty(lgort))
                    {
                        MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                DataTable dtDistinct = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "RSNUM", "RSPOS", "MATNR", "LGORT" });
                if (dt.Rows.Count != dtDistinct.Rows.Count)
                {
                    MessageBox.Show(this, "同一预留单同一物料必须在不同仓库发货！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                DataTable dtTemp = new DataTable();
                double lfGvSum = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string rsnum = dt.Rows[j]["RSNUM"].ToString();
                    string repos = dt.Rows[j]["RSPOS"].ToString();
                    string matnr = dt.Rows[j]["MATNR"].ToString();
                    double lf = double.Parse(dt.Rows[j]["LEFTNUM"].ToString());
                    double lfGv = 0;
                    lfGv = double.Parse(dt.Rows[j]["REALMENGE"].ToString()) * double.Parse(dataGridViewDetails.Rows[j].Cells["pweight"].Value.ToString()) / 1000.0;
                    lfGvSum += lfGv;
                }
                double netValue = double.Parse(textBoxNet.Text);
                balanceValue = Math.Round(Math.Abs(netValue - lfGvSum), 3);
                if (balanceValue > 0)
                {
                    if (MessageBox.Show("实发吨数与实际过磅数量应该相等,差异为" + balanceValue.ToString() + ",确认过账吗？", "史丹利地磅系统 - 产成品赠送出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "史丹利地磅系统 - 产成品赠送出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataGridViewCell dCell = null;
                if (dataGridViewDetails.Rows.Count != 0)
                {
                    dCell = dataGridViewDetails.Rows[0].Cells[0];
                }
                dataGridViewDetails.CurrentCell = dCell;
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                if (dtGv == null || dtGv.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有预留单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_FinishedProductsPresentationTitle modelEnter = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(textBoxCar.Text, father[1].ToString(), father[2].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HS_FLAG == "S")
                {
                    MessageBox.Show(this, "该车已经发货成功，不能再次发货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测SAP
                DataTable dtUpData = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                for (int i = 0; i < dtUpData.Rows.Count; i++)
                {
                    dtUpData.Rows[i]["RSNUM"] = dtUpData.Rows[i]["RSNUM"].ToString().Trim();
                    dtUpData.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();
                    dtUpData.Rows[i]["SGTXT"] = textBoxSgtxt.Text;
                    string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                    dtUpData.Rows[i]["SFIMG"] = double.Parse(dtUpData.Rows[i]["REALMENGE"].ToString()) * double.Parse(dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString()) / 1000.0;
                }
                dtUpData.Columns.Remove("OVERNUM");
                dtUpData.Columns.Remove("MAKTX");
                dtUpData.Columns.Remove("REALMENGE");
                dtUpData.Columns.Remove("BDMNG");
                dtUpData.Columns.Remove("LEFTNUM");

                ListDictionary ltPara = new ListDictionary();
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dtUpData);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();

                DataSet dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_RESB_GZ_CHECK", ltPara, ltParaTb, lt, ref lr);


                string str = string.Empty;
                for (int j = 0; j < dtInfo.Tables[0].Rows.Count; j++)
                {
                    if (dtInfo.Tables[0].Rows.Count == 1)
                    {
                        str += dtInfo.Tables[0].Rows[j][0].ToString();
                    }
                    else
                    {
                        str += dtInfo.Tables[0].Rows[j][0].ToString() + "\n\r";
                    }
                }
                if (str.IndexOf("检查成功") < 0)
                {
                    MessageBox.Show(this, str, "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataSet dtGZ = new DataSet();
                try
                {
                    dtGZ = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_RESB_GZ", ltPara, ltParaTb, lt, ref lr);
                }
                catch (Exception e2x)
                {
                    MessageBox.Show("调用SAP RFC过账失败！，请检查网络原因或者联系管理员！");
                    this.Close();
                    return;
                }
                if (dtGZ.Tables[0] == null)
                {
                    MessageBox.Show(this, "调用SAP RFC函数失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                str = string.Empty;
                for (int j = 0; j < dtGZ.Tables[0].Rows.Count; j++)
                {
                    if (dtGZ.Tables[0].Rows.Count == 1)
                    {
                        str += dtGZ.Tables[0].Rows[j][0].ToString();
                    }
                    else
                    {
                        str += dtGZ.Tables[0].Rows[j][0].ToString() + "\n\r";
                    }
                }
                if (str.IndexOf("成功创建") < 0)
                {
                    MessageBox.Show(this, str, "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    modelEnter.BALANCE = float.Parse(balanceValue.ToString());
                    modelEnter.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                    modelEnter.EXITWEIGHMAN = textBoxWeighMan.Text;
                    modelEnter.GROSS = float.Parse(textBoxGross.Text);
                    modelEnter.HS_FLAG = "S";
                    modelEnter.NET = float.Parse(textBoxNet.Text);
                    modelEnter.EXITFLAG = 0;
                    Sdl_FinishedProductsPresentationTitleAdapter.UpdateSdl_FinishedProductsPresentationTitle(modelEnter);

                    Sdl_FinishedProductsPresentation fpp = new Sdl_FinishedProductsPresentation();
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        fpp.TIMEFLAG = modelEnter.TIMEFLAG;
                        fpp.LGORT = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                        fpp.MAKTX = dataGridViewDetails.Rows[i].Cells["MAKTX"].Value.ToString();
                        fpp.MATNR = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString();
                        fpp.BDMNG = double.Parse(dataGridViewDetails.Rows[i].Cells["BDMNG"].Value.ToString());
                        fpp.REALMENGE = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["REALMENGE"].Value);
                        fpp.RSNUM = dataGridViewDetails.Rows[i].Cells["RSNUM"].Value.ToString();
                        fpp.RSPOS = dataGridViewDetails.Rows[i].Cells["RSPOS"].Value.ToString();
                        fpp.SGTXT = textBoxSgtxt.Text;
                        fpp.SFIMG = double.Parse(dataGridViewDetails.Rows[i].Cells["SFIMG"].Value.ToString());
                        Sdl_FinishedProductsPresentationAdapter.AddSdl_FinishedProductsPresentation(fpp);
                    }
                    Common.PlayGoodBye();
                    MessageBox.Show(this, str, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "向SAP过账成功，向地磅数据库操作失败，请联系管理员！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void toolStripButtonReturn_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            if (toolStripButton.Text != "解锁")
            {
                MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridViewDetails.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有预留号相关信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
            {
                MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
            {
                MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double ylsl = 0;    //  预留数量
            double sfsl = 0;    //  实发数量
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++ )
            {
                ylsl = double.Parse(dataGridViewDetails.Rows[i].Cells["LEFTNUM"].Value.ToString());
                sfsl = double.Parse(dataGridViewDetails.Rows[i].Cells["LEFTNUM"].Value.ToString());
                if (ylsl < sfsl)
                {
                    MessageBox.Show(this, "项目0"+(i+1)+"实发数量大于预留数量，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (Math.Round(double.Parse(textBoxNet.Text), 3) != 0)
            {
                if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-成品赠送出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }

            //头信息操作
            Sdl_FinishedProductsPresentationTitle model = new Sdl_FinishedProductsPresentationTitle();
            model = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(textBoxCar.Text, textBoxRSNUM.Text, father[2].ToString());
            if (model == null)
            {
                MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (model.HS_FLAG == "S")
            {
                MessageBox.Show(this, "该车已经发货出厂，不能再次发货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            model.BALANCE = 0;
            model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
            model.EXITWEIGHMAN = textBoxWeighMan.Text;
            model.GROSS = float.Parse(textBoxGross.Text);
            model.TARE = float.Parse(textBoxTare.Text);
            model.HS_FLAG = "S";
            model.NET = float.Parse(textBoxNet.Text);
            model.EXITFLAG = 1;
            Sdl_FinishedProductsPresentationTitleAdapter.UpdateSdl_FinishedProductsPresentationTitle(model);
            MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Common.PlayGoodBye();
            this.Close();
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDetails.Rows.Count == 0)
                return;
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (columnIndex == 0)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataRow dr = dt.NewRow();
                dr["RSNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["RSNUM"].Value.ToString();
                dr["RSPOS"] = dataGridViewDetails.Rows[rowIndex].Cells["RSPOS"].Value.ToString();
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                dr["BDMNG"] = dataGridViewDetails.Rows[rowIndex].Cells["BDMNG"].Value.ToString();
                dr["OVERNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["OVERNUM"].Value.ToString();
                dr["LEFTNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["LEFTNUM"].Value.ToString();
                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            if (columnIndex == 12)
            {
                string rsnum = dataGridViewDetails.Rows[rowIndex].Cells["RSNUM"].Value.ToString();
                string rspos = dataGridViewDetails.Rows[rowIndex].Cells["RSPOS"].Value.ToString();
                string matnr = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();

                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                //DataTable dtCount = new DataSetHelper().GetNewDataTable(dt, " RSNUM = '" + rsnum + "' and RSPOS='" + rspos + "' and MATNR='" + matnr + "'", "");
                if (dt != null && dt.Rows.Count > 1)
                {
                    dataGridViewDetails.Rows.RemoveAt(e.RowIndex);
                    textBoxTotalSfimg.Text = GetTotalWeight();
                }
                else
                {
                    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string GetTotalWeight()
        {
            double price = 0;
            double realNum = 0;
            string matnr = "";

            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                try
                {
                    string strValue = dataGridViewDetails.Rows[i].Cells[9].Value.ToString();
                    strValue = strValue.Trim() == "" ? "0" : strValue;
                    realNum = Convert.ToDouble(strValue);
                    matnr = dataGridViewDetails.Rows[i].Cells[3].Value.ToString();
                    price += realNum * double.Parse(dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString()) / 1000.0;
                }
                catch
                {
                }
            }

            return price.ToString();
        }

        //private double GetMatnrWeight(string matnr)
        //{
        //    string weight = string.Empty; ;
        //    if (matnr.Length >= 13)
        //        weight = matnr.Substring(matnr.Length - 4, 1);
        //    double returnValue = 0;
        //    switch (weight)
        //    {
        //        case "1":
        //            returnValue = double.Parse(Common.Weight1.ToString());
        //            break;
        //        case "2":
        //            returnValue = double.Parse(Common.Weight2.ToString());
        //            break;
        //        case "3":
        //            returnValue = double.Parse(Common.Weight3.ToString());
        //            break;
        //        case "4":
        //            returnValue = double.Parse(Common.Weight4.ToString());
        //            break;
        //        default:
        //            returnValue = double.Parse(Common.Weight1.ToString());
        //            break;
        //    }
        //    return returnValue;
        //}

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string currentValue = dataGridViewDetails.CurrentCell.FormattedValue.ToString();
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 9)
                {
                    int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                    if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                        currentValue = "0";
                    if (!ValidateHelper.IsNumber(currentValue))
                    {
                        MessageBox.Show(this, "实发数量应为整数", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string matnr = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                    int num = int.Parse(currentValue);
                    dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value = num * double.Parse(dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value.ToString()) / 1000.0;
                }
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 8)
                {
                    try
                    {
                        int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                        if (dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value.ToString() == "")
                        {
                            currentValue = "0";
                        }
                        string matnr = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                        int num = int.Parse(currentValue);
                        dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value = num * double.Parse(dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value.ToString()) / 1000.0;
                    }
                    catch
                    {
                    }
                }
                textBoxTotalSfimg.Text = GetTotalWeight();
            }
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text), 3).ToString();
            }
            catch
            {

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!readPort)
            {
                return;
            }
            DBStatus status = DBStatus.Normal;
            double showNum = s.ShowWeight(ref status);
            this.textBoxGross.Text = showNum.ToString();
            if (status == DBStatus.Normal)
            {
                textBoxWeight.Text = showNum.ToString();
            }
            else
            {
                textBoxWeight.Text = Common.GetEnumDescription(status);
            }
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text), 3).ToString();
            }
            catch
            {

            }
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            if (toolStripButton.Text == "锁定")
            {
                timer.Stop();
                toolStripButton.Text = "解锁";
                toolStripButton.Image = DBSolution2.Properties.Resources.Unlock;
            }
            else
            {
                timer.Start();
                toolStripButton.Text = "锁定";
                toolStripButton.Image = DBSolution2.Properties.Resources.Lock;
            }
        }
    }
}
