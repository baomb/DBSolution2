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
    public partial class SlpsFinishedProductsPresentationEnter : Form
    {
        private string rsnum = string.Empty;
        private string[] father = new string[3];
        private DataSet ds = new DataSet();
        SerialPortHelper s = null;
        private bool readPort = true;
        private string[] qrCodeArray;
        private static string formTittle = "成品赠送入场";


        public SlpsFinishedProductsPresentationEnter(string[] codeArray)
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
                textBoxFactory.Text = sysSetting.WERKS;
                textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                textBoxDbnum.Text = sysSetting.ID;
                toolStripButtonModify.Enabled = false;
                s = new SerialPortHelper(ref serialPort);
                textBoxPrompt.Text = formTittle;
                timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                //添加成品赠送表头
                Slps_FinishedProductsPresentation preHead = new Slps_FinishedProductsPresentation();
                preHead.CarNo = textBoxCar.Text.ToString().Trim();
                preHead.TimeFlag = Common.GetServerDate();
                preHead.Factory = textBoxFactory.Text.ToString();
                preHead.DbNum = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                preHead.EnterWeightMan = textBoxWeighMan.Text.ToString();
                preHead.Tare = Convert.ToDecimal(textBoxTare.Text.ToString().Trim());
                preHead.Hs_flag = "H";
                Slps_FinishedProductsPresentationAdapter.AddSlps_FinishedProductsPresentation(preHead);

                //保存成功将订单状态设置为已入场
                Sdl_SlpsEnter slpsEnter = new Sdl_SlpsEnter();
                for (int i = 0; i < qrCodeArray.Length; i++)
                {
                    slpsEnter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[i]);
                    slpsEnter.TimeFlag = preHead.TimeFlag;
                    slpsEnter.OrderStatus = "0";
                    Sdl_SlpsEnterAdapter.UpdateSdl_SlpsEnter(slpsEnter);
                }

                //保存车辆皮重信息
                Sdl_TruckWeight tw = new Sdl_TruckWeight();
                tw.ENTERTIME = DateTime.Parse(Common.GetServerDate());
                tw.TARE = Convert.ToSingle(preHead.Tare);
                tw.TIMEFLAG = preHead.TimeFlag;
                tw.TRUCKNUM = preHead.CarNo;
                tw.WERKS = preHead.Factory;
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
            
        }

        private void InitDetailsDataBind(string[] codeArray)
        {
            try
            {
                qrCodeArray = codeArray;
                //拼接where查询条件
                string where = string.Empty;
                for (int a = 0; a < qrCodeArray.Length; a++)
                {
                    where = where + "'" + qrCodeArray[a] + "'";
                    if (qrCodeArray.Length > 1 && a < qrCodeArray.Length - 1)
                    {
                        where = where + ",";
                    }
                }
                where = "where qrcodeScanResult in (" + where + ")";
                //查询过磅订单
                DataSet enterDataSet = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnterList(where);
                
                if (enterDataSet.Tables[0].Rows.Count > 0)
                {
                    textBoxCar.Text = enterDataSet.Tables[0].Rows[0]["carNo"].ToString();
                    DataSet dtDetail = Sdl_SlpsEnterDetailAdapter.GetSdl_SlpsEnterDetailList(where);
                    dataGridViewDetails.AutoGenerateColumns = false;
                    dataGridViewDetails.DataSource = dtDetail;

                    //显示车辆过磅记录
                    Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);
                }
                else
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
            
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
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
