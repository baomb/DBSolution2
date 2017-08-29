using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;
using System.Data.SqlTypes;

namespace DBSolution
{
    public partial class RawMaterialsContractEnter : Form
    {
        bool stat = false;
        bool readPort = true;
        bool mode = true;
        string ebeln = string.Empty;
        string[] father = new string[3];
        DataSet ds = new DataSet();
        Sdl_RawMaterialsProcurementTitle rmpt = new Sdl_RawMaterialsProcurementTitle();
        SerialPortHelper s = null;

        public RawMaterialsContractEnter()
        {
            InitializeComponent();
            Common.PlayWelcome();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxGross.ReadOnly = false;
            }
            this.textBoxEnterTime.Format = DateTimePickerFormat.Custom;
            this.textBoxEnterTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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
                this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                this.textBoxEnterTime.Text = Common.GetServerDate2();
                this.textBoxPrompt.Text = this.labelTitle.Text;
                this.toolStripEdit.Enabled = false;
                this.timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxVBELN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ebeln = textBoxEBELN.Text;
                InitDetailsDataBind("");
            }
        }

        private void InitDetailsDataBind(string where)
        {
            try
            {
                if (textBoxEBELN.Text == string.Empty)
                {
                    return;
                }
                textBoxEBELN.Text = TypeConverter.ToDBC(textBoxEBELN.Text);
                ListDictionary la = new ListDictionary();
                la.Add("EBELN", textBoxEBELN.Text);
                la.Add("WERKS", textBoxFactory.Text);
                ListDictionary lt = new ListDictionary();
                lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,LIFNR,NAME1,MENGE,PTEXT");
                ListDictionary lr = new ListDictionary();
                ds = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_RC", la, lt, ref lr);

                ds.Tables[0].Columns.Add("DENGE");
                ds.Tables[0].Columns.Add("LFIMG");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["MENGE"].ToString() == "0")
                    {
                        ds.Tables[0].Rows[i].Delete();
                        i = 0;
                    }
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有此采购订单信息或此采购订单已收货完成", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SqlParameter[] sp = new SqlParameter[] {
                    new SqlParameter("@pstyp", SqlDbType.VarChar,20),
                    new SqlParameter("@vbeln", SqlDbType.VarChar,20),
                    new SqlParameter("@posnr", SqlDbType.VarChar,20)};
                    sp[0].Value = "H";
                    sp[1].Value = ds.Tables[0].Rows[i]["EBELN"].ToString();
                    sp[2].Value = ds.Tables[0].Rows[i]["EBELP"].ToString();
                    double denge = Convert.ToDouble(SQLServerHelper.GetSingle("select sum(LFIMG) from sdl_RawMaterialsProcurement as a inner join sdl_RawMaterialsProcurementTitle as b on a.timeflag = b.timeflag and a.vbeln = b.vbeln and b.exitflag = 0 where a.vbeln=@vbeln and a.posnr=@posnr and a.pstyp=@pstyp", sp));
                    denge = Convert.ToDouble(ds.Tables[0].Rows[i]["MENGE"]) - denge;
                    if (denge <= 0)
                    {
                        ds.Tables[0].Rows[i].Delete();
                        i--;
                        continue;
                    }
                    ds.Tables[0].Rows[i]["DENGE"] = denge;
                    try
                    {
                        Sdl_RawMaterialsProcurement rmp = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(textBoxEnterTime.Text, ds.Tables[0].Rows[i]["EBELN"].ToString(), ds.Tables[0].Rows[i]["EBELP"].ToString());
                        ds.Tables[0].Rows[i]["LFIMG"] = rmp.LFIMG;
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
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = ds.Tables[0];
                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private bool CheckTruckNum(string truckNum)
        {
            bool result = true;
            try
            {
                DataSet ds = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 采购订单", "TIMEFLAG as 进厂时间" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and TRUCKNUM = '" + truckNum + "'");
                if (rmpt.ENTERTIME == SqlDateTime.MinValue)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = false;
                    }
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][2].ToString() != rmpt.TIMEFLAG)
                    {
                        result = false;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
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
                if (DialogResult.Yes != MessageBox.Show(this, "请确认日期选择是否正确，是否继续？", "史丹利地磅系统 - 原材料采购入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (!ValidateControl())
                    return;
                if (!CheckTruckNum(textBoxCar.Text))
                {
                    MessageBox.Show(this, "此车牌号已经入厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Sdl_RawMaterialsProcurementTitle rmpt2 = new Sdl_RawMaterialsProcurementTitle();
                rmpt2.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                rmpt2.TIMEFLAG = textBoxEnterTime.Text;
                rmpt2.GROSS = Convert.ToSingle(textBoxGross.Text);
                rmpt2.HS_FLAG = "H";
                rmpt2.TRUCKNUM = textBoxCar.Text;
                rmpt2.VBELN = textBoxEBELN.Text;
                rmpt2.WEIGHMAN = textBoxWeighMan.Text;
                rmpt2.WERKS = textBoxFactory.Text;
                rmpt2.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                rmpt2.CONTRACT = "1";
                bool add = Sdl_RawMaterialsProcurementTitleAdapter.AddSdl_RawMaterialsProcurementTitle(rmpt2);
                if (!add)
                {
                    MessageBox.Show(this, "已存在此信息，如需修改请点击修改", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Sdl_RawMaterialsProcurement rmp = new Sdl_RawMaterialsProcurement();
                    rmp.TIMEFLAG = rmpt2.TIMEFLAG;
                    rmp.MATNR = ds.Tables[0].Rows[i]["MATNR"].ToString();
                    rmp.MAKTX = ds.Tables[0].Rows[i]["MAKTX"].ToString();
                    rmp.MCOD1 = ds.Tables[0].Rows[i]["NAME1"].ToString();
                    rmp.VBELN = ds.Tables[0].Rows[i]["EBELN"].ToString();
                    rmp.POSNR = ds.Tables[0].Rows[i]["EBELP"].ToString();
                    rmp.PSTYP = "H";
                    rmp.LFIMG = Convert.ToSingle(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                    if (checkBoxKG.Checked == true)
                    {
                        rmp.KG = "1";
                    }
                    else
                    {
                        rmp.KG = "0";
                    }
                    Sdl_RawMaterialsProcurementAdapter.AddSdl_RawMaterialsProcurement(rmp);
                }
                MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateControl()
        {
            if (ebeln != textBoxEBELN.Text || textBoxEBELN.Text != ds.Tables[0].Rows[0]["EBELN"].ToString())
            {
                MessageBox.Show(this, "抬头和行项目中采购订单号不一致", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxCar.Text == string.Empty)
            {
                MessageBox.Show(this, "请输入车牌号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidateHelper.IsTruckNum(textBoxCar.Text))
            {
                MessageBox.Show(this, "车牌号输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            bool result = true;
            bool isZero = true;
            double lfimg = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (dataGridViewDetails.Rows[i].Cells["LFIMG"].Value == null)
                {
                    MessageBox.Show(this, "请输入原发吨数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                lfimg += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                if (checkBoxKG.Checked == true)
                {
                    lfimg = lfimg / 1000;
                }
                if (dataGridViewDetails.Rows[i].Cells["LFIMG"].Value.ToString() != "0")
                {
                    isZero = false;
                }
                if (Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["DENGE"].Value) <= 0)
                {
                    MessageBox.Show(this, "采购订单行项目可收货数量为负数,请联系供应科修改采购订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["DENGE"].Value) < Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value) && mode)
                {
                    result = false;
                }
            }
            if (isZero)
            {
                MessageBox.Show(this, "原发吨数不能为零", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!result)
            {
                MessageBox.Show(this, "原发吨数大于可收货数量,请联系供应科修改订单或修改原发吨数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (lfimg >= Convert.ToDouble(textBoxGross.Text))
            {
                MessageBox.Show(this, "原发吨数必须小于毛重", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                float gross = Convert.ToSingle(textBoxGross.Text);
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请填写正确的毛重信息", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool CorrectMistake()
        {
            dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
            int count = dataGridViewDetails.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show(this, "没有采购订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                string temp = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    if (dataGridViewDetails.Rows[i].Cells[9].Value != null)
                    {
                        temp = dataGridViewDetails.Rows[i].Cells[9].Value.ToString();
                        temp = TypeConverter.ToDBC(temp).Replace("。", ".");
                        dataGridViewDetails.Rows[i].Cells[9].Value = Convert.ToDouble(temp);
                    }
                }
                temp = textBoxCar.Text.ToUpper();
                textBoxCar.Text = TypeConverter.ToDBC(temp).Replace("。", ".");
                temp = textBoxEBELN.Text;
                textBoxEBELN.Text = TypeConverter.ToDBC(temp).Replace("。", ".");
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请检查输入应为数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认修改订单？", "史丹利地磅系统 - 原材料采购入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                mode = false;
                if (!CorrectMistake())
                {
                    return;
                }
                if (!ValidateControl())
                    return;
                if (rmpt == null)
                {
                    MessageBox.Show(this, "没有此车辆信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!CheckTruckNum(textBoxCar.Text))
                {
                    MessageBox.Show(this, "此车牌号已经入厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Sdl_RawMaterialsProcurementAdapter.DeleteSdl_RawMaterialsProcurement(rmpt.TIMEFLAG, rmpt.VBELN);
                string truckNum = rmpt.TRUCKNUM;
                string vbeln = rmpt.VBELN;
                rmpt.TRUCKNUM = textBoxCar.Text;
                rmpt.VBELN = textBoxEBELN.Text;
                rmpt.WEIGHMAN = textBoxWeighMan.Text;
                rmpt.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                Sdl_RawMaterialsProcurementTitleAdapter.UpdateSdl_RawMaterialsProcurementTitle(rmpt, vbeln, truckNum);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Sdl_RawMaterialsProcurement rmp = new Sdl_RawMaterialsProcurement();
                    rmp.TIMEFLAG = rmpt.TIMEFLAG;
                    rmp.MATNR = ds.Tables[0].Rows[i]["MATNR"].ToString();
                    rmp.MAKTX = ds.Tables[0].Rows[i]["MAKTX"].ToString();
                    rmp.MCOD1 = ds.Tables[0].Rows[i]["NAME1"].ToString();
                    rmp.VBELN = ds.Tables[0].Rows[i]["EBELN"].ToString();
                    rmp.POSNR = ds.Tables[0].Rows[i]["EBELP"].ToString();
                    rmp.PSTYP = "H";
                    rmp.LFIMG = Convert.ToSingle(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
                    if (checkBoxKG.Checked == true)
                    {
                        rmp.KG = "1";
                    }
                    else
                    {
                        rmp.KG = "0";
                    }
                    Sdl_RawMaterialsProcurementAdapter.AddSdl_RawMaterialsProcurement(rmp);
                }
                mode = true;
                 MessageBox.Show(this, "修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.textBoxEBELN.Text = father[1].ToString();
                this.textBoxEnterTime.Text = father[2].ToString();
                rmpt = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                this.textBoxGross.Text = rmpt.GROSS.ToString();
                stat = true;
                timer.Stop();
                InitDetailsDataBind("");
                this.toolStripEdit.Enabled = true;
                this.toolStripButtonSave.Enabled = false;
                textBoxEnterTime.Enabled = false;
                ebeln = textBoxEBELN.Text;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!readPort || stat)
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

        private void textBoxCar_TextChanged(object sender, EventArgs e)
        {
            textBoxCar.Text = textBoxCar.Text.ToUpper();
            textBoxCar.SelectionStart = textBoxCar.Text.Length;
        }

        private void textBoxEnterTime_ValueChanged(object sender, EventArgs e)
        {
            this.textBoxEnterTime.Format = DateTimePickerFormat.Custom;
            this.textBoxEnterTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
