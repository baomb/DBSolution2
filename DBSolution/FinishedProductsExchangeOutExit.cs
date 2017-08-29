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
using System.Collections;

namespace DBSolution
{
    public partial class FinishedProductsExchangeOutExit : Form
    {
        private DataTable dtSelect = new DataTable();
        private DataSet ds = new DataSet();
        private string[] father = new string[] { "", "", "" };
        SerialPortHelper s = null;
        private bool readPort = true;
        private Sdl_FinishedProductsExchangeTitle enterHead = new Sdl_FinishedProductsExchangeTitle();
        public FinishedProductsExchangeOutExit()
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
                textBoxGross.ReadOnly = true;
            }
            else
            {
                textBoxGross.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
            this.timer.Start();
        }
        

        private void InitDetailBind(string where)
        {
            bool flag = true;
            try
            {
                BindEnterData();
                if (!enterHead.DBNUM.Equals(Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID))
                {
                    if (MessageBox.Show("与入厂地磅不同，确定键继续吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        flag = false;
                    }
                }

                if (flag)
                {
                    //详细信息绑定
                    DataTable dt = Sdl_FinishedProductsExchangeOutAdapter.GetSdl_FinishedProductsExchangeOutDataSet(where).Tables[0];
                    dataGridViewDetails.AutoGenerateColumns = false;
                    dataGridViewDetails.DataSource = dt;

                    dataGridViewDetails.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
                    dataGridViewDetails.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                    dataGridViewDetails.Columns[2].DefaultCellStyle.BackColor = Color.LightGray;
                    dataGridViewDetails.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;

                    //包重数据绑定
                    DataTable dtPackWeight = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
                    DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewDetails.Columns[5];
                    cbcpw.DataPropertyName = "pweight";
                    cbcpw.DataSource = dtPackWeight;
                    cbcpw.ValueMember = "包重";
                    cbcpw.DisplayMember = "说明";
                    cbcpw.Name = "PWEIGHT";
                    cbcpw.HeaderText = "包重";

                    //库存地点数据绑定
                    DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where lgort like '1%' and werks='" + textBoxFactory.Text + "' ").Tables[0];
                    DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();

                    cmbColumnPro.DataPropertyName = "lgort";
                    cmbColumnPro.DataSource = dtCombox;
                    cmbColumnPro.ValueMember = "lgort";
                    cmbColumnPro.DisplayMember = "lgobe";

                    int i = dataGridViewDetails.Columns["LGORT"].Index;
                    dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
                    dataGridViewDetails.Columns.Remove("LGORT");

                    cmbColumnPro.Name = "LGORT";
                    cmbColumnPro.HeaderText = "发货仓库";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        
        private void BindEnterData()
        {
            enterHead = Sdl_FinishedProductsExchangeOutTitleAdapter.GetSdl_FinishedProductsExchangeOutTitle(textBoxCar.Text, father[2].ToString(), father[1].ToString());
            if (enterHead != null)
            {
                textBoxTare.Text = enterHead.TARE.ToString();
                textBoxOA.Text = enterHead.OANUM.ToString();
                textBoxCNum.Text = enterHead.CNUM;
                textBoxCName.Text = enterHead.CNAME;
                textBoxTType.Text = enterHead.TTYPE;
                textBoxFxqd.Text = enterHead.FXQD;
                textBoxYwy.Text = enterHead.YWY;
                textBoxXsqy.Text = enterHead.XSQY;
                textBoxXsks.Text = enterHead.XSKS;
                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-总公司成品销售入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(this, "没有交货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    string realNum = dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value.ToString();
                    if (!ValidateHelper.IsNumber(realNum))
                    {
                        MessageBox.Show(this, "请输入实发件数,实发件数应为整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                    if (string.IsNullOrEmpty(lgort))
                    {
                        MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    Sdl_FinishedProductsExchangeTitle fpet = new Sdl_FinishedProductsExchangeTitle();
                    
                    enterHead.HS_FLAG = "S";
                    enterHead.EXITFLAG = 0;
                    enterHead.GROSS = Convert.ToDecimal(textBoxGross.Text.ToString().Trim());
                    enterHead.NET = Convert.ToDecimal(textBoxNet.Text.ToString().Trim());
                    enterHead.EXITTIME = DateTime.Parse(textBoxExitTime.Text.ToString().Trim());
                    enterHead.EXITWEIGHT = textBoxWeighMan.Text.ToString().Trim();
                    enterHead.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    Sdl_FinishedProductsExchangeOutTitleAdapter.UpdateSdl_FinishedProductsExchangeOutTitle(enterHead);
                    
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_FinishedProductsExchange fpe = Sdl_FinishedProductsExchangeOutAdapter.GetSdl_FinishedProductsExchangeOut(enterHead.TIMEFLAG, enterHead.OANUM, dtGv.Rows[i]["POSNR"].ToString());
                        fpe.LFIMG = Convert.ToDecimal(dtGv.Rows[i]["LFIMG"].ToString().Trim());
                        fpe.ZFIMG = Convert.ToDecimal(dtGv.Rows[i]["ZFIMG"].ToString().Trim());
                        fpe.LGORT = dtGv.Rows[i]["LGORT"].ToString().Trim();
                        Sdl_FinishedProductsExchangeOutAdapter.UpdateSdl_FinishedProductsExchangeOut(fpe,fpe.ID.ToString());
                    }
                    
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetDateTime();
                }
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", "史丹利地磅系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "ProductExchangeOut");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                this.textBoxCar.Text = father[0].ToString();
                this.textBoxOA.Text = father[2].ToString();
               
                string where = "where timeflag = '" + father[1] + "' and oanum = '" + father[2] + "' ";
                InitDetailBind(where);
                toolStripButtonCancel.Enabled = true;
            }
        }
        
        private void textBoxCar_TextChanged(object sender, EventArgs e)
        {
            textBoxCar.Text = textBoxCar.Text.ToString().Trim().ToUpper();
            textBoxCar.SelectionStart = textBoxCar.Text.Length;
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
                if (this.dataGridViewDetails.IsCurrentCellDirty)
                {
                    dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                timer.Stop();
                toolStripButton.Text = "解锁";
                toolStripButton.Image = DBSolution2.Properties.Resources.Unlock;
                toolStripButtonSave.Enabled = true;
            }
            else
            {
                timer.Start();
                toolStripButton.Text = "锁定";
                toolStripButton.Image = DBSolution2.Properties.Resources.Lock;
                toolStripButtonSave.Enabled = false;
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实重车出厂吗?", "史丹利地磅系统-总公司成品换货", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请选择交货单！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal diff = Convert.ToDecimal(textBoxNet.Text.ToString()) - Convert.ToDecimal(textBoxCount.Text.ToString());
                if (diff > 0)
                {
                    if ((MessageBox.Show(this, "净重与实收吨数差" + diff.ToString() + "吨，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes))
                    {
                        return;
                    }
                }

                try
                {
                    Sdl_FinishedProductsExchangeTitle fpet = new Sdl_FinishedProductsExchangeTitle();

                    enterHead.HS_FLAG = "S";
                    enterHead.EXITFLAG = 1;
                    enterHead.GROSS = fpet.TARE;
                    enterHead.NET = fpet.GROSS - fpet.TARE;
                    enterHead.EXITTIME = DateTime.Parse(textBoxExitTime.Text.ToString().Trim());
                    enterHead.EXITWEIGHT = textBoxWeighMan.Text.ToString().Trim();
                    enterHead.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    Sdl_FinishedProductsExchangeOutTitleAdapter.UpdateSdl_FinishedProductsExchangeOutTitle(enterHead);

                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_FinishedProductsExchange fpe = Sdl_FinishedProductsExchangeOutAdapter.GetSdl_FinishedProductsExchangeOut(enterHead.TIMEFLAG, enterHead.OANUM, dataGridViewDetails.Rows[i].Cells["POSNR"].Value.ToString());
                        fpe.LFIMG = 0;
                        fpe.ZFIMG = 0;
                        fpe.LGORT = "";
                        Sdl_FinishedProductsExchangeOutAdapter.UpdateSdl_FinishedProductsExchangeOut(fpe, fpe.ID.ToString());
                    }

                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxExitTime.Text.ToString().Trim());
                    tw.TARE = Convert.ToSingle(textBoxGross.Text.ToString().Trim());
                    tw.TIMEFLAG = textBoxExitTime.Text.ToString().Trim();
                    tw.TRUCKNUM = textBoxCar.Text.ToString().Trim().ToUpper();
                    tw.WERKS = textBoxFactory.Text.ToString().Trim();
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetDateTime();
                }
            }
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            getNet();
        }

        //重新绑定界面时间
        private void resetDateTime()
        {
            textBoxExitTime.Text = Common.GetServerDate();
        }

        private void getNet()
        {
            decimal net = 0;
            decimal gross = 0;
            decimal tare = 0;

            if (!textBoxGross.Text.ToString().Trim().Equals(""))
            {
                gross = decimal.Parse(textBoxGross.Text.ToString().Trim());
            }
            if (!textBoxTare.Text.ToString().Trim().Equals(""))
            {
                tare = decimal.Parse(textBoxTare.Text.ToString().Trim());
            }

            net = gross - tare;
            textBoxNet.Text = net.ToString();
        }

        
        private void dataGridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDetails.IsCurrentCellDirty)
            {
                int colIndex = dataGridViewDetails.CurrentCell.ColumnIndex;
                dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (colIndex == 4 && (!ValidateHelper.IsNumber(dataGridViewDetails.CurrentCell.FormattedValue.ToString())))
                {
                    if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                        return;
                    MessageBox.Show(this, "实发件数应为整数", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataGridViewDetails.ClearSelection();

                if (colIndex == 4 || colIndex == 5)
                {
                    double price = 0;
                    double realNum = 0;
                    int zfimg = 0;  //实发件数
                    int pweight = 0; //包重
                    double lfimg = 0;  //实发吨数

                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        try
                        {
                            //实发吨数计算
                            zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["ZFIMG"].Value);
                            pweight = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value);
                            lfimg = zfimg * pweight / 1000;
                            dataGridViewDetails.Rows[i].Cells["LFIMG"].Value = Math.Round(lfimg, 2);

                            //实发总数计算
                            string strValue = dataGridViewDetails.Rows[i].Cells[4].Value.ToString();
                            strValue = strValue.Trim() == "" ? "0" : strValue;
                            realNum = Convert.ToDouble(strValue);
                            price += realNum * pweight / 1000;
                        }
                        catch
                        {
                        }
                    }
                        textBoxCount.Text = price.ToString("F2");
                    }
            }
            
            getNet();
        }
    }
}
