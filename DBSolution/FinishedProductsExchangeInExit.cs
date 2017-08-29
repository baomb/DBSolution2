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
    public partial class FinishedProductsExchangeInExit : Form
    {
        private DataTable dtSelect = new DataTable();
        private DataSet ds = new DataSet();
        private string[] father = new string[] { "", "", "" };
        SerialPortHelper s = null;
        private bool readPort = true;
        private Sdl_FinishedProductsExchangeTitle enterHead = new Sdl_FinishedProductsExchangeTitle();
        public FinishedProductsExchangeInExit()
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
                textBoxTare.ReadOnly = true;
            }
            else
            {
                textBoxTare.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
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
                    DataTable dt = Sdl_FinishedProductsExchangeInAdapter.GetSdl_FinishedProductsExchangeInDataSet(where).Tables[0];
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
                    this.dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
                    dataGridViewDetails.Columns.Remove("LGORT");

                    cmbColumnPro.Name = "LGORT";
                    cmbColumnPro.HeaderText = "收货仓库";
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
            enterHead = Sdl_FinishedProductsExchangeInTitleAdapter.GetSdl_FinishedProductsExchangeInTitle(textBoxCar.Text, father[2].ToString(), father[1].ToString());
            if (enterHead != null)
            {
                textBoxGross.Text = enterHead.GROSS.ToString();
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
                    string realNum = dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value.ToString();
                    if (!ValidateHelper.IsNumber(realNum))
                    {
                        MessageBox.Show(this, "请输入实收件数,实收件数应为整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    enterHead.TARE = Convert.ToDecimal(textBoxTare.Text.ToString().Trim());
                    enterHead.NET = Convert.ToDecimal(textBoxNet.Text.ToString());
                    enterHead.EXITTIME = DateTime.Parse(textBoxExitTime.Text.ToString());
                    enterHead.EXITWEIGHT = textBoxWeighMan.Text.ToString();
                    enterHead.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    Sdl_FinishedProductsExchangeInTitleAdapter.UpdateSdl_FinishedProductsExchangeInTitle(enterHead);
                    
                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_FinishedProductsExchange fpe = Sdl_FinishedProductsExchangeInAdapter.GetSdl_FinishedProductsExchangeIn(enterHead.TIMEFLAG, enterHead.OANUM, dtGv.Rows[i]["POSNR"].ToString());
                        fpe.SENGE = Convert.ToDecimal(dtGv.Rows[i]["SENGE"].ToString().Trim());
                        fpe.REALZFIMG = Convert.ToDecimal(dtGv.Rows[i]["REALZFIMG"].ToString().Trim());
                        fpe.LGORT = dtGv.Rows[i]["LGORT"].ToString().Trim();
                        Sdl_FinishedProductsExchangeInAdapter.UpdateSdl_FinishedProductsExchangeIn(fpe,fpe.ID.ToString());
                    }

                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxExitTime.Text);
                    tw.TARE = Convert.ToSingle(textBoxTare.Text);
                    tw.TIMEFLAG = textBoxExitTime.Text;
                    tw.TRUCKNUM = textBoxCar.Text.ToString().Trim().ToUpper();
                    tw.WERKS = textBoxFactory.Text;
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);

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
            TruckSelect ts = new TruckSelect(father, "ProductExchange");
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
            textBoxCar.Text = textBoxCar.Text.ToUpper();
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
            textBoxTare.Text = showNum.ToString();
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
                    enterHead.TARE = fpet.GROSS;
                    enterHead.NET = fpet.GROSS - fpet.TARE;
                    enterHead.EXITTIME = DateTime.Parse(textBoxExitTime.Text.ToString());
                    enterHead.EXITWEIGHT = textBoxWeighMan.Text.ToString();
                    enterHead.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID.ToString();
                    Sdl_FinishedProductsExchangeInTitleAdapter.UpdateSdl_FinishedProductsExchangeInTitle(enterHead);

                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        Sdl_FinishedProductsExchange fpe = Sdl_FinishedProductsExchangeInAdapter.GetSdl_FinishedProductsExchangeIn(enterHead.TIMEFLAG, enterHead.OANUM, dataGridViewDetails.Rows[i].Cells["POSNR"].Value.ToString());
                        fpe.SENGE = 0;
                        fpe.REALZFIMG = 0;
                        fpe.LGORT = "";
                        Sdl_FinishedProductsExchangeInAdapter.UpdateSdl_FinishedProductsExchangeIn(fpe, fpe.ID.ToString());
                    }

                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxExitTime.Text);
                    tw.TARE = Convert.ToSingle(textBoxGross.Text);
                    tw.TIMEFLAG = textBoxExitTime.Text;
                    tw.TRUCKNUM = textBoxCar.Text.ToString().Trim().ToUpper();
                    tw.WERKS = textBoxFactory.Text;
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

        private void dataGridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                int colIndex = dataGridViewDetails.CurrentCell.ColumnIndex;
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
                            //实收吨数计算
                            zfimg = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["REALZFIMG"].Value);
                            pweight = Convert.ToInt32(dataGridViewDetails.Rows[i].Cells["PWEIGHT"].Value);
                            lfimg = zfimg * pweight / 1000;
                            dataGridViewDetails.Rows[i].Cells["SENGE"].Value = Math.Round(lfimg, 2);

                            //实收总数计算
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
            //int colIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;
            //decimal netCount = 0;
            //if (colIndex == 4)
            //{

            //    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            //    {
            //        if (dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString() != "")
            //        {
            //            netCount += (dataGridViewDetails.Rows[i].Cells["SENGE"].Value == DBNull.Value) ? 0 : Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);

            //        }
            //    }
            //    textBoxCount.Text = netCount.ToString();
            //}
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
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

            if ((!textBoxTare.Text.ToString().Trim().Equals("")) && ValidateHelper.IsDecimal(textBoxTare.Text.ToString().Trim()))
            {
                tare = decimal.Parse(textBoxTare.Text.ToString().Trim());
            }

            net = gross - tare;
            textBoxNet.Text = net.ToString();
        }
    }
}
