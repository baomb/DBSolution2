using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsFinishedProductsPresentationExit : Form
    {
        string[] father = new string[3];
        DataSet ds = new DataSet();
        private DataTable dtDetail = new DataTable();
        SerialPortHelper s = null;
        double balanceValue = 0;
        private bool readPort = true;
        private string formTittle = "原材料退货出厂";
        private string[] qrCodeArray;
        Slps_FinishedProductsPresentation preHead = new Slps_FinishedProductsPresentation();

        public SlpsFinishedProductsPresentationExit(string[] codeArray)
        {
            InitializeComponent();
            InitForm();
            InitDetailsDataBind(codeArray);
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
                    textBoxGross.ReadOnly = true;
                }
                else
                {
                    textBoxGross.ReadOnly = false;
                }
                Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
                textBoxFactory.Text = sysSetting.WERKS;
                textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
                textBoxDBNum.Text = sysSetting.ID;
                s = new SerialPortHelper(ref serialPort);
                textBoxPrompt.Text = formTittle;
                timer.Start();
            }
            catch
            {
                MessageBox.Show(this, "读取配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private bool CheckDB(Slps_FinishedProductsPresentation pre)
        {
            string exitDb = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string enterDB = pre.DbNum;
            if (!exitDb.Equals(enterDB))
            {
                DialogResult dr = MessageBox.Show(this, "入厂地磅与出厂地磅不同，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        private void InitDetailsDataBind(string[] codeArray)
        {
            try
            {
                qrCodeArray = codeArray;
                //查询第一个二维码的时间戳，通过时间戳查询入场信息表头
                Sdl_SlpsEnter enter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrCodeArray[0]);
                preHead = Slps_FinishedProductsPresentationAdapter.GetSlps_FinishedProductsPresentation(enter.TimeFlag, enter.CarNo);
                if (preHead == null)
                {
                    MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (preHead.Hs_flag == "S")
                {
                    MessageBox.Show(this, "该车已经发货出厂，不能再次发货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检查地磅是与入场一致
                if (!CheckDB(preHead))
                {
                    return;
                }
                textBoxTare.Text = preHead.Tare.ToString();
                textBoxCar.Text = preHead.CarNo;

                //显示车辆皮重历史
                Common.ShowTruckWeight(textBoxCar.Text, dataGridViewHistory);

                //拼接where查询条件
                string where = string.Empty;
                where = "where timeFlag = '" + preHead.TimeFlag + "'";

                //订单明细查询
                DataTable dt = Slps_FinishedProductsPresentationDetailAdapter.GetSlps_FinishedProductsPresentationDetailDataSet(where).Tables[0];
                //为界面中的明细表绑定数据
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
                
                DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where ( lgort like '1%' or  lgort like '3%' ) and werks='" + textBoxFactory.Text + "' ").Tables[0];
                DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();
                cmbColumnPro.DataPropertyName = "lgort";
                cmbColumnPro.DataSource = dtCombox;
                cmbColumnPro.ValueMember = "lgort";
                cmbColumnPro.DisplayMember = "lgobe";

                dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
                dataGridViewDetails.Columns.Remove("lgort");
                cmbColumnPro.Name = "lgort";
                cmbColumnPro.HeaderText = "发货仓库";

                DataTable dtPackWeight = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
                DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[6];
                cbcpw.DataPropertyName = "pweight";
                cbcpw.DataSource = dtPackWeight;
                cbcpw.ValueMember = "包重";
                cbcpw.DisplayMember = "说明";
                cbcpw.Name = "pweight";
                cbcpw.HeaderText = "包重";
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private bool ValidateControl(DataTable dt)
        {
            try
            {

                if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
                {
                    MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(textBoxSgtxt.Text))
                {
                    MessageBox.Show(this, "领料人不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    string realNum = dataGridViewDetails.Rows[i].Cells["realMenge"].Value.ToString();
                    if (!ValidateHelper.IsNumber(realNum))
                    {
                        MessageBox.Show(this, "请输入实发件数,实发件数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    string realfimg = dataGridViewDetails.Rows[i].Cells["sfimg"].Value.ToString();
                    if (!ValidateHelper.IsNumber(realfimg) && !ValidateHelper.IsDecimal(realfimg))
                    {
                        MessageBox.Show(this, "请输入实发吨数,实发吨数应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    if (string.IsNullOrEmpty(lgort))
                    {
                        MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                DataTable dtDistinct = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "sapOrderNo", "lineItemNo", "matnr", "lgort" });
                if (dt.Rows.Count != dtDistinct.Rows.Count)
                {
                    MessageBox.Show(this, "同一预留单同一物料必须在不同仓库发货！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "史丹利地磅系统 - 产成品赠送出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
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
                    MessageBox.Show(this, "没有预留单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_FinishedProductsPresentationTitle modelEnter = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(textBoxCar.Text, father[1].ToString(), father[2].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.HS_FLAG == "S")
                {
                    MessageBox.Show(this, "该车已经发货成功，不能再次发货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

                try
                {

                    //更新表头数据
                    preHead.Balance = Convert.ToDecimal(balanceValue.ToString());
                    preHead.ExitTime = Common.GetServerDate();
                    preHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
                    preHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                    preHead.Hs_flag = "S";
                    preHead.ExitFlag = "0";
                    preHead.Net = Convert.ToDecimal(textBoxNet.Text.ToString().Trim());
                    Slps_FinishedProductsPresentationAdapter.UpdateSlps_FinishedProductsPresentation(preHead);

                    //更新行项目数据
                    Slps_FinishedProductsPresentationDetail preDetail;
                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        preDetail = Slps_FinishedProductsPresentationDetailAdapter.GetSlps_FinishedProductsPresentationDetail(preHead.TimeFlag, dtGv.Rows[i]["lineItemNo"].ToString());
                        preDetail.Lgort = dtGv.Rows[i]["lgort"].ToString();
                        preDetail.Sfimg = Convert.ToDecimal(dtGv.Rows[i]["sfimg"].ToString());
                        preDetail.RealMenge = Convert.ToDecimal(dtGv.Rows[i]["realMenge"].ToString());
                        preDetail.Bktxt = dtGv.Rows[i]["bktxt"].ToString();
                        Slps_FinishedProductsPresentationDetailAdapter.UpdateSlps_FinishedProductsPresentationDetail(preDetail);

                    }
                    
                    Common.PlayGoodBye();
                    MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch
                {
                    MessageBox.Show(this, "向SAP过账成功，向地磅数据库操作失败，请联系管理员！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void toolStripButtonReturn_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes != MessageBox.Show(this, "请确认数据填写准确无误，是否继续？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            if (toolStripButton.Text != "解锁")
            {
                MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridViewDetails.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有预留号相关信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
            {
                MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
            {
                MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Math.Round(double.Parse(textBoxNet.Text), 3) != 0)
            {
                if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-成品赠送出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }

            //头信息操作
            preHead.Balance = new decimal(0);
            preHead.ExitTime = Common.GetServerDate();
            preHead.ExitWeightMan = textBoxWeighMan.Text.ToString();
            preHead.Gross = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
            preHead.Net = Convert.ToDecimal(textBoxNet.ToString().Trim());
            preHead.Hs_flag = "S";
            preHead.ExitFlag = "1";
            Slps_FinishedProductsPresentationAdapter.UpdateSlps_FinishedProductsPresentation(preHead);

            MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Common.PlayGoodBye();
            this.Close();
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private string GetTotalWeight()
        {
            double price = 0;
            double realNum = 0;
            string matnr = "";

            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                try
                {
                    string strValue = dataGridViewDetails.Rows[i].Cells[9].Value.ToString();
                    strValue = strValue.Trim() == "" ? "0" : strValue;
                    realNum = Convert.ToDouble(strValue);
                    matnr = dataGridViewDetails.Rows[i].Cells[3].Value.ToString();
                    price += realNum * double.Parse(dataGridViewDetails.Rows[i].Cells["pweight"].Value.ToString()) / 1000.0;
                }
                catch
                {
                }
            }

            return price.ToString();
        }
        
        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string currentValue = dataGridViewDetails.CurrentCell.FormattedValue.ToString();
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 9)
                {
                    int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                    if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                        currentValue = "0";
                    if (!ValidateHelper.IsNumber(currentValue))
                    {
                        MessageBox.Show(this, "实发数量应为整数", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string matnr = dataGridViewDetails.Rows[rowIndex].Cells["matnr"].Value.ToString();
                    int num = int.Parse(currentValue);
                    dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value = num * double.Parse(dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value.ToString()) / 1000.0;
                }
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 8)
                {
                    try
                    {
                        int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                        if (dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value.ToString() == "")
                        {
                            currentValue = "0";
                        }
                        string matnr = dataGridViewDetails.Rows[rowIndex].Cells["matnr"].Value.ToString();
                        int num = int.Parse(currentValue);
                        dataGridViewDetails.Rows[rowIndex].Cells["sfimg"].Value = num * double.Parse(dataGridViewDetails.Rows[rowIndex].Cells["pweight"].Value.ToString()) / 1000.0;
                    }
                    catch
                    {
                    }
                }
                textBoxTotalSfimg.Text = GetTotalWeight();
            }
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
