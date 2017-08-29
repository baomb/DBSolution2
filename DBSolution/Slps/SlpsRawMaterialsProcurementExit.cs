using System;
using System.Collections.Specialized;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsRawMaterialsProcurementExit : Form
    {
        bool readPort = true;
        decimal net2 = 0;
        decimal discount = 0;
        string[] father = new string[3];
        string message = string.Empty;
        string lbFlag = string.Empty;       //合同订单标记
        string ebeln = string.Empty;
        string[] qrCodeArray;   //二维码扫描结果数组
        private string formTittle = "成品销售出场";
        DataSet ds = new DataSet();
        Slps_RawMaterialsProcurement rawHead = new Slps_RawMaterialsProcurement();
        SerialPortHelper s = null;

        public SlpsRawMaterialsProcurementExit()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxTare.ReadOnly = false;
            }
        }

        private void InitForm()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
            try
            {
                Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                readPort = Common.GetReadPortFlag();
                s = new SerialPortHelper(ref serialPort);
                textBoxFactory.Text = sysSetting.WERKS;
                bool tray = Sdl_SysSettingAdapter.GetSdl_Tray(sysSetting.WERKS);
                if (tray == true)
                {
                    comboBoxStandardWeight.Visible = true;
                    textBoxQuantity.Visible = true;
                    labelTrayWeight.Visible = true;
                    labelTrayQuantity.Visible = true;
                }
                if (sysSetting.WERKS == "2002" || sysSetting.WERKS == "2003")
                {
                    txtWagonNum.Visible = false;
                    label6.Visible = false;
                }

                textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                Sdl_Manual manual = Sdl_ManualAdapter.GetSdl_Manual(this.labelTitle.Text);
                textBoxPrompt.Text = manual.MANUAL;
                //DataTable dt = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
                //站点绑定
                Sdl_Factory factory = Sdl_FactoryAdapter.GetSdl_Factory(sysSetting.WERKS);
                DataTable dt = Sdl_StationAdapter.GetSdl_StationDataSet("where bukrs = " + factory.BUKRS, "STATION").Tables[0];
                comboBoxABLAD.DataSource = dt;
                comboBoxABLAD.DisplayMember = "STATION";
                comboBoxABLAD.ValueMember = "STATION";
                comboBoxABLAD.SelectedIndex = -1;
                //托盘标重绑定
                DataTable ds = Sdl_SweightAdapter.GetSdl_SweightDataSet("").Tables[0];
                comboBoxStandardWeight.DataSource = ds;
                comboBoxStandardWeight.DisplayMember = "SWEIGHT";
                comboBoxStandardWeight.ValueMember = "SWEIGHT";
                comboBoxStandardWeight.SelectedIndex = -1;
                //计时器启动
                timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitDetailsDataBind(string[] qrCode)
        {
            qrCodeArray = qrCode;

            //查询第一个二维码的时间戳，通过时间戳查询入场信息表头
            Sdl_SlpsEnter enter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[0]);
            rawHead = Slps_RawMaterialsProcurementAdapter.GetSlps_RawMaterialsProcurement(enter.TimeFlag, enter.CarNo);

            //检查地磅是与入场一致
            if (!CheckDB(rawHead))
            {
                return;
            }
            textBoxDBNum.Text = rawHead.DbNum;
            textBoxTare.Text = rawHead.Tare.ToString();
            textBoxCar.Text = rawHead.CarNo;

            //显示车辆皮重历史
            Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);

            //拼接where查询条件
            string where = string.Empty;
            where = "where timeFlag = '" + rawHead.TimeFlag + "'";
            
            //订单明细查询
            DataTable dt = Slps_RawMaterialsProcurementDetailAdapter.GetSlps_RawMaterialsProcurementDetailList(where).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["kg"].Equals("1"))
                {
                    checkBoxKG.Checked = true;
                }
                else
                {
                    checkBoxKG.Checked = false;
                }
            }
            //为界面中的明细表绑定数据
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dt;

            //仓库绑定
            DataTable dtLGORT = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where werks='" + textBoxFactory.Text + "' and ( lgort like '3%' or lgort like '4%' or lgort like '1%' ) order by lgort desc").Tables[0];
            DataGridViewComboBoxColumn cbcLGORT = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[18];
            cbcLGORT.DataPropertyName = "lgort";
            cbcLGORT.DataSource = dtLGORT;
            cbcLGORT.ValueMember = "lgort";
            cbcLGORT.DisplayMember = "lgobe";
            cbcLGORT.Name = "LGORT";
            cbcLGORT.HeaderText = "收货仓库";

            //包重绑定
            DataTable dtPackWeight = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
            DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[12];
            cbcpw.DataPropertyName = "pweight";
            cbcpw.DataSource = dtPackWeight;
            cbcpw.ValueMember = "包重";
            cbcpw.DisplayMember = "说明";
            cbcpw.Name = "PWEIGHT";
            cbcpw.HeaderText = "包重";

            //仓储类型绑定
            DataTable dtStorageType = Sdl_StorageTypeAdapter.GetSdl_StorageTypeDataSet("").Tables[0];
            DataGridViewComboBoxColumn cbst = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[11];
            cbst.DataPropertyName = "storagetype";
            cbst.DataSource = dtStorageType;
            cbst.ValueMember = "TYPENAME";
            cbst.DisplayMember = "TYPENAME";
            cbst.Name = "STORAGETYPE";
            cbst.HeaderText = "仓储类型";
            

            //读取扣杂
            //if (string.IsNullOrEmpty(matnr))
            //    return;
            //la = new ListDictionary();
            //la.Add("I_MATNR", matnr);
            //lt = new ListDictionary();
            //lr = new ListDictionary();
            //lr.Add("E_DISCOUNT", discount);
            //SAPHelper.InvokSAPFun("Z_SDL_MATERIAL_DISCOUNT", la, ref lr);
            //if (lr != null && lr["E_DISCOUNT"] != null)
            //{
            //    if (lr["E_DISCOUNT"].ToString() == "X")
            //    {
            //        MessageBox.Show(this, "该物料没有维护产品层次，请联系SAP相关人员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.Close();
            //    }
            //    else
            //    {
            //        discount = Convert.ToDecimal(lr["E_DISCOUNT"]);
            //    }
            //}
        }

        private bool ValidateControl()
        {
            if ((!ValidateHelper.IsNumber(this.textBoxQuantity.Text)) && this.textBoxQuantity.Visible)
            {
                MessageBox.Show(this, "托盘数量必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(txtCYNum.Text) || ValidateHelper.IsNumber(txtCYNum.Text)))
            {
                MessageBox.Show(this, "承运人亏吨应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string wagon = txtWagon.Text.Trim();
            if (double.Parse(textBoxDiff.Text) < 0 && txtCYNum.Text == "0")
            {
                if (MessageBox.Show("确认是承运人亏吨吗，如果是请确认输入承运人亏吨数量，是否继续?", "原材料采购", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }
            }
            int realzfimg, dfimg;
            double lfimg;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewDetails.Columns.Count; j++)
                {
                    if ((!(j == 11 || j == 19)) && (dataGridViewDetails.Rows[i].Cells[j].Value == DBNull.Value || dataGridViewDetails.Rows[i].Cells[j].Value == null))
                    {
                        MessageBox.Show(this, "请填写所有信息," + dataGridViewDetails.Columns[j].HeaderText, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                if (dataGridViewDetails.Rows[i].Cells["BKTXT"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show(this, "请输入产地品牌", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                try
                {
                    if (!ValidateHelper.IsNumber(dataGridViewDetails.Rows[i].Cells[14].Value.ToString()))
                    {
                        MessageBox.Show(this, "原发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    dfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells[14].Value);
                    if (dfimg < 0)
                    {
                        MessageBox.Show(this, "原发件数不能为负数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "原发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                try
                {
                    if (!ValidateHelper.IsNumber(dataGridViewDetails.Rows[i].Cells[15].Value.ToString()))
                    {
                        MessageBox.Show(this, "实收件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    dfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells[15].Value);
                    if (dfimg < 0)
                    {
                        MessageBox.Show(this, "实收件数不能为负数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "实收件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                try
                {
                    if (!ValidateHelper.IsNumberSign(dataGridViewDetails.Rows[i].Cells[17].Value.ToString()))
                    {
                        MessageBox.Show(this, "涨件亏件必须为整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "亏件必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            realzfimg = 0;
            dfimg = 0;
            lfimg = 0;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                double sfimg = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["sfimg"].Value);
                lfimg = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["lfimg"].Value);
                int zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["zfimg"].Value);
                int rowreal = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["realZfimg"].Value);
                int pweight = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["pweight"].Value);
                
                if (sfimg == 0)
                {
                    MessageBox.Show(this, "实收吨数不能为零，如果没有行项目收货，请删除行项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                realzfimg += Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["realZfimg"].Value);
                dfimg += Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["dfimg"].Value);
                for (int j = i + 1; j < dataGridViewDetails.Rows.Count; j++)
                {
                    if (dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value == dataGridViewDetails.Rows[j].Cells["lineItemNo"].Value)
                    {
                        realzfimg += Convert.ToInt32(dataGridViewDetails.Rows[j].Cells["realZfimg"].Value);
                        dfimg += Convert.ToInt32(dataGridViewDetails.Rows[j].Cells["dfimg"].Value);
                        sfimg += Convert.ToDouble(dataGridViewDetails.Rows[j].Cells["sfimg"].Value);
                        if (dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString() != dataGridViewDetails.Rows[j].Cells["pweight"].Value.ToString())
                        {
                            zfimg += Convert.ToInt32(dataGridViewDetails.Rows[j].Cells["zfimg"].Value);
                        }
                        else
                        {
                            zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["zfimg"].Value);
                        }
                        i++;
                    }
                }
                if ((dataGridViewDetails.Rows[i].Cells["zfimg"].Value != DBNull.Value) && (realzfimg - dfimg) != zfimg)
                {
                    MessageBox.Show(this, "原发件数、实收件数与涨亏件不符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            double sfimg2 = 0;
            decimal lfimg2 = 0;
            string temp = string.Empty;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                if (dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString() != temp)
                {
                    sfimg2 = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["sfimg"].Value);
                    lfimg2 += Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["lfimg"].Value);
                    temp = dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString();
                }
                else
                    if (dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString() == temp && i > 0 && dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString() != dataGridViewDetails.Rows[i - 1].Cells["PWEIGHT"].Value.ToString())
                    {
                        sfimg2 = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["sfimg"].Value);
                        lfimg2 += Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["lfimg"].Value);
                        temp = dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString();
                    }
                    else
                    {
                        sfimg2 += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["sfimg"].Value);
                    } 
                if (Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["menge"].Value) < sfimg2)
                {
                    MessageBox.Show(this, "实收吨数大于可收货数量,请联系供应部门修改订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (i == 0 && dataGridViewDetails.Rows.Count > 1 
                    && dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString() != dataGridViewDetails.Rows[i + 1].Cells["pweight"].Value.ToString())
                {
                    for (int j = 1; j < dataGridViewDetails.Rows.Count; j++)
                    {
                        net2 -= decimal.Parse(dataGridViewDetails.Rows[j].Cells["sfimg"].Value.ToString());
                    }
                }
                if ( i > 0)
                {
                    if (dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString() != dataGridViewDetails.Rows[i - 1].Cells["pweight"].Value.ToString())
                        net2 = decimal.Parse(sfimg2.ToString());
                }
                string storage = dataGridViewDetails.Rows[i].Cells["storageType"].Value.ToString();
                
                dataGridViewDetails.Rows[i].Cells["sgtxt"].Value =
                    dataGridViewDetails.Rows[i].Cells["realZfimg"].Value + "/" +
                    dataGridViewDetails.Rows[i].Cells["dfimg"].Value + "/" +
                    dataGridViewDetails.Rows[i].Cells["lfimg"].Value + "/" +
                    net2.ToString() + "/" +
                    txtCYNum.Text.Trim() + "/" +
                    wagon + "/" +
                    storage + "/" + dataGridViewDetails.Rows[i].Cells["pweight"].Value;
                
                if (StringUtil.StringLength(dataGridViewDetails.Rows[i].Cells["sgtxt"].Value.ToString()) > 50)
                {
                    MessageBox.Show(this, "项目文本长度超出范围", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            string sgtxt = string.Empty;
            string ebelp = string.Empty;
            if (checkBoxKG.Checked == true)
            {
                lfimg2 = lfimg2 / 1000;
            }
            decimal diff = lfimg2 - Convert.ToDecimal(textBoxNetMinus.Text);
            if (diff > 0)
            {
                if (MessageBox.Show(this, "本次过磅亏吨" + diff.ToString() + "，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }
            }
            else if (diff < 0)
            {
                if (MessageBox.Show(this, "本次过磅涨吨" + (-diff).ToString() + "，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }
            }
            if (StringUtil.StringLength(textBoxCar.Text) > 16)
            {
                MessageBox.Show(this, "车牌号长度超出范围", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StringUtil.StringLength(comboBoxABLAD.Text) > 20)
            {
                MessageBox.Show(this, "站点长度超出范围", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (toolStripButton.Text != "解锁")
            {
                MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!CorrectMistake())
            {
                return;
            }
            if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            if (!ValidateControl())
            {
                return;
            }
             
            try
            {
                //更新物料明细
                Slps_RawMaterialsProcurementDetail rawDetail = new Slps_RawMaterialsProcurementDetail();
                DataTable rawDt = (DataTable)dataGridViewDetails.DataSource;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    rawDetail = Slps_RawMaterialsProcurementDetailAdapter.GetSlps_RawMaterialsProcurementDetail(rawHead.TimeFlag, rawDt.Rows[i]["lineItemNo"].ToString());
                    rawDetail.Lfimg = Convert.ToDecimal(rawDt.Rows[i]["lfimg"].ToString());
                    rawDetail.Sfimg = Convert.ToDecimal(rawDt.Rows[i]["sfimg"].ToString());
                    rawDetail.Pweight = Convert.ToDecimal(rawDt.Rows[i]["pweight"].ToString());
                    rawDetail.Pstyp = rawDt.Rows[i]["pstyp"].ToString();
                    rawDetail.Zfimg = int.Parse(rawDt.Rows[i]["zfimg"].ToString());
                    rawDetail.RealZfimg = int.Parse(rawDt.Rows[i]["realZfimg"].ToString());
                    rawDetail.Dfimg = int.Parse(rawDt.Rows[i]["dfimg"].ToString());
                    rawDetail.Lgort = rawDt.Rows[i]["lgort"].ToString();
                    rawDetail.Sgtxt = rawDt.Rows[i]["sgtxt"].ToString();
                    rawDetail.StorageType = rawDt.Rows[i]["storageType"].ToString();
                    rawDetail.Menge = Convert.ToDecimal(rawDt.Rows[i]["menge"].ToString());
                    Slps_RawMaterialsProcurementDetailAdapter.UpdateSlps_RawMaterialsProcurementDetail(rawDetail);
                }
                //更新采购订单表头
                rawHead.Hs_flag = "S";
                rawHead.Tare = Convert.ToDecimal(textBoxTare.Text.Trim().ToString());
                rawHead.Net = Convert.ToDecimal(textBoxNet.Text.Trim().ToString());
                rawHead.ExitWeightMan = textBoxWeighMan.Text.Trim().ToString();
                rawHead.ExitTime = Common.GetServerDate();
                rawHead.Abald = comboBoxABLAD.Text.ToString();
                rawHead.Balance = Convert.ToDecimal(textBoxDiff.Text.Trim().ToString());
                rawHead.Wagon = txtWagon.Text.Trim().ToString();
                rawHead.WagonNum = txtWagonNum.Text.Trim().ToString();
                rawHead.Bfimg = textBfimg.Text.Trim().ToString();
                rawHead.Freight = textFreight.Text.Trim().ToString();
                rawHead.CyNum = Convert.ToDecimal(txtCYNum.Text.Trim().ToString());
                
                //托盘数据
                if (ValidateHelper.IsNumber(comboBoxStandardWeight.Text))
                {
                    rawHead.TrayWeight = Convert.ToDecimal(comboBoxStandardWeight.Text.ToString());
                }
                if (ValidateHelper.IsNumber(textBoxQuantity.Text))
                {
                    rawHead.TrayQuantity = Convert.ToInt32(textBoxQuantity.Text);
                }
                Slps_RawMaterialsProcurementAdapter.UpdateSlps_RawMaterialsProcurement(rawHead);

                //增加车辆皮重历史
                Sdl_TruckWeight tw = new Sdl_TruckWeight();
                tw.ENTERTIME = DateTime.Parse(rawHead.EnterTime);
                tw.TARE = Convert.ToSingle(rawHead.Tare);
                tw.TIMEFLAG = rawHead.TimeFlag;
                tw.TRUCKNUM = rawHead.CarNo;
                tw.WERKS = rawHead.Factory;
                Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                MessageBox.Show(this, message, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //是否启用打印功能
                if (MessageBox.Show("是否打印原料过磅单？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveAndPrint(rawHead.CarNo, rawHead.TimeFlag, rawHead.SapOrderNo);
                }
                Common.PlayGoodBye();
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "地磅数据保存失败，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            if (colIndex == 0)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataRow dr = dt.NewRow();
                dr["sapOrderNo"] = dataGridViewDetails.Rows[rowIndex].Cells["sapOrderNo"].Value.ToString();
                dr["lineItemNo"] = dataGridViewDetails.Rows[rowIndex].Cells["lineItemNo"].Value.ToString();
                dr["matnr"] = dataGridViewDetails.Rows[rowIndex].Cells["matnr"].Value.ToString();
                dr["maktx"] = dataGridViewDetails.Rows[rowIndex].Cells["maktx"].Value.ToString();
                dr["menge"] = dataGridViewDetails.Rows[rowIndex].Cells["menge"].Value.ToString();
                dr["pstyp"] = dataGridViewDetails.Rows[rowIndex].Cells["pstyp"].Value.ToString();   //标准寄售
                dr["zfimg"] = dataGridViewDetails.Rows[rowIndex].Cells["zfimg"].Value.ToString();
                dr["lfimg"] = dataGridViewDetails.Rows[rowIndex].Cells["lfimg"].Value.ToString();
                dr["BKTXT"] = dataGridViewDetails.Rows[rowIndex].Cells["b"].Value.ToString();   //品牌产地
                dr["pweight"] = dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value.ToString();
                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            else if (colIndex == 1)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                dt.Rows[rowIndex].Delete();
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
        }

        private void dataGridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
             if ((colIndex == 12 || colIndex == 13 || colIndex == 14 || colIndex == 15) && rowIndex != -1)
            {
                try
                {
                    double senge = 0;
                    int zfimg = 0;
                    int pweight = Convert.ToInt32(dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value);
                    double lfimg = Convert.ToDouble(dataGridViewDetails.Rows[rowIndex].Cells["lfimg"].Value);
                    if (dataGridViewDetails.Rows[rowIndex].Cells["zfimg"].Value.ToString() == "")
                    {
                        if (checkBoxKG.Checked == true)
                        {
                            zfimg = Convert.ToInt32(lfimg / pweight);
                        }
                        else
                        {
                           zfimg = Convert.ToInt32(lfimg * 1000 / pweight);
                        }
                        
                        dataGridViewDetails.Rows[rowIndex].Cells["zfimg"].Value = zfimg.ToString();
                    }
                    string temp = dataGridViewDetails.Rows[rowIndex].Cells["realZfimg"].Value.ToString();
                    if (!ValidateHelper.IsNumber(temp.TrimEnd('.')))
                    {
                        dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value = DBNull.Value;
                        MessageBox.Show(this, "实收件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int realzfimg = Convert.ToInt32(temp);
                    if (checkBoxKG.Checked == true)
                    {
                        senge = realzfimg * pweight;
                    }
                    else
                    {
                        senge = realzfimg * pweight / 1000.0;
                    }
                    
                    dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value = senge.ToString();
                    CalcDiff();
                }
                catch
                {
                }
                if (colIndex == 17)
                {
                    CalcDiff();
                }
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private bool CorrectMistake()
        {
            int count = dataGridViewDetails.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show(this, "没有采购订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int j = 0;
            try
            {
                string temp = string.Empty;
                dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
                for (int i = 0; i < count; i++)
                {
                    for (j = 11; j <= 17; j++)
                    {
                        if ("仓储类型".Equals(dataGridViewDetails.Columns[j].HeaderText.ToString()))
                        {
                            continue;
                        }

                        if (dataGridViewDetails.Rows[i].Cells[j].Value != null)
                        {
                            temp = dataGridViewDetails.Rows[i].Cells[j].Value.ToString();
                            temp = temp.Replace("。", ".").Replace(",", "").Replace(" ", "");
                            dataGridViewDetails.Rows[i].Cells[j].Value = Convert.ToDouble(temp);
                        }
                        else
                        {
                            MessageBox.Show(this, "请检查输入" + dataGridViewDetails.Columns[j].HeaderText, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请检查输入" + dataGridViewDetails.Columns[j].HeaderText, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void toolStripButtonReturn_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
                if (DialogResult.Yes != MessageBox.Show(this, "确认重车出厂？", "史丹利地磅系统 - 原材料采购出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal diff = Convert.ToDecimal(textBoxGross.Text) - Convert.ToDecimal(textBoxTare.Text);
                if (diff > 0)
                {
                    if (MessageBox.Show(this, "进厂重量比出厂重量重" + diff.ToString() + "吨，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                else if (diff < 0)
                {
                    if (MessageBox.Show(this, "出厂重量比进厂重量重" + (-diff).ToString() + "吨，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                
                rawHead.ExitTime = Common.GetServerDate();
                rawHead.Hs_flag = "S";
                rawHead.Tare = Convert.ToDecimal(textBoxTare.Text.Trim().ToString());
                rawHead.Net = rawHead.Gross - rawHead.Tare;
                rawHead.Balance = Convert.ToDecimal(diff);
                rawHead.ExitWeightMan = textBoxWeighMan.Text.ToString().Trim();
                rawHead.ExitFlag = "1";
                rawHead.Wagon = txtWagon.Text.ToString().Trim();
                rawHead.WagonNum = txtWagonNum.Text.ToString().Trim();
                rawHead.Bfimg = textBfimg.Text.ToString().Trim();
                rawHead.Freight = textFreight.Text.ToString().Trim();
                rawHead.CyNum = Convert.ToDecimal(txtCYNum.Text.ToString().Trim());

                Slps_RawMaterialsProcurementAdapter.UpdateSlps_RawMaterialsProcurement(rawHead);

                MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "地磅数据保存失败，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

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

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void CalcDiff()
        {
            try
            {
                 double tuopan = 0;
                if (this.comboBoxStandardWeight.Text != "" )
                {
                    if(Convert.ToDouble(this.comboBoxStandardWeight.Text) >= 0)
                        tuopan = Convert.ToDouble(this.comboBoxStandardWeight.Text);
                }
                double quantity = 0;
                if (this.textBoxQuantity.Text != "")
                {
                    if (Convert.ToDouble(this.textBoxQuantity.Text) >= 0)
                    {
                        quantity = Convert.ToDouble(this.textBoxQuantity.Text);
                    }
                }
                decimal weight = Convert.ToDecimal(tuopan * quantity / 1000.0);
                decimal tare = Convert.ToDecimal(textBoxTare.Text);
                decimal gross = Convert.ToDecimal(textBoxGross.Text);
                decimal net = gross - tare - weight;
                if (checkBoxKG.Checked == false)
                {
                    net2 = Math.Round(net * discount, 2);
                }
                else
                {
                    net2 = Math.Round(net, 2);
                }
                textBoxNet.Text = net.ToString();
                textBoxNetMinus.Text = net2.ToString();
                decimal total = 0;
                string temp = string.Empty;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    if (dataGridViewDetails.Rows[i].Cells["sapOrderNo"].Value.ToString() != temp)
                    {
                        total += (dataGridViewDetails.Rows[i].Cells["lfimg"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["lfimg"].Value);
                        temp = dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString();
                    }else if (dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString() == temp && i > 0 && dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString() != dataGridViewDetails.Rows[i - 1].Cells["PWEIGHT"].Value.ToString())
                    {
                        total += (dataGridViewDetails.Rows[i].Cells["lfimg"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["lfimg"].Value);
                        temp = dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString();
                    }
                }
                if (checkBoxKG.Checked == true)
                {
                    total = total / 1000;
                }
                textBoxDiff.Text = (net2 - total).ToString();
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

        private bool CheckDB()
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = rawHead.DbNum;
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

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void comboBoxStandardWeight_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void comboBoxStandardWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void textBoxQuantity_TextChanged_1(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            printThisPaper();
        }

        private void printThisPaper()
        {
            decimal Realzfimg = 0;
            try
            {
                if (dataGridViewDetails.IsCurrentCellDirty)
                {
                    dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataTable paper = new DataTable();
                paper.Columns.Add("Car");
                paper.Columns.Add("WERKS");
                paper.Columns.Add("VBELN");
                paper.Columns.Add("ExitTime");
                paper.Columns.Add("EnterTime");
                paper.Columns.Add("ABLAD");
                paper.Columns.Add("Wagon");
                paper.Columns.Add("CYNum");
                paper.Columns.Add("Bfimg");
                paper.Columns.Add("WagonNum");
                paper.Columns.Add("Freight");
                paper.Columns.Add("WeighMan");
                paper.Columns.Add("Gross");
                paper.Columns.Add("Tare");
                paper.Columns.Add("Net");
                paper.Columns.Add("KG");

                DataRow dr = paper.NewRow();
                dr["Car"] = textBoxCar.Text.ToString();
                dr["VBELN"] = father[1].ToString(); ;
                dr["ExitTime"] = rawHead.ExitTime;
                dr["EnterTime"] = rawHead.EnterTime;
                dr["ABLAD"] = comboBoxABLAD.Text.ToString();
                dr["Wagon"] = txtWagon.Text.ToString();
                dr["CYNum"] = txtCYNum.Text.ToString();
                dr["Bfimg"] = textBfimg.Text.ToString();
                dr["WagonNum"] = txtWagonNum.Text.ToString();
                dr["Freight"] = textFreight.Text.ToString();
                dr["WeighMan"] = textBoxWeighMan.Text.ToString();
                dr["Gross"] = textBoxGross.Text.ToString();
                dr["Tare"] = textBoxTare.Text.ToString();
                dr["Net"] = textBoxNetMinus.Text.ToString();
                dr["Werks"] = textBoxFactory.Text.ToString();
                if (checkBoxKG.Checked == true)
                {
                    dr["KG"] = "1";
                }
                else
                {
                    dr["KG"] = "0";
                }
                paper.Rows.Add(dr);

                string Dfimg = "";
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                DataTable dt = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                dt.Columns.Add("realZfimg");
                dt.Columns.Add("dfimg");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Realzfimg = decimal.Parse(dataGridViewDetails.Rows[i].Cells["realZfimg"].Value.ToString());
                    dt.Rows[i]["realZfimg"] = Realzfimg.ToString();
                    dt.Rows[i]["lgort"] = dataGridViewDetails.Rows[i].Cells["lgort"].Value.ToString();
                    dt.Rows[i]["dfimg"] = dataGridViewDetails.Rows[i].Cells["dfimg"].Value.ToString();
                    Dfimg += dt.Rows[i]["dfimg"].ToString();
                }
                int lag = 0;
                if (Dfimg != "")
                {
                    if (Convert.ToInt32(Dfimg) > 0 && txtWagonNum.Text != "")
                    {
                        if (MessageBox.Show("是否抹除涨件？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            lag = 1;
                        }
                    }
                }
                this.Cursor = Cursors.WaitCursor;
                RawMaterialsProcurementDetailsPrint proDetail = new RawMaterialsProcurementDetailsPrint();
                proDetail.StartPosition = FormStartPosition.CenterParent;
                proDetail.ShowDialog(paper, dt, lag, this);
                this.Cursor = Cursors.Default;
            }
            catch
            {
                MessageBox.Show(this, "请输入完整的采购单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void saveAndPrint(string truckNum, string timeFlag, string ebeln)
        {
            int lag = 0;
            if (MessageBox.Show("是否抹除涨件？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lag = 1;
            }
            this.Cursor = Cursors.WaitCursor;
            RawMaterialsProcurementDetailsPrint proDetail = new RawMaterialsProcurementDetailsPrint();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(truckNum, timeFlag, ebeln, lag, this);
            this.Cursor = Cursors.Default;
        }

        private void checkBoxKG_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool CheckDB(Slps_RawMaterialsProcurement title)
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = title.DbNum;
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

    }
}
