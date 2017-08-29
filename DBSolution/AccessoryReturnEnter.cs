using System;
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
using SdlDB.Utility;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class AccessoryReturnEnter : Form
    {
        private DataSet dsSAP = new DataSet();
        private string[] father = new string[] { "", "", "" };
        private string selVbeln = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        public AccessoryReturnEnter()
        {
            InitializeComponent();
            Common.PlayWelcome();
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
                textBoxTare.ReadOnly = true;
            }
            else
            {
                textBoxTare.ReadOnly = false;
            }

            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxEnterWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxEnterTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("配件退货入厂");
            this.timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-配件退货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void InitSelectDataBind()
        {
            try
            {
                ListDictionary la = new ListDictionary();
                la.Add("EBELN", textBoxEbeln.Text.Trim());
                la.Add("WERKS", textBoxFactory.Text.Trim());
                ListDictionary lt = new ListDictionary();
                lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,LIFNR,NAME1,MENGE");
                ListDictionary lr = new ListDictionary();
                dsSAP.Clear();
                dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_RC_RE", la, lt, ref lr);
                DataTable dtS = dsSAP.Tables[0];

                dtS.Columns.Add("SENGE");
                dtS.Columns.Add("LGORT");
                dtS.Columns.Add("WERKS");
                dtS.Columns.Add("OVERNUM");

                for (int i = 0; i < dtS.Rows.Count; i++)
                {
                    double overNum = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetailOverNum(" WHERE EBELN = '" + dtS.Rows[i]["EBELN"].ToString() + "' and EBELP='" + dtS.Rows[i]["EBELP"].ToString() + "' ");
                    dtS.Rows[i]["OVERNUM"] = overNum.ToString();
                }

                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dtS;

                if (dtS.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有该采购退货单信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-配件退货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (father[0].ToString() != "")
                {
                    MessageBox.Show(this, "编辑状态不能入厂操作，请重新进入该界面！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!ValidateHelper.IsVehiclenumber(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号格式不对", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有退货订单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxEbeln.Text.Trim() != selVbeln)
                {
                    MessageBox.Show(this, "输入的退货订单已做修改，请重新调用订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入车牌号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show("皮重数据应为数值！");
                    return;
                }

                DataTable dtenter = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                if (dtenter.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_AccessoryReturnTitle model = new Sdl_AccessoryReturnTitle();
                        model.TRUCKNUM = textBoxCar.Text;
                        model.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                        model.TIMEFLAG = textBoxEnterTime.Text;
                        model.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                        model.HSFLAG = "H";
                        model.TARE = Double.Parse(textBoxTare.Text.Trim());
                        model.ENTERWEIGHMAN = textBoxEnterWeighMan.Text;
                        model.WERKS = textBoxFactory.Text;
                        model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                        Sdl_AccessoryReturnTitleAdapter.AddSdl_AccessoryReturnTitle(model);
                    }
                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                    tw.TARE = float.Parse(textBoxTare.Text.Trim());
                    tw.TIMEFLAG = textBoxEnterTime.Text;
                    tw.TRUCKNUM = textBoxCar.Text;
                    tw.WERKS = textBoxFactory.Text;
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindEnterData()
        {
            Sdl_AccessoryReturnTitle title = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(textBoxCar.Text, father[2].ToString());
            if (title != null)
            {
                textBoxTare.Text = title.TARE.ToString();
            }
        }

        private void textBoxVbeln_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxEbeln.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入采购订单号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InitSelectDataBind();
                selVbeln = textBoxEbeln.Text;
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-配件采购入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (father[0].ToString() == "")
                {
                    MessageBox.Show(this, "请选择要编辑的采购入厂信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入车牌号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxEbeln.Text.Trim() != selVbeln)
                {
                    MessageBox.Show(this, "输入的退货订单已做修改，请重新调用退货订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (father[0].ToString() != textBoxCar.Text)
                {
                    DataTable dtenter = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                try
                {
                    Sdl_AccessoryReturnTitle model = new Sdl_AccessoryReturnTitle();
                    model = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                    if (model == null)
                    {
                        MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (model.HSFLAG == "S")
                    {
                        MessageBox.Show(this, "该车已经出厂，不能再次收货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    model.TRUCKNUM = textBoxCar.Text;
                    model.EBELN = textBoxEbeln.Text;
                    model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    Sdl_AccessoryReturnTitleAdapter.UpdateSdl_AccessoryReturnTitleByTimeFlag(model);

                    MessageBox.Show(this, "修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!ValidateHelper.IsVehiclenumber(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号格式不对", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InitSelectDataBind();
                BindEnterData();
                selVbeln = textBoxEbeln.Text;
            }
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "AccessoryReturn");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                textBoxCar.Text = father[0].ToString();
                textBoxEbeln.Text = father[1].ToString();

                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                timer.Stop();
                InitSelectDataBind();
                BindEnterData();
                textBoxTare.ReadOnly = true;
                selVbeln = textBoxEbeln.Text;
                if (textBoxCar.Text.Trim() != "")
                {
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonSave.Enabled = false;
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
    }
}
