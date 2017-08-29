using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using System.Threading;
using System.Collections.Specialized;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsRawMaterialReturnEnter : Form
    {
        private DataSet dsSAP = new DataSet();
        private string[] father = new string[] { "", "", "" };
        private string selEbeln = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        private string formTittle = "原材料退货入厂";
        private string[] qrCodeArray;

        public SlpsRawMaterialReturnEnter(string[] codeArray)
        {
            InitializeComponent();
            Common.PlayWelcome();
            InitForm();
            BindEnterData(codeArray);
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
            textBoxFactory.Text = sysSetting.WERKS;
            textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            textBoxDbnum.Text = sysSetting.ID;
            textBoxPrompt.Text = formTittle;
            timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-原材料退货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-原材料退货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                DataTable dtenter = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                if (dtenter.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                try
                {
                    //头信息完善
                    Slps_RawMaterialsReturn returnHead = new Slps_RawMaterialsReturn();
                    returnHead.TimeFlag = Common.GetServerDate();
                    returnHead.CarNo = textBoxCar.Text.ToString().Trim();
                    returnHead.Factory = textBoxFactory.Text.ToString();



                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_RawMaterialReturnTitle model = new Sdl_RawMaterialReturnTitle();
                        model.TRUCKNUM = textBoxCar.Text;
                        model.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                        model.TIMEFLAG = Common.GetServerDate();
                        model.LIFNR = dtGv.Rows[i]["LIFNR"].ToString();
                        model.NAME1 = dtGv.Rows[i]["NAME1"].ToString();
                        model.HSFLAG = "H";
                        model.TARE = Double.Parse(textBoxTare.Text.Trim());
                        model.WEIGHMAN = textBoxWeighMan.Text;
                        model.WERKS = textBoxFactory.Text;
                        model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                        Sdl_RawMaterialReturnTitleAdapter.AddSdl_RawMaterialReturnTitle(model);
                    }
                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                    tw.TARE = float.Parse(textBoxTare.Text);
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

        
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-原材料退货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (father[0].ToString() == "")
                {
                    MessageBox.Show(this, "请选择要编辑的退货入厂信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入车牌号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (father[0].ToString() != textBoxCar.Text)
                {
                    DataTable dtenter = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                try
                {
                    //TODO 未修改

                    MessageBox.Show(this, "修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void BindEnterData(string[] codeArray)
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
