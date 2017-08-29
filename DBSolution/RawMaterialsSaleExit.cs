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
    public partial class RawMaterialsSaleExit : Form
    {
        bool readPort = true;
        string[] father = new string[3];
        string message = string.Empty;
        string werks_temp = string.Empty;
        decimal diff = 0;
        DataSet ds = new DataSet();
        DataSet dtInfo = new DataSet();
        Sdl_RawMaterialsSaleTitle rmst = new Sdl_RawMaterialsSaleTitle();
        SerialPortHelper s = null;
        Sdl_SysSetting sysSetting = null;

        public RawMaterialsSaleExit()
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
                this.textBoxExitTime.Text = Common.GetServerDate();
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
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "RawMaterialsSale", werks_temp);
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                this.textBoxCar.Text = father[0].ToString();
                this.textBoxVBELN.Text = father[1].ToString();
                rmst = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                if (!CheckDB())
                {
                    return;
                }
                this.textBoxDBNum.Text = rmst.DBNUM;
                this.textBoxTare.Text = rmst.TARE.ToString();
                if (checkBoxType.Checked == true)
                {
                    werks_temp = "5001";
                    textBoxFactory.Text = werks_temp;
                }
                else
                {
                    textBoxFactory.Text = sysSetting.WERKS;
                    werks_temp = sysSetting.WERKS;
                }
                InitDetailsDataBind("");
            }
        }

        private bool CheckDB()
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = rmst.DBNUM;
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

        private void InitDetailsDataBind(string where)
        {
            ListDictionary la = new ListDictionary();
            la.Add("VBELN", textBoxVBELN.Text);
            la.Add("WERKS", werks_temp);
            ListDictionary lt = new ListDictionary();
            lt.Add("ZLIPS", "VBELN,POSNR,KUNNR,NAME1,MATNR,MAKTX,LFIMG");
            ListDictionary lr = new ListDictionary();
            ds = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_SALE_RC", la, lt, ref lr);
            ds.Tables[0].Columns.Add("SFIMG");
            ds.Tables[0].Columns.Add("WERKS");
            ds.Tables[0].Columns.Add("LGORT");
            ds.Tables[0].Columns.Add("PWEIGHT");

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
                temp = dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value.ToString();
                bool isNumber = ValidateHelper.IsNumber(temp);
                if (!isNumber || Convert.ToInt32(temp) == 0)
                {
                    MessageBox.Show(this, "实发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                sfimg += Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["SFIMG"].Value.ToString());
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
            try
            {
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
                DataTable dt = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["WERKS"] = werks_temp;
                    dt.Rows[i]["LGORT"] = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    dt.Rows[i]["SFIMG"] = dataGridViewDetails.Rows[i].Cells["SFIMG"].Value.ToString();
                }
                dt.Columns.Remove("MAKTX");
                dt.Columns.Remove("KUNNR");
                dt.Columns.Remove("NAME1");
                dt.Columns.Remove("LFIMG");
                dt.Columns.Remove("PWEIGHT");
                ListDictionary ltPara = new ListDictionary();
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dt);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();
                dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_SALE_GZ_CHECK", ltPara, ltParaTb, lt, ref lr);

                if (dtInfo.Tables[0].Rows[0][0].ToString() != "检查成功")
                {
                    for (int i = 0; i < dtInfo.Tables[0].Rows.Count; i++)
                    {
                        MessageBox.Show(this, dtInfo.Tables[0].Rows[i][0].ToString(), "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_SALE_GZ", ltPara, ltParaTb, lt, ref lr);
                if (!dtInfo.Tables[0].Rows[0][0].ToString().StartsWith("过账成功"))
                {
                    MessageBox.Show(this, dtInfo.Tables[0].Rows[0][0].ToString(), "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch
            {
                MessageBox.Show(this, "过账失败，请联系业务人员查看SAP凭证", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hasError = true;
                this.Close();
            }
            if (hasError)
            {
                return;
            }
            try
            {
                Sdl_RawMaterialsSale rms = new Sdl_RawMaterialsSale();
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    rms.TIMEFLAG = rmst.TIMEFLAG;
                    rms.LGORT = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    rms.MAKTX = dataGridViewDetails.Rows[i].Cells["MAKTX"].Value.ToString();
                    rms.MATNR = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString();
                    rms.POSNR = dataGridViewDetails.Rows[i].Cells["POSNR"].Value.ToString();
                    rms.REALZFIMG = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value);
                    rms.SFIMG = Convert.ToSingle(dataGridViewDetails.Rows[i].Cells["SFIMG"].Value);
                    rms.VBELN = dataGridViewDetails.Rows[i].Cells["VBELN"].Value.ToString();
                    rms.KUNNR = dataGridViewDetails.Rows[i].Cells["KUNNR"].Value.ToString();
                    rms.NAME1 = dataGridViewDetails.Rows[i].Cells["NAME1"].Value.ToString();
                    rms.PWEIGHT = Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value);
                    Sdl_RawMaterialsSaleAdapter.AddSdl_RawMaterialsSale(rms);
                }
                rmst.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                rmst.HS_FLAG = "S";
                rmst.GROSS = Convert.ToSingle(textBoxGross.Text);
                rmst.NET = rmst.GROSS - rmst.TARE;
                rmst.BALANCE = Convert.ToSingle(diff);
                rmst.EXITWEIGHMAN = textBoxWeighMan.Text;
                Sdl_RawMaterialsSaleTitleAdapter.UpdateSdl_RawMaterialsSaleTitle(rmst);
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
                    double pweight = Convert.ToDouble(dataGridViewDetails.Rows[rowIndex].Cells["PWEIGHT"].Value);
                    string temp = dataGridViewDetails.Rows[rowIndex].Cells["REALZFIMG"].Value.ToString();
                    temp = TypeConverter.ToDBC(temp).Replace("。", ".");
                    dataGridViewDetails.Rows[rowIndex].Cells["REALZFIMG"].Value = temp;
                    if (!ValidateHelper.IsNumber(temp.TrimEnd('.')))
                    {
                        dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value = DBNull.Value;
                        MessageBox.Show(this, "实发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int realzfimg = Convert.ToInt32(temp);
                    double sfimg = pweight * realzfimg / 1000.0;
                    dataGridViewDetails.Rows[rowIndex].Cells["SFIMG"].Value = sfimg.ToString();
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
                if (DialogResult.Yes != MessageBox.Show(this, "确认空车出厂？", "史丹利地磅系统 - 原材料采购出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                rmst.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                rmst.HS_FLAG = "S";
                rmst.GROSS = Convert.ToSingle(textBoxGross.Text);
                rmst.NET = rmst.GROSS - rmst.TARE;
                rmst.BALANCE = Convert.ToSingle(diff);
                rmst.EXITWEIGHMAN = textBoxWeighMan.Text;
                rmst.EXITFLAG = true;
                Sdl_RawMaterialsSaleTitleAdapter.UpdateSdl_RawMaterialsSaleTitle(rmst);
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
