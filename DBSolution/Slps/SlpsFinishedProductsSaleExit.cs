using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using SdlDB.Utility;
using SdlDB.Data;
using SdlDB.Entity;
using System.Threading;

namespace DBSolution
{
    public partial class SlpsFinishedProductsSaleExit : Form
    {
        private string[] father = new string[] { "", "" };
        private DataTable dtSapDetail = new DataTable();
        private DataTable dtSelect = new DataTable();
        private DataTable dtVBELN = new DataTable();
        SerialPortHelper s = null;
        private bool readPort = true;
        private string strWerks = "";
        private string formTittle = "成品销售出场";
        string[] qrCodeArray;   //二维码扫描结果数组
        Slps_FinishedProductsSale finishedHead = new Slps_FinishedProductsSale();

        //初始化
        public SlpsFinishedProductsSaleExit()
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
            strWerks = sysSetting.WERKS;
            textBoxFactory.Text = strWerks;
            textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            s = new SerialPortHelper(ref serialPort);
            //判断是否启用托盘
            bool tray = Sdl_SysSettingAdapter.GetSdl_Tray(sysSetting.WERKS);
            if ( tray == true)
           {
                comboBoxStandardWeight.Visible = true;
                textBoxQuantity.Visible = true;
                labelTrayWeight.Visible = true;
                labelTrayQuantity.Visible = true;
            }
            //计时器启动
            timer.Start();
        }

        private void InitDetailBind(string[] qrCode)
        {
            qrCodeArray = qrCode;
            
            //查询第一个二维码的时间戳，通过时间戳查询入场信息表头
            Sdl_SlpsEnter enter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[0]);
            finishedHead = Slps_FinishedProductsSaleAdapter.GetSlps_FinishedProductsSale(enter.TimeFlag,enter.CarNo);
            
            //检查地磅是与入场一致
            if (!CheckDB(finishedHead))
            {
                return;
            }
            textBoxDBNum.Text = finishedHead.DbNum;
            textBoxTare.Text = finishedHead.Tare.ToString();
            textBoxCar.Text = finishedHead.CarNo;

            //显示车辆皮重历史
            Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);
            
            //拼接where查询条件
            string where = string.Empty;
            where = "where timeFlag = '" + finishedHead.TimeFlag + "'";
            //订单明细查询
            DataTable dt = Slps_FinishedProductsSaleDetailAdapter.GetSlps_FinishedProductsSaleDetailList(where).Tables[0];
            
            //为界面中的明细表绑定数据
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dt;
            dataGridViewDetails.Columns[7].ReadOnly = false;
            dataGridViewDetails.Columns[8].ReadOnly = false;
            
            //仓库下拉框绑定数据
            DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where lgort like '1%' and werks='" + strWerks + "' ").Tables[0];
            DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();

            cmbColumnPro.DataPropertyName = "lgort";
            cmbColumnPro.DataSource = dtCombox;
            cmbColumnPro.ValueMember = "lgort";
            cmbColumnPro.DisplayMember = "lgobe";

            int i = dataGridViewDetails.Columns["LGORT"].Index;
            dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
            dataGridViewDetails.Columns.Remove("LGORT");

            cmbColumnPro.Name = "LGORT";
            cmbColumnPro.HeaderText = "发货仓库";
        }
        
        private bool CheckDB(Slps_FinishedProductsSale title)
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
        

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            
        }

        private bool ValidateControl(DataTable dt)
        {
            //校验托盘标重和数量是否为整数
            if (this.comboBoxStandardWeight.Text != "" || this.textBoxQuantity.Text != "")
            {
                if ((!ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text)) && this.comboBoxStandardWeight.Visible)
                {
                    MessageBox.Show(this, "托盘标重必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if ((!ValidateHelper.IsNumber(this.textBoxQuantity.Text)) && this.textBoxQuantity.Visible)
                {
                    MessageBox.Show(this, "托盘数量必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
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
                string realNum = dataGridViewDetails.Rows[i].Cells["realNum"].Value.ToString();
                if (!ValidateHelper.IsNumber(realNum))
                {
                    MessageBox.Show(this, "请输入实发件数,实发件数应为整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string lgort = dataGridViewDetails.Rows[i].Cells["lgort"].Value.ToString();
                if (string.IsNullOrEmpty(lgort))
                {
                    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            //DataTable dtTemp = new DataTable();
            //double lfSum = 0;
            //double lfZfimgSum = 0;
            //for (int j = 0; j < dtSelect.Rows.Count; j++)
            //{
            //    string vbeln = dtSelect.Rows[j]["VBELN"].ToString();
            //    string posnr = dtSelect.Rows[j]["POSNR"].ToString();
            //    string matnr = dtSelect.Rows[j]["MATNR"].ToString();

            //    double lf = double.Parse(dtSelect.Rows[j]["LFIMG"].ToString());
            //    double lfZfimg = double.Parse(dtSelect.Rows[j]["ZFIMG"].ToString());
            //    dtTemp = new DataSetHelper().GetNewDataTable(dt, " VBELN = '" + vbeln + "' and POSNR='" + posnr + "' and MATNR='" + matnr + "'", "");
            //    double lfGv = 0;
            //    for (int n = 0; n < dtTemp.Rows.Count; n++)
            //    {
            //        if (string.IsNullOrEmpty(dtTemp.Rows[n]["REAL_NUM"].ToString()))
            //        {
            //            MessageBox.Show(this, "请输入实发数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return false;
            //        }
            //        lfGv += double.Parse(dtTemp.Rows[n]["REAL_NUM"].ToString()) * GetMatnrWeight(matnr) / 1000;
            //    }
            //    if (Math.Round(lf, 3) != Math.Round(lfGv, 3))
            //    {
            //        MessageBox.Show(this, "行项目中物料的原发数量与实际的数量不相符合，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    lfSum += lf;
            //    lfZfimgSum += lfZfimg;
            //}
            //double netValue = double.Parse(textBoxNet.Text);

            //double ProBalance1 = Common.GetProductBalanceValue();
            //double ProBalance = lfZfimgSum * ProBalance1;

            //if (Math.Round(Math.Abs(netValue - lfSum), 3) > Math.Round(ProBalance, 3))
            //{
            //    if (MessageBox.Show("原发吨数与实际过磅数量在误差件数" + lfZfimgSum + "乘以包误差" + ProBalance1 * 1000 + "KG允许的范围内不相等,确认过账吗？", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
            return true;
        }

        private double GetBalanceValue()
        {
            return Sdl_LoadometerDiffAdapter.GetSdl_LoadometerDiff(Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-子公司成品销售出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show(this, "没有单据信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                
                if (finishedHead == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (finishedHead.Hs_flag == "S")
                {
                    MessageBox.Show(this, "该车已经发货成功，不能再次发货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                try
                {
                    //头信息操作
                    finishedHead.ExitTime = Common.GetServerDate();
                    finishedHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                    finishedHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                    finishedHead.ExitFlag = "0";
                    finishedHead.Hs_flag = "S";
                    if (ValidateHelper.IsNumber(comboBoxStandardWeight.Text.ToString().Trim()))
                    {
                        finishedHead.TrayWeight = Convert.ToDecimal(comboBoxStandardWeight.Text.ToString().Trim());
                    }
                    if (ValidateHelper.IsNumber(textBoxQuantity.Text.ToString().Trim()))
                    {
                        finishedHead.TrayQuantity = Convert.ToInt32(textBoxQuantity.Text.ToString().Trim());
                    }
                    Slps_FinishedProductsSaleAdapter.UpdateSlps_FinishedProductsSale(finishedHead);
                    
                    //行项目操作
                    Slps_FinishedProductsSaleDetail finishedDetail = new Slps_FinishedProductsSaleDetail();
                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        finishedDetail.QrcodeScanResult = dtGv.Rows[i]["qrcodeScanResult"].ToString();
                        finishedDetail.SapOrderNo = dtGv.Rows[i]["sapOrderNo"].ToString();
                        finishedDetail.LineItemNo = dtGv.Rows[i]["lineItemNo"].ToString();
                        finishedDetail.Matnr = dtGv.Rows[i]["matnr"].ToString();
                        finishedDetail.Maktx = dtGv.Rows[i]["maktx"].ToString();
                        finishedDetail.Lfimg = Convert.ToDecimal(dtGv.Rows[i]["lfimg"].ToString());
                        finishedDetail.RealZfimg = Convert.ToDecimal(dtGv.Rows[i]["realZfimg"].ToString());
                        finishedDetail.TimeFlag = finishedHead.TimeFlag;
                        string zf = dtGv.Rows[i]["zfimg"].ToString();
                        finishedDetail.Zfimg = int.Parse(zf.Substring(0, zf.IndexOf(".")));
                        Slps_FinishedProductsSaleDetailAdapter.AddSlps_FinishedProductsSaleDetail(finishedDetail);
                    }
                        
                    MessageBox.Show(this, "出厂操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Common.PlayGoodBye();
                    this.Close();
                }
                catch
                {
                    this.Close();
                    return;
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
                case "7":
                    returnValue = double.Parse(Common.Weight7.ToString());
                    break;
                case "8":
                    returnValue = double.Parse(Common.Weight8.ToString());
                    break;
                case "9":
                    returnValue = double.Parse(Common.Weight9.ToString());
                    break;
                default:
                    returnValue = double.Parse(Common.Weight1.ToString());
                    break;
            }
            return returnValue;
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcDiff();
            }
            catch
            {
            }
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)    //托盘数量
        {
            CalcDiff();
        }

        private void comboBoxStandardWeight_TextChanged(object sender, EventArgs e)   //托盘重量
        {
            CalcDiff();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridViewSelect_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //空车出厂
        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空车出厂操作吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
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
                
                finishedHead.ExitTime = Common.GetServerDate();
                finishedHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                finishedHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                finishedHead.ExitFlag = "1";
                finishedHead.Hs_flag = "S";
                if (ValidateHelper.IsNumber(comboBoxStandardWeight.Text.ToString().Trim()))
                {
                    finishedHead.TrayWeight = Convert.ToDecimal(comboBoxStandardWeight.Text.ToString().Trim());
                }
                if (ValidateHelper.IsNumber(textBoxQuantity.Text.ToString().Trim()))
                {
                    finishedHead.TrayQuantity = Convert.ToInt32(textBoxQuantity.Text.ToString().Trim());
                }
                Slps_FinishedProductsSaleAdapter.UpdateSlps_FinishedProductsSale(finishedHead);
                
                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
                Close();
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

        private void CalcDiff()
        {
            try
            {
                int tuopan = 0;
                if (ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text))
                {
                    tuopan = Convert.ToInt16(this.comboBoxStandardWeight.Text);
                }
                int quantity = 0;
               if (ValidateHelper.IsNumber(this.textBoxQuantity.Text))
                    {
                        quantity = Convert.ToInt16(this.textBoxQuantity.Text);
                    }
                double weight = Convert.ToDouble(tuopan * quantity / 1000.0);
                if (textBoxNet.Text.Trim() == string.Empty)
                {
                    textBoxNet.Text = "0";
                    textBoxNet.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxNet.Text), 3).ToString();
                }
                else
                {
                    textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - weight, 3).ToString();
                }
            }
            catch
            { 
                
            }
            
         }
    }
}
