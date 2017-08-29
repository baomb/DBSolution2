using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SdlDB.Utility;
using SdlDB.Entity;
using SdlDB.Data;
using System.Collections;
using System.Threading;

namespace DBSolution
{
    public partial class SlpsProductReturnExit : Form
    {
        private string[] father = new string[] { "", "" };
        private DataTable dtSapDetail = new DataTable();
        private DataTable dtSelect = new DataTable();
        private const string AUGRU = "001";
        SerialPortHelper s = null;
        private bool readPort = true;
        string[] qrCodeArray;   //二维码扫描结果数组
        private string formTittle = "子公司成品退货出厂";
        Slps_ProductsReturn returnHead = new Slps_ProductsReturn();

        public SlpsProductReturnExit(string[] codeArray)
        {
            InitializeComponent();
            InitForm();
            InitSelectDataBind(codeArray);
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
            textBoxFactory.Text = sysSetting.WERKS;
            textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            textBoxExitTime.Text = Common.GetServerDate();
            textBoxDBNum.Text = sysSetting.ID;
            s = new SerialPortHelper(ref serialPort);
            textBoxPrompt.Text = formTittle;
            timer.Start();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool ValidateControl(DataTable dt)
        {
            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
            {
                MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
            {
                MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                string realNum = dataGridViewDetails.Rows[i].Cells["realZfimg"].Value.ToString();
                if (!ValidateHelper.IsNumber(realNum) && !ValidateHelper.IsDecimal(realNum))
                {
                    MessageBox.Show(this, "请输入实退件数,实退件数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string realfimg = dataGridViewDetails.Rows[i].Cells["sfimg"].Value.ToString();
                if (!ValidateHelper.IsNumber(realfimg) && !ValidateHelper.IsDecimal(realfimg))
                {
                    MessageBox.Show(this, "请输入实退吨数,实退吨数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string lgort = dataGridViewDetails.Rows[i].Cells["lgort"].Value.ToString();
                if (string.IsNullOrEmpty(lgort))
                {
                    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            return true;
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
                DataGridViewCell dCell = null;
                if (dataGridViewDetails.Rows.Count != 0)
                {
                    dCell = dataGridViewDetails.Rows[0].Cells[0];
                }
                dataGridViewDetails.CurrentCell = dCell;
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                if (dtGv == null || dtGv.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_ProductReturnRailway modelEnter = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailway(textBoxCar.Text, father[1].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经退货成功，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                try
                {
                    //行项目操作
                    Slps_ProductsReturnDetail returnDetail;
                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        returnDetail = Slps_ProductsReturnDetailAdapter.GetSlps_ProductsReturnDetail(returnHead.TimeFlag, dtGv.Rows[i]["lineItemNo"].ToString());
                        returnDetail.Zfimg = Convert.ToDecimal(dtGv.Rows[i]["zfimg"].ToString());
                        returnDetail.Lgort = dtGv.Rows[i]["lgort"].ToString();
                        returnDetail.RealZfimg = Convert.ToDecimal(dtGv.Rows[i]["realZfimg"].ToString());
                        returnDetail.Sfimg = Convert.ToDecimal(dtGv.Rows[i]["sfimg"].ToString());
                        returnDetail.Dfimg = int.Parse(dtGv.Rows[i]["dfimg"].ToString());
                        Slps_ProductsReturnDetailAdapter.UpdateSlps_ProductsReturnDetail(returnDetail);
                    }

                    //头信息操作
                    returnHead.ExitTime = Common.GetServerDate();
                    returnHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                    returnHead.DbNum = textBoxDBNum.Text.ToString();
                    returnHead.ExitFlag = "0";
                    returnHead.Hs_flag = "S";
                    returnHead.Tare = Convert.ToDecimal(textBoxTare.Text.ToString().Trim());
                    returnHead.Net = Convert.ToDecimal(textBoxNet.Text.ToString().Trim());
                    returnHead.TypeId = "0";
                    Slps_ProductsReturnAdapter.UpdateSlps_ProductsReturn(returnHead);

                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = modelEnter.ENTERTIME;
                    tw.TARE = Convert.ToSingle(textBoxTare.Text);
                    tw.TIMEFLAG = modelEnter.TIMEFLAG;
                    tw.TRUCKNUM = textBoxCar.Text;
                    tw.WERKS = textBoxFactory.Text;
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);

                    MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Common.PlayGoodBye();
                    this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.Close();
                }
            }
        }
        
        private bool CheckDB(Slps_ProductsReturn title)
        {
            string exitDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string enterDB = title.DbNum;
            if (enterDB != exitDB)
            {
                DialogResult dr = MessageBox.Show(this, "入厂地磅与出厂地磅不同，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        private void InitSelectDataBind(string[] codeArray)
        {
            qrCodeArray = codeArray;

            //查询第一个二维码的时间戳，通过时间戳查询入场信息表头
            Sdl_SlpsEnter enter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[0]);
            returnHead = Slps_ProductsReturnAdapter.GetSlps_ProductsReturn(enter.TimeFlag, enter.CarNo);
            
            //检查地磅是与入场一致
            if (!CheckDB(returnHead))
            {
                return;
            }
            textBoxGross.Text = returnHead.Gross.ToString();
            textBoxCar.Text = returnHead.CarNo;

            //显示车辆皮重历史
            Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);

            //拼接where查询条件
            string where = string.Empty;
            where = "where timeFlag = '" + returnHead.TimeFlag + "'";

            //订单明细查询
            DataTable dt = Slps_ProductsReturnDetailAdapter.GetSlps_ProductsReturnDetailDataSet(where).Tables[0];
            //为界面中的明细表绑定数据
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dt;

            DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where lgort like '1%' and werks='" + textBoxFactory.Text + "' ").Tables[0];
            DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();

            cmbColumnPro.DataPropertyName = "lgort";
            cmbColumnPro.DataSource = dtCombox;
            cmbColumnPro.ValueMember = "lgort";
            cmbColumnPro.DisplayMember = "lgobe";

            int i = dataGridViewDetails.Columns["lgort"].Index;
            this.dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["lgort"].Index, cmbColumnPro);
            dataGridViewDetails.Columns.Remove("lgort");

            cmbColumnPro.Name = "lgort";
            cmbColumnPro.HeaderText = "收货仓库";
        }
        

        private double GetMatnrWeight(string matnr)
        {
            string weight = matnr.Substring(matnr.Length - 4, 1);
            double returnValue = 0;
            switch (weight)
            {
                case "1":
                    returnValue = double.Parse(Common.Weight1.ToString());
                    break;
                case "2":
                    returnValue = double.Parse(Common.Weight2.ToString());
                    break;
                case "3":
                    returnValue = double.Parse(Common.Weight3.ToString());
                    break;
                case "4":
                    returnValue = double.Parse(Common.Weight4.ToString());
                    break;
                case "5":
                    returnValue = double.Parse(Common.Weight5.ToString());
                    break;
                case "6":
                    returnValue = double.Parse(Common.Weight6.ToString());
                    break;
                case "7":
                    returnValue = double.Parse(Common.Weight7.ToString());
                    break;
                default:
                    returnValue = double.Parse(Common.Weight1.ToString());
                    break;

            }
            return returnValue;
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text), 3).ToString();
            }
            catch
            {
            }
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text), 3).ToString();
            }
            catch
            {
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                string currentValue = dataGridViewDetails.CurrentCell.FormattedValue.ToString();
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 7)
                {
                    int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                    if ((!ValidateHelper.IsDecimal(currentValue) && !ValidateHelper.IsNumber(currentValue)))
                    {
                        if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                            return;
                        MessageBox.Show(this, "实发数量应为数值", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        GetKuijian();
                        double price = 0;
                        string strCurrentValue = dataGridViewDetails.Rows[rowIndex].Cells["realZfimg"].Value.ToString();
                        strCurrentValue = strCurrentValue.Trim() == "" ? "0" : strCurrentValue;
                        double realCurrentNum = Convert.ToDouble(strCurrentValue);

                        string cmatnr = dataGridViewDetails.CurrentRow.Cells["matnr"].Value.ToString();
                        price = realCurrentNum * GetMatnrWeight(cmatnr) / 1000;
                        dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value = price.ToString();
                        textBoxLFIMG.Text = GetTotalWeight();
                    }
                }
            }
        }

        private void GetKuijian()
        {
            int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
            string cvbeln = dataGridViewDetails.CurrentRow.Cells["sapOrderNo"].Value.ToString();
            string cposnr = dataGridViewDetails.CurrentRow.Cells["lineItemNo"].Value.ToString();
            string cmatnr = dataGridViewDetails.CurrentRow.Cells["matnr"].Value.ToString();

            string vbeln = "";
            string posnr = "";
            string matnr = "";

            double zfimg = double.Parse(dataGridViewDetails.Rows[rowIndex].Cells["zfimg"].Value.ToString());
            double realNum = 0;
            ArrayList rowSame = new ArrayList();
            for (int m = 0; m < dataGridViewDetails.Rows.Count; m++)
            {
                vbeln = dataGridViewDetails.Rows[m].Cells["sapOrderNo"].Value.ToString();
                posnr = dataGridViewDetails.Rows[m].Cells["lineItemNo"].Value.ToString();
                matnr = dataGridViewDetails.Rows[m].Cells["matnr"].Value.ToString();
                if (cvbeln == vbeln && cposnr == posnr && cmatnr == matnr)
                {
                    rowSame.Add(m);
                    string strValue = dataGridViewDetails.Rows[m].Cells["realZfimg"].Value.ToString();
                    strValue = strValue.Trim() == "" ? "0" : strValue;
                    realNum += Convert.ToDouble(strValue);
                }
            }
            for (int i = 0; i < rowSame.Count; i++)
            {
                dataGridViewDetails.Rows[int.Parse(rowSame[i].ToString())].Cells["dfimg"].Value = Math.Round((zfimg - realNum), 3).ToString();
            }
        }

        private void GetKuijian(string cvbeln, string cposnr, string cmatnr, double zfimg)
        {
            string vbeln = "";
            string posnr = "";
            string matnr = "";
            double realNum = 0;
            ArrayList rowSame = new ArrayList();
            for (int m = 0; m < dataGridViewDetails.Rows.Count; m++)
            {
                vbeln = dataGridViewDetails.Rows[m].Cells["sapOrderNo"].Value.ToString();
                posnr = dataGridViewDetails.Rows[m].Cells["lineItemNo"].Value.ToString();
                matnr = dataGridViewDetails.Rows[m].Cells["matnr"].Value.ToString();
                if (cvbeln == vbeln && cposnr == posnr && cmatnr == matnr)
                {
                    rowSame.Add(m);
                    string strValue = dataGridViewDetails.Rows[m].Cells["realZfimg"].Value.ToString();
                    strValue = strValue.Trim() == "" ? "0" : strValue;
                    realNum += Convert.ToDouble(strValue);
                }
            }
            for (int i = 0; i < rowSame.Count; i++)
            {
                dataGridViewDetails.Rows[int.Parse(rowSame[i].ToString())].Cells["dfimg"].Value = Math.Round((zfimg - realNum), 3).ToString();
            }
        }

        private string GetTotalWeight()
        {
            double realNum = 0;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                try
                {
                    string valueNum = dataGridViewDetails.Rows[i].Cells["sfimg"].Value.ToString();
                    realNum += Convert.ToDouble(valueNum);
                }
                catch
                {
                }
            }
            return realNum.ToString();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要重车出厂吗?", "史丹利地磅系统-子公司成品退货出厂(铁运)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                if (dtGv == null || dtGv.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有交货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
                {
                    MessageBox.Show(this, "地磅数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据不能为空或者字符，应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double netValue = double.Parse(textBoxNet.Text);

                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("重车出厂时，毛重与皮重数值应该相等，确认放行吗？", formTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                Sdl_ProductReturnRailway modelEnter = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailway(textBoxCar.Text, father[1].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经退货成功，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Sdl_ProductReturnRailwayAdapter.DeleteSdl_ProductReturnRailwayByTimeFlag(father[1].ToString(), textBoxCar.Text);
                //头信息操作
                returnHead.ExitTime = Common.GetServerDate();
                returnHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                returnHead.DbNum = textBoxDBNum.Text.ToString();
                returnHead.ExitFlag = "1";
                returnHead.Hs_flag = "S";
                returnHead.Tare = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                returnHead.Net = Convert.ToDecimal(returnHead.Gross - returnHead.Tare);
                returnHead.TypeId = "0";
                Slps_ProductsReturnAdapter.UpdateSlps_ProductsReturn(returnHead);

                MessageBox.Show(this, "操作成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
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

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
