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
using SdlDB.Utility;
using System.Threading;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class AccessoryAllotExitTransferIn : Form
    {
        private string[] father = new string[] { "", "", "", "" };
        private DataTable dtSAP = new DataTable();
        SerialPortHelper s = null;
        double yengeSum = 0;
        double balanceValue = 0;
        private bool readPort = true;
        public AccessoryAllotExitTransferIn()
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
                textBoxTare.ReadOnly = true;
            }
            else
            {
                textBoxTare.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("配件调拨(调入)出厂");
            this.timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-配件调拨(调入)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

            DataTable dtWerksCheck = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "RESWK" });
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
                MessageBox.Show(this, "请选择一行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            double senge = 0;
            double yenge = 0;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                string YNum = dataGridViewDetails.Rows[i].Cells["YENGE"].Value.ToString();
                if ((!(ValidateHelper.IsDecimal(realNum) || ValidateHelper.IsNumber(realNum))) || double.Parse(realNum) == 0)
                {
                    MessageBox.Show(this, "请输入调入吨数,调入吨数应为大于零的数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                double Rsenge = double.Parse(realNum);
                senge += Rsenge;
                yenge += double.Parse(YNum);

            }

            if (Math.Round(double.Parse(textBoxNet.Text), 3) != Math.Round(senge, 3))
            {
                MessageBox.Show(this, "地磅数应与调拨总数相等！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            balanceValue = Math.Round(double.Parse(textBoxNet.Text) - yenge, 3);
            string tipStr = string.Empty;
            if (balanceValue == 0)
            {
                tipStr = "该批物料调出数量与调入数量完全相符合,确实要保存吗?";
            }
            else if (balanceValue > 0)
            {
                tipStr = "该批物料涨称" + balanceValue.ToString() + "吨,确实要保存吗?";
            }
            else
            {
                tipStr = "该批物料亏称" + Math.Abs(balanceValue).ToString() + "吨,确实要保存吗?";
            }

            if (MessageBox.Show(tipStr, "史丹利地磅系统-配件调拨(调入)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
            else
            {
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

                    Sdl_AccessoryAllotInTitle model = new Sdl_AccessoryAllotInTitle();
                    model = Sdl_AccessoryAllotInTitleAdapter.GetSdl_AccessoryAllotInTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
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
                    DataTable dtUpData = new DataSetHelper().GetNewSortDataTable(dtGv, " 1=1 ", "EBELN,EBELP,MATNR ");
                    for (int i = 0; i < dtUpData.Rows.Count; i++)
                    {
                        dtUpData.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();

                        //string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                        //dtUpData.Rows[i]["SFIMG"] = double.Parse(dtUpData.Rows[i]["REALZFIMG"].ToString()) * GetMatnrWeight(matnr) / 1000;
                    }



                    //头信息操作

                    model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                    model.GROSS = double.Parse(textBoxGross.Text);
                    model.HSFLAG = "S";
                    model.TARE = double.Parse(textBoxTare.Text);
                    model.EXITWEIGHMAN = textBoxWeighMan.Text;
                    model.DEDUCTNUM = balanceValue;// double.Parse(textBoxDeductNum.Text);
                    model.WERKS = textBoxFactory.Text;
                    model.DBNUM = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    Sdl_AccessoryAllotInTitleAdapter.UpdateSdl_AccessoryAllotInTitle(model);

                    //行项目操作
                    Sdl_AccessoryAllotInDetail modelDetail = new Sdl_AccessoryAllotInDetail();

                    for (int i = 0; i < dtGv.Rows.Count; i++)
                    {
                        modelDetail.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                        modelDetail.EBELP = dtGv.Rows[i]["EBELP"].ToString();
                        modelDetail.LGORT = dtGv.Rows[i]["LGORT"].ToString();
                        modelDetail.MAKTX = dtGv.Rows[i]["MAKTX"].ToString();
                        modelDetail.MATNR = dtGv.Rows[i]["MATNR"].ToString();
                        modelDetail.MENGE = double.Parse(dtGv.Rows[i]["MENGE"].ToString());
                        modelDetail.SENGE = double.Parse(dtGv.Rows[i]["SENGE"].ToString());
                        modelDetail.YENGE = double.Parse(dtGv.Rows[i]["YENGE"].ToString());
                        modelDetail.WERKS = dtGv.Rows[i]["WERKS"].ToString();
                        modelDetail.TIMEFLAG = model.TIMEFLAG;
                        Sdl_AccessoryAllotInDetailAdapter.AddSdl_AccessoryAllotInDetail(modelDetail);
                    }

                    MessageBox.Show(this, "保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "操作失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dr["YENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["YENGE"].Value.ToString();
                dr["RESWK"] = dt.Rows[rowIndex]["RESWK"].ToString();

                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            if (columnIndex == 8)
            {

                if (dataGridViewDetails.Rows.Count > 1)
                {
                    dataGridViewDetails.Rows.RemoveAt(e.RowIndex);
                    //double realNum = 0;
                    //double engeSum = 0;
                    //double netValue = double.Parse(textBoxNet.Text);
                    //for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    //{
                    //    try
                    //    {
                    //        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    //        engeSum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    //        netValue = double.Parse(textBoxNet.Text);
                    //    }
                    //    catch
                    //    {

                    //    }
                    //}
                    //yengeSum = engeSum;

                }
                else
                {
                    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBoxTruckNum_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "AccessoryAllotTransferIn");
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

        private void InitSelectDataBind(string truckNum)
        {
            ListDictionary la = new ListDictionary();
            la.Add("EBELN", textBoxEbeln.Text.Trim());
            la.Add("WERKS", textBoxFactory.Text.Trim());
            ListDictionary lt = new ListDictionary();
            lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,RESWK,MENGE");
            ListDictionary lr = new ListDictionary();
            DataSet dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_DB_RC2", la, lt, ref lr);
            dtSAP = dsSAP.Tables[0];

            dtSAP.Columns.Add("SENGE");
            dtSAP.Columns.Add("YENGE");

            dtSAP.Columns.Add("LGORT");
            dtSAP.Columns.Add("WERKS");

            for (int i = 0; i < dtSAP.Rows.Count; i++)
            {
                DataTable dtH = Sdl_AccessoryAllotOutDetailAdapter.GetSdl_AccessoryAllotOutDetailMengeAndSfimg(" WHERE EBELN = '" + dtSAP.Rows[i]["EBELN"].ToString()
                    + "' and EBELP='" + dtSAP.Rows[i]["EBELP"].ToString() + "' and TimeFlag='" + father[3].ToString() + "' ");
                dtSAP.Rows[i]["YENGE"] = dtH.Rows[0]["SENGE"].ToString();
                dtSAP.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();

                if (Math.Round(double.Parse(dtH.Rows[0]["SENGE"].ToString()), 3) == 0)
                {
                    dtSAP.Rows.RemoveAt(i);
                    i = i - 1;
                }
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
            Sdl_AccessoryAllotInTitle title = Sdl_AccessoryAllotInTitleAdapter.GetSdl_AccessoryAllotInTitle(textBoxTruckNum.Text, father[2].ToString());
            if (title != null)
            {
                if (!CheckDB(title))
                {
                    return;
                }
                this.textBoxDBNum.Text = title.DBNUM;
                textBoxGross.Text = title.GROSS.ToString();
            }
        }

        private bool CheckDB(Sdl_AccessoryAllotInTitle title)
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

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text), 3).ToString();
                //textBoxDeductNum.Text = Math.Round(double.Parse(textBoxGross.Text) - yengeSum, 3).ToString();
            }
            catch
            {

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

        private void textBoxDeductNum_TextChanged(object sender, EventArgs e)
        {

            //if ((!(ValidateHelper.IsNumberSign(textBoxDeductNum.Text) ||
            //   ValidateHelper.IsDecimalSign(textBoxDeductNum.Text)))
            //   && textBoxDeductNum.Text != "-" && textBoxDeductNum.Text.Trim() != "" && textBoxDeductNum.Text.IndexOf('.') <= 0)
            //{
            //    this.textBoxDeductNum.Text = "0";
            //    textBoxDeductNum.Focus();
            //}
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认重车出厂操作吗?", "史丹利地磅系统-配件调拨(调入)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                double netValue = double.Parse(textBoxNet.Text);

                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("重车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-配件调拨(调入)出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                //if (!(ValidateHelper.IsDecimalSign(textBoxDeductNum.Text) || ValidateHelper.IsNumberSign(textBoxDeductNum.Text)))
                //{
                //    MessageBox.Show(this, "扣杂数量应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //double balanceValue = Common.GetBalanceValue();
                //if (Math.Round(Convert.ToDouble(textBoxDeductNum.Text), 3) > Math.Round(balanceValue, 3))
                //{
                //    MessageBox.Show(this, "扣杂不在误差" + balanceValue + "吨允许范围内", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //if (Math.Round(double.Parse(textBoxNet.Text) + double.Parse(textBoxDeductNum.Text), 3) != 0)
                //{
                //    MessageBox.Show(this, "空车出厂时，毛重与皮重数值应该相等，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //头信息操作
                Sdl_AccessoryAllotInTitle model = new Sdl_AccessoryAllotInTitle();
                model = Sdl_AccessoryAllotInTitleAdapter.GetSdl_AccessoryAllotInTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
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
                model.EXITWEIGHMAN = textBoxWeighMan.Text;
                model.DEDUCTNUM = 0;// double.Parse(textBoxDeductNum.Text);
                model.EXITFLAG = 1;
                Sdl_AccessoryAllotInTitleAdapter.UpdateSdl_AccessoryAllotInTitle(model);

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
                        MessageBox.Show(this, "转入数量应为数值", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //double realNum = 0;
                        //double engeSum = 0;
                        //double netValue = 0;
                        //for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                        //{
                        //    try
                        //    {
                        //        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                        //        engeSum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                        //        netValue = double.Parse(textBoxNet.Text);
                        //    }
                        //    catch
                        //    {

                        //    }
                        //}
                        //yengeSum = engeSum;
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
