using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;
using System.Threading;
using SdlDB.Utility;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class AccessoryReturnExit : Form
    {
        private string[] father = new string[] { "", "", "" };
        private DataTable dtSAP = new DataTable();
        SerialPortHelper s = null;
        private bool readPort = true;
        public AccessoryReturnExit()
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
            this.textBoxExitWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("配件退货出厂");
            this.timer.Start();
        }
        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-配件退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private bool ValidateControl(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有订单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
            if (!(ValidateHelper.IsDecimalSign(textBoxDeductNum.Text) || ValidateHelper.IsNumberSign(textBoxDeductNum.Text)))
            {
                MessageBox.Show(this, "差异数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool isSelect = false;
            double selectNum = 0;
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                if (dataGridViewDetails.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                {
                    isSelect = true;
                    string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                    string menge = dataGridViewDetails.Rows[i].Cells["MENGE"].Value.ToString();
                    if ((!(ValidateHelper.IsDecimal(realNum) || ValidateHelper.IsNumber(realNum))) || double.Parse(realNum) == 0)
                    {
                        MessageBox.Show(this, "请输入实退数量,实退数量应为大于零的数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        selectNum = Math.Round(double.Parse(realNum), 3);
                        if (selectNum > Math.Round(double.Parse(menge), 3))
                        {
                            MessageBox.Show(this, "实退数量不能大于订单数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    break;
                }
            }
            if (!isSelect)
            {
                MessageBox.Show(this, "请选择一个行项目！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            double balanceValue = Math.Round(double.Parse(textBoxNet.Text) - selectNum, 3);

            string strTip = string.Empty;
            if (balanceValue > 0)
            {
                strTip = "实退数量与实际过磅数量不相等,该批物料涨吨" + Math.Abs(balanceValue).ToString() + ",确认操作吗？";
            }
            else
            {
                strTip = "实退数量与实际过磅数量不相等,该批物料亏吨" + Math.Abs(balanceValue).ToString() + ",确认操作吗？";
            }


            if (Math.Round(double.Parse(textBoxNet.Text), 3) != selectNum)
            {
                if (MessageBox.Show(strTip, "史丹利地磅系统-配件退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                {
                    return false;
                }
            }
            //if (selectNum > double.Parse(textBoxNet.Text))
            //{
            //    MessageBox.Show(this, "实退数量不能大于地磅数量，请修改订单！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}



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
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-配件退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                    Sdl_AccessoryReturnTitle model = new Sdl_AccessoryReturnTitle();
                    model = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
                    if (model == null)
                    {
                        MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (model.HSFLAG == "S")
                    {
                        MessageBox.Show(this, "该车已经退货出厂，不能再次退货，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //头信息操作
                    model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                    model.GROSS = double.Parse(textBoxGross.Text);
                    model.HSFLAG = "S";
                    model.TARE = double.Parse(textBoxTare.Text);
                    model.EXITWEIGHMAN = textBoxExitWeighMan.Text;
                    model.WERKS = textBoxFactory.Text;
                    model.DEDUCTNUM = double.Parse(textBoxDeductNum.Text);
                    Sdl_AccessoryReturnTitleAdapter.UpdateSdl_AccessoryReturnTitle(model);

                    //行项目操作
                    Sdl_AccessoryReturnDetail modelDetail = new Sdl_AccessoryReturnDetail();

                    for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                    {
                        if (dataGridViewDetails.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                        {
                            modelDetail.EBELN = dataGridViewDetails.Rows[i].Cells["EBELN"].Value.ToString();
                            modelDetail.EBELP = dataGridViewDetails.Rows[i].Cells["EBELP"].Value.ToString();
                            modelDetail.MAKTX = dataGridViewDetails.Rows[i].Cells["MAKTX"].Value.ToString();
                            modelDetail.MATNR = dataGridViewDetails.Rows[i].Cells["MATNR"].Value.ToString();
                            modelDetail.LIFNR = dataGridViewDetails.Rows[i].Cells["LIFNR"].Value.ToString();
                            modelDetail.NAME1 = dataGridViewDetails.Rows[i].Cells["NAME1"].Value.ToString();
                            modelDetail.MENGE = double.Parse(dataGridViewDetails.Rows[i].Cells["MENGE"].Value.ToString());
                            modelDetail.ZFIMG = 0;
                            modelDetail.SENGE = double.Parse(dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString());
                            modelDetail.REALZFIMG = 0;
                            modelDetail.TIMEFLAG = model.TIMEFLAG;
                            Sdl_AccessoryReturnDetailAdapter.AddSdl_AccessoryReturnDetail(modelDetail);
                        }
                    }
                    MessageBox.Show(this, "保存成功!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Common.PlayGoodBye();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "操作失败，请联系管理员!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void textBoxTruckNum_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "AccessoryReturn");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                textBoxTruckNum.Text = father[0].ToString();
                textBoxEbeln.Text = father[1].ToString();

                InitSelectDataBind(textBoxTruckNum.Text);
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show("没有该车的退货单！");
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
            lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,LIFNR,NAME1,MENGE");
            ListDictionary lr = new ListDictionary();
            DataSet dsSAP = SAPHelper.InvokSAPFun("Z_SDL_ROH_MUTUAL_RC_RE", la, lt, ref lr);
            DataTable dtSAP = dsSAP.Tables[0];

            dtSAP.Columns.Add("SENGE");
            dtSAP.Columns.Add("LGORT");
            dtSAP.Columns.Add("WERKS");
            dtSAP.Columns.Add("OVERNUM");

            for (int i = 0; i < dtSAP.Rows.Count; i++)
            {
                double overNum = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetailOverNum(" WHERE EBELN = '" + dtSAP.Rows[i]["EBELN"].ToString() + "' and EBELP='" + dtSAP.Rows[i]["EBELP"].ToString() + "' ");
                dtSAP.Rows[i]["OVERNUM"] = overNum.ToString();
                dtSAP.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();
            }

            DataTable dtBindGv = new DataSetHelper().GetNewDataTable(dtSAP, " 1=1 ", "");
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dtBindGv;
            for (int n = 0; n < 9; n++)
            {
                dataGridViewDetails.Columns[n].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewDetails.Columns[n].ReadOnly = true;
            }
            Common.ShowTruckWeight(this.textBoxTruckNum.Text, dataGridViewHistory);
        }

        private void BindEnterData()
        {
            Sdl_AccessoryReturnTitle title = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(textBoxTruckNum.Text, father[2].ToString());
            if (title != null)
            {
                if (!CheckDB(title))
                {
                    return;
                }
                this.textBoxDBNum.Text = title.DBNUM;
                textBoxTare.Text = title.TARE.ToString();
            }
        }

        private bool CheckDB(Sdl_AccessoryReturnTitle title)
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

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round((double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text)), 3).ToString();

                if (textBoxSenge.Text.Trim() == string.Empty)
                    textBoxSenge.Text = "0";
                textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxSenge.Text), 3).ToString();

            }
            catch
            {

            }
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            double senge = 0;
            if (columnIndex == 0)
            {
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewDetails.Rows[i].Cells["chk"];
                    if (rowIndex == i)
                    {
                        chk.Value = true;
                        string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                        realNum = realNum.Trim() == "" ? "0" : realNum;
                        try
                        {
                            senge += Math.Round(double.Parse(realNum), 3);
                        }
                        catch
                        {
                        }
                        textBoxSenge.Text = senge.ToString();
                        continue;
                    }
                    else
                    {
                        chk.Value = false;
                    }
                }
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
                    MessageBox.Show("没有该车的退货单！");
                    return;
                }
                BindEnterData();
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                int rowIndex = dataGridViewDetails.CurrentCell.RowIndex;
                if (dataGridViewDetails.CurrentCell.ColumnIndex != 9)
                    return;
                double sengeValue = 0;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    string senge = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                    if (senge.Trim() == "")
                        return;
                    if (!(ValidateHelper.IsDecimal(senge) || ValidateHelper.IsNumber(senge)))
                    {
                        MessageBox.Show(this, "请输入数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dataGridViewDetails.Rows[i].Cells[0].EditedFormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                        realNum = realNum.Trim() == "" ? "0" : realNum;
                        try
                        {
                            sengeValue += Math.Round(double.Parse(realNum), 3);
                        }
                        catch
                        {
                        }
                    }
                }
                textBoxSenge.Text = sengeValue.ToString();
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空出厂操作吗?", "史丹利地磅系统-配件退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有订单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //    MessageBox.Show(this, "扣杂数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (Math.Round(double.Parse(textBoxNet.Text), 3) != 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重应该等于皮重，确认操作吗？", "史丹利地磅系统-配件退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                Sdl_AccessoryReturnTitle model = new Sdl_AccessoryReturnTitle();
                model = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[2].ToString());
                if (model == null)
                {
                    MessageBox.Show(this, "没有该车的进厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (model.HSFLAG == "S")
                {
                    MessageBox.Show(this, "该车已经退货出厂，不能空车出厂，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                model.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                model.GROSS = double.Parse(textBoxGross.Text);
                model.HSFLAG = "S";
                model.TARE = double.Parse(textBoxTare.Text);
                model.EXITWEIGHMAN = textBoxExitWeighMan.Text;
                model.WERKS = textBoxFactory.Text;
                model.DEDUCTNUM = 0;
                model.EXITFLAG = 1;
                Sdl_AccessoryReturnTitleAdapter.UpdateSdl_AccessoryReturnTitle(model);
                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                textBoxNet.Text = Math.Round((double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text)), 3).ToString();
            }
            catch
            {

            }
        }

        private void textBoxSenge_TextChanged(object sender, EventArgs e)
        {
            try
            {

                textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxSenge.Text), 3).ToString();

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
