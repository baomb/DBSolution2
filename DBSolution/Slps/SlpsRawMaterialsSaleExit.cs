using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsRawMaterialsSaleExit : Form
    {
        bool readPort = true;
        string[] father = new string[3];
        string message = string.Empty;
        string werks_temp = string.Empty;
        private string formTittle = "原材料采购销售出厂";
        private string[] qrCodeArray;   //二维码扫描结果数组
        decimal diff = 0;
        DataSet ds = new DataSet();
        DataSet dtInfo = new DataSet();
        SerialPortHelper s = null;
        Sdl_SysSetting sysSetting = null;
        private Slps_RawMaterialsSale rawHead = new Slps_RawMaterialsSale();

        public SlpsRawMaterialsSaleExit()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxGross.ReadOnly = false;
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
            try
            {
                sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                readPort = Common.GetReadPortFlag();
                s = new SerialPortHelper(ref serialPort);
                werks_temp = sysSetting.WERKS;
                this.textBoxFactory.Text = sysSetting.WERKS;
                if (sysSetting.WERKS == "2003" || sysSetting.WERKS == "2002")
                {
                    checkBoxType.Visible = true;
                }
                else
                {
                    checkBoxType.Visible = false;
                }
                this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                Sdl_Manual manual = Sdl_ManualAdapter.GetSdl_Manual(this.labelTitle.Text);
                this.textBoxPrompt.Text = manual.MANUAL;
                this.timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {

        }

        private bool CheckDB(Slps_RawMaterialsSale raw)
        {
            string enterDB = raw.DbNum;
            string exitDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
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

        private void InitDetailsDataBind(string[] qrCode)
        {
            //查询
            qrCodeArray = qrCode;
            //查询第一个二维码的时间戳，通过时间戳查询入场信息表头
            Sdl_SlpsEnter enter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[0]);
            rawHead = Slps_RawMaterialsSaleAdapter.GetSlps_RawMaterialsSale(enter.TimeFlag, enter.CarNo);

            //检查地磅是与入场一致
            if (!CheckDB(rawHead))
            {
                return;
            }
            textBoxDbnum.Text = rawHead.DbNum;
            textBoxTare.Text = rawHead.Tare.ToString();


            //绑定库存地
            string WhereSql;
            if (werks_temp == "2003" || werks_temp == "2501" || werks_temp == "2101")
            {
                WhereSql = " where ( lgort like '1%' or lgort like '3%' or lgort like '4%') and werks='" + textBoxFactory.Text + "' ";
            }
            else if ( werks_temp == "5001" )        
            {
                WhereSql = " where ( lgort like '1%' or lgort like '3%' or lgort like '4%') and werks='" + werks_temp + "' ";
            }  
            else 
            {
                WhereSql = " where ( lgort like '3%' or lgort like '4%') and werks='" + textBoxFactory.Text + "' ";
            }
            DataTable dtLGORT = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(WhereSql).Tables[0];
            DataGridViewComboBoxColumn cbcLGORT = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[12];
            cbcLGORT.DataPropertyName = "lgort";
            cbcLGORT.DataSource = dtLGORT;
            cbcLGORT.ValueMember = "lgort";
            cbcLGORT.DisplayMember = "lgobe";
            cbcLGORT.Name = "LGORT";
            cbcLGORT.HeaderText = "仓库";

            //绑定包重
            DataTable dtPackWeight = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
            DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[9];
            cbcpw.DataPropertyName = "pweight";
            cbcpw.DataSource = dtPackWeight;
            cbcpw.ValueMember = "包重";
            cbcpw.DisplayMember = "说明";
            cbcpw.Name = "PWEIGHT";
            cbcpw.HeaderText = "包重";

            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = ds.Tables[0];
            Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
        }

        private bool ValidateControl()
        {
            if (dataGridViewDetails.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有销售订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                for (int j = 2; j < dataGridViewDetails.Columns.Count; j++)
                {
                    if (dataGridViewDetails.Rows[i].Cells[j].Value == DBNull.Value || dataGridViewDetails.Rows[i].Cells[j].Value == null)
                    {
                        MessageBox.Show(this, "请检查输入" + dataGridViewDetails.Columns[j].HeaderText, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            string temp = string.Empty;
            decimal sfimg;
            sfimg = 0;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                temp = dataGridViewDetails.Rows[i].Cells["realZfimg"].Value.ToString();
                bool isNumber = ValidateHelper.IsNumber(temp);
                if (!isNumber || Convert.ToInt32(temp) == 0)
                {
                    MessageBox.Show(this, "实发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                sfimg += Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["sfimg"].Value.ToString());
            }
            diff = Convert.ToDecimal(textBoxGross.Text) - Convert.ToDecimal(textBoxTare.Text) - sfimg;
            if (diff > 0)
            {
                if (MessageBox.Show(this, "该批货物比应发数量涨吨" + diff.ToString() + "吨，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }
            }
            else if (diff < 0)
            {
                if (MessageBox.Show(this, "该批货物比应发数量亏吨" + (-diff).ToString() + "吨，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "史丹利地磅系统 - 原材料采购出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            if (toolStripButton.Text != "解锁")
            {
                MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateControl())
            {
                return;
            }
            DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                
            
            try
            {
                //更新头信息
                rawHead.Hs_flag = "S";
                rawHead.Gross = Convert.ToDecimal(textBoxGross.Text);
                rawHead.Balance = Convert.ToDecimal(diff);
                rawHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                rawHead.ExitTime = Common.GetServerDate();
                rawHead.ExitFlag = "0";
                Slps_RawMaterialsSaleAdapter.UpdateSlps_RawMaterialsSale(rawHead);

                //删除原行项目
                Slps_RawMaterialsSaleDetailAdapter.DeleteSlps_RawMaterialsSaleDetail(rawHead.TimeFlag);

                //更新行项目信息
                Slps_RawMaterialsSaleDetail rawDetail;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    rawDetail = new Slps_RawMaterialsSaleDetail();
                    rawDetail.QrcodeScanResult = dtGv.Rows[i]["qrcodeScanResult"].ToString();
                    rawDetail.SapOrderNo = dtGv.Rows[i]["sapOrderNo"].ToString();
                    rawDetail.LineItemNo = dtGv.Rows[i]["lineItemNo"].ToString();
                    rawDetail.TimeFlag = rawHead.TimeFlag;
                    rawDetail.Matnr = dtGv.Rows[i]["matnr"].ToString();
                    rawDetail.Maktx = dtGv.Rows[i]["maktx"].ToString();
                    rawDetail.Sfimg = Convert.ToDecimal(dtGv.Rows[i]["sfimg"].ToString());
                    rawDetail.Pweight = Convert.ToDecimal(dtGv.Rows[i]["pweight"].ToString());
                    rawDetail.Lgort = dtGv.Rows[i]["lgort"].ToString();
                    rawDetail.RealZfimg = Convert.ToDecimal(dtGv.Rows[i]["realZfimg"].ToString());
                    Slps_RawMaterialsSaleDetailAdapter.AddSlps_RawMaterialsSaleDetail(rawDetail);
                }
                
                MessageBox.Show(this, dtInfo.Tables[0].Rows[0][0].ToString(), "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "SAP过账成功，地磅数据保存失败，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void dataGridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if ((colIndex == 9 || colIndex == 10) && rowIndex != -1)
            {
                try
                {
                    double pweight = Convert.ToDouble(dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value);
                    string temp = dataGridViewDetails.Rows[rowIndex].Cells["realZfimg"].Value.ToString();
                    temp = TypeConverter.ToDBC(temp).Replace("。", ".");
                    dataGridViewDetails.Rows[rowIndex].Cells["realZfimg"].Value = temp;
                    if (!ValidateHelper.IsNumber(temp.TrimEnd('.')))
                    {
                        dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value = DBNull.Value;
                        MessageBox.Show(this, "实发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int realzfimg = Convert.ToInt32(temp);
                    double sfimg = pweight * realzfimg / 1000.0;
                    dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value = sfimg.ToString();
                }
                catch
                {
                }
                finally
                {
                    CalcDiff();
                }
            }
        }

        private void toolStripButtonReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "确认空车出厂？", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal diff = Convert.ToDecimal(textBoxTare.Text) - Convert.ToDecimal(textBoxGross.Text);
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

                //更新头信息
                rawHead.Hs_flag = "S";
                rawHead.Gross = Convert.ToDecimal(textBoxGross.Text);
                rawHead.Balance = Convert.ToDecimal(diff);
                rawHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                rawHead.ExitTime = Common.GetServerDate();
                rawHead.ExitFlag = "!";
                Slps_RawMaterialsSaleAdapter.UpdateSlps_RawMaterialsSale(rawHead);
                
                MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dataGridViewDetails.DataSource != null)
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                if (colIndex == 0)
                {
                    DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                    DataRow dr = dt.NewRow();
                    dr["VBELN"] = dataGridViewDetails.Rows[rowIndex].Cells["VBELN"].Value.ToString();
                    dr["POSNR"] = dataGridViewDetails.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                    dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                    dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                    dr["LFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["LFIMG"].Value.ToString();
                    dr["KUNNR"] = dataGridViewDetails.Rows[rowIndex].Cells["KUNNR"].Value.ToString();
                    dr["NAME1"] = dataGridViewDetails.Rows[rowIndex].Cells["NAME1"].Value.ToString();
                    dr["PWEIGHT"] = dataGridViewDetails.Rows[rowIndex].Cells["PWEIGHT"].Value.ToString();
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

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewDetails.IsCurrentCellDirty)
            {
                dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void CalcDiff()
        {
            try
            {
                decimal tare = Convert.ToDecimal(textBoxTare.Text);
                decimal gross = Convert.ToDecimal(textBoxGross.Text);
                decimal net = gross - tare;
                textBoxNet.Text = net.ToString();
                decimal total = 0;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    total += (dataGridViewDetails.Rows[i].Cells["SFIMG"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["SFIMG"].Value);
                }
                textBoxDiff.Text = (net - total).ToString();
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

        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxType.Checked == true)
            {
                werks_temp = "5001";
                textBoxFactory.Text = "5001";
            }
            else
            {
                if (sysSetting != null)
                {
                    textBoxFactory.Text = sysSetting.WERKS;
                    werks_temp = sysSetting.WERKS;
                }
            }
        }
    }
}
