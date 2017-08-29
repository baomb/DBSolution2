using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;
using System.Threading;
using SdlDB.Utility;
using System.Collections;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class ProductReturnMerchantExit : Form
    {
        private string[] father = new string[] { "", "" };
        private DataTable dtSapDetail = new DataTable();
        private DataTable dtSelect = new DataTable();
        private const string AUGRU = "002";
        SerialPortHelper s = null;
        private bool readPort = true;
        public ProductReturnMerchantExit()
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
            readPort = Common.GetReadPortFlag();
            if (readPort)
            {
                textBoxTare.ReadOnly = true;
            }
            else
            {
                textBoxTare.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxPrompt.Text = Common.GetHelpStr("总公司成品经销商退货出厂");
            this.timer.Start();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", "史丹利地磅系统-总公司成品经销商退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private bool ValidateControl(DataTable dt)
        {
            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
            {
                MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(textBoxGrossE.Text) || ValidateHelper.IsNumber(textBoxGrossE.Text)))
            {
                MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (!(ValidateHelper.IsDecimalSign(textBoxKuijian.Text) || ValidateHelper.IsNumberSign(textBoxKuijian.Text)))
            //{
            //    MessageBox.Show(this, "亏件数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                string realNum = dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value.ToString();
                if (!ValidateHelper.IsNumber(realNum) && !ValidateHelper.IsDecimal(realNum))
                {
                    MessageBox.Show(this, "请输入实退件数,实退件数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string realfimg = dataGridViewDetails.Rows[i].Cells["SFIMG"].Value.ToString();
                if (!ValidateHelper.IsNumber(realfimg) && !ValidateHelper.IsDecimal(realfimg))
                {
                    MessageBox.Show(this, "请输入实退吨数,实退吨数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                if (string.IsNullOrEmpty(lgort))
                {
                    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            DataTable dtDistinct = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "VBELN", "POSNR", "MATNR", "LGORT" });
            if (dt.Rows.Count != dtDistinct.Rows.Count)
            {
                MessageBox.Show(this, "同一退货单同一物料必须在不同仓库退货！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataTable dtTemp = new DataTable();
            double lfSum = 0;
            double lfGvSum = 0;
            for (int j = 0; j < dtSelect.Rows.Count; j++)
            {
                string vbeln = dtSelect.Rows[j]["VBELN"].ToString();
                string posnr = dtSelect.Rows[j]["POSNR"].ToString();
                string matnr = dtSelect.Rows[j]["MATNR"].ToString();
                double lf = double.Parse(dtSelect.Rows[j]["LFIMG"].ToString());

                dtTemp = new DataSetHelper().GetNewDataTable(dt, " VBELN = '" + vbeln + "' and POSNR='" + posnr + "' and MATNR='" + matnr + "'", "");
                double lfGv = 0;
                for (int n = 0; n < dtTemp.Rows.Count; n++)
                {
                    //lfGv += double.Parse(dtTemp.Rows[n]["SFIMG"].ToString()) * GetMatnrWeight(matnr) / 1000;
                    lfGv += double.Parse(dtTemp.Rows[n]["SFIMG"].ToString());
                }
                if (Math.Round(lf, 3) < Math.Round(lfGv, 3))
                {
                    MessageBox.Show(this, "行项目中物料的实退吨数不能大于订单吨数，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                lfSum += lf;
                lfGvSum += lfGv;
            }


            double netValue = double.Parse(textBoxNet.Text);
            //double balanceValue = Common.GetBalanceValue();
            //if (balanceValue == -1)
            //{
            //    MessageBox.Show(this, "读取地磅容差错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (!((netValue - balanceValue) <= lfSum && lfSum <= (netValue + balanceValue)))
            if (Math.Round(Math.Abs(netValue - lfGvSum), 3) > 0)
            {
                if (MessageBox.Show("实退吨数与实际过磅数量应该相等，确认过账吗?", "总公司成品退货出厂(经销商)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }

            //if (double.Parse(textBoxNet.Text) != lfGvSum)
            //{
            //    MessageBox.Show(this, "实退吨数应与地磅数量相等！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            return true;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-总公司成品退货出厂(经销商)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
                    MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_ProductReturnMerchant modelEnter = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(textBoxCar.Text, father[1].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经退货成功，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测SAP
                DataTable dtUpData = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                for (int i = 0; i < dtUpData.Rows.Count; i++)
                {
                    dtUpData.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();
                    //string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                    //dtUpData.Rows[i]["SFIMG"] = double.Parse(dtUpData.Rows[i]["REALZFIMG"].ToString()) * GetMatnrWeight(matnr) / 1000;
                }

                ListDictionary ltPara = new ListDictionary();
                DataTable dtNew = new DataSetHelper().SelectDistinct("dtNew", dtUpData, new string[] { "VBELN", "POSNR", "MATNR", "SFIMG", "WERKS", "LGORT" });
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dtNew);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();
                try
                {
                    //使用SAP通信
                    DataSet dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_FERT_MUTUAL_RE_GZ_CHECK", ltPara, ltParaTb, lt, ref lr);

                    string str = string.Empty;
                    if (dtInfo.Tables[0].Rows.Count > 0)
                    {
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
                    }
                    if (str.Trim() != "检查成功")
                    {
                        MessageBox.Show(this, str, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //使用SAP通信
                    DataSet dtGZ = new DataSet();
                    try
                    {
                        dtGZ = SAPHelper.InvokSAPFunTable("Z_SDL_FERT_MUTUAL_RE_GZ", ltPara, ltParaTb, lt, ref lr);
                    }
                    catch
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
                    string strInfo = string.Empty;
                    if (dtGZ.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < dtGZ.Tables[0].Rows.Count; j++)
                        {
                            if (dtGZ.Tables[0].Rows.Count == 1)
                            {
                                strInfo += dtGZ.Tables[0].Rows[j][0].ToString();
                            }
                            else
                            {
                                strInfo += dtGZ.Tables[0].Rows[j][0].ToString() + "\n\r";
                            }
                        }
                    }

                    if (strInfo.IndexOf("过账成功") < 0)
                    {
                        MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        Sdl_ProductReturnMerchantAdapter.DeleteSdl_ProductReturnMerchantByTimeFlag(father[1].ToString(), textBoxCar.Text);
                        //头信息操作
                        Sdl_ProductReturnMerchant model = new Sdl_ProductReturnMerchant();
                        for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                        {
                            if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                model = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(textBoxCar.Text, dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString(), father[1].ToString());
                                if (model == null)
                                {
                                    model = new Sdl_ProductReturnMerchant();
                                }
                                model.ENTERTIME = modelEnter.ENTERTIME;
                                model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                                model.GROSS = double.Parse(textBoxGrossE.Text);
                                model.HSFLAG = "S";
                                model.KUNNR = modelEnter.KUNNR;
                                model.NAME1 = modelEnter.NAME1;
                                model.TARE = double.Parse(textBoxTare.Text);
                                model.TIMEFLAG = modelEnter.TIMEFLAG;
                                model.VBELN = dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString();
                                model.ENTERWEIGHMAN = modelEnter.ENTERWEIGHMAN;
                                model.EXITWEIGHMAN = textBoxWeighMan.Text;
                                model.WERKS = textBoxFactory.Text;
                                model.KUIJIAN = 0;
                                model.TYPEID = 0;
                                if (model.TRUCKNUM == "")
                                {
                                    model.TRUCKNUM = modelEnter.TRUCKNUM;
                                    Sdl_ProductReturnMerchantAdapter.AddSdl_ProductReturnMerchant(model);
                                }
                                else
                                {
                                    model.TRUCKNUM = modelEnter.TRUCKNUM;
                                    Sdl_ProductReturnMerchantAdapter.UpdateSdl_ProductReturnMerchant(model);
                                }
                            }
                        }


                        //行项目操作
                        Sdl_ProductReturnMerchantDetail modelDetail = new Sdl_ProductReturnMerchantDetail();

                        for (int i = 0; i < dtGv.Rows.Count; i++)
                        {
                            modelDetail.LFIMG = double.Parse(dtGv.Rows[i]["LFIMG"].ToString());
                            modelDetail.LGORT = dtGv.Rows[i]["LGORT"].ToString();
                            modelDetail.MAKTX = dtGv.Rows[i]["MAKTX"].ToString();
                            modelDetail.MATNR = dtGv.Rows[i]["MATNR"].ToString();
                            modelDetail.POSNR = dtGv.Rows[i]["POSNR"].ToString();
                            modelDetail.REALZFIMG = double.Parse(dtGv.Rows[i]["REALZFIMG"].ToString());
                            modelDetail.SFIMG = double.Parse(dtGv.Rows[i]["SFIMG"].ToString());
                            modelDetail.TIMEFLAG = modelEnter.TIMEFLAG;
                            modelDetail.VBELN = dtGv.Rows[i]["VBELN"].ToString();
                            string zf = dtGv.Rows[i]["ZFIMG"].ToString();
                            modelDetail.ZFIMG = double.Parse(zf);
                            Sdl_ProductReturnMerchantDetailAdapter.AddSdl_ProductReturnMerchantDetail(modelDetail);
                        }
                        Sdl_TruckWeight tw = new Sdl_TruckWeight();
                        tw.ENTERTIME = modelEnter.ENTERTIME;
                        tw.TARE = float.Parse(textBoxTare.Text);
                        tw.TIMEFLAG = modelEnter.TIMEFLAG;
                        tw.TRUCKNUM = modelEnter.TRUCKNUM;
                        tw.WERKS = modelEnter.WERKS;
                        Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                        MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Common.PlayGoodBye();
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
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "ProductReturnMerchant");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                this.textBoxCar.Text = father[0].ToString();
            }
        }

        private void textBoxCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtBefore = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchantSetByFeild(new string[] { "VBELN" }, " where trucknum='" + textBoxCar.Text + "' and timeflag='" + father[1].ToString() + "' and HSFLAG = 'H' ").Tables[0];
                ArrayList arrayStr = new ArrayList();
                foreach (DataRow dr in dtBefore.Rows)
                {
                    arrayStr.Add(dr["VBELN"].ToString());
                }
                InitSelectDataBind(arrayStr);
                InitDetailBind(arrayStr);
                BindEnterData();
            }
        }

        private void BindEnterData()
        {
            Sdl_ProductReturnMerchant title = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(textBoxCar.Text, father[1].ToString());
            if (title != null)
            {
                if (!CheckDB(title))
                {
                    return;
                }
                this.textBoxDBNum.Text = title.DBNUM;
                textBoxGrossE.Text = title.GROSS.ToString();
            }
        }

        private bool CheckDB(Sdl_ProductReturnMerchant title)
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = title.DBNUM;
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

        private void InitSelectDataBind(ArrayList arrayStr)
        {
            try
            {
                ListDictionary la = new ListDictionary();
                la.Add("AUGRU", AUGRU);
                la.Add("WERKS", textBoxFactory.Text);
                ListDictionary lt = new ListDictionary();
                lt.Add("ZLIPS", "VBELN,POSNR,MATNR,MAKTX,KUNNR,NAME1,LFIMG,ZFIMG");
                ListDictionary lr = new ListDictionary();
                DataSet ds = SAPHelper.InvokSAPFun("Z_SDL_FERT_MUTUAL_RE_RC", la, lt, ref lr);

                DataTable dtSap = new DataSetHelper().SelectDistinct("dtTitle", ds.Tables[0], new string[] { "VBELN", "KUNNR", "NAME1" });

                dtSapDetail = new DataSetHelper().SelectDistinct("dtDetail", ds.Tables[0], new string[] { "VBELN", "POSNR", "MATNR", "MAKTX", "LFIMG", "ZFIMG" });
                dtSapDetail.Columns.Add("SFIMG");
                dtSapDetail.Columns.Add("REALZFIMG");
                dtSapDetail.Columns.Add("WERKS");
                dtSapDetail.Columns.Add("LGORT");

                string where = GetDataTableWhere(arrayStr);
                DataTable dtTitle = new DataSetHelper().GetNewDataTable(dtSap, where, "");
                dataGridViewSelect.AutoGenerateColumns = false;
                dataGridViewSelect.DataSource = dtTitle;

                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewSelect.Rows[i].Cells["chk"];
                    chk.Value = true;
                }

                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void InitDetailBind(ArrayList arrayVbeln)
        {
            string where = GetDataTableWhere(arrayVbeln);
            dtSelect = new DataSetHelper().GetNewDataTable(dtSapDetail, where, "");
            DataTable dtGv = new DataSetHelper().GetNewDataTable(dtSelect, " 1=1 ", "");
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dtGv;

            DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where lgort like '1%' and werks='" + textBoxFactory.Text + "' ").Tables[0];
            DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();

            cmbColumnPro.DataPropertyName = "lgort";
            cmbColumnPro.DataSource = dtCombox;
            cmbColumnPro.ValueMember = "lgort";
            cmbColumnPro.DisplayMember = "lgobe";

            int i = dataGridViewDetails.Columns["LGORT"].Index;
            this.dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
            dataGridViewDetails.Columns.Remove("LGORT");

            cmbColumnPro.Name = "LGORT";
            cmbColumnPro.HeaderText = "收货仓库";
        }

        private string GetDataTableWhere(ArrayList arrayVbeln)
        {
            string where = "''";
            for (int j = 0; j < arrayVbeln.Count; j++)
            {
                where += ",'" + arrayVbeln[j].ToString() + "'";
            }
            return " VBELN IN (" + where + ")";
        }

        private void dataGridViewSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

            ArrayList arrayStr = new ArrayList();
            for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
            {
                if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                {
                    arrayStr.Add(dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString());
                }
            }
            InitDetailBind(arrayStr);
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (columnIndex == 0)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataRow dr = dt.NewRow();
                dr["VBELN"] = dataGridViewDetails.Rows[rowIndex].Cells["VBELN"].Value.ToString();
                dr["POSNR"] = dataGridViewDetails.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                dr["LFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["LFIMG"].Value.ToString();
                dr["ZFIMG"] = dt.Rows[rowIndex]["ZFIMG"].ToString();
                //dr["SFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value.ToString();
                //dr["REALZFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["REALZFIMG"].Value.ToString();

                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            if (columnIndex == 9)
            {
                string vbeln = dataGridViewDetails.Rows[rowIndex].Cells["VBELN"].Value.ToString();
                string posnr = dataGridViewDetails.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                string matnr = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();

                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataTable dtCount = new DataSetHelper().GetNewDataTable(dt, " VBELN = '" + vbeln + "' and POSNR='" + posnr + "' and MATNR='" + matnr + "'", "");
                if (dtCount != null && dtCount.Rows.Count > 1)
                {
                    dataGridViewDetails.Rows.RemoveAt(e.RowIndex);
                    textBoxLFIMG.Text = GetTotalWeight();
                }
                else
                {
                    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private double GetMatnrWeight(string matnr)
        {
            string weight = string.Empty; ;
            if (matnr.Length >= 13)
                weight = matnr.Substring(matnr.Length - 4, 1);
            double returnValue = 0;
            switch (weight)
            {
                case "1":
                    returnValue = double.Parse(Common.Weight1.ToString());
                    break;
                case "2":
                    returnValue = double.Parse(Common.Weight2.ToString());
                    break;
                case "3":
                    returnValue = double.Parse(Common.Weight3.ToString());
                    break;
                case "4":
                    returnValue = double.Parse(Common.Weight4.ToString());
                    break;
                default:
                    returnValue = double.Parse(Common.Weight1.ToString());
                    break;
            }
            return returnValue;
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string currentValue = dataGridViewDetails.CurrentCell.FormattedValue.ToString();
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 7)
                {
                    if (!ValidateHelper.IsDecimal(currentValue) && !ValidateHelper.IsNumber(currentValue))
                    {
                        if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                            return;
                        MessageBox.Show(this, "实发数量应为数值", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        textBoxLFIMG.Text = GetTotalWeight();
                    }
                }

            }
        }

        private string GetTotalWeight()
        {
            double price = 0;
            double realNum = 0;
            string matnr = "";
            if (dataGridViewDetails.CurrentCell.ColumnIndex == 7)
            {
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    try
                    {
                        string strValue = dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value.ToString();
                        strValue = strValue.Trim() == "" ? "0" : strValue;
                        realNum = Convert.ToDouble(strValue);
                        matnr = dataGridViewDetails.Rows[i].Cells[3].Value.ToString();
                        price += realNum * GetMatnrWeight(matnr) / 1000;
                    }
                    catch
                    {
                    }
                }
            }
            return price.ToString();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要重车出厂吗?", "史丹利地磅系统-总公司成品退货出厂(经销商)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                if (dtGv == null || dtGv.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有交货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
                {
                    MessageBox.Show(this, "地磅数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据不能为空或者字符，应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGrossE.Text) || ValidateHelper.IsNumber(textBoxGrossE.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double netValue = double.Parse(textBoxNet.Text);
                //double balanceValue = Common.GetBalanceValue();
                //if (balanceValue == -1)
                //{
                //    MessageBox.Show(this, "读取地磅容差错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //if (!((netValue - balanceValue) <= lfSum && lfSum <= (netValue + balanceValue)))
                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("重车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-总公司成品退货出厂(经销商)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                //if (textBoxNet.Text != "0")
                //{
                //    MessageBox.Show(this, "重车出厂时，毛重与皮重数值应该相等，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                Sdl_ProductReturnMerchant modelEnter = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(textBoxCar.Text, father[1].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经退货成功，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Sdl_ProductReturnMerchantAdapter.DeleteSdl_ProductReturnMerchantByTimeFlag(father[1].ToString(), textBoxCar.Text);
                //头信息操作
                Sdl_ProductReturnMerchant model = new Sdl_ProductReturnMerchant();
                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        model = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(textBoxCar.Text, dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString(), father[1].ToString());
                        if (model == null)
                        {
                            model = new Sdl_ProductReturnMerchant();
                        }
                        model.ENTERTIME = modelEnter.ENTERTIME;
                        model.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                        model.GROSS = double.Parse(textBoxGrossE.Text);
                        model.TARE = double.Parse(textBoxTare.Text);
                        model.HSFLAG = "S";
                        model.KUNNR = modelEnter.KUNNR;
                        model.NAME1 = modelEnter.NAME1;
                        model.TIMEFLAG = modelEnter.TIMEFLAG;
                        model.VBELN = dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString();
                        model.ENTERWEIGHMAN = modelEnter.ENTERWEIGHMAN;
                        model.EXITWEIGHMAN = textBoxWeighMan.Text;
                        model.WERKS = textBoxFactory.Text;
                        model.KUIJIAN = 0;
                        model.TYPEID = 1;
                        if (model.TRUCKNUM == "")
                        {
                            model.TRUCKNUM = modelEnter.TRUCKNUM;
                            Sdl_ProductReturnMerchantAdapter.AddSdl_ProductReturnMerchant(model);
                        }
                        else
                        {
                            model.TRUCKNUM = modelEnter.TRUCKNUM;
                            Sdl_ProductReturnMerchantAdapter.UpdateSdl_ProductReturnMerchant(model);
                        }
                    }
                }
                MessageBox.Show(this, "操作成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
                this.Close();
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
            this.textBoxTare.Text = showNum.ToString();
            if (status == DBStatus.Normal)
            {
                textBoxWeight.Text = showNum.ToString();
            }
            else
            {
                textBoxWeight.Text = Common.GetEnumDescription(status);
            }
        }

        private void textBoxGrossE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGrossE.Text) - double.Parse(textBoxTare.Text), 3).ToString();
            }
            catch
            {
            }
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGrossE.Text) - double.Parse(textBoxTare.Text), 3).ToString();
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
