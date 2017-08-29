using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;
using SdlDB.Utility;
using System.Threading;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class AllotEnterTranferOut : Form
    {
        private DataSet dsSAP = new DataSet();
        private string[] father = new string[] { "", "", "" };
        private string selEbeln = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        public AllotEnterTranferOut()
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
                textBoxTare.ReadOnly = true;
            }
            else
            {
                textBoxTare.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxEnterTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("原材料调拨(调出)入厂");
            this.timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-原材料调拨(调出)入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-原材料调拨(调出)入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
                if (father[0].ToString() != "")
                {
                    MessageBox.Show(this, "编辑状态不能入厂操作，请重新进入该界面！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxEbeln.Text.Trim() != selEbeln)
                {
                    MessageBox.Show(this, "输入的调拨单已做修改，请重新调用调拨单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dtenter = Sdl_AllotTitleAdapter.GetSdl_AllotTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                if (dtenter.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                DataTable dtWerksCheck = new DataSetHelper().SelectDistinct("dtDistinct", dtGv, new string[] { "WERKS" });
                if (dtWerksCheck.Rows.Count > 1)
                {
                    MessageBox.Show(this, "调拨单行项目信息中的调入仓库必须相同！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_AllotTitle model = new Sdl_AllotTitle();
                        model.TRUCKNUM = textBoxCar.Text.ToString().Trim();
                        model.EBELN = textBoxEbeln.Text.ToString().Trim();
                        model.TIMEFLAG = textBoxEnterTime.Text;
                        model.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                        model.HSFLAG = "H";
                        model.TARE = Double.Parse(textBoxTare.Text.Trim());
                        model.ENTERWEIGHMAN = textBoxWeighMan.Text;
                        model.RESWK = textBoxFactory.Text.ToString().Trim();
                        model.EXITFLAG = 0;
                        model.ALLOTFLAG = 0;
                        model.TRAYNUM = "0";
                        model.TRAYWEIGHT = "0";
                        model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                        Sdl_AllotTitleAdapter.AddSdl_AllotTitle(model);
                    }
                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                    tw.TARE = float.Parse(textBoxTare.Text.Trim());
                    tw.TIMEFLAG = textBoxEnterTime.Text;
                    tw.TRUCKNUM = textBoxCar.Text.ToString().Trim();
                    tw.WERKS = textBoxFactory.Text.ToString();
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

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-原材料调拨(调出)入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (father[0].ToString() == "")
                {
                    MessageBox.Show(this, "请选择要编辑的调拨入厂信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入车牌号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxEbeln.Text.Trim() != selEbeln)
                {
                    MessageBox.Show(this, "输入的调拨单已做修改，请重新调用调拨单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有调拨单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (father[0].ToString() != textBoxCar.Text)
                {
                    DataTable dtenter = Sdl_AllotTitleAdapter.GetSdl_AllotTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                try
                {
                    Sdl_AllotTitle model = new Sdl_AllotTitle();
                    model = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                    if (model == null)
                    {
                        MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (model.HSFLAG == "S")
                    {
                        MessageBox.Show(this, "该车已经退货出厂，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    model.TRUCKNUM = textBoxCar.Text.ToString().Trim();
                    model.EBELN = textBoxEbeln.Text.ToString().Trim();
                    model.ENTERWEIGHMAN = textBoxWeighMan.Text;
                    model.TRAYNUM = "0";
                    model.TRAYWEIGHT = "0";
                    model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    Sdl_AllotTitleAdapter.UpdateSdl_AllotTitleByTimeFlag(model);

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
                selEbeln = textBoxEbeln.Text;
            }
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "AllotTransferIn");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                timer.Stop();
                textBoxCar.Text = father[0].ToString();
                textBoxEbeln.Text = father[1].ToString();
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                InitSelectDataBind();
                BindEnterData();
                selEbeln = textBoxEbeln.Text;
                if (textBoxCar.Text.Trim() != "")
                {
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonSave.Enabled = false;
                }
            }
        }

        private void InitSelectDataBind()
        {
            try
            {
                ListDictionary la = new ListDictionary();
                la.Add("EBELN", textBoxEbeln.Text.ToString().Trim());
                la.Add("WERKS", textBoxFactory.Text.ToString().Trim());
                ListDictionary lt = new ListDictionary();
                lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,MENGE");
                ListDictionary lr = new ListDictionary();
                dsSAP.Clear();
                dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_DB_RC", la, lt, ref lr);
                DataTable dtS = dsSAP.Tables[0];

                dtS.Columns.Add("SENGE");
                dtS.Columns.Add("LGORT");
                dtS.Columns.Add("WERKS");
                dtS.Columns.Add("OVERNUM");

                for (int i = 0; i < dtS.Rows.Count; i++)
                {
                    double overNum = Sdl_AllotDetailAdapter.GetSdl_AllotDetailOverNum(" WHERE EBELN = '" + dtS.Rows[i]["EBELN"].ToString() + "' and EBELP='" + dtS.Rows[i]["EBELP"].ToString() + "' ");
                    dtS.Rows[i]["OVERNUM"] = overNum.ToString();
                }
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dtS;

                dataGridViewDetails.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[7].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[8].DefaultCellStyle.BackColor = Color.Gray;

                if (dtS.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有该调拨单信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void textBoxEbeln_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxEbeln.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入调拨单号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InitSelectDataBind();
                selEbeln = textBoxEbeln.Text;
            }
        }

        private void BindEnterData()
        {
            Sdl_AllotTitle title = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(textBoxCar.Text, father[2].ToString());
            if (title != null)
            {
                textBoxTare.Text = title.TARE.ToString();
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
