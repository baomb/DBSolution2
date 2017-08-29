using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class RawMaterialsSaleEdit : Form
    {
        Sdl_RawMaterialsSaleTitle model;
        DataTable dtfps;
        bool isInsert = false;
        public RawMaterialsSaleEdit()
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
                Sdl_RawMaterialsSaleTitle modelTitleInsert = new Sdl_RawMaterialsSaleTitle();
                Sdl_RawMaterialsSale modelInsert = new Sdl_RawMaterialsSale();
                //if (this.dataGridViewDetail.Rows.Count <= 1)
                //{
                //    MessageBox.Show(this, "信息不全，禁止添加！");
                //    return false;
                //}
                for (int i = 0; i < this.dataGridViewDetail.Rows.Count - 1; i++)
                {
                    if (this.dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString() != "" && this.dataGridViewDetail.Rows[i].Cells["POSNR"].Value.ToString() != "")
                    {
                        modelInsert.LGORT = this.dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString();
                        modelInsert.MAKTX = this.dataGridViewDetail.Rows[i].Cells["MAKTX"].Value.ToString();
                        modelInsert.MATNR = this.dataGridViewDetail.Rows[i].Cells["MATNR"].Value.ToString();
                        modelInsert.POSNR = this.dataGridViewDetail.Rows[i].Cells["POSNR"].Value.ToString();
                        modelInsert.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["REALZFIMG"].Value);
                        modelInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                        modelInsert.VBELN = this.textBoxRSNUM.Text;
                        modelInsert.SFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[i].Cells["SFIMG"].Value);
                        modelInsert.KUNNR = this.dataGridViewDetail.Rows[i].Cells["KUNNR"].Value.ToString();
                        modelInsert.NAME1 = this.dataGridViewDetail.Rows[i].Cells["NAME1"].Value.ToString();
                        Sdl_RawMaterialsSaleAdapter.AddSdl_RawMaterialsSale(modelInsert);

                        CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsSale;
                        CompareModelHelper.CompareModel(new Sdl_RawMaterialsSale(), modelInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                    }
                    //else
                    //{
                    //    MessageBox.Show(this, "第" + (i + 1) + "行信息不全，添加失败！");
                    //    return false;
                    //}
                }
                modelTitleInsert = new Sdl_RawMaterialsSaleTitle();
                modelTitleInsert.ENTERTIME = DateTime.Parse(this.textBoxEnterTime.Text);
                modelTitleInsert.EXITFLAG = this.checkBoxCancel.Checked ? true : false;
                modelTitleInsert.EXITTIME = DateTime.Parse(Common.GetServerDate());
                modelTitleInsert.GROSS = Convert.ToSingle(this.textBoxGross.Text);
                modelTitleInsert.HS_FLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                modelTitleInsert.TARE = Convert.ToSingle(this.textBoxTare.Text);
                modelTitleInsert.NET = Convert.ToSingle(this.textBoxNet.Text);
                modelTitleInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                modelTitleInsert.TRUCKNUM = this.textTruckNum.Text;
                modelTitleInsert.VBELN = this.textBoxRSNUM.Text;
                modelTitleInsert.WERKS = this.cbWerks.Text;
                modelTitleInsert.WEIGHMAN = this.textWeighMan.Text;
                modelTitleInsert.EXITWEIGHMAN = this.textBoxExitWeignMan.Text;

                Sdl_RawMaterialsSaleTitleAdapter.AddSdl_RawMaterialsSaleTitle(modelTitleInsert);

                CompareModelHelper.SdlDB_Modules moduleTitle = CompareModelHelper.SdlDB_Modules.RawMaterialsSaleTitle;
                CompareModelHelper.CompareModel(new Sdl_RawMaterialsSaleTitle(), modelTitleInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(moduleTitle));
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
                Sdl_RawMaterialsSaleTitle fpstNew = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitle(model.TRUCKNUM, model.VBELN, model.TIMEFLAG);
                Sdl_RawMaterialsSaleTitle fpstOld = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitle(model.TRUCKNUM, model.VBELN, model.TIMEFLAG);
                fpstNew.HS_FLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                fpstNew.EXITFLAG = this.checkBoxCancel.Checked ? true : false;
                fpstNew.GROSS = Convert.ToSingle(this.textBoxGross.Text);
                fpstNew.TARE = Convert.ToSingle(this.textBoxTare.Text);
                fpstNew.NET = Convert.ToSingle(this.textBoxNet.Text);
                fpstNew.VBELN = this.textBoxRSNUM.Text;
                fpstNew.TRUCKNUM = this.textTruckNum.Text;
                fpstNew.WERKS = this.cbWerks.Text;

                Sdl_RawMaterialsSaleTitleAdapter.UpdateSdl_RawMaterialsSaleTitle(fpstNew, fpstOld.TRUCKNUM, fpstOld.VBELN);

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsSaleTitle;
                CompareModelHelper.CompareModel(model, fpstNew, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));
                if (fpstNew.VBELN != fpstOld.VBELN)
                {
                    for (int i = 0; i < dataGridViewDetail.Rows.Count; i++)
                    {
                        if (dataGridViewDetail.Rows[i].IsNewRow)
                        {
                            continue;
                        }
                        string vbeln = dataGridViewDetail.Rows[i].Cells["VBELN"].Value.ToString();
                        string timeflag = dataGridViewDetail.Rows[i].Cells["TIMEFLAG"].Value.ToString();
                        string posnr = dataGridViewDetail.Rows[i].Cells["POSNR"].Value.ToString();
                        string lgort = dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString();
                        Sdl_RawMaterialsSale fpp = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSale(timeflag, vbeln, posnr, lgort);
                        Sdl_RawMaterialsSale fppOld = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSale(timeflag, vbeln, posnr, lgort);
                        fpp.VBELN = fpstNew.VBELN;
                        Sdl_RawMaterialsSaleAdapter.UpdateSdl_RawMaterialsSale(fpp, vbeln, lgort, posnr);

                        module = CompareModelHelper.SdlDB_Modules.RawMaterialsSale;
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
                Sdl_RawMaterialsSale fps = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSale(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());
                Sdl_RawMaterialsSale fpsOld = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSale(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());
                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.POSNR = this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                fps.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value.ToString());
                fps.KUNNR = this.dataGridViewDetail.Rows[rowIndex].Cells["KUNNR"].Value.ToString();
                fps.NAME1 = this.dataGridViewDetail.Rows[rowIndex].Cells["NAME1"].Value.ToString();
                fps.SFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[rowIndex].Cells["SFIMG"].Value.ToString());

                Sdl_RawMaterialsSaleAdapter.UpdateSdl_RawMaterialsSale(fps, dtfps.Rows[rowIndex]["VBELN"].ToString().Trim(' '), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsSale;
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
                Sdl_RawMaterialsSale fps = new Sdl_RawMaterialsSale();
                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.POSNR = this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                fps.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value);
                fps.VBELN = this.textBoxRSNUM.Text;
                fps.SFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["SFIMG"].Value);
                fps.TIMEFLAG = model.TIMEFLAG;
                fps.KUNNR = this.dataGridViewDetail.Rows[rowIndex].Cells["KUNNR"].Value.ToString();
                fps.NAME1 = this.dataGridViewDetail.Rows[rowIndex].Cells["NAME1"].Value.ToString();

                int count = Sdl_RawMaterialsSaleAdapter.AddSdl_RawMaterialsSale(fps);
                if (count == 1)
                {
                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsSale;
                    CompareModelHelper.CompareModel(new Sdl_RawMaterialsSale(), fps, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
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
                Sdl_RawMaterialsSale fps = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSale(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());

                Sdl_RawMaterialsSaleAdapter.DeleteSdl_RawMaterialsSale(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsSale;
                CompareModelHelper.CompareModel(fps, new Sdl_RawMaterialsSale(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
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
            this.textWeighMan.Text = model.WEIGHMAN;
            this.textBoxEnterTime.Text = model.TIMEFLAG;
            this.textBoxExitTime.Text = model.EXITTIME.ToString();
            this.textBoxGross.Text = model.GROSS.ToString();
            this.textBoxTare.Text = model.TARE.ToString();
            this.textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            this.textBoxNet.Text = (model.GROSS - model.TARE).ToString();
            this.textBoxRSNUM.Text = model.VBELN;
            this.cbWerks.Text = model.WERKS;
            string where = "where timeflag='" + model.TIMEFLAG + "' and vbeln='" + model.VBELN + "' ";
            DataTable dt = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSaleDataSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            checkBoxCancel.Checked = model.EXITFLAG;
            checkBoxHSFlag.Checked = (model.HS_FLAG == "S") ? true : false;
            dtfps = dt.Copy();
        }

        public void ShowDialog(IWin32Window parent, string truckNum, string vbeln, string timeFlag)
        {
            if (truckNum != "" || timeFlag != "")
            {
                toolStripButtonSave.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripButtonEdit.Visible = true;
                toolStripButtonCancel.Visible = true;
                model = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitle(truckNum, vbeln, timeFlag);
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
