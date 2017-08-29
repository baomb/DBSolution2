using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Utility;
using SdlDB.Entity;
using SdlDB.Data;
using System.Threading;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class AccessoryAllotExitTransferOut : Form
    {
        private string[] father = new string[] { "", "", "" };
        private DataTable dtSAP = new DataTable();
        SerialPortHelper s = null;
        private string werks = string.Empty;
        private bool readPort = true;
        public AccessoryAllotExitTransferOut()
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
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
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
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("配件调拨(调出)出厂");
            this.timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-配件调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool ValidateControl(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有调拨单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataTable dtWerksCheck = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "WERKS" });
            if (dtWerksCheck.Rows.Count > 1)
            {
                MessageBox.Show(this, "调拨单行项目信息中的调入工厂必须相同！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (!(ValidateHelper.IsNumberSign(textBoxDeductNum.Text) || ValidateHelper.IsDecimalSign(textBoxDeductNum.Text)))
            //{
            //    MessageBox.Show(this, "扣杂数量应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

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

            if (dataGridViewDetails.Rows.Count > 1)
            {
                MessageBox.Show(this, "只能选择一个行项目！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            double senge = 0;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                if ((!(ValidateHelper.IsDecimal(realNum) || ValidateHelper.IsNumber(realNum))) || double.Parse(realNum) == 0)
                {
                    MessageBox.Show(this, "请输入调拨吨数,调拨吨数应为大于零的数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                double Rsenge = double.Parse(realNum);
                senge += Rsenge;

                //string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                //if (string.IsNullOrEmpty(lgort))
                //{
                //    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}
            }
            if (Math.Round(double.Parse(textBoxNet.Text), 3) != Math.Round(senge, 3))
            {
                MessageBox.Show(this, "地磅数应与调拨总数相等！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            DataGridViewCell dCell = null;
            if (dataGridViewDetails.Rows.Count != 0)
            {
                dCell = dataGridViewDetails.Rows[0].Cells[0];
            }
            dataGridViewDetails.CurrentCell = dCell;
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-配件调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                    //检测窗体数据
                    if (!ValidateControl(dtGv))
                        return;

                    Sdl_AccessoryAllotOutTitle model = new Sdl_AccessoryAllotOutTitle();
                    model = Sdl_AccessoryAllotOutTitleAdapter.GetSdl_AccessoryAllotOutTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
                    if (model == null)
                    {
                        MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (model.HSFLAG == "S")
                    {
                        MessageBox.Show(this, "该车已经调拨出厂，不能再次调拨，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //检测SAP
                    DataTable dtUpData = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                    for (int i = 0; i < dtUpData.Rows.Count; i++)
                    {
                        dtUpData.Rows[i]["RESWK"] = textBoxFactory.Text.Trim();
                        //string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                        //dtUpData.Rows[i]["SENGE"] = double.Parse(dtUpData.Rows[i]["SENGE"].ToString());
                        //dtUpData.Rows[i]["FRBNR"] = textBoxTruckNum.Text;
                    }
                    //头信息操作

                    model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                    model.GROSS = double.Parse(textBoxGross.Text);
                    model.HSFLAG = "S";
                    model.TARE = double.Parse(textBoxTare.Text);
                    model.EXITWEIGHMAN = textBoxWeighMan.Text;
                    model.RESWK = textBoxFactory.Text;
                    model.DEDUCTNUM = 0;// double.Parse(textBoxDeductNum.Text);
                    model.ALLOTFLAG = 0;
                    model.WERKS = werks;
                    Sdl_AccessoryAllotOutTitleAdapter.UpdateSdl_AccessoryAllotOutTitle(model);

                    //行项目操作
                    Sdl_AccessoryAllotOutDetail modelDetail = new Sdl_AccessoryAllotOutDetail();

                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        modelDetail.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                        modelDetail.EBELP = dtGv.Rows[i]["EBELP"].ToString();
                        modelDetail.LGORT = dtGv.Rows[i]["LGORT"].ToString();
                        modelDetail.MAKTX = dtGv.Rows[i]["MAKTX"].ToString();
                        modelDetail.MATNR = dtGv.Rows[i]["MATNR"].ToString();
                        modelDetail.MENGE = double.Parse(dtGv.Rows[i]["MENGE"].ToString());
                        modelDetail.SENGE = double.Parse(dtGv.Rows[i]["SENGE"].ToString());
                        modelDetail.WERKS = dtGv.Rows[i]["WERKS"].ToString();
                        modelDetail.TIMEFLAG = model.TIMEFLAG;
                        Sdl_AccessoryAllotOutDetailAdapter.AddSdl_AccessoryAllotOutDetail(modelDetail);
                    }
                    MessageBox.Show(this, "保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "操作失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (columnIndex == 0)
            {
                DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                DataRow dr = dt.NewRow();
                dr["EBELN"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                dr["EBELP"] = dataGridViewDetails.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                dr["MATNR"] = dataGridViewDetails.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                dr["MAKTX"] = dataGridViewDetails.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString();
                dr["MEINS"] = dataGridViewDetails.Rows[rowIndex].Cells["MEINS"].Value.ToString();
                dr["WERKS"] = dt.Rows[rowIndex]["WERKS"].ToString();
                dr["RESWK"] = dt.Rows[rowIndex]["RESWK"].ToString();
                dr["OVERNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["OVERNUM"].Value.ToString();
                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            if (columnIndex == 8)
            {
                //string ebeln = dataGridViewDetails.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                //string ebelp = dataGridViewDetails.Rows[rowIndex].Cells["EBELP"].Value.ToString();

                //DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                //DataTable dtCount = new DataSetHelper().GetNewDataTable(dt, " EBELN = '" + ebeln + "' and EBELP='" + ebelp + "'", "");
                if (dataGridViewDetails.Rows.Count == 1)
                {
                    MessageBox.Show(this, "该行不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataGridViewDetails.Rows.RemoveAt(e.RowIndex);
                //double realNum = 0;
                //for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                //{
                //    try
                //    {
                //        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                //    }
                //    catch
                //    {

                //    }
                //}
                //textBoxZMenge.Text = realNum.ToString();
                //}
                //else
                //{
                //    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void InitSelectDataBind(string truckNum)
        {
            ListDictionary la = new ListDictionary();
            la.Add("EBELN", textBoxEbeln.Text.Trim());
            la.Add("WERKS", textBoxFactory.Text.Trim());
            ListDictionary lt = new ListDictionary();
            lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,WERKS,MENGE");
            ListDictionary lr = new ListDictionary();
            DataSet dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_DB_RC", la, lt, ref lr);
            dtSAP = dsSAP.Tables[0];

            dtSAP.Columns.Add("RESWK");
            dtSAP.Columns.Add("SENGE");
            dtSAP.Columns.Add("LGORT");
            dtSAP.Columns.Add("OVERNUM");

            for (int i = 0; i < dtSAP.Rows.Count; i++)
            {
                double overNum = Sdl_AccessoryAllotOutDetailAdapter.GetSdl_AccessoryAllotOutDetailOverNum(" WHERE EBELN = '" + dtSAP.Rows[i]["EBELN"].ToString() + "' and EBELP='" + dtSAP.Rows[i]["EBELP"].ToString() + "' ");
                dtSAP.Rows[i]["OVERNUM"] = overNum.ToString();
                dtSAP.Rows[i]["RESWK"] = textBoxFactory.Text.Trim();
                werks = dtSAP.Rows[i]["WERKS"].ToString();
            }

            DataTable dtBindGv = new DataSetHelper().GetNewDataTable(dtSAP, " 1=1 ", "");
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dtBindGv;
            for (int n = 0; n < 7; n++)
            {
                dataGridViewDetails.Columns[n].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[n].ReadOnly = true;
            }
            Common.ShowTruckWeight(this.textBoxTruckNum.Text, dataGridViewHistory);
        }

        private void BindEnterData()
        {
            Sdl_AccessoryAllotOutTitle title = Sdl_AccessoryAllotOutTitleAdapter.GetSdl_AccessoryAllotOutTitle(textBoxTruckNum.Text, father[2].ToString());
            if (title != null)
            {
                if (!CheckDB(title))
                {
                    return;
                }
                textBoxTare.Text = title.TARE.ToString();
                textBoxDBNum.Text = title.DBNUM;
            }
        }

        private bool CheckDB(Sdl_AccessoryAllotOutTitle title)
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = title.DBNUM;
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

        private void textBoxTruckNum_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "AccessoryAllotTransferOut");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                textBoxTruckNum.Text = father[0].ToString();
                textBoxEbeln.Text = father[1].ToString();
                InitSelectDataBind(textBoxTruckNum.Text);
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show("没有该车的调拨单！");
                    return;
                }
                BindEnterData();
            }
        }

        private void textBoxTruckNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string truckNum = textBoxTruckNum.Text;
                InitSelectDataBind(truckNum);
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show("没有该车的调拨单！");
                    return;
                }
                BindEnterData();
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

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空车出厂操作吗?", "史丹利地磅系统-配件调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //if (!(ValidateHelper.IsDecimalSign(textBoxDeductNum.Text) || ValidateHelper.IsNumberSign(textBoxDeductNum.Text)))
                //{
                //    MessageBox.Show(this, "扣杂数量应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                double netValue = double.Parse(textBoxNet.Text);

                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-配件调拨(调出)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                //头信息操作
                Sdl_AccessoryAllotOutTitle model = new Sdl_AccessoryAllotOutTitle();
                model = Sdl_AccessoryAllotOutTitleAdapter.GetSdl_AccessoryAllotOutTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
                if (model == null)
                {
                    MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (model.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经调拨出厂，不能再次调拨，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                model.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                model.GROSS = double.Parse(textBoxGross.Text);
                model.HSFLAG = "S";
                model.TARE = double.Parse(textBoxTare.Text);
                //model.ENTERWEIGHMAN = textBoxWeighMan.Text;
                model.EXITWEIGHMAN = textBoxWeighMan.Text;
                model.RESWK = textBoxFactory.Text;
                model.DEDUCTNUM = 0;// double.Parse(textBoxDeductNum.Text);
                model.EXITFLAG = 1;
                model.ALLOTFLAG = 1;
                model.WERKS = werks;
                Sdl_AccessoryAllotOutTitleAdapter.UpdateSdl_AccessoryAllotOutTitle(model);

                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string currentValue = dataGridViewDetails.Rows[rowIndex].Cells["SENGE"].Value.ToString();
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 7)
                {
                    if ((!ValidateHelper.IsDecimal(currentValue) && !ValidateHelper.IsNumber(currentValue)))
                    {
                        if (dataGridViewDetails.CurrentCell.FormattedValue.ToString() == "")
                            return;
                        MessageBox.Show(this, "转出数量应为数值", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //double realNum = 0;
                        //for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                        //{
                        //    try
                        //    {
                        //        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                        //    }
                        //    catch
                        //    {
                        //    }
                        //}
                        //textBoxZMenge.Text = realNum.ToString();
                    }
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
