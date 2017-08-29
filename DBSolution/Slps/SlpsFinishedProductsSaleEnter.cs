using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using System.Text;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsFinishedProductsSaleEnter : Form
    {
        private DataTable dtSelect = new DataTable();
        private DataSet ds = new DataSet();
        private string[] father = new string[] { "", "","" };
        public string vbelns = string.Empty;
        private string selCarNum = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        private string[] qrCodeArray;
        private static string FORMTITTLE = "成品销售入场";
        public SlpsFinishedProductsSaleEnter()
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
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            readPort = Common.GetReadPortFlag();
            if (readPort)
            {
                tbTare.ReadOnly = true;
            }
            else
            {
                tbTare.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            this.tbFactory.Text = sysSetting.WERKS;
            this.tbWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            tbSolution.Text = sysSetting.ID;
            s = new SerialPortHelper(ref serialPort);
            timer.Start();
        }
        
        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        
        //进行数据绑定
        public void BindEnterData(string[] codeArray)
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
                tbCarNo.Text = enterDataSet.Tables[0].Rows[0]["carNo"].ToString();
                //显示车辆过磅记录
                Common.ShowTruckWeight(tbCarNo.Text, dataGridViewHistory);
            }
            //查询订单明细
            DataSet slpsEnterDetail =  Sdl_SlpsEnterDetailAdapter.GetSdl_SlpsEnterDetailList(where);
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = slpsEnterDetail.Tables[0];
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确实要保存吗?", FORMTITTLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(tbCarNo.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请填写交货单！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    //保存入场表头信息
                    //如果为成品销售订单
                    Slps_FinishedProductsSale finishedHead = new Slps_FinishedProductsSale();
                    finishedHead.CarNo = tbCarNo.Text.ToString();
                    finishedHead.Factory = tbFactory.Text;
                    finishedHead.DbNum = tbSolution.Text;
                    finishedHead.EnterWeightMan = tbWeighMan.Text;
                    finishedHead.Tare = Convert.ToDecimal(tbTare.Text.ToString().Trim());
                    finishedHead.Hs_flag = "H";
                    finishedHead.TimeFlag = Common.GetServerDate();
                    int addFlag = Slps_FinishedProductsSaleAdapter.AddSlps_FinishedProductsSale(finishedHead);
                    if (addFlag > 0)
                    {
                        //头信息保存成功，接下来保存入场明细信息
                        Slps_FinishedProductsSaleDetail finishedDetail = new Slps_FinishedProductsSaleDetail();
                        for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                        {
                            finishedDetail = new Slps_FinishedProductsSaleDetail();
                            finishedDetail.QrcodeScanResult = dataGridViewDetails.Rows[i].Cells["qrcodeScanResult"].Value.ToString();
                            finishedDetail.SapOrderNo = dataGridViewDetails.Rows[i].Cells["sapOrderNo"].Value.ToString();
                            finishedDetail.LineItemNo = dataGridViewDetails.Rows[i].Cells["lineItemNo"].Value.ToString();
                            finishedDetail.Matnr = dataGridViewDetails.Rows[i].Cells["skuCode"].Value.ToString();
                            finishedDetail.Maktx = dataGridViewDetails.Rows[i].Cells["skuName"].Value.ToString();
                            finishedDetail.Lfimg = Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["beforeSendTonQuantity"].Value.ToString());
                            finishedDetail.Zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["zfimg"].Value.ToString());
                            finishedDetail.TimeFlag = finishedHead.TimeFlag;
                            addFlag = 0;
                            addFlag = Slps_FinishedProductsSaleDetailAdapter.AddSlps_FinishedProductsSaleDetail(finishedDetail);
                            if (addFlag <= 1)
                            {
                                Slps_FinishedProductsSaleDetailAdapter.DeleteSlps_FinishedProductsSaleDetail(finishedHead.QrcodeScanResult);
                                Slps_FinishedProductsSaleAdapter.DeleteSlps_FinishedProductsSale(finishedHead.TimeFlag, finishedHead.CarNo);
                                break;
                            }
                        }
                        if(addFlag <= 1)
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
                                slpsEnter.TimeFlag = finishedHead.TimeFlag;
                                slpsEnter.OrderStatus = "0";
                                Sdl_SlpsEnterAdapter.UpdateSdl_SlpsEnter(slpsEnter);
                            }

                            //保存车辆皮重信息
                            Sdl_TruckWeight tw = new Sdl_TruckWeight();
                            tw.ENTERTIME = DateTime.Parse(Common.GetServerDate());
                            tw.TARE = float.Parse(finishedHead.Tare.ToString());
                            tw.TIMEFLAG = finishedHead.TimeFlag;
                            tw.TRUCKNUM = finishedHead.CarNo;
                            tw.WERKS = finishedHead.Factory;
                            Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);

                            MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "车辆入场头信息保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", FORMTITTLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
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
            this.tbTare.Text = showNum.ToString();
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
                //检查是否存在未提交数据
                if (this.dataGridViewDetails.IsCurrentCellDirty)
                {
                    dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
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

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
        
    }
}
