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
    public partial class AllotEnterTranferIn : Form
    {
        private DataSet dsSAP = new DataSet();
        private string[] father = new string[] { "", "", "" };
        private string selEbeln = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        public AllotEnterTranferIn()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-原材料调拨(调入)入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
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
                textBoxGross.ReadOnly = true;
            }
            else
            {
                textBoxGross.ReadOnly = false;
            }

            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxEnterTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("原材料调拨(调入)入厂");
            this.timer.Start();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-原材料调拨(调入)入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                if (textBoxCar.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入车牌号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show("毛重数据应为数值！");
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dtenter = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                if (dtenter.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                DataTable dtWerksCheck = new DataSetHelper().SelectDistinct("dtDistinct", dtGv, new string[] { "WERKS" });
                //if (dtWerksCheck.Rows.Count > 1)
                //{
                //    MessageBox.Show(this, "调拨单行项目信息中的调入仓库必须相同！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                try
                {
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_AllotInTitle model = new Sdl_AllotInTitle();
                        model.TRUCKNUM = textBoxCar.Text;
                        model.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                        model.TIMEFLAG = textBoxEnterTime.Text;
                        model.OUTTIMEFLAG = father[2].ToString();
                        model.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                        model.HSFLAG = "H";
                        model.GROSS = Double.Parse(textBoxGross.Text.Trim());
                        model.ENTERWEIGHMAN = textBoxWeighMan.Text;
                        //model.RESWK = textBoxFactory.Text;
                        model.EXITFLAG = 0;
                        model.WERKS = textBoxFactory.Text;
                        model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                        model.TRAYNUM = "0";
                        model.TRAYWEIGHT = "0";
                        Sdl_AllotInTitleAdapter.AddSdl_AllotInTitle(model);
                    }
                    Sdl_AllotTitle outTitle = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(textBoxCar.Text, textBoxEbeln.Text, father[2].ToString());
                    outTitle.ALLOTFLAG = 1;
                    Sdl_AllotTitleAdapter.UpdateSdl_AllotTitle(outTitle);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TruckSelect ts = new TruckSelect(father, "AllotTransferOutAndIn");
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

                InitSelectDataBind();
                BindEnterData();
                selEbeln = textBoxEbeln.Text;
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
                lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,MENGE,RESWK");
                ListDictionary lr = new ListDictionary();
                dsSAP.Clear();
                dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_DB_RC2", la, lt, ref lr);
                DataTable dtS = dsSAP.Tables[0];

                dtS.Columns.Add("YENGE");
                dtS.Columns.Add("YFIMG");
                dtS.Columns.Add("SFIMG");
                dtS.Columns.Add("SENGE");
                dtS.Columns.Add("LGORT");
                dtS.Columns.Add("WERKS");




                for (int i = 0; i < dtS.Rows.Count; i++)
                {
                    DataTable dtH = Sdl_AllotDetailAdapter.GetSdl_AllotDetailMengeAndSfimg(" WHERE EBELN = '" + dtS.Rows[i]["EBELN"].ToString()
                        + "' and EBELP='" + dtS.Rows[i]["EBELP"].ToString() + "' and TimeFlag='" + father[2].ToString() + "' ");
                    dtS.Rows[i]["YENGE"] = dtH.Rows[0]["SENGE"].ToString();
                    dtS.Rows[i]["YFIMG"] = dtH.Rows[0]["SFIMG"].ToString();

                    dtS.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();

                    if (Math.Round(double.Parse(dtH.Rows[0]["SENGE"].ToString()), 3) == 0)
                    {
                        dtS.Rows.RemoveAt(i);
                        i = i - 1;
                    }
                }

                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dtS;

                dataGridViewDetails.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[7].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[8].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[9].DefaultCellStyle.BackColor = Color.Gray;


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
            //Sdl_AllotInTitle title = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(textBoxCar.Text, father[2].ToString());
            //if (title != null)
            //{
            //    textBoxGross.Text = title.TARE.ToString();
            //}
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
