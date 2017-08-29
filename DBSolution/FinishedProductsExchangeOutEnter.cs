using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;
using System.Text.RegularExpressions;

namespace DBSolution
{
    public partial class FinishedProductsExchangeOutEnter : Form
    {
        private DataTable dtSelect = new DataTable();
        private DataSet ds = new DataSet();
        private string[] father = new string[] { "", "","" };
        public string vbelns = string.Empty;
        private string selCarNum = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        private Sdl_FinishedProductsExchangeTitle inTitle = null;
        public FinishedProductsExchangeOutEnter()
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
            this.textBoxEnterTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxPrompt.Text = Common.GetHelpStr("成品换货重车入厂");
            this.timer.Start();
            InitDetailBind("");
        }
        

        //行项目数据绑定
        private void InitDetailBind(string where)
        {
            try
            {
                if (where != "")
                {
                    BindEnterData();
                    //详细信息绑定
                    DataTable dt = Sdl_FinishedProductsExchangeOutAdapter.GetSdl_FinishedProductsExchangeOutDataSet(where).Tables[0];
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
        
        private void BindEnterData()
        {
            inTitle = Sdl_FinishedProductsExchangeOutTitleAdapter.GetSdl_FinishedProductsExchangeOutTitle(textBoxCar.Text, father[2].ToString(), father[1].ToString());
            if (inTitle != null)
            {
                textBoxTare.Text = inTitle.TARE.ToString();
                textBoxOA.Text = inTitle.OANUM.ToString();
                textBoxEnterTime.Text = inTitle.ENTERTIME.ToString();

                textBoxCar.Text = inTitle.TRUCKNUM.ToString();
                textBoxCNum.Text = inTitle.CNUM.ToString();
                textBoxCName.Text = inTitle.CNAME.ToString();
                textBoxTType.Text = inTitle.TTYPE.ToString();
                textBoxFxqd.Text = inTitle.FXQD.ToString();
                textBoxYwy.Text = inTitle.YWY.ToString();
                textBoxXsqy.Text = inTitle.XSQY.ToString();
                textBoxXsks.Text = inTitle.XSKS.ToString();

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
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请填写交货单！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    //重车入场表头

                    Sdl_FinishedProductsExchangeTitle fpet = new Sdl_FinishedProductsExchangeTitle();
                    fpet.ID = textBoxFactory.Text.Trim() + DateTime.Now.ToString("yyyyMMddhhmmss");
                    fpet.OANUM = textBoxOA.Text.ToString().Trim().ToString();
                    fpet.TIMEFLAG = Common.GetServerDate();
                    fpet.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text.ToString());
                    fpet.HS_FLAG = "H";
                    fpet.TARE = Convert.ToDecimal(textBoxTare.Text.ToString());
                    fpet.GROSS = 0;
                    fpet.NET = 0;
                    fpet.TRUCKNUM = textBoxCar.Text.Trim().ToString().ToUpper();
                    fpet.ENTERWEIGHT = textBoxWeighMan.Text.Trim().ToString();
                    fpet.WERKS = textBoxFactory.Text.ToString();
                    fpet.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    fpet.EXITFLAG = 0;
                    fpet.CNUM = textBoxCNum.Text.ToString().Trim();
                    fpet.CNAME = textBoxCName.Text.ToString().Trim();
                    fpet.TTYPE = textBoxTType.Text.ToString().Trim();
                    fpet.FXQD = textBoxFxqd.Text.ToString().Trim();
                    fpet.YWY = textBoxYwy.Text.ToString().Trim();
                    fpet.XSQY = textBoxXsqy.Text.ToString().Trim();
                    fpet.XSKS = textBoxXsks.Text.ToString().Trim();
                    if (Sdl_FinishedProductsExchangeOutTitleAdapter.AddSdl_FinishedProductsExchangeOutTitle(fpet) != 0)
                    {
                        for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                        {
                            Sdl_FinishedProductsExchange fpe = new Sdl_FinishedProductsExchange();
                            fpe.TRUCKNUM = fpet.TRUCKNUM;
                            fpe.OANUM = fpet.OANUM;
                            fpe.TIMEFLAG = fpet.TIMEFLAG;
                            fpe.POSNR = dataGridViewDetails.Rows[i].Cells["POSNR"].Value.ToString().Trim();
                            fpe.MATNR = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString().Trim();
                            fpe.MAKTX = dataGridViewDetails.Rows[i].Cells["MAKTX"].Value.ToString().Trim();
                            fpe.MENGE = Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["MENGE"].Value.ToString().Trim());
                            Sdl_FinishedProductsExchangeOutAdapter.AddSdl_FinishedProductsExchangeOut(fpe);
                        }

                        Sdl_TruckWeight tw = new Sdl_TruckWeight();
                        tw.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                        tw.TARE = Convert.ToSingle(textBoxTare.Text);
                        tw.TIMEFLAG = textBoxEnterTime.Text;
                        tw.TRUCKNUM = textBoxCar.Text.ToUpper();
                        tw.WERKS = textBoxFactory.Text;
                        Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                        if (inTitle != null)
                        {
                            inTitle.ISOUT = "1";
                            Sdl_FinishedProductsExchangeInTitleAdapter.UpdateSdl_FinishedProductsExchangeInTitle(inTitle);
                        }
                        MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //是否启用打印功能
                        if (MessageBox.Show("是否打印换货通知单？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            saveAndPrint(fpet.TRUCKNUM, fpet.TIMEFLAG, fpet.OANUM);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetDateTime();
                    }
                    
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetDateTime();
                }
            }
        }

        //打印单据
        private void saveAndPrint(string truckNum, string timeFlag, string oanum)
        {
            this.Cursor = Cursors.WaitCursor;
            FinishedProductsExchangeInPrint printer = new FinishedProductsExchangeInPrint();
            printer.StartPosition = FormStartPosition.CenterParent;
            printer.ShowDialog(this, truckNum, oanum, timeFlag,"out");
            this.Cursor = Cursors.Default;
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
                if (textBoxCar.Text.Trim() != "")
                {
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonPrint.Enabled = true;
                    //textBoxGross.ReadOnly = true;

                }
                string where = "where timeflag = '" + father[1] + "' and oanum = '" + father[2] + "' ";
                InitDetailBind(where);
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-成品换货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (father[0].ToString() == "")
                {
                    MessageBox.Show(this, "请选择要编辑的入厂信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入车牌号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有交货单详细信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() != father[0].ToString())
                {
                    MessageBox.Show(this, "输入的车牌号与选择的车牌号不相同，请核实", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                try
                {
                    Sdl_FinishedProductsExchangeTitle modelEnter = Sdl_FinishedProductsExchangeOutTitleAdapter.GetSdl_FinishedProductsExchangeOutTitle(textBoxCar.Text,father[2].ToString(), father[1].ToString());
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
                    
                    //头信息操作
                    try
                    {
                        Sdl_FinishedProductsExchangeTitle fpet = inTitle;
                        fpet.ID = textBoxFactory.Text.Trim() + DateTime.Now.ToString("yyyyMMddhhmmss");
                        fpet.OANUM = textBoxOA.Text.ToString().Trim();
                        fpet.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text.ToString());
                        fpet.HS_FLAG = "H";
                        fpet.TARE = Convert.ToDecimal(textBoxTare.Text.ToString());
                        fpet.GROSS = 0;
                        fpet.NET = 0;
                        fpet.TRUCKNUM = textBoxCar.Text.ToUpper();
                        fpet.ENTERWEIGHT = textBoxWeighMan.Text.ToString();
                        fpet.WERKS = textBoxFactory.Text.ToString();
                        fpet.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                        fpet.EXITFLAG = 0;
                        fpet.CNUM = textBoxCNum.Text.ToString().Trim();
                        fpet.CNAME = textBoxCName.Text.ToString().Trim();
                        fpet.TTYPE = textBoxTType.Text.ToString().Trim();
                        fpet.FXQD = textBoxFxqd.Text.ToString().Trim();
                        fpet.YWY = textBoxYwy.Text.ToString().Trim();
                        fpet.XSQY = textBoxXsqy.Text.ToString().Trim();
                        fpet.XSKS = textBoxXsks.Text.ToString().Trim();
                        Sdl_FinishedProductsExchangeOutTitleAdapter.UpdateSdl_FinishedProductsExchangeOutTitle(fpet,father[0].ToString(),father[2].ToString());

                        //删除行项目并重新添加
                        Sdl_FinishedProductsExchangeOutAdapter.DeleteSdl_FinishedProductsExchangeOut(father[1].ToString(), father[2].ToString());

                        for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                        {
                            Sdl_FinishedProductsExchange fpe = new Sdl_FinishedProductsExchange();
                            fpe.TRUCKNUM = fpet.TRUCKNUM;
                            fpe.OANUM = fpet.OANUM;
                            fpe.TIMEFLAG = fpet.TIMEFLAG;
                            fpe.POSNR = dataGridViewDetails.Rows[i].Cells["POSNR"].Value.ToString();
                            fpe.MATNR = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString();
                            fpe.MAKTX = dataGridViewDetails.Rows[i].Cells["MAKTX"].Value.ToString();
                            fpe.MENGE = Convert.ToDecimal(dataGridViewDetails.Rows[i].Cells["MENGE"].Value.ToString());
                            Sdl_FinishedProductsExchangeOutAdapter.AddSdl_FinishedProductsExchangeOut(fpe);
                        }
                        
                        MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetDateTime();
                    }

                }
                catch
                {
                    MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetDateTime();
                }
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
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString() ;
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();;
                dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString();
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

        private void textBoxOA_TextChanged(object sender, EventArgs e)
        {
            textBoxOA.Text = textBoxOA.Text.ToUpper();
            textBoxOA.SelectionStart = textBoxOA.Text.Length;
        }

        /// <summary>
        /// 检查文本框是否为中文
        /// </summary>
        /// <param name="inputStr">文本框</param>
        private void checkTextBoxText(TextBox inputStr)
        {
            bool flag = true;
            if (inputStr.Text != "")
            {
                char[] s = inputStr.Text.ToCharArray();
                for (int i = 0; i < s.Length; i++)
                {
                    Regex rx = new Regex("^[\u4e00-\u9fa5]$");
                    if (!rx.IsMatch(s[i].ToString()))
                    {
                        flag = false;
                        break;
                    }
                }

                if (!flag)
                {
                    inputStr.ForeColor = Color.Red;
                    MessageBox.Show(this, "请输入中文!", "注意");
                }
                else
                {
                    inputStr.ForeColor = Color.Black;
                }
            }

        }

        private void textBoxTType_Leave(object sender, EventArgs e)
        {
            checkTextBoxText(textBoxTType);
        }

        private void textBoxFxqd_Leave(object sender, EventArgs e)
        {
            checkTextBoxText(textBoxFxqd);
        }

        private void textBoxYwy_Leave(object sender, EventArgs e)
        {
            checkTextBoxText(textBoxYwy);
        }

        private void textBoxXsqy_Leave(object sender, EventArgs e)
        {
            checkTextBoxText(textBoxXsqy);
        }

        private void textBoxXsks_Leave(object sender, EventArgs e)
        {
            checkTextBoxText(textBoxXsks);
        }

        private void textBoxOA_Leave(object sender, EventArgs e)
        {
            if (textBoxOA.Text.Trim().Length > 14)
            {
                textBoxOA.ForeColor = Color.Red;
                MessageBox.Show(this, "申请单号不能超过14位!", "注意");
            }
            else
            {
                textBoxOA.ForeColor = Color.Black;
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            if (father.Length > 0)
            {
                saveAndPrint(textBoxCar.Text.ToString(), father[1].ToString(), father[2].ToString());
            }
            
        }

        private void textBoxOA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar != 13 )  //不是按下回车键时的处理
            {
                return;
            }
            string where = " where 1=1 ";
            if (textBoxOA.Text.ToString().Trim() != string.Empty)
            {
                where = where + " and oanum = '" + textBoxOA.Text.ToString().Trim() + "' ";
            }
            if (textBoxCar.Text.ToString().Trim() != string.Empty)
            {
                where = where + " and trucknum = '" + textBoxCar.Text.ToString().Trim() + "' ";
            }
            where = where + " and isout = '0' ";


            DataTable truckDt = Sdl_FinishedProductsExchangeInTitleAdapter.GetSdl_FinishedProductsExchangeInTitleDataSet(where).Tables[0];
            if (truckDt.Rows.Count == 1)
            {
                inTitle = new Sdl_FinishedProductsExchangeTitle();
                inTitle = Sdl_FinishedProductsExchangeInTitleAdapter.GetSdl_FinishedProductsExchangeInTitle(truckDt.Rows[0]["TRUCKNUM"].ToString(), truckDt.Rows[0]["OANUM"].ToString(), truckDt.Rows[0]["TIMEFLAG"].ToString());
                textBoxCar.Text = inTitle.TRUCKNUM.ToString();
                textBoxCNum.Text = inTitle.CNUM.ToString();
                textBoxCName.Text = inTitle.CNAME.ToString();
                textBoxTType.Text = inTitle.TTYPE.ToString();
                textBoxFxqd.Text = inTitle.FXQD.ToString();
                textBoxYwy.Text = inTitle.YWY.ToString();
                textBoxXsqy.Text = inTitle.XSQY.ToString();
                textBoxXsks.Text = inTitle.XSKS.ToString();
            }
            else if (truckDt.Rows.Count > 1)
            {
                MessageBox.Show(this, "此申请单有多行数据，请补充车牌号进行精确查询!", "注意");
            }
            else
            {
                MessageBox.Show(this, "未发现此申请单!", "注意");
            }
        }

        //重新绑定界面时间
        private void resetDateTime()
        {
            textBoxEnterTime.Text = Common.GetServerDate();
        }
    }
}
