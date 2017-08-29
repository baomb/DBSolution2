using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class AccessoryReturnEdit : Form
    {
        Sdl_AccessoryReturnTitle model;
        DataTable dtfps;
        bool isInsert = false;
        public AccessoryReturnEdit()
        {
            InitializeComponent();
            Common.BindCBox(cbWerks);
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
                Sdl_AccessoryReturnTitle modelTitleInsert = new Sdl_AccessoryReturnTitle();
                Sdl_AccessoryReturnDetail modelInsert = new Sdl_AccessoryReturnDetail();
                //if (this.dataGridViewDetail.Rows.Count <= 1)
                //{
                //    MessageBox.Show(this, "信息不全，禁止添加！");
                //    return false;
                //}
                for (int i = 0; i < this.dataGridViewDetail.Rows.Count - 1; i++)
                {
                    if (this.dataGridViewDetail.Rows[i].Cells["SENGE"].Value.ToString() != "" && this.dataGridViewDetail.Rows[i].Cells["EBELP"].Value.ToString() != "")
                    {
                        modelInsert.MAKTX = this.dataGridViewDetail.Rows[i].Cells["MAKTX"].Value.ToString();
                        modelInsert.MATNR = this.dataGridViewDetail.Rows[i].Cells["MATNR"].Value.ToString();
                        modelInsert.EBELP = this.dataGridViewDetail.Rows[i].Cells["EBELP"].Value.ToString();
                        modelInsert.LIFNR = this.dataGridViewDetail.Rows[i].Cells["LIFNR"].Value.ToString();
                        modelInsert.NAME1 = this.dataGridViewDetail.Rows[i].Cells["NAME1"].Value.ToString();
                        modelInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                        modelInsert.EBELN = this.textBoxRSNUM.Text;
                        modelInsert.SENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[i].Cells["SENGE"].Value);
                        Sdl_AccessoryReturnDetailAdapter.AddSdl_AccessoryReturnDetail(modelInsert);

                        CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AccessoryReturnDetail;
                        CompareModelHelper.CompareModel(new Sdl_AccessoryReturnDetail(), modelInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                    }
                    //else
                    //{
                    //    MessageBox.Show(this, "第" + (i + 1) + "行信息不全，添加失败！");
                    //    return false;
                    //}
                }
                modelTitleInsert = new Sdl_AccessoryReturnTitle();
                modelTitleInsert.ENTERTIME = DateTime.Parse(this.textBoxEnterTime.Text);
                modelTitleInsert.EXITFLAG = this.checkBoxCancel.Checked ? 1 : 0;
                modelTitleInsert.EXITTIME = DateTime.Parse(Common.GetServerDate());
                modelTitleInsert.GROSS = Convert.ToSingle(this.textBoxGross.Text);
                modelTitleInsert.HSFLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                modelTitleInsert.TARE = Convert.ToSingle(this.textBoxTare.Text);
                modelTitleInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                modelTitleInsert.TRUCKNUM = this.textTruckNum.Text;
                modelTitleInsert.EBELN = this.textBoxRSNUM.Text;
                modelTitleInsert.WERKS = this.cbWerks.Text;
                modelTitleInsert.ENTERWEIGHMAN = this.textWeighMan.Text;
                modelTitleInsert.EXITWEIGHMAN = this.textBoxExitWeignMan.Text;
                modelTitleInsert.DEDUCTNUM = Convert.ToDouble(this.textBoxDuductNum.Text);

                Sdl_AccessoryReturnTitleAdapter.AddSdl_AccessoryReturnTitle(modelTitleInsert);

                CompareModelHelper.SdlDB_Modules moduleTitle = CompareModelHelper.SdlDB_Modules.AccessoryReturnTitle;
                CompareModelHelper.CompareModel(new Sdl_AccessoryReturnTitle(), modelTitleInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(moduleTitle));
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
                Sdl_AccessoryReturnTitle fpstNew = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(model.TRUCKNUM, model.EBELN, model.TIMEFLAG);
                Sdl_AccessoryReturnTitle fpstOld = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(model.TRUCKNUM, model.EBELN, model.TIMEFLAG);
                fpstNew.HSFLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                fpstNew.EXITFLAG = this.checkBoxCancel.Checked ? 1 : 0;
                fpstNew.GROSS = Convert.ToSingle(this.textBoxGross.Text);
                fpstNew.TARE = Convert.ToSingle(this.textBoxTare.Text);
                fpstNew.EBELN = this.textBoxRSNUM.Text;
                fpstNew.TRUCKNUM = this.textTruckNum.Text;
                fpstNew.WERKS = this.cbWerks.Text;
                fpstNew.DEDUCTNUM = Convert.ToDouble(this.textBoxDuductNum.Text);

                Sdl_AccessoryReturnTitleAdapter.UpdateSdl_AccessoryReturnTitle(fpstNew, fpstOld.EBELN, fpstOld.TRUCKNUM);

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AccessoryReturnTitle;
                CompareModelHelper.CompareModel(model, fpstNew, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));
                if (fpstNew.EBELN != fpstOld.EBELN)
                {
                    for (int i = 0; i < dataGridViewDetail.Rows.Count; i++)
                    {
                        if (dataGridViewDetail.Rows[i].IsNewRow)
                        {
                            continue;
                        }
                        string EBELN = dataGridViewDetail.Rows[i].Cells["EBELN"].Value.ToString();
                        string timeflag = dataGridViewDetail.Rows[i].Cells["TIMEFLAG"].Value.ToString();
                        string EBELP = dataGridViewDetail.Rows[i].Cells["EBELP"].Value.ToString();
                        Sdl_AccessoryReturnDetail fpp = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetail(timeflag, EBELN, EBELP);
                        Sdl_AccessoryReturnDetail fppOld = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetail(timeflag, EBELN, EBELP);
                        fpp.EBELN = fpstNew.EBELN;
                        Sdl_AccessoryReturnDetailAdapter.UpdateSdl_AccessoryReturnDetail(fpp, EBELN, EBELP);

                        module = CompareModelHelper.SdlDB_Modules.AccessoryReturnDetail;
                        CompareModelHelper.CompareModel(fppOld, fpp, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));
                    }
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
                Sdl_AccessoryReturnDetail fps = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString());
                Sdl_AccessoryReturnDetail fpsOld = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString());
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.EBELP = this.dataGridViewDetail.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                fps.SENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["SENGE"].Value);

                Sdl_AccessoryReturnDetailAdapter.UpdateSdl_AccessoryReturnDetail(fps, dtfps.Rows[rowIndex]["EBELN"].ToString().Trim(' '), dtfps.Rows[rowIndex]["EBELP"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AccessoryReturnDetail;
                CompareModelHelper.CompareModel(fpsOld, fps, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));
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
                Sdl_AccessoryReturnDetail fps = new Sdl_AccessoryReturnDetail();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.EBELP = this.dataGridViewDetail.Rows[rowIndex].Cells["EBELP"].Value.ToString();
                fps.LIFNR = this.dataGridViewDetail.Rows[rowIndex].Cells["LIFNR"].Value.ToString();
                fps.NAME1 = this.dataGridViewDetail.Rows[rowIndex].Cells["NAME1"].Value.ToString();
                fps.SENGE = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["SENGE"].Value);
                fps.TIMEFLAG = model.TIMEFLAG;
                fps.EBELN = model.EBELN;

                int count = Sdl_AccessoryReturnDetailAdapter.AddSdl_AccessoryReturnDetail(fps);
                if (count == 1)
                {
                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AccessoryReturnDetail;
                    CompareModelHelper.CompareModel(new Sdl_AccessoryReturnDetail(), fps, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
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
                Sdl_AccessoryReturnDetail fps = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString());

                Sdl_AccessoryReturnDetailAdapter.DeleteSdl_AccessoryReturnDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["EBELN"].ToString(), dtfps.Rows[rowIndex]["EBELP"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AccessoryReturnDetail;
                CompareModelHelper.CompareModel(fps, new Sdl_AccessoryReturnDetail(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
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
            this.textBoxGross.ReadOnly = false;
            this.textBoxTare.ReadOnly = false;
            this.textTruckNum.ReadOnly = false;
            this.textBoxRSNUM.ReadOnly = false;
            this.textBoxDuductNum.ReadOnly = false;
            this.dataGridViewDetail.ReadOnly = false;
            this.cbWerks.Enabled = true;
            this.checkBoxCancel.Enabled = true;
            this.checkBoxHSFlag.Enabled = true;
        }

        private void SwitchToInsert()
        {
            this.textBoxGross.ReadOnly = false;
            this.textBoxTare.ReadOnly = false;
            this.textTruckNum.ReadOnly = false;
            this.textBoxRSNUM.ReadOnly = false;
            this.textBoxDuductNum.ReadOnly = false;
            this.checkBoxCancel.Enabled = true;
            this.checkBoxHSFlag.Enabled = true;
            this.dataGridViewDetail.ReadOnly = false;
            toolStripButtonSave.Visible = true;
            toolStripButtonEdit.Visible = false;
            toolStripButtonCancel.Visible = false;
            toolStripSeparator1.Visible = true;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
            this.cbWerks.Enabled = true;
        }

        private void SwitchToReadOnly()
        {
            this.textBoxGross.ReadOnly = true;
            this.textBoxTare.ReadOnly = true;
            this.textTruckNum.ReadOnly = true;
            this.textBoxRSNUM.ReadOnly = true;
            this.textBoxDuductNum.ReadOnly = true;
            this.cbWerks.Enabled = false;
            this.dataGridViewDetail.ReadOnly = true;
            this.checkBoxCancel.Enabled = false;
            this.checkBoxHSFlag.Enabled = false;
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
            this.textBoxGross.Text = string.Empty;
            this.textBoxTare.Text = string.Empty;
            this.textBoxNet.Text = string.Empty;
            this.textBoxDuductNum.Text = string.Empty;
            this.cbWerks.Text = string.Empty;
            this.textTruckNum.Text = string.Empty;
            this.textBoxEnterTime.Text = Common.GetServerDate2();
            this.textBoxExitTime.Text = string.Empty;
            this.textWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitWeignMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.dataGridViewDetail.DataSource = null;
            this.checkBoxCancel.Checked = false;
            this.checkBoxHSFlag.Checked = false;
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
            this.textBoxRSNUM.Text = model.EBELN;
            this.textBoxDuductNum.Text = model.DEDUCTNUM.ToString();
            this.cbWerks.Text = model.WERKS;
            string where = "where timeflag='" + model.TIMEFLAG + "' and EBELN='" + model.EBELN + "' ";
            DataTable dt = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetailSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            checkBoxCancel.Checked = model.EXITFLAG == 1 ? true : false;
            checkBoxHSFlag.Checked = (model.HSFLAG == "S") ? true : false;
            dtfps = dt.Copy();
        }

        public void ShowDialog(IWin32Window parent, string truckNum, string EBELN, string timeFlag)
        {
            if (truckNum != "" || timeFlag != "")
            {
                toolStripButtonSave.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripButtonEdit.Visible = true;
                toolStripButtonCancel.Visible = true;
                model = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(truckNum, EBELN, timeFlag);
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
                this.textBoxNet.Text = (gross - tare).ToString();
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
