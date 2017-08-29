using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Utility;
using SdlDB.Entity;
using SdlDB.Data;
using System.Threading;

namespace DBSolution
{
    public partial class SlpsProductReturnEnter : Form
    {
        private string[] father = new string[] { "", "" };
        private const string AUGRU = "001";
        SerialPortHelper s = null;
        private bool readPort = true;
        private string formTittle = "成品退货入厂";
        private string[] qrCodeArray;

        public SlpsProductReturnEnter(string[] codeArray)
        {
            InitializeComponent();
            Common.PlayWelcome();
            InitForm();
            InitDetailBind(codeArray);
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
                textBoxGross.ReadOnly = true;
            }
            else
            {
                textBoxGross.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            textBoxFactory.Text = sysSetting.WERKS;
            textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            textBoxDbnum.Text = sysSetting.ID;
            s = new SerialPortHelper(ref serialPort);
            timer.Start();
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
            if (MessageBox.Show("确实要保存吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请选择退货订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (father[1].ToString() == "")
                {
                    DataTable dtenter = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                try
                {
                    Slps_ProductsReturn returnHead = new Slps_ProductsReturn();
                    returnHead.CarNo = textBoxCar.Text.ToString().Trim();
                    returnHead.TimeFlag = Common.GetServerDate();
                    returnHead.Factory = textBoxFactory.Text.ToString().Trim();
                    returnHead.DbNum = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    returnHead.EnterWeightMan = textBoxWeighMan.Text.ToString();
                    returnHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                    returnHead.Hs_flag = "H";
                    int addFlag = Slps_ProductsReturnAdapter.AddSlps_ProductsReturn(returnHead);
                    if (addFlag > 1)
                    {
                        DataTable returnDt = (DataTable)dataGridViewDetails.DataSource;
                        Slps_ProductsReturnDetail returnDetail;
                        for (int i = 0; i < returnDt.Rows.Count; i++)
                        {
                            returnDetail = new Slps_ProductsReturnDetail();
                            returnDetail.QrcodeScanResult = returnDt.Rows[i]["qrcodeScanResult"].ToString();
                            returnDetail.SapOrderNo = returnDt.Rows[i]["sapOrderNo"].ToString();
                            returnDetail.LineItemNo = returnDt.Rows[i]["lineItemNo"].ToString();
                            returnDetail.Matnr = returnDt.Rows[i]["skuCode"].ToString();
                            returnDetail.Maktx = returnDt.Rows[i]["skuName"].ToString();
                            returnDetail.Lfimg = Convert.ToDecimal(returnDt.Rows[i]["beforeSendTonQuantity"].ToString());
                            returnDetail.TimeFlag = returnHead.TimeFlag;
                            Slps_ProductsReturnDetailAdapter.AddSlps_ProductsReturnDetail(returnDetail);
                        }


                        MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        private void InitDetailBind(string[] codeArray)
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
