using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using System.Threading;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsRawMaterialReturnExit : Form
    {
        
        SerialPortHelper s = null;
        private bool readPort = true;
        private string formTittle = "成品退货出场";
        string[] qrCodeArray;   //二维码扫描结果数组
        Slps_RawMaterialsReturn returnHead = new Slps_RawMaterialsReturn();

        public SlpsRawMaterialReturnExit(string[] codeArray)
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
                textBoxGross.ReadOnly = true;
            }
            else
            {
                textBoxGross.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            s = new SerialPortHelper(ref serialPort);
            textBoxFactory.Text = sysSetting.WERKS;
            if (sysSetting.WERKS == "2501")
            {
                comboBoxStandardWeight.Visible = true;
                textBoxQuantity.Visible = true;
                labelTrayWeight.Visible = true;
                labelTrayQuantity.Visible = true;
            }
            textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            textBoxExitTime.Text = Common.GetServerDate();
            textBoxPrompt.Text = formTittle;
            timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private bool ValidateControl(DataTable dt)
        {
            if ((!ValidateHelper.IsNumber(comboBoxStandardWeight.Text)) && comboBoxStandardWeight.Visible)
            {
                MessageBox.Show(this, "托盘标重必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidateHelper.IsNumber(textBoxQuantity.Text) && textBoxQuantity.Visible)
            {
                MessageBox.Show(this, "托盘数量必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsNumber(textBoxNet.Text) || ValidateHelper.IsDecimal(textBoxNet.Text)))
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
                string realNum = dataGridViewDetails.Rows[i].Cells["senge"].Value.ToString();
                if ((!(ValidateHelper.IsDecimal(realNum) || ValidateHelper.IsNumber(realNum))) || double.Parse(realNum) == 0)
                {
                    MessageBox.Show(this, "请输入实退吨数,实退吨数应为大于零的数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                if (string.IsNullOrEmpty(lgort))
                {
                    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            return true;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            DataGridViewCell dCell = null;
            if (dataGridViewDetails.Rows.Count != 0)
            {
                dCell = dataGridViewDetails.Rows[0].Cells[0];
            }
            dataGridViewDetails.CurrentCell = dCell;
            if (MessageBox.Show("确实要保存吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                if (returnHead == null)
                {
                    MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (returnHead.Hs_flag == "S")
                {
                    MessageBox.Show(this, "该车已经退货出厂，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                try
                {
                    //头信息操作
                    returnHead.ExitTime = Common.GetServerDate();
                    returnHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                    returnHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                    returnHead.Net = Convert.ToDecimal(textBoxNet.Text.ToString().Trim());
                    returnHead.ExitFlag = "0";
                    returnHead.Hs_flag = "S";
                    returnHead.DeuctNum = Convert.ToDecimal(textBoxDeductNum.Text.ToString().Trim());
                    returnHead.TrayWeight = Convert.ToDecimal(comboBoxStandardWeight.SelectedValue);
                    returnHead.TrayQuantity = Convert.ToDecimal(textBoxQuantity.Text.ToString().Trim());
                    Slps_RawMaterialsReturnAdapter.UpdateSlps_RawMaterialsReturn(returnHead);

                    //行项目操作
                    Slps_RawMaterialsReturnDetail returnDetail;
                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        returnDetail = Slps_RawMaterialsReturnDetailAdapter.GetSlps_RawMaterialsReturnDetail(returnHead.TimeFlag, dtGv.Rows[i]["lineItemNo"].ToString());
                        returnDetail.QrcodeScanResult = dtGv.Rows[i]["qrcodeScanResult"].ToString();
                        returnDetail.SapOrderNo = dtGv.Rows[i]["sapOrderNo"].ToString();
                        returnDetail.LineItemNo = dtGv.Rows[i]["lineItemNo"].ToString();
                        returnDetail.Matnr = dtGv.Rows[i]["matnr"].ToString();
                        returnDetail.Maktx = dtGv.Rows[i]["maktx"].ToString();
                        returnDetail.Menge = Convert.ToDecimal(dtGv.Rows[i]["menge"].ToString());
                        returnDetail.Senge = Convert.ToDecimal(dtGv.Rows[i]["senge"].ToString());
                        returnDetail.Lgort = dtGv.Rows[i]["lgort"].ToString();
                        returnDetail.Bktxt = dtGv.Rows[i]["bktxt"].ToString();
                        Slps_RawMaterialsReturnDetailAdapter.UpdateSlps_RawMaterialsReturnDetail(returnDetail);
                    }

                    //保存成功将订单状态设置为已出厂
                    Sdl_SlpsEnter slpsEnter = new Sdl_SlpsEnter();
                    for (int i = 0; i < qrCodeArray.Length; i++)
                    {
                        slpsEnter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[i]);
                        slpsEnter.OrderStatus = "1";
                        Sdl_SlpsEnterAdapter.UpdateSdl_SlpsEnter(slpsEnter);
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
            //int columnIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;
            //if (columnIndex == 0)
            //{
            //    DataTable dt = (DataTable)dataGridViewDetails.DataSource;
            //    DataRow dr = dt.NewRow();
            //    dr["EBELN"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELN"].Value.ToString();
            //    dr["EBELP"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELP"].Value.ToString();
            //    dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
            //    dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
            //    dr["LIFNR"] = dataGridViewDetails.Rows[rowIndex].Cells["LIFNR"].Value.ToString();
            //    dr["NAME1"] = dataGridViewDetails.Rows[rowIndex].Cells["NAME1"].Value.ToString();
            //    dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString();
            //    dr["BKTXT"] = dataGridViewDetails.Rows[rowIndex].Cells["BKTXT"].Value.ToString();
            //    dr["OVERNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["OVERNUM"].Value.ToString();
            //    dt.Rows.InsertAt(dr, rowIndex + 1);
            //    dataGridViewDetails.AutoGenerateColumns = false;
            //    dataGridViewDetails.DataSource = dt;
            //}
            //if (columnIndex == 12)
            //{
            //    if (dataGridViewDetails.Rows.Count == 1)
            //    {
            //        MessageBox.Show(this, "该行不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    dataGridViewDetails.Rows.RemoveAt(e.RowIndex);
            //    double realNum = 0;
            //    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            //    {
            //        try
            //        {
            //            realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
            //        }
            //        catch
            //        {

            //        }
            //    }
            //    textBoxZMenge.Text = realNum.ToString();
               
            //}
        }

        private void InitDetailDataBind(string[] codeArray)
        {

            qrCodeArray = codeArray;

            //查询第一个二维码的时间戳，通过时间戳查询入场信息表头
            Sdl_SlpsEnter enter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[0]);
            returnHead = Slps_RawMaterialsReturnAdapter.GetSlps_RawMaterialsReturn(enter.TimeFlag, enter.CarNo);

            textBoxTare.Text = returnHead.Tare.ToString();
            textBoxCar.Text = returnHead.CarNo;

            //显示车辆皮重历史
            Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);

            //拼接where查询条件
            string where = string.Empty;
            where = "where timeFlag = '" + returnHead.TimeFlag + "'";
            
            //订单明细查询
            DataTable dt = Slps_RawMaterialsReturnDetailAdapter.GetSlps_RawMaterialsReturnDetailDataSet(where).Tables[0];
            
            //为界面中的明细表绑定数据
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dt;
            
            DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where ( lgort like '3%' or lgort like '1%' ) and werks='" + textBoxFactory.Text + "' ").Tables[0];
            DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();
            cmbColumnPro.DataPropertyName = "lgort";
            cmbColumnPro.DataSource = dtCombox;
            cmbColumnPro.ValueMember = "lgort";
            cmbColumnPro.DisplayMember = "lgobe";

            dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["lgort"].Index, cmbColumnPro);
            dataGridViewDetails.Columns.Remove("lgort");
            cmbColumnPro.Name = "lgort";
            cmbColumnPro.HeaderText = "发货仓库";
            
        }
        

        private void textBoxGross_TextChanged(object sender, EventArgs e)
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
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - weight, 3).ToString();
                if (textBoxZMenge.Text.Trim() == string.Empty)
                    textBoxZMenge.Text = "0";
                textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxZMenge.Text), 3).ToString();
            }
            catch
            {

            }
        }

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

                if (Math.Round(double.Parse(textBoxNet.Text), 3) != 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }


                //头信息操作
                returnHead.ExitTime = Common.GetServerDate();
                returnHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                returnHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                returnHead.Net = Convert.ToDecimal(textBoxNet.Text.ToString().Trim());
                returnHead.ExitFlag = "1";
                returnHead.Hs_flag = "S";
                returnHead.DeuctNum = Convert.ToDecimal(textBoxDeductNum.Text.ToString().Trim());
                returnHead.TrayWeight = Convert.ToDecimal(comboBoxStandardWeight.SelectedValue);
                returnHead.TrayQuantity = Convert.ToDecimal(textBoxQuantity.Text.ToString().Trim());
                Slps_RawMaterialsReturnAdapter.UpdateSlps_RawMaterialsReturn(returnHead);
                
                //保存成功将订单状态设置为已出厂
                Sdl_SlpsEnter slpsEnter = new Sdl_SlpsEnter();
                for (int i = 0; i < qrCodeArray.Length; i++)
                {
                    slpsEnter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[i]);
                    slpsEnter.OrderStatus = "1";
                    Sdl_SlpsEnterAdapter.UpdateSdl_SlpsEnter(slpsEnter);
                }

                
                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
                this.Close();
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 9)
                {
                    string cellValue = dataGridViewDetails.CurrentCell.FormattedValue.ToString();
                    if (!StringUtil.IsOverLength(cellValue, 25))
                    {
                        MessageBox.Show(this, "产地/品牌输入的长度不能超过12个汉字，或者不能超过25个英文字母", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                dataGridViewDetails.ClearSelection();
                double realNum = 0;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    try
                    {
                        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["senge"].Value);
                    }
                    catch
                    {
                    }
                }
                textBoxZMenge.Text = realNum.ToString();
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
            CalcDiff();
        }

        private void textBoxZMenge_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
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

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void comboBoxStandardWeight_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void CalcDiff()
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
            textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - weight, 3).ToString();
            if (textBoxZMenge.Text.Trim() == string.Empty)
                textBoxZMenge.Text = "0";
            textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxZMenge.Text), 3).ToString();
        }
    }
}
