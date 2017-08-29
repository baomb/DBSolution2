using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using System.Threading;
using System.Collections.Specialized;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class SlpsRawMaterialReturnExit : Form
    {
        private string[] father = new string[] { "", "", "" };
        private DataTable dtSAP = new DataTable();
        SerialPortHelper s = null;
        private bool readPort = true;
        public SlpsRawMaterialReturnExit()
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
            if (sysSetting.WERKS == "2501")
            {
                this.comboBoxStandardWeight.Visible = true;
                this.textBoxQuantity.Visible = true;
                this.labelTrayWeight.Visible = true;
                this.labelTrayQuantity.Visible = true;
            }
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("原材料退货出厂");
            this.timer.Start();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool ValidateControl(DataTable dt)
        {
            if ((!ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text)) && this.comboBoxStandardWeight.Visible)
            {
                MessageBox.Show(this, "托盘标重必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidateHelper.IsNumber(this.textBoxQuantity.Text) && this.textBoxQuantity.Visible)
            {
                MessageBox.Show(this, "托盘数量必须为正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有退货单信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsNumber(textBoxNet.Text) || ValidateHelper.IsDecimal(textBoxNet.Text)))
            {
                MessageBox.Show(this, "地磅数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsNumberSign(textBoxDeductNum.Text) || ValidateHelper.IsDecimalSign(textBoxDeductNum.Text)))
            {
                MessageBox.Show(this, "扣杂数量应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
            {
                string realNum = dataGridViewDetails.Rows[i].Cells["SENGE"].Value.ToString();
                if ((!(ValidateHelper.IsDecimal(realNum) || ValidateHelper.IsNumber(realNum))) || double.Parse(realNum) == 0)
                {
                    MessageBox.Show(this, "请输入实退吨数,实退吨数应为大于零的数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string lgort = dataGridViewDetails.Rows[i].Cells["LGORT"].Value.ToString();
                if (string.IsNullOrEmpty(lgort))
                {
                    MessageBox.Show(this, "请选择库存地！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string bktxt = dataGridViewDetails.Rows[i].Cells["BKTXT"].Value.ToString();
                if ((!StringUtil.IsOverLength(bktxt, 25)) || string.IsNullOrEmpty(bktxt))
                {
                    MessageBox.Show(this, "产地/品牌输入的长度不能超过12个汉字，或者不能超过25个英文字母,且不能为空！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            DataTable dtDistinct = new DataSetHelper().SelectDistinct("dtDistinct", dt, new string[] { "EBELN", "EBELP", "MATNR", "LGORT" });
            if (dt.Rows.Count != dtDistinct.Rows.Count)
            {
                MessageBox.Show(this, "同一退货单同一物料必须在不同仓库取货！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataTable dtTemp = new DataTable();
            double mengeSum = 0;
            double mengeGvSum = 0;
            for (int j = 0; j < dtSAP.Rows.Count; j++)
            {
                string ebeln = dtSAP.Rows[j]["EBELN"].ToString();
                string ebelp = dtSAP.Rows[j]["EBELP"].ToString();
                string matnr = dtSAP.Rows[j]["MATNR"].ToString();
                double menge = double.Parse(dtSAP.Rows[j]["MENGE"].ToString());
                dtTemp = new DataSetHelper().GetNewDataTable(dt, " EBELN = '" + ebeln + "' and EBELP='" + ebelp + "' and MATNR='" + matnr + "'", "");
                double mengeGv = 0;
                for (int n = 0; n < dtTemp.Rows.Count; n++)
                {
                    if (string.IsNullOrEmpty(dtTemp.Rows[n]["SENGE"].ToString()))
                    {
                        MessageBox.Show(this, "请输入实退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    mengeGv += double.Parse(dtTemp.Rows[n]["SENGE"].ToString());
                }
                if (Math.Round(menge, 3) < Math.Round(mengeGv, 3))
                {
                    if (MessageBox.Show("行项目中物料的实退数量不能大于可退货数量，是否联系供应部修改订单?", "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    return false;
                }
                mengeGvSum += mengeGv;
                mengeSum += menge;
            }
            

            double Dvalue = Math.Round(double.Parse(textBoxNet.Text), 3);
            if (Dvalue > Math.Round(mengeSum, 3))
            {
                MessageBox.Show(this, "实际过磅数量不能大于退货单订单数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            double balanceValue = Math.Round(double.Parse(textBoxNet.Text) - mengeGvSum, 3);
            string strTip = string.Empty;
            if (balanceValue > 0)
            {
                strTip = "实退数量与实际过磅数量不相符,该批物料涨吨" + Math.Abs(balanceValue).ToString() + ",确认退货过账吗？";
            }
            else
            {
                strTip = "实退数量与实际过磅数量不相符,该批物料亏吨" + Math.Abs(balanceValue).ToString() + ",确认退货过账吗？";
            }
            if (Dvalue != Math.Round(mengeGvSum, 3))
            {
                if (MessageBox.Show(strTip, "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                {
                    return false;
                }
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
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtGv = (DataTable)dataGridViewDetails.DataSource;
                //检测窗体数据
                if (!ValidateControl(dtGv))
                    return;

                Sdl_RawMaterialReturnTitle model = new Sdl_RawMaterialReturnTitle();
                model = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[1].ToString());
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

                //检测SAP
                DataTable dtUpData = new DataSetHelper().GetNewDataTable(dtGv, " 1=1 ", "");
                for (int i = 0; i < dtUpData.Rows.Count; i++)
                {
                    dtUpData.Rows[i]["WERKS"] = textBoxFactory.Text.Trim();
                    string matnr = dtUpData.Rows[i]["MATNR"].ToString();
                    dtUpData.Rows[i]["SENGE"] = double.Parse(dtUpData.Rows[i]["SENGE"].ToString());
                    dtUpData.Rows[i]["FRBNR"] = textBoxTruckNum.Text;
                }

                ListDictionary ltPara = new ListDictionary();
                DataTable dtNew = new DataSetHelper().SelectDistinct("dtNew", dtUpData, new string[] { "EBELN", "EBELP", "LIFNR", "NAME1", "MATNR", "MENGE", "SENGE", "WERKS", "LGORT", "FRBNR", "BKTXT" });
                ListDictionary ltParaTb = new ListDictionary();
                ltParaTb.Add("ZTOT", dtNew);
                ListDictionary lt = new ListDictionary();
                lt.Add("MESG", "NOTE");
                ListDictionary lr = new ListDictionary();
                try
                {
                    //使用SAP通信
                    DataSet dtInfo = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_GZ_CHECK_RE", ltPara, ltParaTb, lt, ref lr);

                    if (dtInfo.Tables[0].Rows.Count > 0)
                    {
                        string str = string.Empty;
                        for (int j = 0; j < dtInfo.Tables[0].Rows.Count; j++)
                        {
                            if (dtInfo.Tables[0].Rows.Count == 1)
                            {
                                str += dtInfo.Tables[0].Rows[j][0].ToString();
                            }
                            else
                            {
                                str += dtInfo.Tables[0].Rows[j][0].ToString() + "\n\r";
                            }
                        }
                        if (str.Trim() == "检查成功")
                        {
                            DataSet dtGZ = new DataSet();
                            try
                            {
                                //使用SAP通信
                                dtGZ = SAPHelper.InvokSAPFunTable("Z_SDL_ROH_MUTUAL_GZ_RE", ltPara, ltParaTb, lt, ref lr);
                            }
                            catch
                            {
                                MessageBox.Show("调用SAP RFC过账失败！，请检查网络原因或者联系管理员！");
                                this.Close();
                                return;
                            }
                            if (dtGZ.Tables[0] == null)
                            {
                                MessageBox.Show(this, "调用SAP RFC函数失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            string strInfo = string.Empty;
                            if (dtGZ.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < dtGZ.Tables[0].Rows.Count; j++)
                                {
                                    if (dtGZ.Tables[0].Rows.Count == 1)
                                    {
                                        strInfo += dtGZ.Tables[0].Rows[j][0].ToString();
                                    }
                                    else
                                    {
                                        strInfo += dtGZ.Tables[0].Rows[j][0].ToString() + "\n\r";
                                    }
                                }
                            }

                            if (strInfo.IndexOf("已成功创建") >= 0)
                            {
                                try
                                {
                                    //头信息操作

                                    model.EXITTIME = DateTime.Parse(this.textBoxExitTime.Text);
                                    model.GROSS = double.Parse(textBoxGross.Text);
                                    model.HSFLAG = "S";
                                    model.TARE = double.Parse(textBoxTare.Text);
                                    model.EXITWEIGHMAN = textBoxWeighMan.Text;
                                    model.WERKS = textBoxFactory.Text;
                                    model.DEDUCTNUM = double.Parse(textBoxDeductNum.Text);
                                    if (ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text))
                                    {
                                        model.TRAYWEIGHT = Convert.ToInt16(comboBoxStandardWeight.Text);
                                    }
                                    if (ValidateHelper.IsNumber(this.textBoxQuantity.Text))
                                    {
                                        model.TRAYQUANTITY = Convert.ToInt16(textBoxQuantity.Text);
                                    }
                                    Sdl_RawMaterialReturnTitleAdapter.UpdateSdl_RawMaterialReturnTitle(model);

                                    //行项目操作
                                    Sdl_RawMaterialReturnDetail modelDetail = new Sdl_RawMaterialReturnDetail();

                                    for (int i = 0; i < dtGv.Rows.Count; i++)
                                    {
                                        modelDetail.EBELN = dtGv.Rows[i]["EBELN"].ToString();
                                        modelDetail.EBELP = dtGv.Rows[i]["EBELP"].ToString();
                                        modelDetail.LGORT = dtGv.Rows[i]["LGORT"].ToString();
                                        modelDetail.MAKTX = dtGv.Rows[i]["MAKTX"].ToString();
                                        modelDetail.MATNR = dtGv.Rows[i]["MATNR"].ToString();
                                        modelDetail.BKTXT = dtGv.Rows[i]["BKTXT"].ToString();
                                        modelDetail.MENGE = double.Parse(dtGv.Rows[i]["MENGE"].ToString());
                                        modelDetail.SENGE = double.Parse(dtGv.Rows[i]["SENGE"].ToString());
                                        modelDetail.TIMEFLAG = model.TIMEFLAG;
                                        Sdl_RawMaterialReturnDetailAdapter.AddSdl_RawMaterialReturnDetail(modelDetail);
                                    }
                                    MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Common.PlayGoodBye();
                                    this.Close();
                                }
                                catch
                                {
                                    MessageBox.Show(this, "向SAP过账成功，向地磅数据库操作失败，请联系管理员！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, strInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, str, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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
                dr["LIFNR"] = dataGridViewDetails.Rows[rowIndex].Cells["LIFNR"].Value.ToString();
                dr["NAME1"] = dataGridViewDetails.Rows[rowIndex].Cells["NAME1"].Value.ToString();
                dr["MENGE"] = dataGridViewDetails.Rows[rowIndex].Cells["MENGE"].Value.ToString();
                dr["BKTXT"] = dataGridViewDetails.Rows[rowIndex].Cells["BKTXT"].Value.ToString();
                dr["OVERNUM"] = dataGridViewDetails.Rows[rowIndex].Cells["OVERNUM"].Value.ToString();
                dt.Rows.InsertAt(dr, rowIndex + 1);
                dataGridViewDetails.AutoGenerateColumns = false;
                dataGridViewDetails.DataSource = dt;
            }
            if (columnIndex == 12)
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
                double realNum = 0;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    try
                    {
                        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    }
                    catch
                    {

                    }
                }
                textBoxZMenge.Text = realNum.ToString();
                //}
                //else
                //{
                //    MessageBox.Show(this, "该行不能删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
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
                    MessageBox.Show("没有该车的交货单！");
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
            dtSAP = dsSAP.Tables[0];

            dtSAP.Columns.Add("SENGE");
            dtSAP.Columns.Add("LGORT");
            dtSAP.Columns.Add("WERKS");
            dtSAP.Columns.Add("OVERNUM");
            dtSAP.Columns.Add("FRBNR");
            dtSAP.Columns.Add("BKTXT");

            for (int i = 0; i < dtSAP.Rows.Count; i++)
            {
                double overNum = Sdl_RawMaterialReturnDetailAdapter.GetSdl_RawMaterialReturnDetailOverNum(" WHERE EBELN = '" + dtSAP.Rows[i]["EBELN"].ToString() + "' and EBELP='" + dtSAP.Rows[i]["EBELP"].ToString() + "' ");
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

            DataTable dtCombox = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(" where ( lgort like '3%' or lgort like '1%' ) and werks='" + textBoxFactory.Text + "' ").Tables[0];
            DataGridViewComboBoxColumn cmbColumnPro = new DataGridViewComboBoxColumn();
            cmbColumnPro.DataPropertyName = "lgort";
            cmbColumnPro.DataSource = dtCombox;
            cmbColumnPro.ValueMember = "lgort";
            cmbColumnPro.DisplayMember = "lgobe";

            this.dataGridViewDetails.Columns.Insert(dataGridViewDetails.Columns["LGORT"].Index, cmbColumnPro);
            dataGridViewDetails.Columns.Remove("LGORT");
            cmbColumnPro.Name = "LGORT";
            cmbColumnPro.HeaderText = "发货仓库";

            Common.ShowTruckWeight(this.textBoxTruckNum.Text, dataGridViewHistory);
        }

        private void BindEnterData()
        {
            Sdl_RawMaterialReturnTitle title = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitle(textBoxTruckNum.Text, father[1].ToString());
            if (title != null)
            {
                textBoxTare.Text = title.TARE.ToString();
            }
        }

        private void textBoxTruckNum_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "RawMaterialReturn");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                textBoxTruckNum.Text = father[0].ToString();
                textBoxEbeln.Text = father[2].ToString();

                InitSelectDataBind(textBoxTruckNum.Text);
                if (dataGridViewDetails.Rows.Count == 0)
                {
                    MessageBox.Show("没有该车的交货单！");
                    return;
                }
                BindEnterData();
            }
        }

        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tuopan = 0;
                if (ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text))
                {
                    tuopan = Convert.ToInt16(this.comboBoxStandardWeight.Text);
                }
                int quantity = 0;
                if (ValidateHelper.IsNumber(this.textBoxQuantity.Text))
                {
                    quantity = Convert.ToInt16(this.textBoxQuantity.Text);
                }
                double weight = Convert.ToDouble(tuopan * quantity / 1000.0);
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - weight, 3).ToString();
                if (textBoxZMenge.Text.Trim() == string.Empty)
                    textBoxZMenge.Text = "0";
                textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxZMenge.Text), 3).ToString();
            }
            catch
            {

            }
        }

        private void textBoxDeductNum_TextChanged(object sender, EventArgs e)
        {
            //if ((!(ValidateHelper.IsNumberSign(textBoxDeductNum.Text) ||
            //    ValidateHelper.IsDecimalSign(textBoxDeductNum.Text)))
            //    && textBoxDeductNum.Text != "-" && textBoxDeductNum.Text.Trim() != "" && textBoxDeductNum.Text.IndexOf('.') <= 0)
            //{
            //    this.textBoxDeductNum.Text = "0";
            //    textBoxDeductNum.Focus();
            //}
            //try
            //{
            //    textBoxNet.Text = (double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) + double.Parse(textBoxDeductNum.Text)).ToString();
            //}
            //catch
            //{

            //}
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空车出厂操作吗?", "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                //double balanceValue = Common.GetBalanceValue();
                //if (Math.Round(Convert.ToDouble(textBoxDeductNum.Text),3) > Math.Round(balanceValue,3))
                //{
                //    MessageBox.Show(this, "扣杂不在误差" + balanceValue + "吨允许范围内", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (Math.Round(double.Parse(textBoxNet.Text), 3) != 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-原材料退货出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                //头信息操作
                Sdl_RawMaterialReturnTitle model = new Sdl_RawMaterialReturnTitle();
                model = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitle(textBoxTruckNum.Text, textBoxEbeln.Text, father[1].ToString());
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
                model.EXITTIME = DateTime.Parse(textBoxExitTime.Text);
                model.GROSS = double.Parse(textBoxGross.Text);
                model.HSFLAG = "S";
                model.TARE = double.Parse(textBoxTare.Text);
                model.WEIGHMAN = textBoxWeighMan.Text;
                model.WERKS = textBoxFactory.Text;
                model.DEDUCTNUM = double.Parse(textBoxDeductNum.Text);
                model.EXITFLAG = 1;
                Sdl_RawMaterialReturnTitleAdapter.UpdateSdl_RawMaterialReturnTitle(model);
                MessageBox.Show(this, "操作成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.PlayGoodBye();
                this.Close();
            }
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.IsCurrentCellDirty)
            {
                this.dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dataGridViewDetails.CurrentCell.ColumnIndex == 9)
                {
                    string cellValue = dataGridViewDetails.CurrentCell.FormattedValue.ToString();
                    if (!StringUtil.IsOverLength(cellValue, 25))
                    {
                        MessageBox.Show(this, "产地/品牌输入的长度不能超过12个汉字，或者不能超过25个英文字母", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                dataGridViewDetails.ClearSelection();
                double realNum = 0;
                for (int i = 0; i < dataGridViewDetails.Rows.Count; i++)
                {
                    try
                    {
                        realNum += Convert.ToDouble(dataGridViewDetails.Rows[i].Cells["SENGE"].Value);
                    }
                    catch
                    {
                    }
                }
                textBoxZMenge.Text = realNum.ToString();
            }
        }

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void textBoxZMenge_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
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

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void comboBoxStandardWeight_TextChanged(object sender, EventArgs e)
        {
            CalcDiff();
        }

        private void CalcDiff()
        {
            int tuopan = 0;
            if (ValidateHelper.IsNumber(this.comboBoxStandardWeight.Text))
            {
                tuopan = Convert.ToInt16(this.comboBoxStandardWeight.Text);
            }
            int quantity = 0;
            if (ValidateHelper.IsNumber(this.textBoxQuantity.Text))
            {
                quantity = Convert.ToInt16(this.textBoxQuantity.Text);
            }
            double weight = Convert.ToDouble(tuopan * quantity / 1000.0);
            textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - weight, 3).ToString();
            if (textBoxZMenge.Text.Trim() == string.Empty)
                textBoxZMenge.Text = "0";
            textBoxDeductNum.Text = Math.Round(double.Parse(textBoxNet.Text) - double.Parse(textBoxZMenge.Text), 3).ToString();
        }
    }
}
