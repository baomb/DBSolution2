using System;
using System.Collections;
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
using System.Collections.Specialized;
using SdlDB.Utility;
using SAPTableFactoryCtrl;

namespace DBSolution
{
    public partial class FinishedProductsSaleExit : Form
    {
        private string[] father = new string[] { "", "" };
        private DataTable dtSapDetail = new DataTable();
        private DataTable dtSelect = new DataTable();
        SerialPortHelper s = null;
        private bool readPort = true;
        public FinishedProductsSaleExit()
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
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
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
            this.textBoxPrompt.Text = Common.GetHelpStr("总公司成品销售出厂");
            this.timer.Start();
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "ProductSale");
            ts.ShowDialog();
            this.textBoxCar.Text = father[0].ToString();

        }

        private void InitSelectDataBind(string truckNum, string strSel)
        {
            ListDictionary la = new ListDictionary();
            la.Add("NUMBR", truckNum);
            la.Add("WERKS", textBoxFactory.Text);

            ListDictionary lt = new ListDictionary();
            lt.Add("ZLIKP", "VBELN,KUNNR,NAME1");
            lt.Add("ZLIPS", "VBELN,POSNR,MATNR,MAKTX,LFIMG,ZFIMG,WERKS,LGORT,SFIMG");
            ListDictionary lr = new ListDictionary();

            //使用SAP通信
            DataSet ds = SAPHelper.InvokSAPFun("Z_SDL_FERT_MUTUAL_ZB_RC", la, lt, ref lr);
            DataTable dtSap = ds.Tables[0];

            dtSapDetail = ds.Tables[1];
            dtSapDetail.Columns.Add(new DataColumn("REAL_NUM", typeof(string)));

            DataTable dtGv = new DataSetHelper().GetNewDataTable(dtSap, " VBELN IN " + strSel, "");
            dataGridViewSelect.AutoGenerateColumns = false;
            dataGridViewSelect.DataSource = dtGv;

            for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewSelect.Rows[i].Cells["chk"];
                chk.Value = true;
            }

            Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
        }

        private void InitDetailBind(string where)
        {
            dtSelect = new DataSetHelper().GetNewDataTable(dtSapDetail, " VBELN IN " + where, "");
            DataTable dt = new DataSetHelper().GetNewDataTable(dtSelect, " 1=1 ", "");
            //new DataSetHelper().GetNewDataTable(dtSapDetail, " VBELN IN " + where, "");

            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dt;

            this.dataGridViewDetails.Columns[7].ReadOnly = false;
            this.dataGridViewDetails.Columns[8].ReadOnly = false;

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
            cmbColumnPro.HeaderText = "发货仓库";
        }

        private void textBoxCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string truckNum = textBoxCar.Text;
                DataTable dt = Sdl_FinishedProductsSaleTitleAdapter.
                     GetSdl_FinishedProductsSaleTitleSetByFeild(new string[] { "VBELN" }, " where trucknum='" + truckNum + "' and timeflag='" + father[1].ToString() + "' and HS_FLAG = 'H' ").Tables[0];
                string strSel = "''";
                string deliNum = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    strSel += "," + "'" + dr["VBELN"].ToString() + "'";
                }
                InitSelectDataBind(truckNum, "(" + strSel + ")");
                if (dataGridViewSelect.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有该车的交货单！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                InitDetailBind(" (" + strSel + ")");
                BindEnterData();
            }
        }

        private void BindEnterData()
        {
            Sdl_FinishedProductsSaleTitle title = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, father[1].ToString());
            if (title != null)
            {
                if (!CheckDB(title))
                {
                    return;
                }
                this.textBoxDBNum.Text = title.DBNUM;
                textBoxTare.Text = title.TARE.ToString();
            }
        }

        private bool CheckDB(Sdl_FinishedProductsSaleTitle title)
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

        private void dataGridViewSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            try
            {
                string strSel = "''";
                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        strSel += "," + "'" + dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString() + "'";
                    }
                }
                InitDetailBind(" (" + strSel + ")");
            }
            catch (Exception exc) { }
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
                dr["ZFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["ZFIMG"].Value.ToString();
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

                    double price = 0;
                    double realNum = 0;
                    string matnrNum = "";
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        try
                        {
                            string strValue = dataGridViewDetails.Rows[i].Cells[7].Value.ToString();
                            strValue = strValue.Trim() == "" ? "0" : strValue;
                            realNum = Convert.ToDouble(strValue);
                            matnrNum = dataGridViewDetails.Rows[i].Cells[3].Value.ToString();
                            price += realNum * GetMatnrWeight(matnrNum) / 1000;
                        }
                        catch
                        {
                        }
                    }
                    textBoxLFIMG.Text = price.ToString();

                }
                else
                {
                    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewSelect_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-总公司成品销售出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                string realNum = dataGridViewDetails.Rows[i].Cells["REAL_NUM"].Value.ToString();
                if (!ValidateHelper.IsNumber(realNum))
                {
                    MessageBox.Show(this, "请输入实发件数,实发件数应为整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(this, "同一交货单同一物料必须在不同仓库取货！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataTable dtTemp = new DataTable();
            double lfSum = 0;
            double lfZfimgSum = 0;
            for (int j = 0; j < dtSelect.Rows.Count; j++)
            {
                string vbeln = dtSelect.Rows[j]["VBELN"].ToString();
                string posnr = dtSelect.Rows[j]["POSNR"].ToString();
                string matnr = dtSelect.Rows[j]["MATNR"].ToString();

                double lf = double.Parse(dtSelect.Rows[j]["LFIMG"].ToString());
                double lfZfimg = double.Parse(dtSelect.Rows[j]["ZFIMG"].ToString());
                dtTemp = new DataSetHelper().GetNewDataTable(dt, " VBELN = '" + vbeln + "' and POSNR='" + posnr + "' and MATNR='" + matnr + "'", "");
                double lfGv = 0;
                for (int n = 0; n < dtTemp.Rows.Count; n++)
                {
                    if (string.IsNullOrEmpty(dtTemp.Rows[n]["REAL_NUM"].ToString()))
                    {
                        MessageBox.Show(this, "请输入实发数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    lfGv += double.Parse(dtTemp.Rows[n]["REAL_NUM"].ToString()) * GetMatnrWeight(matnr) / 1000;
                }
                if (Math.Round(lf, 3) != Math.Round(lfGv, 3))
                {
                    MessageBox.Show(this, "行项目中物料的原发数量与实际的数量不相符合，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                lfSum += lf;
                lfZfimgSum += lfZfimg;
            }

            double netValue = double.Parse(textBoxNet.Text);
            //double balanceValue = GetBalanceValue();
            //if (balanceValue == -1)
            //{
            //    MessageBox.Show(this, "读取地磅容差错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (!((netValue - balanceValue) <= lfSum && lfSum <= (netValue + balanceValue)))
            //if (Math.Abs(netValue - lfSum) > balanceValue)
            //{
            //    MessageBox.Show(this, "原发吨数与实际过磅数量应该在误差允许的范围内相等！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (Math.Abs(netValue - lfSum) > balanceValue)
            //{
            //    MessageBox.Show(this, "原发吨数与实际过磅数量应该在误差允许的范围内相等！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            double ProBalance1 = Common.GetProductBalanceValue();
            double ProBalance = lfZfimgSum * ProBalance1;

            if (Math.Round(Math.Abs(netValue - lfSum), 3) > Math.Round(ProBalance, 3))
            {
                if (MessageBox.Show("原发吨数与实际过磅数量在误差件数" + lfZfimgSum + "乘以包误差" + ProBalance1 * 1000 + "KG允许的范围内不相等,确认过账吗？", "史丹利地磅系统-总公司成品销售出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }

            return true;
        }

        private double GetBalanceValue()
        {
            return Sdl_LoadometerDiffAdapter.GetSdl_LoadometerDiff(Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-总公司成品销售出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show(this, "没有交货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_FinishedProductsSaleTitle modelEnter = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, father[1].ToString());
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
                    dtUpData.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();
                    string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                    dtUpData.Rows[i]["SFIMG"] = double.Parse(dtUpData.Rows[i]["REAL_NUM"].ToString()) * GetMatnrWeight(matnr) / 1000;
                }

                ListDictionary ltPara = new ListDictionary();
                DataTable dtNew = new DataSetHelper().SelectDistinct("dtNew", dtUpData, new string[] { "VBELN", "POSNR", "MATNR", "LFIMG", "SFIMG", "WERKS", "LGORT" });
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dtNew);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();

                try
                {
                    //使用SAP通信
                    DataSet dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_FERT_MUTUAL_ZB_GZ_CHECK", ltPara, ltParaTb, lt, ref lr);

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
                        dtGZ = SAPHelper.InvokSAPFunTable("Z_SDL_FERT_MUTUAL_ZB_GZ", ltPara, ltParaTb, lt, ref lr);
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
                        this.Close();
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
                        this.Close();
                        return;
                    }

                    try
                    {
                        StringBuilder sql = new StringBuilder();
                        DataTable dtVbeln = Sdl_FinishedProductsSaleTitleAdapter
                            .GetSdl_FinishedProductsSaleTitleSetByFeild(new string[] { " vbeln " }, " where trucknum='" + textBoxCar.Text + "' and timeFlag='" + father[1].ToString() + "' ").Tables[0];
                        for (int m = 0; m < dtVbeln.Rows.Count; m++)
                        {
                            string vbeln = dtVbeln.Rows[m]["VBELN"].ToString();
                            int t = 0;
                            for (int i = 0; i < dtSelect.Rows.Count; i++)
                            {
                                if (vbeln == dtSelect.Rows[i]["VBELN"].ToString())
                                {
                                    t = 1;
                                    break;
                                }
                            }
                            if (t == 0)
                            {
                                Sdl_FinishedProductsSaleTitleAdapter.DeleteSdl_FinishedProductsSaleTitle(textBoxCar.Text, father[1].ToString(), vbeln);
                                //sql.AppendFormat(" delete from Sdl_FinishedProductsSaleTitle where  trucknum='{0}' and timeFlag='{1}' and vbeln='{2}'; ", textBoxCar.Text, father[1].ToString(), vbeln);
                                //CommonOper.ExecuteSql(sql.ToString());
                            }
                        }

                        //头信息操作
                        Sdl_FinishedProductsSaleTitle model = new Sdl_FinishedProductsSaleTitle();
                        for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                        {
                            if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                model = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString(), father[1].ToString());
                                if (model == null)
                                {
                                    model = new Sdl_FinishedProductsSaleTitle();
                                }
                                model.ENTERTIME = modelEnter.ENTERTIME;
                                model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                                model.GROSS = double.Parse(textBoxGross.Text);
                                model.HS_FLAG = "S";
                                model.KUNNR = modelEnter.KUNNR;
                                model.NAME1 = modelEnter.NAME1;
                                model.TARE = double.Parse(textBoxTare.Text);
                                model.TIMEFLAG = modelEnter.TIMEFLAG;
                                model.VBELN = dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString();
                                model.WEIGHMAN = modelEnter.WEIGHMAN;
                                model.EXITWEIGHMAN = textBoxWeighMan.Text;
                                model.WERKS = textBoxFactory.Text;
                                model.EXITFLAG = 0;
                                if (model.TRUCKNUM == "")
                                {
                                    model.TRUCKNUM = modelEnter.TRUCKNUM;
                                    Sdl_FinishedProductsSaleTitleAdapter.AddSdl_FinishedProductsSaleTitle(model);
                                }
                                else
                                {
                                    model.TRUCKNUM = modelEnter.TRUCKNUM;
                                    Sdl_FinishedProductsSaleTitleAdapter.UpdateSdl_FinishedProductsSaleTitle(model);
                                }
                            }
                        }

                        //行项目操作
                        Sdl_FinishedProductsSale modelDetail = new Sdl_FinishedProductsSale();

                        for (int i = 0; i < dtGv.Rows.Count; i++)
                        {
                            modelDetail.LFIMG = double.Parse(dtGv.Rows[i]["LFIMG"].ToString());
                            modelDetail.LGORT = dtGv.Rows[i]["LGORT"].ToString();
                            modelDetail.MAKTX = dtGv.Rows[i]["MAKTX"].ToString();
                            modelDetail.MATNR = dtGv.Rows[i]["MATNR"].ToString();
                            modelDetail.POSNR = dtGv.Rows[i]["POSNR"].ToString();
                            modelDetail.REALZFIMG = int.Parse(dtGv.Rows[i]["REAL_NUM"].ToString());
                            modelDetail.TIMEFLAG = modelEnter.TIMEFLAG;
                            modelDetail.VBELN = dtGv.Rows[i]["VBELN"].ToString();
                            string zf = dtGv.Rows[i]["ZFIMG"].ToString();
                            modelDetail.ZFIMG = int.Parse(zf.Substring(0, zf.IndexOf(".")));
                            Sdl_FinishedProductsSaleAdapter.AddSdl_FinishedProductsSale(modelDetail);
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this, "向SAP过账成功，向地磅数据库操作失败，请联系管理员！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    ListDictionary ltParaWW = new ListDictionary();
                    DataTable dtNewWW = new DataTable();
                    try
                    {
                        dtNewWW.Columns.Add("VBELN");
                        dtNewWW.Columns.Add("ERDAT");
                        dtNewWW.Columns.Add("ERZET");
                        dtNewWW.Columns.Add("PZ");
                        dtNewWW.Columns.Add("MZ");
                        dtNewWW.Columns.Add("NRDAT");
                        dtNewWW.Columns.Add("NRZET");
                        dtNewWW.Columns.Add("NUMBR");
                        dtNewWW.Columns.Add("FLAG");
                        dtNewWW.Columns.Add("EFLAG");
                    }
                    catch
                    {
                        MessageBox.Show(this, "dtNewWW初始化失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    try
                    {
                        DataRow dr;
                        for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                        {
                            if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                dr = dtNewWW.NewRow();
                                dr["VBELN"] = dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString();
                                dr["MZ"] = textBoxGross.Text;
                                dr["NUMBR"] = textBoxCar.Text;
                                dr["FLAG"] = "1";
                                dtNewWW.Rows.Add(dr);
                            }
                        }

                        ListDictionary ltParaTbWW = new ListDictionary();
                        ltParaTbWW.Add("WLINFO", dtNewWW);
                        ListDictionary ltWW = new ListDictionary();
                        ltWW.Add("MESG", "NOTE");
                        ListDictionary lrWW = new ListDictionary();
                        //使用SAP通信
                        DataTable dtWW = SAPHelper.InvokSAPFunTable("Z_SDL_WL_INFO_UPDATE", ltParaWW, ltParaTbWW, ltWW, ref lrWW).Tables[0];

                        string strWW = string.Empty;
                        if (dtWW == null || dtWW.Rows.Count <= 0 || dtWW.Rows[0][0].ToString() != "保存出厂信息成功！")
                        {
                            MessageBox.Show(this, "发货过账成功，往SAP写出厂信息失败，请检查原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this, "发货过账成功，往SAP写出厂信息失败，请检查原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                    if (strInfo.Contains("失败") || strInfo.Contains("异常"))
                    {
                        MessageBox.Show(this, "过账异常！请点击确定后记录异常信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int errorIndex = strInfo.IndexOf("发货过账失败");
                    int begin = strInfo.Substring(0, errorIndex).LastIndexOf('！');
                    int end = strInfo.Substring(errorIndex).IndexOf('！');
                    string errorMessage = strInfo;

                    DataTable dtVBELN = new DataTable();
                    dtVBELN.Columns.Add("vbeln");
                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        DataRow drVBELN = dtVBELN.NewRow();
                        drVBELN["vbeln"] = dtGv.Rows[i]["VBELN"];
                        dtVBELN.Rows.Add(drVBELN);
                    }
                    ListDictionary ldVBELN = new ListDictionary();
                    ldVBELN.Add("VBLEN_ITAB", dtVBELN);
                    ListDictionary ld1 = new ListDictionary();
                    ListDictionary ld2 = new ListDictionary();
                    //使用SAP通信
                    SAPHelper.InvokSAPFunTable("Z_SDL_ZGS_SEND", ld1, ldVBELN, ld2, ref ld1);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.Close();
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
                case "5":
                    returnValue = double.Parse(Common.Weight5.ToString());
                    break;
                case "6":
                    returnValue = double.Parse(Common.Weight6.ToString());
                    break;
                default:
                    returnValue = double.Parse(Common.Weight1.ToString());
                    break;
            }
            return returnValue;
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

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空车出厂操作吗?", "史丹利地磅系统-总公司成品销售出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                //if (dtGv == null || dtGv.Rows.Count == 0)
                //{
                //    MessageBox.Show(this, "没有交货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
                {
                    MessageBox.Show(this, "地磅数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据不能为空或者字符，应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double netValue = double.Parse(textBoxNet.Text);

                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-总公司成品销售出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }


                try
                {
                    ListDictionary ltParaWW = new ListDictionary();
                    DataTable dtNewWW = new DataTable();

                    dtNewWW.Columns.Add("VBELN");
                    dtNewWW.Columns.Add("ERDAT");
                    dtNewWW.Columns.Add("ERZET");
                    dtNewWW.Columns.Add("PZ");
                    dtNewWW.Columns.Add("MZ");
                    dtNewWW.Columns.Add("NRDAT");
                    dtNewWW.Columns.Add("NRZET");
                    dtNewWW.Columns.Add("NUMBR");
                    dtNewWW.Columns.Add("FLAG");
                    dtNewWW.Columns.Add("EFLAG");

                    DataRow dr;
                    for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                    {
                        if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                        {
                            dr = dtNewWW.NewRow();
                            dr["VBELN"] = dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString();
                            dr["MZ"] = textBoxGross.Text;
                            dr["NUMBR"] = textBoxCar.Text;
                            dr["FLAG"] = "1";
                            dr["EFLAG"] = "1";
                            dtNewWW.Rows.Add(dr);
                        }
                    }

                    ListDictionary ltParaTbWW = new ListDictionary();
                    ltParaTbWW.Add("WLINFO", dtNewWW);
                    ListDictionary ltWW = new ListDictionary();
                    ltWW.Add("MESG", "NOTE");
                    ListDictionary lrWW = new ListDictionary();
                    //使用SAP通信
                    DataTable dtWW = SAPHelper.InvokSAPFunTable("Z_SDL_WL_INFO_UPDATE", ltParaWW, ltParaTbWW, ltWW, ref lrWW).Tables[0];

                    string strWW = string.Empty;
                    if (dtWW == null || dtWW.Rows.Count <= 0 || dtWW.Rows[0][0].ToString() != "保存出厂信息成功！")
                    {
                        MessageBox.Show(this, "往SAP写出厂信息失败，请检查原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;

                    }
                }
                catch
                {
                    MessageBox.Show(this, "往SAP写出厂信息失败，请检查原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }


                Sdl_FinishedProductsSaleTitle modelEnter = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, father[1].ToString());
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
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(" delete from Sdl_FinishedProductsSaleTitle where  trucknum='{0}' and timeFlag='{1}' ; ", textBoxCar.Text, father[1].ToString());
                CommonOper.ExecuteSql(sql.ToString());

                Sdl_FinishedProductsSaleTitle model = new Sdl_FinishedProductsSaleTitle();
                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        model = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString(), father[1].ToString());
                        if (model == null)
                        {
                            model = new Sdl_FinishedProductsSaleTitle();
                        }
                        model.ENTERTIME = modelEnter.ENTERTIME;
                        model.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                        model.GROSS = double.Parse(textBoxGross.Text);
                        model.HS_FLAG = "S";
                        model.KUNNR = modelEnter.KUNNR;
                        model.NAME1 = modelEnter.NAME1;
                        model.TARE = double.Parse(textBoxTare.Text);
                        model.TIMEFLAG = modelEnter.TIMEFLAG;
                        model.VBELN = dataGridViewSelect.Rows[i].Cells["DELIVERY_NUM"].Value.ToString();
                        model.WEIGHMAN = modelEnter.WEIGHMAN;
                        model.EXITWEIGHMAN = textBoxWeighMan.Text;
                        model.WERKS = textBoxFactory.Text;
                        model.EXITFLAG = 1;
                        if (model.TRUCKNUM == "")
                        {
                            model.TRUCKNUM = modelEnter.TRUCKNUM;
                            Sdl_FinishedProductsSaleTitleAdapter.AddSdl_FinishedProductsSaleTitle(model);
                        }
                        else
                        {
                            model.TRUCKNUM = modelEnter.TRUCKNUM;
                            Sdl_FinishedProductsSaleTitleAdapter.UpdateSdl_FinishedProductsSaleTitle(model);
                        }
                    }
                }
                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 7 && (!ValidateHelper.IsNumber(dataGridViewDetails.CurrentCell.FormattedValue.ToString())))
                {
                    if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                        return;
                    MessageBox.Show(this, "实发数量应为整数", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataGridViewDetails.ClearSelection();
                double price = 0;
                double realNum = 0;
                string matnr = "";
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 7 || dataGridViewDetails.CurrentCell.ColumnIndex == 8)
                {
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        try
                        {
                            string strValue = dataGridViewDetails.Rows[i].Cells[7].Value.ToString();
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
                textBoxLFIMG.Text = price.ToString();
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
