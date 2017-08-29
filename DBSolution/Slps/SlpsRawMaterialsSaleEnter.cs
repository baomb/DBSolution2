using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsRawMaterialsSaleEnter : Form
    {
        bool stat = false;
        bool readPort = true;
        string vbeln = string.Empty;
        DataSet ds = new DataSet();
        SerialPortHelper s = null;
        Sdl_SysSetting sysSetting = null;
        string werks_temp = string.Empty;
        private string[] qrCodeArray;
        private string formTittle = "原材料销售入场";

        public SlpsRawMaterialsSaleEnter()
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
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
            try
            {
                sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                readPort = Common.GetReadPortFlag();
                s = new SerialPortHelper(ref serialPort);
                werks_temp = sysSetting.WERKS;
                textBoxFactory.Text = sysSetting.WERKS;
                textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                textBoxDbnum.Text = sysSetting.ID;
                Sdl_Manual manual = Sdl_ManualAdapter.GetSdl_Manual(this.labelTitle.Text);
                textBoxPrompt.Text = manual.MANUAL;
                timer.Start();
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

        //数据绑定
        private void InitDataBind(string[] codeArray)
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
                //显示车辆过磅记录
                Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);
            }
            //查询订单明细
            DataSet slpsEnterDetail = Sdl_SlpsEnterDetailAdapter.GetSdl_SlpsEnterDetailList(where);
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = slpsEnterDetail.Tables[0];
            Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);
            
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？",formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                
                int addFlag = 0;
                //创建入场头信息
                Slps_RawMaterialsSale enterHead = new Slps_RawMaterialsSale();
                enterHead.TimeFlag = Common.GetServerDate();
                enterHead.CarNo = textBoxCar.Text.ToString().Trim();
                enterHead.Factory = textBoxFactory.Text.ToString().Trim();
                enterHead.DbNum = textBoxDbnum.Text.ToString().Trim();
                enterHead.EnterWeightMan = textBoxWeighMan.Text.ToString();
                enterHead.Tare = Convert.ToDecimal(textBoxTare.Text.ToString().Trim());
                enterHead.Hs_flag = "H";
                Slps_RawMaterialsSaleAdapter.AddSlps_RawMaterialsSale(enterHead);

                //创建入场物料明细
                DataTable dtDetail = (DataTable)dataGridViewDetails.DataSource;
                Slps_RawMaterialsSaleDetail enterDetail = new Slps_RawMaterialsSaleDetail();
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    enterDetail = new Slps_RawMaterialsSaleDetail();
                    enterDetail.QrcodeScanResult = dtDetail.Rows[i]["qrcodeScanResult"].ToString();
                    enterDetail.SapOrderNo = dtDetail.Rows[i]["sapOrderNo"].ToString();
                    enterDetail.LineItemNo = dtDetail.Rows[i]["lineItemNo"].ToString();
                    enterDetail.Matnr = dtDetail.Rows[i]["matnr"].ToString();
                    enterDetail.Maktx = dtDetail.Rows[i]["maktx"].ToString();
                    enterDetail.Sfimg = Convert.ToDecimal(dtDetail.Rows[i]["beforeSendTonQuantity"].ToString());
                    addFlag = Slps_RawMaterialsSaleDetailAdapter.AddSlps_RawMaterialsSaleDetail(enterDetail);
                    if (addFlag <= 1)
                    {
                        Slps_RawMaterialsSaleDetailAdapter.DeleteSlps_RawMaterialsSaleDetail(enterDetail.QrcodeScanResult);
                        Slps_RawMaterialsSaleAdapter.DeleteSlps_RawMaterialsSale(enterHead.TimeFlag, enterHead.CarNo);
                        break;
                    }
                }



                if (addFlag <= 1)
                {
                    MessageBox.Show(this, "车辆入场信息保存失败，数据已重置，请重新过磅。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //保存成功将订单状态设置为已入场
                    Sdl_SlpsEnter slpsEnter = new Sdl_SlpsEnter();
                    for (int i = 0; i < qrCodeArray.Length; i++)
                    {
                        slpsEnter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[i]);
                        slpsEnter.TimeFlag = enterHead.TimeFlag;
                        slpsEnter.OrderStatus = "0";
                        Sdl_SlpsEnterAdapter.UpdateSdl_SlpsEnter(slpsEnter);
                    }

                    //保存车辆皮重信息
                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(Common.GetServerDate());
                    tw.TARE = float.Parse(enterHead.Tare.ToString());
                    tw.TIMEFLAG = enterHead.TimeFlag;
                    tw.TRUCKNUM = enterHead.CarNo;
                    tw.WERKS = enterHead.Factory;
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);

                    MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                
            }
            catch
            {
                MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool ValidateControl()
        {
            int count = dataGridViewDetails.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show(this, "没有销售订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (vbeln != textBoxDbnum.Text || textBoxDbnum.Text != ds.Tables[0].Rows[0]["VBELN"].ToString())
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
