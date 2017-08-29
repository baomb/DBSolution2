using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class AllotTransferInEdit : Form
    {
        Sdl_AllotInTitle model;
        DataTable dtfps;
        bool isInsert = false;
        public AllotTransferInEdit()
        {
            InitializeComponent();
            Common.BindCBox(comboBoxRESWK);
            Common.BindCBox(comboBoxWERKS);
            this.textBoxEnterTime.Text = Common.GetServerDate2();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            bool result = InsertData();
            ShowMessage(result);
            if (result)
            {
                SwitchToReadOnly();
            }
        }

        private bool InsertData()
        {
            bool result = true;
            try
            {
                Sdl_AllotInTitle modelTitleInsert = new Sdl_AllotInTitle();
                Sdl_AllotInDetail modelInsert = new Sdl_AllotInDetail();
                //if (this.dataGridViewDetail.Rows.Count <= 1)
                //{
                //    MessageBox.Show(this, "信息不全，禁止添加！");
                //    return false;
                //}
                for (int i = 0; i < this.dataGridViewDetail.Rows.Count - 1; i++)
                {
                    if (this.dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString() != "" && this.dataGridViewDetail.Rows[i].Cells["EBELP"].Value.ToString() != "")
                    {
                        modelInsert.LGORT = this.dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString();
                        modelInsert.MAKTX = this.dataGridViewDetail.Rows[i].Cells["MAKTX"].Value.ToString();
                        modelInsert.MATNR = this.dataGridViewDetail.Rows[i].Cells["MATNR"].Value.ToString();
                        modelInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                        modelInsert.EBELN = this.dataGridViewDetail.Rows[i].Cells["EBELN"].Value.ToString();
                        modelInsert.SENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[i].Cells["SENGE"].Value);
                        modelInsert.MENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[i].Cells["MENGE"].Value);
                        modelInsert.EBELP = this.dataGridViewDetail.Rows[i].Cells["EBELP"].Value.ToString();
                        modelInsert.WERKS = this.dataGridViewDetail.Rows[i].Cells["WERKS"].Value.ToString();
                        Sdl_AllotInDetailAdapter.AddSdl_AllotInDetail(modelInsert);

                        CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AllotInDetail;
                        CompareModelHelper.CompareModel(new Sdl_AllotInDetail(), modelInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                    }
                    //else
                    //{
                    //    MessageBox.Show(this, "第" + (i + 1) + "行信息不全，添加失败！");
                    //    return false;
                    //}
                }
                for (int i = 0; i < this.dataGridViewDetail.Rows.Count - 1; i++)
                {
                    if (Sdl_AllotInTitleAdapter.ExistsSdl_AllotInTitle(this.textBoxEnterTime.Text, this.dataGridViewDetail.Rows[i].Cells["EBELN"].Value.ToString()))
                    {
                        continue;
                    }

                    modelTitleInsert = new Sdl_AllotInTitle();
                    modelTitleInsert.ENTERTIME = DateTime.Parse(this.textBoxEnterTime.Text.ToString().Trim());
                    modelTitleInsert.EXITFLAG = this.checkBoxCancel.Checked ? 1 : 0;
                    modelTitleInsert.EXITTIME = DateTime.Parse(Common.GetServerDate());
                    modelTitleInsert.GROSS = Convert.ToDouble(this.textBoxGross.Text.ToString().Trim());
                    modelTitleInsert.HSFLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                    modelTitleInsert.TARE = Convert.ToDouble(this.textBoxTare.Text.ToString().Trim());
                    modelTitleInsert.DEDUCTNUM = Convert.ToDouble(this.textBoxDEDUCTNUM.Text.ToString().Trim());
                    modelTitleInsert.TIMEFLAG = this.textBoxEnterTime.Text.ToString().Trim();
                    modelTitleInsert.TRUCKNUM = this.textTruckNum.Text.ToString().Trim();
                    modelTitleInsert.EBELN = this.dataGridViewDetail.Rows[i].Cells["EBELN"].Value.ToString().Trim();
                    modelTitleInsert.WERKS = this.dataGridViewDetail.Rows[i].Cells["WERKS"].Value.ToString().Trim();
                    modelTitleInsert.RESWK = this.comboBoxRESWK.Text.ToString().Trim();
                    modelTitleInsert.ENTERWEIGHMAN = this.textWeighMan.Text.ToString().Trim();
                    modelTitleInsert.EXITWEIGHMAN = this.textBoxExitWeignMan.Text.ToString().Trim();
                    modelTitleInsert.TRAYWEIGHT = this.comboBoxTrayWeight.Text.ToString().Trim();
                    modelTitleInsert.TRAYNUM = this.textBoxTrayNum.Text.ToString().Trim();

                    Sdl_AllotInTitleAdapter.AddSdl_AllotInTitle(modelTitleInsert);

                    CompareModelHelper.SdlDB_Modules moduleTitle = CompareModelHelper.SdlDB_Modules.AllotInTitle;
                    CompareModelHelper.CompareModel(new Sdl_AllotInTitle(), modelTitleInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(moduleTitle));
                }

            }
            catch
            {
                result = false;
            }
            return result;
        }

        private bool UpdateTitle()
        {
            bool result = true;
            try
            {
                DataTable dt = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitleDataTable(model.TRUCKNUM, model.TIMEFLAG);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sdl_AllotInTitle fpstNew = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(model.TRUCKNUM, dt.Rows[i]["EBELN"].ToString(), model.TIMEFLAG);
                    Sdl_AllotInTitle fpstOld = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(model.TRUCKNUM, dt.Rows[i]["EBELN"].ToString(), model.TIMEFLAG);
                    fpstNew.HSFLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                    fpstNew.EXITFLAG = this.checkBoxCancel.Checked ? 1 : 0;
                    fpstNew.GROSS = Convert.ToDouble(this.textBoxGross.Text.ToString().Trim());
                    fpstNew.TARE = Convert.ToDouble(this.textBoxTare.Text.ToString().Trim());
                    fpstNew.TRUCKNUM = this.textTruckNum.Text.ToString().Trim();
                    fpstNew.DEDUCTNUM = Convert.ToDouble(this.textBoxDEDUCTNUM.Text.ToString().Trim());
                    fpstNew.RESWK = this.comboBoxRESWK.Text.ToString().Trim();
                    fpstNew.WERKS = this.comboBoxWERKS.Text.ToString().Trim();
                    fpstNew.TRAYWEIGHT = comboBoxTrayWeight.Text.ToString().Trim();
                    fpstNew.TRAYNUM = textBoxTrayNum.Text.ToString().Trim();
                    
                    Sdl_AllotInTitleAdapter.UpdateSdl_AllotInTitle(fpstNew, fpstOld.EBELN, fpstOld.TRUCKNUM);

                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AllotInTitle;
                    CompareModelHelper.CompareModel(model, fpstNew, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private bool UpdateItem(int rowIndex)
        {
            bool result = true;
            try
            {

                Sdl_AllotInDetail fps = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());
                Sdl_AllotInDetail fpsOld = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());

                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.SENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["SENGE"].Value);
                fps.MENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["MENGE"].Value);
                fps.EBELN = this.dataGridViewDetail.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                fps.EBELP = this.dataGridViewDetail.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                fps.WERKS = this.dataGridViewDetail.Rows[rowIndex].Cells["WERKS"].Value.ToString();

                Sdl_AllotInDetailAdapter.UpdateSdl_AllotInDetail(fps, dtfps.Rows[rowIndex]["EBELN"].ToString().Trim(' '), dtfps.Rows[rowIndex]["EBELP"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AllotInDetail;
                CompareModelHelper.CompareModel(fpsOld, fps, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));
                if (!Sdl_AllotInTitleAdapter.ExistsSdl_AllotInTitle(fps.TIMEFLAG, fps.EBELN))
                {
                    Sdl_AllotInTitle newTitle = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(model.TRUCKNUM, model.EBELN, model.TIMEFLAG);
                    newTitle.EBELN = fps.EBELN;
                    Sdl_AllotInTitleAdapter.AddSdl_AllotInTitle(newTitle);
                    module = CompareModelHelper.SdlDB_Modules.AllotInTitle;
                    CompareModelHelper.CompareModel(new Sdl_AllotInTitle(), newTitle, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private bool InsertItem(int rowIndex)
        {
            bool result = true;
            try
            {
                Sdl_AllotInDetail fps = new Sdl_AllotInDetail();

                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.TIMEFLAG = this.textBoxEnterTime.Text;
                fps.EBELN = this.dataGridViewDetail.Rows[rowIndex].Cells["EBELN"].Value.ToString();
                fps.SENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["SENGE"].Value);
                fps.MENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["MENGE"].Value);
                fps.EBELP = this.dataGridViewDetail.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                fps.WERKS = this.dataGridViewDetail.Rows[rowIndex].Cells["WERKS"].Value.ToString();

                int count = Sdl_AllotInDetailAdapter.AddSdl_AllotInDetail(fps);
                if (count == 1)
                {
                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AllotInDetail;
                    CompareModelHelper.CompareModel(new Sdl_AllotInDetail(), fps, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                    Sdl_AllotInTitle newTitle = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(model.TRUCKNUM, model.EBELN, model.TIMEFLAG);
                    newTitle.EBELN = fps.EBELN;
                    Sdl_AllotInTitleAdapter.AddSdl_AllotInTitle(newTitle);
                    module = CompareModelHelper.SdlDB_Modules.AllotInTitle;
                    CompareModelHelper.CompareModel(new Sdl_AllotInTitle(), newTitle, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private bool DeleteItem(int rowIndex)
        {
            bool result = true;
            try
            {
                Sdl_AllotInDetail fps = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());

                Sdl_AllotInDetailAdapter.DeleteSdl_AllotInDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AllotInDetail;
                CompareModelHelper.CompareModel(fps, new Sdl_AllotInDetail(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (toolStripButtonEdit.Text == "修改")
            {
                toolStripButtonEdit.Text = "保存";
                SwitchToEdit();
            }
            else
            {
                bool result = UpdateTitle();
                ShowMessage(result);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SwitchToEdit()
        {
            textBoxGross.ReadOnly = false;
            textBoxTare.ReadOnly = false;
            textTruckNum.ReadOnly = false;
            textBoxDEDUCTNUM.ReadOnly = false;
            dataGridViewDetail.ReadOnly = false;
            comboBoxRESWK.Enabled = true;
            comboBoxWERKS.Enabled = true;
            checkBoxCancel.Enabled = true;
            checkBoxHSFlag.Enabled = true;
            checkBoxAllotFlag.Enabled = true;
            comboBoxTrayWeight.Enabled = true;
            textBoxTrayNum.Enabled = true;
        }

        private void SwitchToInsert()
        {
            textBoxGross.ReadOnly = false;
            textBoxTare.ReadOnly = false;
            textTruckNum.ReadOnly = false;
            textBoxDEDUCTNUM.ReadOnly = false;
            checkBoxCancel.Enabled = true;
            checkBoxHSFlag.Enabled = true;
            checkBoxAllotFlag.Enabled = true;
            dataGridViewDetail.ReadOnly = false;
            toolStripButtonSave.Visible = true;
            toolStripButtonEdit.Visible = false;
            toolStripButtonCancel.Visible = false;
            toolStripSeparator1.Visible = true;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
            comboBoxRESWK.Enabled = true;
            comboBoxWERKS.Enabled = true;
            textBoxTrayNum.Enabled = true;
            comboBoxTrayWeight.Enabled = true;
        }

        private void SwitchToReadOnly()
        {
            textBoxGross.ReadOnly = true;
            textBoxTare.ReadOnly = true;
            textTruckNum.ReadOnly = true;
            textBoxDEDUCTNUM.ReadOnly = true;
            comboBoxRESWK.Enabled = false;
            comboBoxWERKS.Enabled = false;
            dataGridViewDetail.ReadOnly = true;
            checkBoxCancel.Enabled = false;
            checkBoxHSFlag.Enabled = false;
            checkBoxAllotFlag.Enabled = false;
            textBoxTrayNum.Enabled = false;
            comboBoxTrayWeight.Enabled = false;
        }

        private void SwitchItemToEdit()
        {
            this.dataGridViewDetail.Columns[0].Visible = false;
            this.dataGridViewDetail.Columns[1].Visible = false;
            this.dataGridViewDetail.Columns[2].Visible = true;
            this.dataGridViewDetail.Columns[3].Visible = true;
            this.dataGridViewDetail.Columns[4].Visible = false;
            this.dataGridViewDetail.ReadOnly = false;
            isInsert = false;
        }

        private void SwitchItemToReadOnly()
        {
            this.dataGridViewDetail.Columns[0].Visible = true;
            this.dataGridViewDetail.Columns[1].Visible = true;
            this.dataGridViewDetail.Columns[2].Visible = false;
            this.dataGridViewDetail.Columns[3].Visible = false;
            this.dataGridViewDetail.Columns[4].Visible = true;
            this.dataGridViewDetail.ReadOnly = true;
        }

        private void SwitchItemToInsert(int rowIndex)
        {
            this.dataGridViewDetail.Columns[0].Visible = false;
            this.dataGridViewDetail.Columns[1].Visible = false;
            this.dataGridViewDetail.Columns[2].Visible = true;
            this.dataGridViewDetail.Columns[3].Visible = true;
            this.dataGridViewDetail.Columns[4].Visible = false;
            this.dataGridViewDetail.ReadOnly = false;
            isInsert = true;
        }

        private void ClearContent()
        {
            this.comboBoxRESWK.Text = string.Empty;
            this.comboBoxWERKS.Text = string.Empty;
            this.textBoxGross.Text = string.Empty;
            this.textBoxTare.Text = string.Empty;
            this.textBoxNet.Text = string.Empty;
            this.textTruckNum.Text = string.Empty;
            this.textBoxDEDUCTNUM.Text = string.Empty;
            this.textBoxEnterTime.Text = Common.GetServerDate2();
            this.textBoxExitTime.Text = string.Empty;
            this.textWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitWeignMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.dataGridViewDetail.DataSource = null;
            this.checkBoxCancel.Checked = false;
            this.checkBoxHSFlag.Checked = false;
            this.checkBoxAllotFlag.Checked = false;
            comboBoxTrayWeight.SelectedIndex = -1;
            textBoxTrayNum.Text = "0";
        }

        private void BindData()
        {
            this.textTruckNum.Text = model.TRUCKNUM;
            this.textWeighMan.Text = model.ENTERWEIGHMAN;
            this.textBoxEnterTime.Text = model.TIMEFLAG;
            this.textBoxExitTime.Text = model.EXITTIME.ToString();
            this.textBoxGross.Text = model.GROSS.ToString();
            this.textBoxTare.Text = model.TARE.ToString();
            this.textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            this.textBoxNet.Text = (model.GROSS - model.TARE).ToString();
            this.textBoxDEDUCTNUM.Text = model.DEDUCTNUM.ToString();
            this.comboBoxRESWK.Text = model.RESWK;
            this.comboBoxWERKS.Text = model.WERKS;
            comboBoxTrayWeight.Text = model.TRAYWEIGHT;
            textBoxTrayNum.Text = model.TRAYNUM;
            string where = "where timeflag='" + model.TIMEFLAG + "'";
            DataTable dt = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetailSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            checkBoxCancel.Checked = (model.EXITFLAG == 1) ? true : false;
            checkBoxHSFlag.Checked = (model.HSFLAG == "S") ? true : false;
            dtfps = dt.Copy();
        }

        public void ShowDialog(IWin32Window parent, string truckNum, string timeFlag)
        {
            if (truckNum != "" || timeFlag != "")
            {
                toolStripButtonSave.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripButtonEdit.Visible = true;
                toolStripButtonCancel.Visible = true;
                model = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(truckNum, timeFlag);
                BindData();
            }
            else
            {
                ClearContent();
                SwitchToInsert();
            }
            this.ShowDialog(parent);
        }

        private void textBoxGrossTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxGross.Text == "" || this.textBoxTare.Text == "")
                {
                    return;
                }
                Decimal gross = Convert.ToDecimal(this.textBoxGross.Text.TrimEnd('.'));
                Decimal tare = Convert.ToDecimal(this.textBoxTare.Text.TrimEnd('.'));
                Decimal trayWeight = Convert.ToDecimal(comboBoxTrayWeight.Text.Trim());
                Decimal trayNum = Convert.ToDecimal(textBoxTrayNum.Text.Trim());
                this.textBoxNet.Text = (gross - tare - (trayWeight * trayNum)).ToString();
            }
            catch
            {
                if (model != null)
                {
                    MessageBox.Show(this, "请输入正确的皮重和毛重");
                }
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            toolStripButtonEdit.Text = "修改";
            SwitchToReadOnly();
            BindData();
        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewDetail.CurrentRow.Index;
            int columnIndex = e.ColumnIndex;
            bool result = false;
            if (columnIndex == 0)
            {
                SwitchItemToInsert(rowIndex);
            }
            else if (columnIndex == 1)
            {
                SwitchItemToEdit();
            }
            else if (columnIndex == 2)
            {
                if (isInsert)
                {
                    result = InsertItem(rowIndex);
                }
                else
                {
                    result = UpdateItem(rowIndex);
                }
                ShowMessage(result);
            }
            else if (columnIndex == 3)
            {
                SwitchItemToReadOnly();
            }
            else if (columnIndex == 4)
            {
                DialogResult dr = MessageBox.Show(this, "确认删除此条数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    result = DeleteItem(rowIndex);
                    ShowMessage(result);
                }
            }
        }

        private void ShowMessage(bool result)
        {
            if (result)
            {
                MessageBox.Show(this, "操作成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "操作失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}