using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using SdlDB.Data;
using SdlDB.Entity;
using System.Threading;
using SdlDB.Utility;
using System.Collections;

namespace DBSolution
{
    public partial class SubFinishedProductsSaleEnter : Form
    {
        private string[] father = new string[] { "", "" };
        private DataTable dtSapDetail = new DataTable();
        private DataTable dtSelect = new DataTable();
        private string selCarNum = "";
        SerialPortHelper s = null;
        private bool readPort = true;
        private string strWerks = "";
        public SubFinishedProductsSaleEnter()
        {
            InitializeComponent();
            Common.PlayWelcome();
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
            strWerks = sysSetting.WERKS;
            this.textBoxFactory.Text = strWerks;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxEnterTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxPrompt.Text = Common.GetHelpStr("子公司成品销售入厂");
            this.timer.Start();
        }

        private void InitSelectDataBind()
        {
            try
            {
                string truckNum = textBoxCar.Text.Trim();
                if (father[1].ToString() == "")
                {
                    DataTable dtenter = Sdl_FinishedProductsSaleTitleAdapter.
                       GetSdl_FinishedProductsSaleTitleSetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + truckNum + "' and HS_FLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                ListDictionary la = new ListDictionary();
                la.Add("NUMBR", textBoxCar.Text);
                la.Add("WERKS", strWerks);
                ListDictionary lt = new ListDictionary();
                lt.Add("ZLIKP", "VBELN,KUNNR,NAME1");
                lt.Add("ZLIPS", "VBELN,POSNR,MATNR,MAKTX,LFIMG,ZFIMG,WERKS,LGORT,SFIMG");

                ListDictionary lr = new ListDictionary();
                DataSet ds = SAPHelper.InvokSAPFun("Z_SDL_FERT_MUTUAL_ZB_RC", la, lt, ref lr);
                DataTable dtSap = ds.Tables[0];

                dtSapDetail = ds.Tables[1];
                //DataTable dtGv = new DataSetHelper().GetNewDataTable(dtSap, " 1=1 ", "");
                dataGridViewSelect.AutoGenerateColumns = false;
                dataGridViewSelect.DataSource = dtSap;

                if (father[1].ToString() != "")
                {
                    DataTable dtBefore = Sdl_FinishedProductsSaleTitleAdapter.
                         GetSdl_FinishedProductsSaleTitleSetByFeild(new string[] { "VBELN" }, " where trucknum='" + truckNum + "' and timeflag='" + father[1].ToString() + "' and HS_FLAG = 'H' ").Tables[0];

                    string strSel = "''";
                    ArrayList arrayStr = new ArrayList();
                    foreach (DataRow dr in dtBefore.Rows)
                    {
                        arrayStr.Add(dr["VBELN"].ToString());
                        strSel += "," + "'" + dr["VBELN"].ToString() + "'";
                    }
                    InitDetailBind(" (" + strSel + ")");

                    for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                    {
                        for (int j = 0; j < arrayStr.Count; j++)
                        {
                            if (dataGridViewSelect.Rows[i].Cells["VBELN"].Value.ToString() == arrayStr[j].ToString())
                            {
                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewSelect.Rows[i].Cells["chk"];
                                chk.Value = true;
                            }
                        }
                    }
                    BindEnterData();
                }

                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void BindEnterData()
        {
            Sdl_FinishedProductsSaleTitle title = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, father[1].ToString());
            if (title != null)
            {
                textBoxTare.Text = title.TARE.ToString();
            }
        }

        private void InitDetailBind(string where)
        {
            dtSelect = new DataSetHelper().GetNewDataTable(dtSapDetail, " VBELN IN " + where, "");

            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dtSelect;

            dataGridViewDetails.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
            dataGridViewDetails.Columns[7].DefaultCellStyle.BackColor = Color.Gray;
        }

        private void dataGridViewSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            try
            {
                string strSel = "''";
                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        strSel += "," + "'" + dataGridViewSelect.Rows[i].Cells["VBELN"].Value.ToString() + "'";
                    }
                }
                InitDetailBind(" (" + strSel + ")");
            }
            catch
            {
            }

        }

        private void dataGridViewSelect_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void textBoxCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InitSelectDataBind();
                if (dataGridViewSelect.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有该车的交货单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selCarNum = textBoxCar.Text;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-子公司成品销售入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请选择交货订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() != selCarNum)
                {
                    MessageBox.Show(this, "输入的车牌号已做修改，请重新调用交货单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string kunnr = string.Empty;
                bool validate = true;
                bool firstkunnr = false;
                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        if (!firstkunnr)
                            kunnr = dataGridViewSelect.Rows[i].Cells["KUNNR"].Value.ToString();
                        firstkunnr = true;
                        if (kunnr != dataGridViewSelect.Rows[i].Cells["KUNNR"].Value.ToString())
                        {
                            validate = false;
                            break;
                        }
                    }
                }

                if (!validate)
                {
                    MessageBox.Show(this, "请选择相同的经销商", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ListDictionary ltPara = new ListDictionary();
                    DataTable dtNew = new DataTable();

                    dtNew.Columns.Add("VBELN");
                    dtNew.Columns.Add("ERDAT");
                    dtNew.Columns.Add("ERZET");
                    dtNew.Columns.Add("PZ");
                    dtNew.Columns.Add("MZ");
                    dtNew.Columns.Add("NRDAT");
                    dtNew.Columns.Add("NRZET");
                    dtNew.Columns.Add("NUMBR");
                    dtNew.Columns.Add("FLAG");
                    dtNew.Columns.Add("EFLAG");

                    DataRow dr;
                    for (int i = 0; i < dtSelect.Rows.Count; i++)
                    {
                        dr = dtNew.NewRow();
                        dr["VBELN"] = dtSelect.Rows[i]["VBELN"].ToString(); ;
                        dr["PZ"] = textBoxTare.Text;
                        dr["NUMBR"] = textBoxCar.Text;
                        dr["FLAG"] = "0";
                        dtNew.Rows.Add(dr);
                    }

                    ListDictionary ltParaTb = new ListDictionary();
                    ltParaTb.Add("WLINFO", dtNew);
                    ListDictionary lt = new ListDictionary();
                    lt.Add("MESG", "NOTE");
                    ListDictionary lr = new ListDictionary();
                    //使用SAP通信
                    DataTable dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_WL_INFO_UPDATE", ltPara, ltParaTb, lt, ref lr).Tables[0];

                    string str = string.Empty;
                    if (dtInfo == null || dtInfo.Rows.Count <= 0 || dtInfo.Rows[0][0].ToString() != "保存入厂信息成功！")
                    {
                        MessageBox.Show(this, "往SAP写入厂信息失败，请检查原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "往SAP写入厂信息失败，请检查原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                    {
                        if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                        {
                            Sdl_FinishedProductsSaleTitle fps = new Sdl_FinishedProductsSaleTitle();
                            fps.VBELN = dataGridViewSelect.Rows[i].Cells["VBELN"].Value.ToString();
                            fps.TIMEFLAG = textBoxEnterTime.Text;
                            fps.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                            fps.HS_FLAG = "H";
                            fps.KUNNR = dataGridViewSelect.Rows[i].Cells["KUNNR"].Value.ToString();
                            fps.NAME1 = dataGridViewSelect.Rows[i].Cells["NAME1"].Value.ToString();
                            fps.TARE = Convert.ToSingle(textBoxTare.Text);
                            fps.TRUCKNUM = textBoxCar.Text;
                            fps.WEIGHMAN = textBoxWeighMan.Text;
                            fps.WERKS = strWerks;
                            fps.NOTE = textBoxNote.Text;
                            fps.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                            fps.CONTRACT = "";
                            Sdl_FinishedProductsSaleTitleAdapter.AddSdl_FinishedProductsSaleTitle(fps);
                        }
                    }
                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                    tw.TARE = Convert.ToSingle(textBoxTare.Text);
                    tw.TIMEFLAG = textBoxEnterTime.Text;
                    tw.TRUCKNUM = textBoxCar.Text.Trim();
                    tw.WERKS = strWerks;
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出吗?", "史丹利地磅系统-子公司成品销售入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "ProductSale");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                timer.Stop();
                this.textBoxCar.Text = father[0].ToString();
                if (textBoxCar.Text.Trim() != "")
                {
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonEdit.Enabled = true;
                    textBoxTare.ReadOnly = true;
                }
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-成品销售入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                if (dataGridViewSelect.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有交货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有交货单详细信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() != selCarNum)
                {
                    MessageBox.Show(this, "输入的车牌号已做修改，请重新调用交货单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxCar.Text.Trim() != father[0].ToString())
                {
                    MessageBox.Show(this, "输入的车牌号与选择的车牌号不相同，请核实", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string kunnr = string.Empty;
                bool validate = true;
                bool firstkunnr = false;
                for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                {
                    if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        if (!firstkunnr)
                            kunnr = dataGridViewSelect.Rows[i].Cells["KUNNR"].Value.ToString();
                        firstkunnr = true;
                        if (kunnr != dataGridViewSelect.Rows[i].Cells["KUNNR"].Value.ToString())
                        {
                            validate = false;
                            break;
                        }
                    }
                }

                if (!validate)
                {
                    MessageBox.Show(this, "请选择相同的经销商", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    Sdl_FinishedProductsSaleTitle modelEnter = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(textBoxCar.Text, father[1].ToString());
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
                        StringBuilder sql = new StringBuilder();
                        sql.AppendFormat(" delete from Sdl_FinishedProductsSaleTitle where  trucknum='{0}' and timeFlag='{1}' ; ", textBoxCar.Text, father[1].ToString());
                        CommonOper.ExecuteSql(sql.ToString());
                        for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                        {
                            if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                Sdl_FinishedProductsSaleTitle fpst = new Sdl_FinishedProductsSaleTitle();
                                fpst.VBELN = dataGridViewSelect.Rows[i].Cells["VBELN"].Value.ToString();
                                fpst.TIMEFLAG = modelEnter.TIMEFLAG;
                                fpst.ENTERTIME = modelEnter.ENTERTIME;
                                fpst.HS_FLAG = "H";
                                fpst.KUNNR = dataGridViewSelect.Rows[i].Cells["KUNNR"].Value.ToString();
                                fpst.NAME1 = dataGridViewSelect.Rows[i].Cells["NAME1"].Value.ToString();
                                fpst.TARE = modelEnter.TARE;
                                fpst.TRUCKNUM = textBoxCar.Text.ToUpper();
                                fpst.WEIGHMAN = modelEnter.WEIGHMAN;
                                fpst.WERKS = strWerks;
                                fpst.NOTE = modelEnter.NOTE;
                                fpst.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                                Sdl_FinishedProductsSaleTitleAdapter.AddSdl_FinishedProductsSaleTitle(fpst);
                            }
                        }
                        MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
