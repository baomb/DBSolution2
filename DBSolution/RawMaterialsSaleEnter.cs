using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using System.Data.SqlClient;
using SdlDB.Utility;
using System.Data.SqlTypes;

namespace DBSolution
{
    public partial class RawMaterialsSaleEnter : Form
    {
        bool stat = false;
        bool readPort = true;
        string vbeln = string.Empty;
        string[] father = new string[3];
        DataSet ds = new DataSet();
        Sdl_RawMaterialsSaleTitle rmst = new Sdl_RawMaterialsSaleTitle();
        SerialPortHelper s = null;
        Sdl_SysSetting sysSetting = null;
        string werks_temp = string.Empty;

        public RawMaterialsSaleEnter()
        {
            InitializeComponent();
            Common.PlayWelcome();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxTare.ReadOnly = false;
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
                this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                this.textBoxEnterTime.Text = Common.GetServerDate();
                Sdl_Manual manual = Sdl_ManualAdapter.GetSdl_Manual(this.labelTitle.Text);
                this.textBoxPrompt.Text = manual.MANUAL;
                this.toolStripButtonModify.Enabled = false;
                this.timer.Start();
                if (sysSetting.WERKS == "2003" || sysSetting.WERKS == "2002")
                {
                    checkBoxType.Visible = true;
                } 
                else
                {
                    checkBoxType.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "史丹利地磅系统 - 原材料销售入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!ValidateControl())
                    return;
                if (!CheckTruckNum(textBoxCar.Text))
                {
                    MessageBox.Show(this, "此车牌号已经入厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Sdl_RawMaterialsSaleTitle rmst = new Sdl_RawMaterialsSaleTitle();
                rmst.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                rmst.TIMEFLAG = textBoxEnterTime.Text;
                rmst.TARE = Convert.ToSingle(textBoxTare.Text);
                rmst.HS_FLAG = "H";
                rmst.TRUCKNUM = textBoxCar.Text;
                rmst.VBELN = textBoxVBELN.Text;
                rmst.WEIGHMAN = textBoxWeighMan.Text;
                rmst.WERKS = textBoxFactory.Text;
                rmst.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;

                Sdl_RawMaterialsSaleTitleAdapter.AddSdl_RawMaterialsSaleTitle(rmst);
                Sdl_TruckWeight tw = new Sdl_TruckWeight();
                tw.ENTERTIME = rmst.ENTERTIME;
                tw.TARE = rmst.TARE;
                tw.TIMEFLAG = rmst.TIMEFLAG;
                tw.TRUCKNUM = rmst.TRUCKNUM;
                tw.WERKS = rmst.WERKS;
                Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckTruckNum(string truckNum)
        {
            bool result = true;
            DataSet ds = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 采购订单", "TIMEFLAG as 进厂时间" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and TRUCKNUM = '" + truckNum + "'");
            if (rmst.ENTERTIME == SqlDateTime.MinValue)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = false;
                }
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][2].ToString() != rmst.TIMEFLAG)
                {
                    result = false;
                }
            }
            return result;
        }

        private bool ValidateControl()
        {
            int count = dataGridViewDetails.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show(this, "没有销售订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (vbeln != textBoxVBELN.Text || textBoxVBELN.Text != ds.Tables[0].Rows[0]["VBELN"].ToString())
            {
                MessageBox.Show(this, "抬头和行项目中的销售订单号不一致", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (ValidateHelper.IsDecimal(textBoxTare.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(this, "皮重不是数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                this.textBoxEnterTime.Text = father[2].ToString();
                rmst = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                this.textBoxTare.Text = rmst.TARE.ToString();
                stat = true;
                timer.Stop();
                InitDetailsDataBind("");
                this.toolStripButtonModify.Enabled = true;
                this.toolStripButtonSave.Enabled = false;
                vbeln = textBoxVBELN.Text;
            }
        }

        private void toolStripButtonModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "确认修改订单？", "史丹利地磅系统 - 原材料采购入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (!ValidateControl())
                    return;
                if (rmst == null)
                {
                    MessageBox.Show(this, "没有此车辆信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!CheckTruckNum(textBoxCar.Text))
                {
                    MessageBox.Show(this, "此车牌号已经入厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                rmst.TRUCKNUM = textBoxCar.Text;
                rmst.VBELN = textBoxVBELN.Text;
                rmst.WEIGHMAN = textBoxWeighMan.Text;
                rmst.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                Sdl_RawMaterialsSaleTitleAdapter.UpdateSdl_RawMaterialsSaleTitle(rmst);
                MessageBox.Show(this, "修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxVBELN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vbeln = textBoxVBELN.Text;
                InitDetailsDataBind("");
            }
        }

        private void InitDetailsDataBind(string where)
        {
            try
            {
                if (textBoxVBELN.Text == string.Empty)
                {
                    MessageBox.Show(this, "销售订单未填写", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ListDictionary la = new ListDictionary();
                la.Add("VBELN", textBoxVBELN.Text);
                la.Add("WERKS", werks_temp); ;
               
                ListDictionary lt = new ListDictionary();
                lt.Add("ZLIPS", "VBELN,POSNR,KUNNR,NAME1,MATNR,MAKTX,LFIMG");
                ListDictionary lr = new ListDictionary();
                ds = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_SALE_RC", la, lt, ref lr);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["LFIMG"].ToString() == "0")
                    {
                        ds.Tables[0].Rows[i].Delete();
                        --i;
                    }
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有此销售订单信息或此销售订单已发货完成", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!readPort || stat)
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
