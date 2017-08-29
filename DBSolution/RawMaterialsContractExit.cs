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
    public partial class RawMaterialsContractExit : Form
    {
        bool readPort = true;
        decimal net2 = 0;
        decimal discount = 0;
        string[] father = new string[3];
        string message = string.Empty;
        DataSet ds = new DataSet();
        Sdl_RawMaterialsProcurementTitle rmpt = new Sdl_RawMaterialsProcurementTitle();
        SerialPortHelper s = null;

        public RawMaterialsContractExit()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxTare.ReadOnly = false;
            }

            this.textBoxExitTime.Format = DateTimePickerFormat.Custom;
            this.textBoxExitTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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
                Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                readPort = Common.GetReadPortFlag();
                s = new SerialPortHelper(ref serialPort);
                this.textBoxFactory.Text = sysSetting.WERKS;
                bool tray = Sdl_SysSettingAdapter.GetSdl_Tray(sysSetting.WERKS);
                if (tray == true)
                
                {
                    this.comboBoxStandardWeight.Visible = true;
                    this.textBoxQuantity.Visible = true;
                    this.labelTrayWeight.Visible = true;
                    this.labelTrayQuantity.Visible = true;
                }
                if (sysSetting.WERKS == "2002" || sysSetting.WERKS == "2003")
                {
                    this.txtWagonNum.Visible = false;
                    this.label6.Visible = false;
                }

                this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                this.textBoxExitTime.Text = Common.GetServerDate();
                this.textBoxPrompt.Text = this.labelTitle.Text;
                DataTable dt = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
                Sdl_Factory factory = Sdl_FactoryAdapter.GetSdl_Factory(sysSetting.WERKS);
                dt = Sdl_StationAdapter.GetSdl_StationDataSet("where bukrs = " + factory.BUKRS, "STATION").Tables[0];
                this.comboBoxABLAD.DataSource = dt;
                this.comboBoxABLAD.DisplayMember = "STATION";
                this.comboBoxABLAD.ValueMember = "STATION";
                this.comboBoxABLAD.SelectedIndex = -1;
                DataTable ds = Sdl_SweightAdapter.GetSdl_SweightDataSet("").Tables[0];
                this.comboBoxStandardWeight.DataSource = ds;
                this.comboBoxStandardWeight.DisplayMember = "SWEIGHT";
                this.comboBoxStandardWeight.ValueMember = "SWEIGHT";
                this.comboBoxStandardWeight.SelectedIndex = -1;
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
            TruckSelect ts = new TruckSelect(father, "RawMaterialsContract");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                this.textBoxCar.Text = father[0].ToString();
                this.textBoxVBELN.Text = father[1].ToString();
                rmpt = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                if (!CheckDB())
                {
                    return;
                }
                this.textBoxGross.Text = rmpt.GROSS.ToString();
                this.textBoxDBNum.Text = rmpt.DBNUM;
                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
                InitDetailsDataBind("");
            }
        }

        private void InitDetailsDataBind(string where)
        {
            ListDictionary la = new ListDictionary();
            la.Add("EBELN", textBoxVBELN.Text);
            la.Add("WERKS", textBoxFactory.Text);
            ListDictionary lt = new ListDictionary();
            lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,LIFNR,NAME1,MENGE,PTEXT");
            ListDictionary lr = new ListDictionary();
            ds = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_RC", la, lt, ref lr);
            ds.Tables[0].Columns.Add("ZFIMG");
            ds.Tables[0].Columns.Add("LGORT");
            ds.Tables[0].Columns.Add("BKTXT");
            ds.Tables[0].Columns.Add("LFIMG");
            ds.Tables[0].Columns.Add("PWEIGHT");
            string matnr = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                try
                {
                    Sdl_RawMaterialsProcurement rmp = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(father[2].ToString(), ds.Tables[0].Rows[i]["EBELN"].ToString(), ds.Tables[0].Rows[i]["EBELP"].ToString());
                    if (rmp.LFIMG == 0)
                    {
                        ds.Tables[0].Rows[i].Delete();
                        --i;
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["LFIMG"] = rmp.LFIMG;
                    }
                    if (i == 0)
                    {
                        matnr = ds.Tables[0].Rows[0]["MATNR"].ToString();
                    }
                    if (rmp.KG == "1")
                    {
                        checkBoxKG.Checked = true;
                    }
                    else
                    {
                        checkBoxKG.Checked = false;
                    }
                }
                catch
                {
                }
            }

            DataTable dtLGORT = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where werks='" + textBoxFactory.Text + "' and ( lgort like '3%' or lgort like '4%' or lgort like '1%' ) order by lgort desc").Tables[0];
            DataGridViewComboBoxColumn cbcLGORT = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[17];
            cbcLGORT.DataPropertyName = "lgort";
            cbcLGORT.DataSource = dtLGORT;
            cbcLGORT.ValueMember = "lgort";
            cbcLGORT.DisplayMember = "lgobe";
            cbcLGORT.Name = "LGORT";
            cbcLGORT.HeaderText = "收货仓库";

            DataTable dtPackWeight = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
            DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[11];
            cbcpw.DataPropertyName = "pweight";
            cbcpw.DataSource = dtPackWeight;
            cbcpw.ValueMember = "包重";
            cbcpw.DisplayMember = "说明";
            cbcpw.Name = "PWEIGHT";
            cbcpw.HeaderText = "包重";

            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = ds.Tables[0];

            //读取扣杂
            if (string.IsNullOrEmpty(matnr))
                return;
            la = new ListDictionary();
            la.Add("I_MATNR", matnr);
            lt = new ListDictionary();
            lr = new ListDictionary();
            lr.Add("E_DISCOUNT", discount);
            SAPHelper.InvokSAPFun("Z_SDL_MATERIAL_DISCOUNT", la, ref lr);
            if (lr != null && lr["E_DISCOUNT"] != null)
            {
                if (lr["E_DISCOUNT"].ToString() == "X")
                {
                    MessageBox.Show(this, "该物料没有维护产品层次，请联系SAP相关人员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    discount = Convert.ToDecimal(lr["E_DISCOUNT"]);
                }
            }
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
                    if ((!(j == 13 || j == 18)) && (dataGridViewDetails.Rows[i].Cells[j].Value == DBNull.Value || dataGridViewDetails.Rows[i].Cells[j].Value == null))
                    {
                        MessageBox.Show(this, "请填写所有信息", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (!ValidateHelper.IsNumber(dataGridViewDetails.Rows[i].Cells[13].Value.ToString()))
                    {
                        MessageBox.Show(this, "原发件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    dfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells[13].Value);
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
                    if (!ValidateHelper.IsNumber(dataGridViewDetails.Rows[i].Cells[14].Value.ToString()))
                    {
                        MessageBox.Show(this, "实收件数必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    dfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells[14].Value);
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
                    if (!ValidateHelper.IsNumberSign(dataGridViewDetails.Rows[i].Cells[16].Value.ToString()))
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
                double senge = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                lfimg = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                int zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value);
                int rowreal = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value);
                int pweight = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value);
                if (senge == 0)
                {
                    MessageBox.Show(this, "实收吨数不能为零，如果没有行项目收货，请删除行项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                realzfimg += Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value);
                dfimg += Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["DFIMG"].Value);
                for (int j = i + 1; j < dataGridViewDetails.Rows.Count; j++)
                {
                    if (dataGridViewDetails.Rows[i].Cells["EBELP"].Value == dataGridViewDetails.Rows[j].Cells["EBELP"].Value)
                    {
                        realzfimg += Convert.ToInt32(dataGridViewDetails.Rows[j].Cells["REALZFIMG"].Value);
                        dfimg += Convert.ToInt32(dataGridViewDetails.Rows[j].Cells["DFIMG"].Value);
                        senge += Convert.ToDouble(dataGridViewDetails.Rows[j].Cells["SENGE"].Value);
                        if (dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value.ToString() != dataGridViewDetails.Rows[j].Cells["PWEIGHT"].Value.ToString())
                        {
                            zfimg += Convert.ToInt32(dataGridViewDetails.Rows[j].Cells["ZFIMG"].Value);
                        }
                        else
                        {
                            zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value);
                        }
                        i++;
                    }
                }
                if ((dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value != DBNull.Value) && (realzfimg - dfimg) != zfimg)
                {
                    MessageBox.Show(this, "原发件数、实收件数与涨亏件不符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            double senge2 = 0;
            decimal lfimg2 = 0;
            string temp = string.Empty;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                if (dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString() != temp)
                {
                    senge2 = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    lfimg2 += Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                    temp = dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString();
                }
                else
                    if (dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString() == temp && i > 0 && dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value.ToString() != dataGridViewDetails.Rows[i - 1].Cells["PWEIGHT"].Value.ToString())
                    {
                        senge2 = Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                        lfimg2 += Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                        temp = dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString();
                    }
                    else
                    {
                        senge2 += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    } 
                if (Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["MENGE"].Value) < senge2)
                {
                    MessageBox.Show(this, "实收吨数大于可收货数量,请联系供应部门修改订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (i == 0 && dataGridViewDetails.Rows.Count > 1 
                    && dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value.ToString() != dataGridViewDetails.Rows[i + 1].Cells["PWEIGHT"].Value.ToString())
                {
                    for (int j = 1; j < dataGridViewDetails.Rows.Count; j++)
                    {
                        net2 -= decimal.Parse(dataGridViewDetails.Rows[j].Cells["SENGE"].Value.ToString());
                    }
                }
                if ( i > 0)
                {
                    if (dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value.ToString() != dataGridViewDetails.Rows[i - 1].Cells["PWEIGHT"].Value.ToString())
                        net2 = decimal.Parse(senge2.ToString());
                }
                dataGridViewDetails.Rows[i].Cells["SGTXT"].Value =
                    dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value + "/" +
                    dataGridViewDetails.Rows[i].Cells["DFIMG"].Value + "/" +
                    dataGridViewDetails.Rows[i].Cells["LFIMG"].Value + "/" +
                    net2.ToString() + "/" +
                    txtCYNum.Text.Trim() + "/" +
                    wagon;
                if (StringUtil.StringLength(dataGridViewDetails.Rows[i].Cells["BKTXT"].Value.ToString()) > 25)
                {
                    MessageBox.Show(this, "品牌产地长度超出范围", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (StringUtil.StringLength(dataGridViewDetails.Rows[i].Cells["SGTXT"].Value.ToString()) > 50)
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
            bool hasError = false;
            string idatum = textBoxExitTime.Text.ToString().Substring(0, 10).Replace("-", "");
            try
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
                if (DialogResult.Yes != MessageBox.Show(this, "请确认日期选择是否正确，是否继续？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (!ValidateControl())
                {
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                DataTable dt = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");

                DataTable dtDistinct = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "EBELN", "EBELP", "BKTXT", "LGORT", "PWEIGHT" });
                if (dt.Rows.Count != dtDistinct.Rows.Count)
                {
                    MessageBox.Show(this, "行项目存在相同的数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dtLfimg = new DataSetHelper().SelectDistinct("dtLFIMG", dt, new string[] { "EBELN", "LFIMG","PWEIGHT" });
                if (dtLfimg.Rows.Count > 1)
                {
                    DataTable dtPweight = new DataSetHelper().SelectDistinct("dtPweight", dt, new string[] { "EBELN", "PWEIGHT" });
                    if (dtPweight.Rows.Count <= 1)
                    {
                        MessageBox.Show(this, "不同的行项目，原发吨数必须一致！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                dt.Columns.Add("WERKS");
                dt.Columns.Add("SENGE");
                dt.Columns.Add("FRBNR");
                dt.Columns.Add("ABLAD");
                dt.Columns.Add("SGTXT");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["WERKS"] = textBoxFactory.Text;
                    dt.Rows[i]["LGORT"] = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    dt.Rows[i]["SENGE"] = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                    dt.Rows[i]["BKTXT"] = dataGridViewDetails.Rows[i].Cells["BKTXT"].Value.ToString();
                    dt.Rows[i]["FRBNR"] = textBoxCar.Text;
                    dt.Rows[i]["ABLAD"] = comboBoxABLAD.Text;
                    dt.Rows[i]["SGTXT"] = dataGridViewDetails.Rows[i].Cells["SGTXT"].Value.ToString();
                }
                dt.Columns.Remove("ZFIMG");
                dt.Columns.Remove("LFIMG");
                dt.Columns.Remove("PWEIGHT");
                //dt.Columns.Remove("WAGON");
                ListDictionary ltPara = new ListDictionary();
                
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dt);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();
                DataSet dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_GZ_CHECK", ltPara, ltParaTb, lt, ref lr);

                if (dtInfo.Tables[0].Rows[0][0].ToString() != "检查成功")
                {
                    for (int i = 0; i < dtInfo.Tables[0].Rows.Count; i++)
                    {
                        MessageBox.Show(this, dtInfo.Tables[0].Rows[i][0].ToString(), "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                ltPara.Add("IDATUM", idatum);
                dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_GZ", ltPara, ltParaTb, lt, ref lr);
                string error = string.Empty;
                for (int i = 0; i < dtInfo.Tables[0].Rows.Count; i++)
                {
                    if (dtInfo.Tables[0].Rows[i][0].ToString().StartsWith("收货物料凭证"))
                    {
                        message += dtInfo.Tables[0].Rows[i][0].ToString() + "\n";
                    }
                    else
                    {
                        error += dtInfo.Tables[0].Rows[i][0].ToString() + "\n";
                    }
                }
                if (error != string.Empty)
                {
                    MessageBox.Show(this, error, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Sdl_RawMaterialsProcurementAdapter.DeleteSdl_RawMaterialsProcurement(rmpt.TIMEFLAG, rmpt.VBELN);
                Sdl_RawMaterialsProcurement rmp = new Sdl_RawMaterialsProcurement();
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    rmp.TIMEFLAG = rmpt.TIMEFLAG;
                    rmp.BKTXT = dataGridViewDetails.Rows[i].Cells["BKTXT"].Value.ToString();
                    rmp.DFIMG = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["DFIMG"].Value);
                    rmp.LFIMG = Convert.ToSingle(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                    rmp.LGORT = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    rmp.MAKTX = dataGridViewDetails.Rows[i].Cells["MAKTX"].Value.ToString();
                    rmp.MATNR = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString();
                    rmp.POSNR = dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString();
                    rmp.PSTYP = dataGridViewDetails.Rows[i].Cells["PTEXT"].Value.ToString();
                    rmp.REALZFIMG = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value);
                    rmp.SFIMG = Convert.ToSingle(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    rmp.VBELN = dataGridViewDetails.Rows[i].Cells["EBELN"].Value.ToString();
                    rmp.LIFNR = dataGridViewDetails.Rows[i].Cells["LIFNR"].Value.ToString();
                    rmp.MCOD1 = dataGridViewDetails.Rows[i].Cells["NAME1"].Value.ToString();
                    rmp.WAGON = txtWagon.Text.Trim();
                    rmp.SGTXT = dataGridViewDetails.Rows[i].Cells["SGTXT"].Value.ToString();
                    rmp.NKEY = i + 1;
                    if (checkBoxKG.Checked == true)
                    {
                        rmp.KG = "1";
                    }
                    else
                    {
                        rmp.KG = "0";
                    }
                    
                    if (!(dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value == DBNull.Value || dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value == null))
                    {
                        rmp.ZFIMG = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value);
                    }
                    rmp.PWEIGHT = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value);
                    Sdl_RawMaterialsProcurementAdapter.AddSdl_RawMaterialsProcurement(rmp);
                }
                rmpt.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                rmpt.HS_FLAG = "S";
                rmpt.TARE = Convert.ToSingle(textBoxTare.Text);
                rmpt.NET = Convert.ToSingle(textBoxNetMinus.Text);
                rmpt.EXITWEIGHMAN = textBoxWeighMan.Text;
                rmpt.ABLAD = comboBoxABLAD.Text;
                rmpt.BALANCE = Convert.ToSingle(textBoxDiff.Text);
                rmpt.WAGON = txtWagon.Text.Trim();
                rmpt.WAGONNUM = txtWagonNum.Text.Trim();
                rmpt.BFIMG = textBfimg.Text.Trim();
                rmpt.FREIGHT = textFreight.Text.Trim();
                rmpt.CYNUM = Convert.ToSingle(txtCYNum.Text.Trim());
                if (ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text))
                {
                    rmpt.TRAYWEIGHT = Convert.ToInt16(comboBoxStandardWeight.Text);
                }
                if (ValidateHelper.IsNumber(this.textBoxQuantity.Text))
                {
                    rmpt.TRAYQUANTITY = Convert.ToInt16(textBoxQuantity.Text);
                }
                Sdl_RawMaterialsProcurementTitleAdapter.UpdateSdl_RawMaterialsProcurementTitle(rmpt, rmpt.VBELN, rmpt.TRUCKNUM);
                Sdl_TruckWeight tw = new Sdl_TruckWeight();
                tw.ENTERTIME = rmpt.ENTERTIME;
                tw.TARE = rmpt.TARE;
                tw.TIMEFLAG = rmpt.TIMEFLAG;
                tw.TRUCKNUM = rmpt.TRUCKNUM;
                tw.WERKS = rmpt.WERKS;
                Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                MessageBox.Show(this, message, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //是否启用打印功能
                if (MessageBox.Show("是否打印原料过磅单？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveAndPrint(rmpt.TRUCKNUM, rmpt.TIMEFLAG, rmpt.VBELN);
                }
                Common.PlayGoodBye();
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "SAP过账成功，地磅数据保存失败，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dr["EBELN"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                dr["EBELP"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString();
                dr["PTEXT"] = dataGridViewDetails.Rows[rowIndex].Cells["PTEXT"].Value.ToString();
                dr["ZFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["ZFIMG"].Value.ToString();
                dr["LIFNR"] = dataGridViewDetails.Rows[rowIndex].Cells["LIFNR"].Value.ToString();
                dr["NAME1"] = dataGridViewDetails.Rows[rowIndex].Cells["NAME1"].Value.ToString();
                dr["LFIMG"] = dataGridViewDetails.Rows[rowIndex].Cells["LFIMG"].Value.ToString();
                dr["BKTXT"] = dataGridViewDetails.Rows[rowIndex].Cells["BKTXT"].Value.ToString();
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

        private void dataGridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if ((colIndex == 11 || colIndex == 12 || colIndex == 13 || colIndex == 14) && rowIndex != -1)
            {
                try
                {
                    double senge = 0;
                    int zfimg = 0;
                    int pweight = Convert.ToInt32(dataGridViewDetails.Rows[rowIndex].Cells["PWEIGHT"].Value);
                    double lfimg = Convert.ToDouble(dataGridViewDetails.Rows[rowIndex].Cells["LFIMG"].Value);
                    if (dataGridViewDetails.Rows[rowIndex].Cells["ZFIMG"].Value.ToString() == "")
                    {
                        if (checkBoxKG.Checked == true)
                        {
                            zfimg = Convert.ToInt32(lfimg / pweight);
                        }
                        else
                        {
                           zfimg = Convert.ToInt32(lfimg * 1000 / pweight);
                        }
                        
                        dataGridViewDetails.Rows[rowIndex].Cells["ZFIMG"].Value = zfimg.ToString();
                    }
                    string temp = dataGridViewDetails.Rows[rowIndex].Cells["REALZFIMG"].Value.ToString();
                    if (!ValidateHelper.IsNumber(temp.TrimEnd('.')))
                    {
                        dataGridViewDetails.Rows[rowIndex].Cells["SENGE"].Value = DBNull.Value;
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
                    
                    dataGridViewDetails.Rows[rowIndex].Cells["SENGE"].Value = senge.ToString();
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
                Sdl_RawMaterialsProcurementAdapter.DeleteSdl_RawMaterialsProcurement(rmpt.TIMEFLAG, rmpt.VBELN);
                rmpt.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                rmpt.HS_FLAG = "S";
                rmpt.TARE = Convert.ToSingle(textBoxTare.Text);
                rmpt.NET = rmpt.GROSS - rmpt.TARE;
                rmpt.BALANCE = Convert.ToSingle(diff);
                rmpt.EXITWEIGHMAN = textBoxWeighMan.Text;
                rmpt.EXITFLAG = true;
                rmpt.WAGON = txtWagon.Text.Trim();
                rmpt.BFIMG = textBfimg.Text.Trim();
                rmpt.WAGONNUM = txtWagonNum.Text.Trim();
                rmpt.FREIGHT = textFreight.Text.Trim();
                rmpt.CYNUM = Convert.ToSingle(txtCYNum.Text.Trim());
                
                Sdl_RawMaterialsProcurementTitleAdapter.UpdateSdl_RawMaterialsProcurementTitle(rmpt, rmpt.VBELN, rmpt.TRUCKNUM);
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
                    if (dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString() != temp)
                    {
                        total += (dataGridViewDetails.Rows[i].Cells["LFIMG"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                        temp = dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString();
                    }
                    if (dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString() == temp && i > 0 && dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value.ToString() != dataGridViewDetails.Rows[i - 1].Cells["PWEIGHT"].Value.ToString())
                    {
                        total += (dataGridViewDetails.Rows[i].Cells["LFIMG"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                        temp = dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString();
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
            string exitDB = rmpt.DBNUM;
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
                dr["VBELN"] = textBoxVBELN.Text.ToString();
                dr["ExitTime"] = textBoxExitTime.Text.ToString();
                dr["EnterTime"] = rmpt.ENTERTIME;
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
                dt.Columns.Add("REALZFIMG");
                dt.Columns.Add("DFIMG");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if ( i > 0 &&
                    //    dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value.ToString() != dataGridViewDetails.Rows[i-1].Cells["PWEIGHT"].Value.ToString())
                    //{
                    //    Realzfimg = Realzfimg + decimal.Parse(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value.ToString());
                    //}
                    //else
                    //{
                    Realzfimg = decimal.Parse(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value.ToString());
                    //}
                    dt.Rows[i]["REALZFIMG"] = Realzfimg.ToString();
                    dt.Rows[i]["LGORT"] = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    dt.Rows[i]["DFIMG"] = dataGridViewDetails.Rows[i].Cells["DFIMG"].Value.ToString();
                    Dfimg += dt.Rows[i]["DFIMG"].ToString();
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

        private void textBoxExitTime_ValueChanged(object sender, EventArgs e)
        {
            this.textBoxExitTime.Format = DateTimePickerFormat.Custom;
            this.textBoxExitTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
