using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Utility;
using System.Threading;
using SdlDB.Data;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class AllotExitTranferOut : Form
    {
        private string[] father = new string[] { "", "", "" };
        private DataTable dtSAP = new DataTable();
        SerialPortHelper s = null;
        private string werks = string.Empty;

        private bool readPort = true;
        public AllotExitTranferOut()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-原材料调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void InitForm()
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
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
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("原材料调拨(调出)出厂");
            this.timer.Start();

            if (sysSetting.WERKS.Equals("2002") || sysSetting.WERKS.Equals("2003"))
            {
                labelTrayNum.Visible = true;
                labelTrayWeight.Visible = true;
                comboBoxTrayWeight.Visible = true;
                textTrayNum.Visible = true;
                DataTable ds = Sdl_SweightAdapter.GetSdl_SweightDataSet("").Tables[0];
                this.comboBoxTrayWeight.DataSource = ds;
                this.comboBoxTrayWeight.DisplayMember = "SWEIGHT";
                this.comboBoxTrayWeight.ValueMember = "SWEIGHT";
                this.comboBoxTrayWeight.SelectedIndex = -1;
                this.comboBoxTrayWeight.Text = "0";
            }
        }

        private bool ValidateControl(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有调拨单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataTable dtWerksCheck = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "WERKS" });
            if (dtWerksCheck.Rows.Count > 1)
            {
                MessageBox.Show(this, "调拨单行项目信息中的调入仓库必须相同！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsNumberSign(textBoxDeductNum.Text) || ValidateHelper.IsDecimalSign(textBoxDeductNum.Text)))
            {
                MessageBox.Show(this, "扣杂数量应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string sfimg = dataGridViewDetails.Rows[i].Cells["SFIMG"].Value.ToString();
                if ((!ValidateHelper.IsNumber(sfimg)) || double.Parse(sfimg) == 0)
                {
                    MessageBox.Show(this, "请输入转出件数,转出件数应为大于零的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                //if ((!(ValidateHelper.IsDecimal(realNum) || ValidateHelper.IsNumber(realNum))) || double.Parse(realNum) == 0)
                //{
                //    MessageBox.Show(this, "请输入实退吨数,实退吨数应为大于零的数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}

                string pWeight = dataGridViewDetails.Rows[i].Cells["PACKAGEWEIGHT"].Value.ToString();
                if (string.IsNullOrEmpty(pWeight))
                {
                    MessageBox.Show(this, "请选择包重！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                if (string.IsNullOrEmpty(lgort))
                {
                    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            DataTable dtDistinct = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "EBELN", "EBELP", "MATNR", "LGORT" });
            if (dt.Rows.Count != dtDistinct.Rows.Count)
            {
                MessageBox.Show(this, "同一退货单同一物料必须在不同仓库取货！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataTable dtTemp = new DataTable();
            double mengeSum = 0;
            double mengeGvSum = 0;
            for (int j = 0; j < dtSAP.Rows.Count; j++)
            {
                string ebeln = dtSAP.Rows[j]["EBELN"].ToString();
                string ebelp = dtSAP.Rows[j]["EBELP"].ToString();
                string matnr = dtSAP.Rows[j]["MATNR"].ToString();
                double menge = double.Parse(dtSAP.Rows[j]["MENGE"].ToString());
                dtTemp = new DataSetHelper().GetNewDataTable(dt, " EBELN = '" + ebeln + "' and EBELP='" + ebelp + "' and MATNR='" + matnr + "'", "");
                double mengeGv = 0;
                for (int n = 0; n < dtTemp.Rows.Count; n++)
                {
                    mengeGv += double.Parse(dtTemp.Rows[n]["SENGE"].ToString());
                }
                if (Math.Round(menge, 3) < Math.Round(mengeGv, 3))
                {
                    MessageBox.Show(this, "行项目中物料的转出数量不能大于可转出数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                mengeGvSum += mengeGv;
                mengeSum += menge;
            }

            double netValue = double.Parse(textBoxNet.Text);
            double balanceValue = Math.Round(netValue - mengeGvSum, 3);

            string strTip = string.Empty;
            if (balanceValue > 0)
            {
                strTip = "实际转出数量与实际过磅数量存在差异,该批物料涨吨" + Math.Abs(balanceValue).ToString() + ",是否调拨过账？";
            }
            else
            {
                strTip = "实际转出数量与实际过磅数量存在差异,该批物料亏吨" + Math.Abs(balanceValue).ToString() + ",是否调拨过账？";
            }

            if (Math.Round(Math.Abs(netValue - mengeGvSum), 3) != 0)
            {
                if (MessageBox.Show(strTip, "史丹利地磅系统-原材料调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            DataGridViewCell dCell = null;
            if (dataGridViewDetails.Rows.Count != 0)
            {
                dCell = dataGridViewDetails.Rows[0].Cells[0];
            }
            dataGridViewDetails.CurrentCell = dCell;
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-原材料调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_AllotTitle model = new Sdl_AllotTitle();
                model = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
                if (model == null)
                {
                    MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (model.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经调拨出厂，不能再次调拨，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //检测SAP
                DataTable dtUpData = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                
                for (int i = 0; i < dtUpData.Rows.Count; i++)
                {
                    
                    dtUpData.Rows[i]["RESWK"] = textBoxFactory.Text.ToString().Trim();
                    dtUpData.Rows[i]["EBELN"] = textBoxEbeln.Text.ToString().Trim();
                    dtUpData.Rows[i]["LGORT"] = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    dtUpData.Rows[i]["MATNR"] = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString();

                    //StringBuilder str = new StringBuilder();
                    //str.Append("RESWK: " + textBoxFactory.Text.ToString().Trim() + "\n");
                    //str.Append("EBELN: " + textBoxEbeln.Text.ToString().Trim() + "\n");
                    //str.Append("LGORT: " + dtUpData.Rows[i]["LGORT"].ToString() + " " + dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString() + "\n");
                    //str.Append("MATNR: " + dtUpData.Rows[i]["MATNR"].ToString() + " " + dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString() + "\n");

                    //MessageBox.Show(this, str.ToString(), "提示", MessageBoxButtons.OK);
                    //string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                    //dtUpData.Rows[i]["SENGE"] = double.Parse(dtUpData.Rows[i]["SENGE"].ToString());
                    //dtUpData.Rows[i]["FRBNR"] = textBoxTruckNum.Text;
                }

                ListDictionary ltPara = new ListDictionary();
                DataTable dtNew = new DataSetHelper().SelectDistinct("dtNew", dtUpData, new string[] { "EBELN", "EBELP", "MATNR", "SENGE", "WERKS", "LGORT", "RESWK" });
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dtNew);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();
                try
                {
                    //使用SAP通信
                    DataSet dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_GZ_CHECK_DB", ltPara, ltParaTb, lt, ref lr);

                    if (dtInfo.Tables[0].Rows.Count > 0)
                    {
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
                        if (str.Trim() == "检查成功")
                        {
                            DataSet dtGZ = new DataSet();
                            try
                            {
                                //使用SAP通信
                                dtGZ = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_GZ_DB", ltPara, ltParaTb, lt, ref lr);
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

                            if (strInfo.IndexOf("已成功创建") >= 0)
                            {
                                try
                                {
                                    //头信息操作

                                    model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                                    model.GROSS = double.Parse(textBoxGross.Text);
                                    model.HSFLAG = "S";
                                    model.TARE = double.Parse(textBoxTare.Text);
                                    model.EXITWEIGHMAN = textBoxWeighMan.Text;
                                    model.RESWK = textBoxFactory.Text;
                                    model.DEDUCTNUM = double.Parse(textBoxDeductNum.Text);
                                    model.ALLOTFLAG = 0;
                                    model.WERKS = werks;
                                    model.TRAYWEIGHT = comboBoxTrayWeight.Text.ToString().Trim();
                                    model.TRAYNUM = textTrayNum.Text.ToString().Trim();
                                    Sdl_AllotTitleAdapter.UpdateSdl_AllotTitle(model);

                                    //行项目操作
                                    Sdl_AllotDetail modelDetail = new Sdl_AllotDetail();

                                    for (int i = 0; i < dtGv.Rows.Count; i++)
                                    {
                                        modelDetail.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                                        modelDetail.EBELP = dtGv.Rows[i]["EBELP"].ToString();
                                        modelDetail.LGORT = dtGv.Rows[i]["LGORT"].ToString();
                                        modelDetail.MAKTX = dtGv.Rows[i]["MAKTX"].ToString();
                                        modelDetail.MATNR = dtGv.Rows[i]["MATNR"].ToString();
                                        modelDetail.PACKAGEWEIGHT = int.Parse(dtGv.Rows[i]["PACKAGEWEIGHT"].ToString());
                                        modelDetail.MENGE = double.Parse(dtGv.Rows[i]["MENGE"].ToString());
                                        modelDetail.SENGE = double.Parse(dtGv.Rows[i]["SENGE"].ToString());
                                        modelDetail.SFIMG = int.Parse(dtGv.Rows[i]["SFIMG"].ToString());
                                        modelDetail.WERKS = dtGv.Rows[i]["WERKS"].ToString();
                                        modelDetail.TIMEFLAG = model.TIMEFLAG;
                                        Sdl_AllotDetailAdapter.AddSdl_AllotDetail(modelDetail);
                                    }
                                    MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch
                                {
                                    MessageBox.Show(this, "向SAP过账成功，向地磅数据库操作失败，请联系管理员！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, str, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.Close();
                }
            }
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (columnIndex == 0)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataRow dr = dt.NewRow();
                dr["EBELN"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                dr["EBELP"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString();
                dr["WERKS"] = textBoxFactory.Text.ToString().Trim();
                dr["RESWK"] = textBoxFactory.Text.ToString().Trim();
                dr["OVERNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["OVERNUM"].Value.ToString();
                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            if (columnIndex == 11)
            {
                //string ebeln = dataGridViewDetails.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                //string ebelp = dataGridViewDetails.Rows[rowIndex].Cells["EBELP"].Value.ToString();

                //DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                //DataTable dtCount = new DataSetHelper().GetNewDataTable(dt, " EBELN = '" + ebeln + "' and EBELP='" + ebelp + "'", "");
                if (dataGridViewDetails.Rows.Count == 1)
                {
                    MessageBox.Show(this, "该行不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataGridViewDetails.Rows.RemoveAt(e.RowIndex);
                double realNum = 0;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    try
                    {
                        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    }
                    catch
                    {

                    }
                }
                textBoxZMenge.Text = realNum.ToString();
                //}
                //else
                //{
                //    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void textBoxTruckNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string truckNum = textBoxTruckNum.Text;
                InitSelectDataBind(truckNum);
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show("没有该车的调拨单！");
                    return;
                }
                BindEnterData();
            }
        }

        private void InitSelectDataBind(string truckNum)
        {
            ListDictionary la = new ListDictionary();
            la.Add("EBELN", textBoxEbeln.Text.Trim());
            la.Add("WERKS", textBoxFactory.Text.Trim());
            ListDictionary lt = new ListDictionary();
            lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,WERKS,MENGE");
            ListDictionary lr = new ListDictionary();
            DataSet dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_DB_RC", la, lt, ref lr);
            dtSAP = dsSAP.Tables[0];

            dtSAP.Columns.Add("RESWK");
            dtSAP.Columns.Add("SENGE");
            dtSAP.Columns.Add("LGORT");
            dtSAP.Columns.Add("OVERNUM");
            dtSAP.Columns.Add("PACKAGEWEIGHT");
            dtSAP.Columns.Add("SFIMG");

            for (int i = 0; i < dtSAP.Rows.Count; i++)
            {
                double overNum = Sdl_AllotDetailAdapter.GetSdl_AllotDetailOverNum(" WHERE EBELN = '" + dtSAP.Rows[i]["EBELN"].ToString() + "' and EBELP='" + dtSAP.Rows[i]["EBELP"].ToString() + "' ");
                dtSAP.Rows[i]["OVERNUM"] = overNum.ToString();
                dtSAP.Rows[i]["RESWK"] = textBoxFactory.Text.Trim();
                werks = dtSAP.Rows[i]["WERKS"].ToString();
            }

            DataTable dtBindGv = new DataSetHelper().GetNewDataTable(dtSAP, " 1=1 ", "");
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dtBindGv;
            
            DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where (lgort like '3%' or lgort like '1%') and werks='" + textBoxFactory.Text + "' ").Tables[0];
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
            DataGridViewComboBoxColumn cbcpw = new DataGridViewComboBoxColumn();
            cbcpw.DataPropertyName = "PACKAGEWEIGHT";
            cbcpw.DataSource = dtPackWeight;
            cbcpw.ValueMember = "包重";
            cbcpw.DisplayMember = "说明";

            this.dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["PACKAGEWEIGHT"].Index, cbcpw);
            dataGridViewDetails.Columns.Remove("PACKAGEWEIGHT");
            cbcpw.Name = "PACKAGEWEIGHT";
            cbcpw.HeaderText = "包重";

            Common.ShowTruckWeight(this.textBoxTruckNum.Text, dataGridViewHistory);
        }

        private void BindEnterData()
        {
            Sdl_AllotTitle title = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(textBoxTruckNum.Text, father[2].ToString());
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

        private bool CheckDB(Sdl_AllotTitle title)
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

        private void textBoxTruckNum_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "AllotTransferIn");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                textBoxTruckNum.Text = father[0].ToString();
                textBoxEbeln.Text = father[1].ToString();

                InitSelectDataBind(textBoxTruckNum.Text);
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show("没有该车的调拨单！");
                    return;
                }
                BindEnterData();
            }
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CountNet();
            }
            catch
            {

            }
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            CountNet();
        }

        private void CountNet()
        {
            try
            {
               textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - (double.Parse(textTrayNum.Text) * double.Parse(comboBoxTrayWeight.Text)) / 1000, 3).ToString();
               textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxZMenge.Text), 3).ToString();
            }
            catch
            {

            }
        }

        private void textBoxDeductNum_TextChanged(object sender, EventArgs e)
        {
            //if ((!(ValidateHelper.IsNumberSign(textBoxDeductNum.Text) ||
            //    ValidateHelper.IsDecimalSign(textBoxDeductNum.Text)))
            //    && textBoxDeductNum.Text != "-" && textBoxDeductNum.Text.Trim() != "" && textBoxDeductNum.Text.IndexOf('.') <= 0)
            //{
            //    this.textBoxDeductNum.Text = "0";
            //    textBoxDeductNum.Focus();
            //}
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空车出厂操作吗?", "史丹利地磅系统-原材料调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (!(ValidateHelper.IsDecimalSign(textBoxDeductNum.Text) || ValidateHelper.IsNumberSign(textBoxDeductNum.Text)))
                {
                    MessageBox.Show(this, "差异数量应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                double netValue = double.Parse(textBoxNet.Text);

                //if (!((netValue - balanceValue) <= lfSum && lfSum <= (netValue + balanceValue)))
                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-原材料调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }


                //头信息操作
                Sdl_AllotTitle model = new Sdl_AllotTitle();
                model = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
                if (model == null)
                {
                    MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (model.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经调拨出厂，不能再次调拨，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                model.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                model.GROSS = double.Parse(textBoxGross.Text);
                model.HSFLAG = "S";
                model.TARE = double.Parse(textBoxTare.Text);
                model.EXITWEIGHMAN = textBoxWeighMan.Text;
                model.RESWK = textBoxFactory.Text;
                model.DEDUCTNUM = double.Parse(textBoxDeductNum.Text);
                model.EXITFLAG = 1;
                model.ALLOTFLAG = 1;
                model.WERKS = werks;
                model.TRAYWEIGHT = comboBoxTrayWeight.Text.ToString().Trim();
                model.TRAYNUM = textTrayNum.Text.ToString().Trim();
                Sdl_AllotTitleAdapter.UpdateSdl_AllotTitle(model);
                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string currentValue = dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value.ToString();
                
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 7 || dataGridViewDetails.CurrentCell.ColumnIndex == 8)
                {
                    if ((!ValidateHelper.IsNumber(currentValue)))
                    {
                        if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                            return;
                        MessageBox.Show(this, "转出件数应为数值", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        double price = 0;
                        string strCurrentValue = dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value.ToString();
                        strCurrentValue = strCurrentValue.Trim() == "" ? "0" : strCurrentValue;
                        int realCurrentNum = int.Parse(strCurrentValue);

                        string strPwValue = dataGridViewDetails.Rows[rowIndex].Cells["PACKAGEWEIGHT"].Value.ToString();
                        strPwValue = strPwValue.Trim() == "" ? "1" : strPwValue;
                        int realPwValue = int.Parse(strPwValue);

                        price = (double)(realCurrentNum * realPwValue) / 1000;
                        dataGridViewDetails.Rows[rowIndex].Cells["SENGE"].Value = price.ToString();

                        double realNum = 0;
                        for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                        {
                            try
                            {
                                realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                            }
                            catch
                            {

                            }
                        }
                        textBoxZMenge.Text = realNum.ToString();
                    }
                }
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

        private void textBoxZMenge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CountNet();
                
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

        private void comboBoxTrayWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountNet();
        }

        private void textStandardNum_TextChanged(object sender, EventArgs e)
        {
            CountNet();
        }

        private void comboBoxTrayWeight_TextChanged(object sender, EventArgs e)
        {
            CountNet();
        }
    }
}
