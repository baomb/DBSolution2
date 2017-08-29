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
    public partial class SlpsEnter : Form
    {
        private DataTable dtSelect = new DataTable();
        private DataSet ds = new DataSet();
        private string[] father = new string[] { "", "","" };
        public string vbelns = string.Empty;
        private string selCarNum = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        private Sdl_SlpsEnter slpsEnter = new Sdl_SlpsEnter();
        public SlpsEnter()
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
            this.tbFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.tbEnterTime.Text = Common.GetServerDate();
            tbSolution.Text = sysSetting.ID;
            s = new SerialPortHelper(ref serialPort);
            //InitDetailBind("");
        }
        

        //行项目数据绑定
        private void InitDetailBind(string where)
        {
            try
            {
                if (where != "")
                {
                    //详细信息绑定
                    DataTable dt = Sdl_FinishedProductsExchangeInAdapter.GetSdl_FinishedProductsExchangeInDataSet(where).Tables[0];
                    dataGridViewDetails.AutoGenerateColumns = false;
                    dataGridViewDetails.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DelButton");
                    dt.Columns.Add("POSNR");
                    dt.Columns.Add("MATNR");
                    dt.Columns.Add("MAKTX");
                    dt.Columns.Add("MENGE");

                    DataRow dr = dt.NewRow();
                    dr["POSNR"] = "1";
                    dr["MATNR"] = "";
                    dr["MAKTX"] = "";
                    dr["MENGE"] = "";
                    dt.Rows.Add(dr);
                    dataGridViewDetails.AutoGenerateColumns = false;
                    dataGridViewDetails.DataSource = dt;
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
        
        //进行数据绑定
        private void BindEnterData(string qrcodeScanResult, string sapOrderNo, string carNo)
        {
            //根据扫描信息绑定界面表头
            slpsEnter = Sdl_SlpsEnterAdapter.GetSdl_SlpsEnter(qrcodeScanResult,sapOrderNo,carNo);
            if (slpsEnter != null)
            {
                tbSapOrder.Text = slpsEnter.SapOrderNo.ToString();
                tbCarNo.Text = slpsEnter.CarNo.ToString();
                //显示车辆过磅记录
                Common.ShowTruckWeight(this.tbCarNo.Text, dataGridViewHistory);
            }
            //查询订单明细
            DataSet slpsEnterDetail =  Sdl_SlpsEnterDetailAdapter.GetSdl_SlpsEnterDetailList(qrcodeScanResult,sapOrderNo);
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = slpsEnterDetail.Tables[0];
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    if (slpsEnter.OrderType == "ZOR")
                    {
                       
                    }


                    //保存入场明细信息
                }
                catch (Exception ex)
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
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            if (colIndex == 0)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataRow dr = dt.NewRow();
                dr["POSNR"] = dt.Rows.Count+1;
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString().Trim();
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString().Trim();
                dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString().Trim();
                dt.Rows.Add(dr);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            else if (colIndex == 1)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                if (dt.Rows.Count > 1)
                {
                    dt.Rows[rowIndex].Delete();
                    dataGridViewDetails.AutoGenerateColumns = false;
                    dataGridViewDetails.DataSource = dt;
                }
                
                
            }
        }
        
        //重新绑定界面时间
        private void resetDateTime()
        {
            tbEnterTime.Text = Common.GetServerDate();
        }
    }
}
