using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;
using System.Threading;
using SdlDB.Utility;
using System.Collections.Specialized;
using System.Collections;

namespace DBSolution
{
    public partial class ProductReturnRailwayEnter : Form
    {
        private string[] father = new string[] { "", "" };
        private DataTable dtSapDetail = new DataTable();
        private string selCarNum = "";
        private const string AUGRU = "001";
        SerialPortHelper s = null;
        private bool readPort = true;
        public ProductReturnRailwayEnter()
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
            this.textBoxEnterTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxPrompt.Text = Common.GetHelpStr("总公司成品铁运退货入厂");
            this.timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实退出该界面吗?", "史丹利地磅系统-总公司成品铁运退货入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private bool IsSameMerchant()
        {
            string kunnr = string.Empty;
            bool validate = true;
            bool firstkunnr = false;
            for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
            {
                if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                {
                    if (!firstkunnr)
                        kunnr = dataGridViewSelect.Rows[i].Cells["SELECT_KUNNR"].Value.ToString();
                    firstkunnr = true;
                    if (kunnr != dataGridViewSelect.Rows[i].Cells["SELECT_KUNNR"].Value.ToString())
                    {
                        validate = false;
                        break;
                    }
                }
            }
            return validate;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-总公司成品退货进厂(铁运退货)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请选择退货订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (father[1].ToString() == "")
                {
                    DataTable dtenter = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (!IsSameMerchant())
                //{
                //    MessageBox.Show(this, "请选择相同的经销商", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                try
                {
                    for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                    {
                        if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                        {
                            Sdl_ProductReturnRailway fps = new Sdl_ProductReturnRailway();
                            fps.VBELN = dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString();
                            fps.TIMEFLAG = textBoxEnterTime.Text;
                            fps.ENTERTIME = DateTime.Parse(textBoxEnterTime.Text);
                            fps.HSFLAG = "H";
                            fps.KUNNR = dataGridViewSelect.Rows[i].Cells["SELECT_KUNNR"].Value.ToString();
                            fps.NAME1 = dataGridViewSelect.Rows[i].Cells["SELECT_NAME1"].Value.ToString();
                            fps.GROSS = Convert.ToDouble(textBoxGross.Text);
                            fps.TRUCKNUM = textBoxCar.Text;
                            fps.ENTERWEIGHMAN = textBoxWeighMan.Text;
                            fps.WERKS = textBoxFactory.Text;
                            fps.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                            Sdl_ProductReturnRailwayAdapter.AddSdl_ProductReturnRailway(fps);
                        }
                    }
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!ValidateHelper.IsVehiclenumber(textBoxCar.Text))
                {
                    MessageBox.Show(this, "输入的车牌号格式不正确，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InitSelectDataBind();

                if (father[0].ToString() != "")
                {
                    BindEditData();
                }

                if (dataGridViewSelect.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有该工厂的退货单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selCarNum = textBoxCar.Text;
            }
        }

        private void BindEditData()
        {
            DataTable dtBefore = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySetByFeild(new string[] { "VBELN" }, " where trucknum='" + textBoxCar.Text + "' and timeflag='" + father[1].ToString() + "' and HSFLAG = 'H' ").Tables[0];
            ArrayList arrayStr = new ArrayList();
            foreach (DataRow dr in dtBefore.Rows)
            {
                arrayStr.Add(dr["VBELN"].ToString());
            }
            InitDetailBind(arrayStr);

            for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
            {
                for (int j = 0; j < arrayStr.Count; j++)
                {
                    if (dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString() == arrayStr[j].ToString())
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewSelect.Rows[i].Cells["chk"];
                        chk.Value = true;
                    }
                }
            }
            BindEnterData();
        }

        private void BindEnterData()
        {
            Sdl_ProductReturnRailway title = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailway(textBoxCar.Text, father[1].ToString());
            if (title != null)
            {
                textBoxGross.Text = title.GROSS.ToString();
            }
        }

        private void InitSelectDataBind()
        {
            try
            {
                ListDictionary la = new ListDictionary();
                la.Add("AUGRU", AUGRU);
                la.Add("WERKS", textBoxFactory.Text);
                ListDictionary lt = new ListDictionary();
                lt.Add("ZLIPS", "VBELN,POSNR,MATNR,MAKTX,KUNNR,NAME1,LFIMG,ZFIMG");
                ListDictionary lr = new ListDictionary();
                DataSet ds = SAPHelper.InvokSAPFun("Z_SDL_FERT_MUTUAL_RE_RC", la, lt, ref lr);

                DataTable dtSap = new DataSetHelper().SelectDistinct("dtTitle", ds.Tables[0], new string[] { "VBELN", "KUNNR", "NAME1" });

                dtSapDetail = new DataSetHelper().SelectDistinct("dtDetail", ds.Tables[0], new string[] { "VBELN", "POSNR", "MATNR", "MAKTX", "LFIMG", "ZFIMG" });
                dtSapDetail.Columns.Add("REALLFIMG");
                dtSapDetail.Columns.Add("REALZFIMG");
                dtSapDetail.Columns.Add("WERKS");

                dataGridViewSelect.AutoGenerateColumns = false;
                dataGridViewSelect.DataSource = dtSap;

                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void dataGridViewSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

            ArrayList arrayStr = new ArrayList();
            for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
            {
                if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                {
                    arrayStr.Add(dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString());
                }
            }
            InitDetailBind(arrayStr);
        }

        private void InitDetailBind(ArrayList arrayVbeln)
        {
            string where = GetDataTableWhere(arrayVbeln);
            DataTable dtSelect = new DataSetHelper().GetNewDataTable(dtSapDetail, where, "");
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dtSelect;

            dataGridViewDetails.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            dataGridViewDetails.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
            dataGridViewDetails.Columns[7].DefaultCellStyle.BackColor = Color.Gray;
        }

        private string GetDataTableWhere(ArrayList arrayVbeln)
        {
            string where = "''";
            for (int j = 0; j < arrayVbeln.Count; j++)
            {
                where += ",'" + arrayVbeln[j].ToString() + "'";
            }
            return " VBELN IN (" + where + ")";
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-总公司成品退货进厂(铁运退货)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (father[0].ToString() == "")
                {
                    MessageBox.Show(this, "请选择要编辑的入厂信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "请选择退货订单", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (father[1].ToString() == "")
                {
                    DataTable dtenter = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySetByFeild(new string[] { "ENTERTIME" }, " where trucknum='" + textBoxCar.Text + "' and HSFLAG = 'H' ").Tables[0];
                    if (dtenter.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该车已经与" + DateTime.Parse(dtenter.Rows[0]["ENTERTIME"].ToString()).ToString("yyyy-MM-dd hh:mm") + "进厂,还未出厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (!IsSameMerchant())
                //{
                //    MessageBox.Show(this, "请选择相同的经销商", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (textBoxCar.Text.Trim() != selCarNum)
                {
                    MessageBox.Show(this, "输入的车牌号已做修改，请重新调用交货单信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
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
                    //头信息操作
                    try
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.AppendFormat(" delete from Sdl_ProductReturnRailway where  trucknum='{0}' and timeFlag='{1}' ; ", textBoxCar.Text, father[1].ToString());
                        CommonOper.ExecuteSql(sql.ToString());
                        for (int i = 0; i < dataGridViewSelect.Rows.Count; i++)
                        {
                            if (dataGridViewSelect.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                Sdl_ProductReturnRailway fpst = new Sdl_ProductReturnRailway();
                                fpst.VBELN = dataGridViewSelect.Rows[i].Cells["SELECT_VBELN"].Value.ToString();
                                fpst.TIMEFLAG = modelEnter.TIMEFLAG;
                                fpst.ENTERTIME = modelEnter.ENTERTIME;
                                fpst.HSFLAG = "H";
                                fpst.KUNNR = dataGridViewSelect.Rows[i].Cells["SELECT_KUNNR"].Value.ToString();
                                fpst.NAME1 = dataGridViewSelect.Rows[i].Cells["SELECT_NAME1"].Value.ToString();
                                fpst.GROSS = modelEnter.GROSS;
                                fpst.TRUCKNUM = textBoxCar.Text.ToUpper();
                                fpst.ENTERWEIGHMAN = modelEnter.ENTERWEIGHMAN;
                                fpst.WERKS = modelEnter.WERKS;
                                fpst.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                                Sdl_ProductReturnRailwayAdapter.AddSdl_ProductReturnRailway(fpst);
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

        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "ProductReturnRailway");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                timer.Stop();
                this.textBoxCar.Text = father[0].ToString();
                if (textBoxCar.Text.Trim() != "")
                {
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonEdit.Enabled = true;
                    textBoxGross.ReadOnly = true;
                }
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

        private void textBoxCar_TextChanged(object sender, EventArgs e)
        {
            textBoxCar.Text = textBoxCar.Text.ToUpper();
            textBoxCar.SelectionStart = textBoxCar.Text.Length;
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
