using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class FinishedProductsPresentationEnter : Form
    {
        private string rsnum = string.Empty;
        private string[] father = new string[3];
        private DataSet ds = new DataSet();
        SerialPortHelper s = null;
        private bool readPort = true;
        public FinishedProductsPresentationEnter()
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
            try
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
                this.textBoxFactory.Text = sysSetting.WERKS;
                this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                this.textBoxEnterTime.Text = Common.GetServerDate();
                this.toolStripButtonModify.Enabled = false;
                s = new SerialPortHelper(ref serialPort);
                this.textBoxPrompt.Text = Common.GetHelpStr("成品免费赠送入厂");
                this.timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", "史丹利地磅系统-成品免费赠送入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "史丹利地磅系统 - 产成品赠送入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                DataTable dtenter = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitleDataSetByField(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HS_FLAG = 'H' ").Tables[0];
                if (dtenter.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Sdl_FinishedProductsPresentationTitle fppt = new Sdl_FinishedProductsPresentationTitle();
                fppt.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                fppt.TIMEFLAG = textBoxEnterTime.Text;
                fppt.TARE = Convert.ToSingle(textBoxTare.Text);
                fppt.HS_FLAG = "H";
                fppt.TRUCKNUM = textBoxCar.Text;
                fppt.RSNUM = textBoxRSNUM.Text;
                fppt.ENTERWEIGHMAN = textBoxWeighMan.Text;
                fppt.WERKS = textBoxFactory.Text;
                fppt.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                Sdl_FinishedProductsPresentationTitleAdapter.AddSdl_FinishedProductsPresentationTitle(fppt);
                Sdl_TruckWeight tw = new Sdl_TruckWeight();
                tw.ENTERTIME = fppt.ENTERTIME;
                tw.TARE = fppt.TARE;
                tw.TIMEFLAG = fppt.TIMEFLAG;
                tw.TRUCKNUM = fppt.TRUCKNUM;
                tw.WERKS = fppt.WERKS;
                Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
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
            if (dataGridViewDetails.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有预留单号信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (rsnum != textBoxRSNUM.Text)
            {
                MessageBox.Show(this, "预留单号与项目信息中的预留号不同，请核实", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidateHelper.IsVehiclenumber(textBoxCar.Text))
            {
                MessageBox.Show(this, "车牌号输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidateHelper.IsDecimal(textBoxTare.Text) && !ValidateHelper.IsNumber(textBoxTare.Text))
            {
                MessageBox.Show(this, "皮重不是数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void textBoxRSNUM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rsnum = textBoxRSNUM.Text;
                InitDetailsDataBind();
            }
        }

        private void InitDetailsDataBind()
        {
            try
            {
                if (textBoxRSNUM.Text == string.Empty)
                {
                    MessageBox.Show(this, "预留单号未填写", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ListDictionary la = new ListDictionary();
                la.Add("RSNUM", TypeConverter.ToDBC(textBoxRSNUM.Text));
                la.Add("WERKS", textBoxFactory.Text);
                ListDictionary lt = new ListDictionary();
                lt.Add("ZRESB", "RSNUM,RSPOS,MATNR,MAKTX,BDMNG");
                ListDictionary lr = new ListDictionary();
                ds = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_RESB_RC", la, lt, ref lr);

                DataTable dtDetail = ds.Tables[0];
                dtDetail.Columns.Add("OVERNUM");
                dtDetail.Columns.Add("LEFTNUM");

                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    double overNum = Sdl_FinishedProductsPresentationAdapter.GetSdl_FinishedProductsPresentationOverNum(" WHERE RSNUM = '" + dtDetail.Rows[i]["RSNUM"].ToString() + "' and RSPOS='" + dtDetail.Rows[i]["RSPOS"].ToString() + "' ");
                    dtDetail.Rows[i]["OVERNUM"] = overNum.ToString();
                    dtDetail.Rows[i]["LEFTNUM"] = (double.Parse(dtDetail.Rows[i]["BDMNG"].ToString()) + overNum).ToString();
                }

                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dtDetail;

                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有预留单号信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void toolStripButtonModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "确认修改订单？", "史丹利地磅系统 - 产成品赠送入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (!ValidateControl())
                    return;

                if (father[0].ToString() != textBoxCar.Text)
                {
                    DataTable dtenter = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitleDataSetByField(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HS_FLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                Sdl_FinishedProductsPresentationTitle modelEnter = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HS_FLAG == "S")
                {
                    MessageBox.Show(this, "该车已经发货成功，不能再次收货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                modelEnter.TRUCKNUM = textBoxCar.Text;
                modelEnter.RSNUM = textBoxRSNUM.Text;
                modelEnter.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID; Sdl_FinishedProductsPresentationTitleAdapter.UpdateSdl_FinishedProductsPresentationTitleByTimeFlag(modelEnter);


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
            TruckSelect ts = new TruckSelect(father, "FinishedProductsPresentation");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                timer.Stop();
                this.textBoxCar.Text = father[0].ToString();
                this.textBoxRSNUM.Text = father[1].ToString();
                this.textBoxEnterTime.Text = father[2].ToString();
                rsnum = textBoxRSNUM.Text;
                Sdl_FinishedProductsPresentationTitle fppt = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(father[0].ToString(), father[1].ToString(), father[2].ToString());
                this.textBoxTare.Text = fppt.TARE.ToString();
                InitDetailsDataBind();
                this.toolStripButtonModify.Enabled = true;
                this.toolStripButtonSave.Enabled = false;
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
