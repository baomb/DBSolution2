using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class ProductReturnMerchantEdit : Form
    {
        Sdl_ProductReturnMerchant model;
        DataTable dtfps;
        bool isInsert = false;
        public ProductReturnMerchantEdit()
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
                Sdl_ProductReturnMerchant modelTitleInsert = new Sdl_ProductReturnMerchant();
                Sdl_ProductReturnMerchantDetail modelInsert = new Sdl_ProductReturnMerchantDetail();
                //if (this.dataGridViewDetail.Rows.Count <= 1)
                //{
                //    MessageBox.Show(this, "信息不全，禁止添加！");
                //    return false;
                //}
                for (int i = 0; i < this.dataGridViewDetail.Rows.Count - 1; i++)
                {
                    if (this.dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString() != "" && this.dataGridViewDetail.Rows[i].Cells["POSNR"].Value.ToString() != "" && this.dataGridViewDetail.Rows[i].Cells["VBELN"].Value.ToString() != "")
                    {
                        modelInsert.LFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[i].Cells["LFIMG"].Value);
                        modelInsert.LGORT = this.dataGridViewDetail.Rows[i].Cells["LGORT"].Value.ToString();
                        modelInsert.MAKTX = this.dataGridViewDetail.Rows[i].Cells["MAKTX"].Value.ToString();
                        modelInsert.MATNR = this.dataGridViewDetail.Rows[i].Cells["MATNR"].Value.ToString();
                        modelInsert.POSNR = this.dataGridViewDetail.Rows[i].Cells["POSNR"].Value.ToString();
                        modelInsert.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["REALZFIMG"].Value);
                        modelInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                        modelInsert.VBELN = this.dataGridViewDetail.Rows[i].Cells["VBELN"].Value.ToString();
                        modelInsert.ZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["ZFIMG"].Value);
                        modelInsert.SFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[i].Cells["SFIMG"].Value);

                        Sdl_ProductReturnMerchantDetailAdapter.AddSdl_ProductReturnMerchantDetail(modelInsert);

                        CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchantDetail;
                        CompareModelHelper.CompareModel(new Sdl_ProductReturnMerchantDetail(), modelInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                    }
                    //else
                    //{
                    //    MessageBox.Show(this, "第" + (i + 1) + "行信息不全，添加失败！");
                    //    return false;
                    //}
                }
                for (int i = 0; i < this.dataGridViewDetail.Rows.Count - 1; i++)
                {
                    modelTitleInsert = new Sdl_ProductReturnMerchant();
                    modelTitleInsert.ENTERTIME = DateTime.Parse(this.textBoxEnterTime.Text);
                    modelTitleInsert.TYPEID = this.checkBoxCancel.Checked ? 1 : 0;
                    modelTitleInsert.EXITTIME = DateTime.Parse(Common.GetServerDate());
                    modelTitleInsert.GROSS = Convert.ToDouble(this.textBoxGross.Text);
                    modelTitleInsert.HSFLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                    modelTitleInsert.KUNNR = this.textBoxKUNNR.Text;
                    modelTitleInsert.NAME1 = this.textBoxNAME1.Text;
                    modelTitleInsert.TARE = Convert.ToDouble(this.textBoxTare.Text);
                    modelTitleInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                    modelTitleInsert.TRUCKNUM = this.textTruckNum.Text;
                    modelTitleInsert.VBELN = this.dataGridViewDetail.Rows[i].Cells["VBELN"].Value.ToString();
                    modelTitleInsert.WERKS = this.cbWerks.Text;
                    modelTitleInsert.ENTERWEIGHMAN = this.textWeighMan.Text;
                    modelTitleInsert.EXITWEIGHMAN = this.textBoxExitWeignMan.Text;
                    modelTitleInsert.KUIJIAN = Convert.ToDouble(this.textBoxKuijian.Text);

                    Sdl_ProductReturnMerchantAdapter.AddSdl_ProductReturnMerchant(modelTitleInsert);

                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchant;
                    CompareModelHelper.CompareModel(new Sdl_ProductReturnMerchant(), modelTitleInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
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
                DataTable dt = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchantDataTable(model.TRUCKNUM, model.TIMEFLAG);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sdl_ProductReturnMerchant fpstNew = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(model.TRUCKNUM, dt.Rows[i]["VBELN"].ToString(), model.TIMEFLAG);
                    fpstNew.HSFLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                    fpstNew.TYPEID = this.checkBoxCancel.Checked ? 1 : 0;
                    fpstNew.GROSS = Convert.ToDouble(this.textBoxGross.Text);
                    fpstNew.KUNNR = this.textBoxKUNNR.Text;
                    fpstNew.NAME1 = this.textBoxNAME1.Text;
                    fpstNew.TARE = Convert.ToDouble(this.textBoxTare.Text);
                    fpstNew.TRUCKNUM = this.textTruckNum.Text;
                    fpstNew.WERKS = this.cbWerks.Text;
                    fpstNew.KUIJIAN = Convert.ToDouble(this.textBoxKuijian.Text);

                    Sdl_ProductReturnMerchantAdapter.UpdateSdl_ProductReturnMerchant(fpstNew, dt.Rows[i]["VBELN"].ToString(), model.TRUCKNUM);

                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchant;
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
                Sdl_ProductReturnMerchantDetail fps = Sdl_ProductReturnMerchantDetailAdapter.GetSdl_ProductReturnMerchantDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());
                Sdl_ProductReturnMerchantDetail fpsOld = Sdl_ProductReturnMerchantDetailAdapter.GetSdl_ProductReturnMerchantDetail(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString());
                fps.LFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["LFIMG"].Value.ToString());
                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.POSNR = this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                fps.REALZFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value.ToString());
                fps.VBELN = this.dataGridViewDetail.Rows[rowIndex].Cells["VBELN"].Value.ToString();
                fps.ZFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["ZFIMG"].Value.ToString());
                fps.SFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["SFIMG"].Value.ToString());

                Sdl_ProductReturnMerchantDetailAdapter.UpdateSdl_ProductReturnMerchantDetail(fps, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchantDetail;
                CompareModelHelper.CompareModel(fpsOld, fps, CompareModelHelper.EditType.Update, Common.GetEnumDescription(module));

                if (fps.VBELN != dtfps.Rows[rowIndex]["VBELN"].ToString() && !Sdl_ProductReturnMerchantAdapter.ExistsSdl_ProductReturnMerchant(fps.TIMEFLAG, fps.VBELN))
                {
                    Sdl_ProductReturnMerchant newTitle = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(model.TRUCKNUM, model.VBELN, model.TIMEFLAG);
                    newTitle.VBELN = fps.VBELN;

                    Sdl_ProductReturnMerchantAdapter.AddSdl_ProductReturnMerchant(newTitle);

                    module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchant;
                    CompareModelHelper.CompareModel(new Sdl_ProductReturnMerchant(), newTitle, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
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
                Sdl_ProductReturnMerchantDetail fps = new Sdl_ProductReturnMerchantDetail();
                fps.LFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["LFIMG"].Value);
                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.POSNR = this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                fps.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value);
                fps.VBELN = this.dataGridViewDetail.Rows[rowIndex].Cells["VBELN"].Value.ToString().TrimStart('0');
                fps.ZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["ZFIMG"].Value);
                fps.TIMEFLAG = model.TIMEFLAG;
                fps.SFIMG = Convert.ToDouble(this.dataGridViewDetail.Rows[rowIndex].Cells["SFIMG"].Value);

                Sdl_ProductReturnMerchantDetailAdapter.AddSdl_ProductReturnMerchantDetail(fps);

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchantDetail;
                CompareModelHelper.CompareModel(new Sdl_ProductReturnMerchantDetail(), fps, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));

                if (!Sdl_ProductReturnMerchantAdapter.ExistsSdl_ProductReturnMerchant(fps.TIMEFLAG, fps.VBELN) && fps.VBELN != model.VBELN)
                {
                    Sdl_ProductReturnMerchant fpst = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(model.TRUCKNUM, model.TIMEFLAG);
                    fpst.VBELN = fps.VBELN;

                    Sdl_ProductReturnMerchantAdapter.AddSdl_ProductReturnMerchant(fpst);

                    module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchant;
                    CompareModelHelper.CompareModel(new Sdl_ProductReturnMerchant(), fpst, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
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
                Sdl_ProductReturnMerchantDetail fps = Sdl_ProductReturnMerchantDetailAdapter.GetSdl_ProductReturnMerchantDetail(model.TIMEFLAG, this.dataGridViewDetail.Rows[rowIndex].Cells["VBELN"].Value.ToString(), this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString(), this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString());

                Sdl_ProductReturnMerchantDetailAdapter.DeleteSdl_ProductReturnMerchantDetail(model.TIMEFLAG, this.dataGridViewDetail.Rows[rowIndex].Cells["VBELN"].Value.ToString(), this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString(), this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.ProductReturnMerchantDetail;
                CompareModelHelper.CompareModel(fps, new Sdl_ProductReturnMerchantDetail(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private bool DeleteTitle()
        {
            bool result = true;
            try
            {
                Sdl_ProductReturnMerchantAdapter.DeleteSdl_ProductReturnMerchant(model.TRUCKNUM, model.TIMEFLAG, model.VBELN);
                Sdl_ProductReturnMerchantDetailAdapter.DeleteSdl_ProductReturnMerchantDetail(model.TIMEFLAG, model.VBELN);
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
            this.textBoxKUNNR.ReadOnly = false;
            this.textBoxNAME1.ReadOnly = false;
            this.textBoxKuijian.ReadOnly = false;
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
            this.textBoxKUNNR.ReadOnly = false;
            this.textBoxNAME1.ReadOnly = false;
            this.textBoxKuijian.ReadOnly = false;
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
            this.textBoxKUNNR.ReadOnly = true;
            this.textBoxNAME1.ReadOnly = true;
            this.textBoxKuijian.ReadOnly = true;
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
            this.textBoxKuijian.Text = string.Empty;
            this.cbWerks.Text = string.Empty;
            this.textTruckNum.Text = string.Empty;
            this.textBoxKUNNR.Text = string.Empty;
            this.textBoxNAME1.Text = string.Empty;
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
            this.textBoxKUNNR.Text = model.KUNNR;
            this.textBoxNAME1.Text = model.NAME1;
            this.textBoxKuijian.Text = model.KUIJIAN.ToString();
            this.cbWerks.Text = model.WERKS;
            string where = " where B.timeflag='" + model.TIMEFLAG + "' and werks='" + model.WERKS + "' ";
            DataTable dt = Sdl_ProductReturnMerchantDetailAdapter.GetSdl_ProductReturnMerchantDetailSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            checkBoxCancel.Checked = (model.TYPEID == 1) ? true : false;
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
                model = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(truckNum, timeFlag);
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
