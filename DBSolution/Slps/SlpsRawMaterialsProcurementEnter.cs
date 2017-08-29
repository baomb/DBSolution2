using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;
using System.Data.SqlTypes;

namespace DBSolution
{
    public partial class SlpsRawMaterialsProcurementEnter : Form
    {
        bool stat = false;
        bool readPort = true;
        bool mode = true;
        string ebeln = string.Empty;
        string[] father = new string[3];
        string lbFlag = string.Empty;       //合同订单标记
        private string[] qrCodeArray;
        private string formTittle = "原材料采购入场";

        DataSet ds = new DataSet();
        
        Sdl_RawMaterialsProcurementTitle rmpt = new Sdl_RawMaterialsProcurementTitle();
        SerialPortHelper s = null;

        public SlpsRawMaterialsProcurementEnter()
        {
            InitializeComponent();
            Common.PlayWelcome();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxGross.ReadOnly = false;
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
                Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                readPort = Common.GetReadPortFlag();
                s = new SerialPortHelper(ref serialPort);
                textBoxFactory.Text = sysSetting.WERKS;
                textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                textBoxDbnum.Text = sysSetting.ID;
                Sdl_Manual manual = Sdl_ManualAdapter.GetSdl_Manual(labelTitle.Text);
                textBoxPrompt.Text = manual.MANUAL;
                toolStripEdit.Enabled = false;
                timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    //显示车辆过磅记录
                    Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);
                }
                //查询订单明细
                DataSet slpsEnterDetail = Sdl_SlpsEnterDetailAdapter.GetSdl_SlpsEnterDetailList(where);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = slpsEnterDetail.Tables[0];

                Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private bool CheckTruckNum(string truckNum)
        {
            bool result = true;
            try
            {
                DataSet ds = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 采购订单", "TIMEFLAG as 进厂时间" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and TRUCKNUM = '" + truckNum + "'");
                if (rmpt.ENTERTIME == SqlDateTime.MinValue)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = false;
                    }
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][2].ToString() != rmpt.TIMEFLAG)
                    {
                        result = false;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!CorrectMistake())
                {
                    return;
                }
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "史丹利地磅系统 - 原材料采购入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                if (!ValidateControl())
                    return;
                if (!CheckTruckNum(textBoxCar.Text))
                {
                    MessageBox.Show(this, "此车牌号已经入厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int addFlag = 0;
                Slps_RawMaterialsProcurement enterHead = new Slps_RawMaterialsProcurement();
                enterHead.TimeFlag = Common.GetServerDate();
                enterHead.CarNo = textBoxCar.Text.ToString().Trim();
                enterHead.Factory = textBoxFactory.Text.ToString().Trim();
                enterHead.DbNum = textBoxDbnum.Text.ToString().Trim();
                enterHead.EnterWeightMan = textBoxWeighMan.Text.ToString();
                enterHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                enterHead.Hs_flag = "H";
                addFlag = Slps_RawMaterialsProcurementAdapter.AddSlps_RawMaterialsProcurement(enterHead);
                
                
                if (addFlag > 1)
                {
                    DataTable dtDetail = (DataTable)dataGridViewDetails.DataSource;
                    Slps_RawMaterialsProcurementDetail enterDetail = new Slps_RawMaterialsProcurementDetail();
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        enterDetail = new Slps_RawMaterialsProcurementDetail();
                        enterDetail.TimeFlag = enterHead.TimeFlag;
                        enterDetail.QrcodeScanResult = dtDetail.Rows[i]["qrcodeScanResult"].ToString();
                        enterDetail.SapOrderNo = dtDetail.Rows[i]["sapOrderNo"].ToString();
                        enterDetail.LineItemNo = dtDetail.Rows[i]["lineItemNo"].ToString();
                        enterDetail.Matnr = dtDetail.Rows[i]["matnr"].ToString();
                        enterDetail.Maktx = dtDetail.Rows[i]["maktx"].ToString();
                        enterDetail.Lfimg = Convert.ToDecimal(dtDetail.Rows[i]["lfimg"].ToString());
                        enterDetail.Pstyp = "H";
                        if (checkBoxKG.Checked == true)
                        {
                            enterDetail.Kg = "1";
                        }
                        else
                        {
                            enterDetail.Kg = "0";
                        }
                        addFlag = Slps_RawMaterialsProcurementDetailAdapter.AddSlps_RawMaterialsProcurementDetail(enterDetail);
                        if (addFlag <= 1)
                        {
                            Slps_RawMaterialsSaleDetailAdapter.DeleteSlps_RawMaterialsSaleDetail(enterDetail.QrcodeScanResult);
                            Slps_RawMaterialsSaleAdapter.DeleteSlps_RawMaterialsSale(enterHead.TimeFlag, enterHead.CarNo);
                            break;
                        }
                    }
                }
                
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
            bool result = true;
            bool isZero = true;
            double lfimg = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (dataGridViewDetails.Rows[i].Cells["lfimg"].Value == null)
                {
                    MessageBox.Show(this, "请输入原发吨数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                lfimg += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["lfimg"].Value);
                if (checkBoxKG.Checked == true)
                {
                    lfimg = lfimg / 1000;
                }
                if (dataGridViewDetails.Rows[i].Cells["lfimg"].Value.ToString() != "0")
                {
                    isZero = false;
                }
                if (Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["menge"].Value) <= 0)
                {
                    MessageBox.Show(this, "采购订单行项目可收货数量为负数,请联系供应科修改采购订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["menge"].Value) < Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value) && mode)
                {
                    result = false;
                }
            }
            if (isZero)
            {
                MessageBox.Show(this, "原发吨数不能为零", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!result)
            {
                MessageBox.Show(this, "原发吨数大于可收货数量,请联系供应科修改订单或修改原发吨数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (lfimg >= Convert.ToDouble(textBoxGross.Text))
            {
                MessageBox.Show(this, "原发吨数必须小于毛重", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                float gross = Convert.ToSingle(textBoxGross.Text);
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请填写正确的毛重信息", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool CorrectMistake()
        {
            dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
            int count = dataGridViewDetails.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show(this, "没有采购订单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                string temp = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    if (dataGridViewDetails.Rows[i].Cells[9].Value != null)
                    {
                        temp = dataGridViewDetails.Rows[i].Cells[9].Value.ToString();
                        temp = TypeConverter.ToDBC(temp).Replace("。", ".");
                        dataGridViewDetails.Rows[i].Cells[9].Value = Convert.ToDouble(temp);
                    }
                }
                temp = textBoxCar.Text.ToUpper();
                textBoxCar.Text = TypeConverter.ToDBC(temp).Replace("。", ".");
                
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请检查输入应为数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("确认修改订单？", "史丹利地磅系统 - 原材料采购入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //    return;
            //try
            //{
            //    mode = false;
            //    if (!CorrectMistake())
            //    {
            //        return;
            //    }
            //    if (!ValidateControl())
            //        return;
            //    if (rmpt == null)
            //    {
            //        MessageBox.Show(this, "没有此车辆信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    if (!CheckTruckNum(textBoxCar.Text))
            //    {
            //        MessageBox.Show(this, "此车牌号已经入厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    Sdl_RawMaterialsProcurementAdapter.DeleteSdl_RawMaterialsProcurement(rmpt.TIMEFLAG, rmpt.VBELN);
            //    string truckNum = rmpt.TRUCKNUM;
            //    string vbeln = rmpt.VBELN;
            //    rmpt.TRUCKNUM = textBoxCar.Text;
            //    rmpt.VBELN = textBoxEBELN.Text;
            //    rmpt.WEIGHMAN = textBoxWeighMan.Text;
            //    rmpt.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            //    Sdl_RawMaterialsProcurementTitleAdapter.UpdateSdl_RawMaterialsProcurementTitle(rmpt, vbeln, truckNum);
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        Sdl_RawMaterialsProcurement rmp = new Sdl_RawMaterialsProcurement();
            //        rmp.TIMEFLAG = rmpt.TIMEFLAG;
            //        rmp.MATNR = ds.Tables[0].Rows[i]["MATNR"].ToString();
            //        rmp.MAKTX = ds.Tables[0].Rows[i]["MAKTX"].ToString();
            //        rmp.MCOD1 = ds.Tables[0].Rows[i]["NAME1"].ToString();
            //        rmp.VBELN = ds.Tables[0].Rows[i]["EBELN"].ToString();
            //        rmp.POSNR = ds.Tables[0].Rows[i]["EBELP"].ToString();
            //        rmp.PSTYP = "H";
            //        rmp.LFIMG = Convert.ToSingle(dataGridViewDetails.Rows[i].Cells["LFIMG"].Value);
            //        if (checkBoxKG.Checked == true)
            //        {
            //            rmp.KG = "1";
            //        }
            //        else
            //        {
            //            rmp.KG = "0";
            //        }
            //        Sdl_RawMaterialsProcurementAdapter.AddSdl_RawMaterialsProcurement(rmp);
            //    }
            //    mode = true;
            //     MessageBox.Show(this, "修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
            //catch
            //{
            //    MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!readPort || stat)
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
