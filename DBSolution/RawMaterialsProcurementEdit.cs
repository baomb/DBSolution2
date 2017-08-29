using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;
using System.Collections.Specialized;

namespace DBSolution
{
    public partial class RawMaterialsProcurementEdit : Form
    {
        Sdl_RawMaterialsProcurementTitle model;
        DataTable dtfps;
        string matnr = string.Empty;
        decimal discount = 0.997M;
        bool isInsert = false;
        bool status = false;
        public RawMaterialsProcurementEdit()
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
                Sdl_RawMaterialsProcurementTitle modelTitleInsert = new Sdl_RawMaterialsProcurementTitle();
                Sdl_RawMaterialsProcurement modelInsert = new Sdl_RawMaterialsProcurement();
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
                        modelInsert.PSTYP = this.dataGridViewDetail.Rows[i].Cells["PSTYP"].Value.ToString();
                        modelInsert.BKTXT = this.dataGridViewDetail.Rows[i].Cells["BKTXT"].Value.ToString();
                        modelInsert.ZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["ZFIMG"].Value);
                        modelInsert.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["REALZFIMG"].Value);
                        modelInsert.PWEIGHT = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["PWEIGHT"].Value);
                        modelInsert.LIFNR = this.dataGridViewDetail.Rows[i].Cells["LIFNR"].Value.ToString();
                        modelInsert.MCOD1 = this.dataGridViewDetail.Rows[i].Cells["MCOD1"].Value.ToString();
                        modelInsert.NKEY = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["NKEY"].Value);
                        modelInsert.DFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[i].Cells["DFIMG"].Value);
                        modelInsert.TIMEFLAG = this.textBoxEnterTime.Text;
                        modelInsert.VBELN = this.textBoxRSNUM.Text;
                        modelInsert.SFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[i].Cells["SFIMG"].Value);
                        modelInsert.LFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[i].Cells["LFIMG"].Value);
                        modelInsert.SGTXT = this.dataGridViewDetail.Rows[i].Cells["LFIMG"].Value + "/" + this.dataGridViewDetail.Rows[i].Cells["REALZFIMG"].Value + "/" + this.dataGridViewDetail.Rows[i].Cells["DFIMG"].Value + "/" + this.textBoxWAGON.Text + "/" + this.textBoxNet.Text + "/" + this.textBoxCYNUM.Text;
                        modelInsert.STORAGETYPE = this.dataGridViewDetail.Rows[i].Cells["StorageType"].Value.ToString();
                        Sdl_RawMaterialsProcurementAdapter.AddSdl_RawMaterialsProcurement(modelInsert);

                        CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurement;
                        CompareModelHelper.CompareModel(new Sdl_RawMaterialsProcurement(), modelInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
                    }
                    //else
                    //{
                    //    MessageBox.Show(this, "第" + (i + 1) + "行信息不全，添加失败！");
                    //    return false;
                    //}
                }
                modelTitleInsert = new Sdl_RawMaterialsProcurementTitle();
                modelTitleInsert.ENTERTIME = DateTime.Parse(this.textBoxEnterTime.Text);
                modelTitleInsert.EXITFLAG = this.checkBoxCancel.Checked;
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
                modelTitleInsert.ABLAD = this.textBoxABLAD.Text;
                modelTitleInsert.WAGON = this.textBoxWAGON.Text;
                modelTitleInsert.CYNUM = Convert.ToSingle(this.textBoxCYNUM.Text);
                modelTitleInsert.BALANCE = Convert.ToSingle(this.textBoxDiff.Text);
                modelTitleInsert.TRAYWEIGHT = Convert.ToInt16(this.textBoxTrayWeight.Text);
                modelTitleInsert.TRAYQUANTITY = Convert.ToInt16(this.textBoxTrayQuantity.Text);
                modelTitleInsert.BFIMG = this.textBfimg.Text.ToString();
                modelTitleInsert.FREIGHT = this.textFreight.Text.ToString();
                modelTitleInsert.WAGONNUM = this.txtWagonNum.Text.ToString();
                Sdl_RawMaterialsProcurementTitleAdapter.AddSdl_RawMaterialsProcurementTitle(modelTitleInsert);

                CompareModelHelper.SdlDB_Modules moduleTitle = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurementTitle;
                CompareModelHelper.CompareModel(new Sdl_RawMaterialsProcurementTitle(), modelTitleInsert, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(moduleTitle));
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
                Sdl_RawMaterialsProcurementTitle fpstNew = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(model.TRUCKNUM, model.VBELN, model.TIMEFLAG);
                Sdl_RawMaterialsProcurementTitle fpstOld = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(model.TRUCKNUM, model.VBELN, model.TIMEFLAG);
                fpstNew.HS_FLAG = this.checkBoxHSFlag.Checked ? "S" : "H";
                fpstNew.EXITFLAG = this.checkBoxCancel.Checked;
                fpstNew.GROSS = Convert.ToSingle(this.textBoxGross.Text);
                fpstNew.TARE = Convert.ToSingle(this.textBoxTare.Text);
                fpstNew.NET = Convert.ToSingle(this.textBoxNet.Text);
                fpstNew.VBELN = this.textBoxRSNUM.Text;
                fpstNew.TRUCKNUM = this.textTruckNum.Text;
                fpstNew.WERKS = this.cbWerks.Text;
                fpstNew.ABLAD = this.textBoxABLAD.Text;
                fpstNew.CYNUM = Convert.ToSingle(this.textBoxCYNUM.Text);
                fpstNew.WAGON = this.textBoxWAGON.Text;
                fpstNew.BALANCE = Convert.ToSingle(this.textBoxDiff.Text);
                fpstNew.BFIMG = this.textBfimg.Text.ToString();
                fpstNew.WAGONNUM = this.txtWagonNum.Text.ToString();
                fpstNew.FREIGHT = this.textFreight.Text.ToString();
                if (this.textBoxTrayWeight.Text != "")
                {
                    fpstNew.TRAYWEIGHT = Convert.ToInt16(this.textBoxTrayWeight.Text);
                    fpstNew.TRAYQUANTITY = Convert.ToInt16(this.textBoxTrayQuantity.Text);
                }
                else
                {
                    fpstNew.TRAYWEIGHT = 0;
                    fpstNew.TRAYQUANTITY = 0;
                }
                Sdl_RawMaterialsProcurementTitleAdapter.UpdateSdl_RawMaterialsProcurementTitle(fpstNew, fpstOld.VBELN, fpstOld.TRUCKNUM);

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurementTitle;
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
                        string bktxt = dataGridViewDetail.Rows[i].Cells["BKTXT"].Value.ToString();
                        int nkey = Convert.ToInt16(dataGridViewDetail.Rows[i].Cells["NKEY"].Value.ToString());
                        Sdl_RawMaterialsProcurement fpp = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(timeflag, vbeln, posnr, lgort, bktxt, nkey);
                        Sdl_RawMaterialsProcurement fppOld = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(timeflag, vbeln, posnr, lgort, bktxt, nkey);
                        fpp.VBELN = fpstNew.VBELN;
                        Sdl_RawMaterialsProcurementAdapter.UpdateSdl_RawMaterialsProcurement(fpp, vbeln, lgort, nkey.ToString(), bktxt, posnr);

                        module = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurement;
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
                Sdl_RawMaterialsProcurement fps = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["BKTXT"].ToString(), Convert.ToInt16(dtfps.Rows[rowIndex]["NKEY"].ToString()));
                Sdl_RawMaterialsProcurement fpsOld = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["BKTXT"].ToString(), Convert.ToInt16(dtfps.Rows[rowIndex]["NKEY"].ToString()));
                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.POSNR = this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                fps.PSTYP = this.dataGridViewDetail.Rows[rowIndex].Cells["PSTYP"].Value.ToString();
                fps.BKTXT = this.dataGridViewDetail.Rows[rowIndex].Cells["BKTXT"].Value.ToString();
                fps.ZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["ZFIMG"].Value);
                fps.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value);
                fps.PWEIGHT = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["PWEIGHT"].Value);
                fps.LIFNR = this.dataGridViewDetail.Rows[rowIndex].Cells["LIFNR"].Value.ToString();
                fps.MCOD1 = this.dataGridViewDetail.Rows[rowIndex].Cells["MCOD1"].Value.ToString();
                fps.NKEY = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["NKEY"].Value);
                fps.DFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["DFIMG"].Value);
                fps.SFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[rowIndex].Cells["SFIMG"].Value);
                fps.LFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[rowIndex].Cells["LFIMG"].Value);
                fps.SGTXT = this.dataGridViewDetail.Rows[rowIndex].Cells["SGTXT"].Value.ToString();
                fps.STORAGETYPE = this.dataGridViewDetail.Rows[rowIndex].Cells["StorageType"].Value.ToString();

                Sdl_RawMaterialsProcurementAdapter.UpdateSdl_RawMaterialsProcurement(fps, dtfps.Rows[rowIndex]["VBELN"].ToString().Trim(' '), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["NKEY"].ToString(), dtfps.Rows[rowIndex]["BKTXT"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString());

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurement;
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
                Sdl_RawMaterialsProcurement fps = new Sdl_RawMaterialsProcurement();
                fps.LGORT = this.dataGridViewDetail.Rows[rowIndex].Cells["LGORT"].Value.ToString();
                fps.MAKTX = this.dataGridViewDetail.Rows[rowIndex].Cells["MAKTX"].Value.ToString();
                fps.MATNR = this.dataGridViewDetail.Rows[rowIndex].Cells["MATNR"].Value.ToString();
                fps.POSNR = this.dataGridViewDetail.Rows[rowIndex].Cells["POSNR"].Value.ToString();
                fps.PSTYP = this.dataGridViewDetail.Rows[rowIndex].Cells["PSTYP"].Value.ToString();
                fps.BKTXT = this.dataGridViewDetail.Rows[rowIndex].Cells["BKTXT"].Value.ToString();
                fps.ZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["ZFIMG"].Value);
                fps.REALZFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value);
                fps.PWEIGHT = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["PWEIGHT"].Value);
                fps.LIFNR = this.dataGridViewDetail.Rows[rowIndex].Cells["LIFNR"].Value.ToString();
                fps.MCOD1 = this.dataGridViewDetail.Rows[rowIndex].Cells["MCOD1"].Value.ToString();
                fps.NKEY = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["NKEY"].Value);
                fps.DFIMG = Convert.ToInt32(this.dataGridViewDetail.Rows[rowIndex].Cells["DFIMG"].Value);
                fps.TIMEFLAG = model.TIMEFLAG;
                fps.VBELN = model.VBELN;
                fps.SFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[rowIndex].Cells["SFIMG"].Value);
                fps.LFIMG = Convert.ToSingle(this.dataGridViewDetail.Rows[rowIndex].Cells["LFIMG"].Value);
                fps.STORAGETYPE = this.dataGridViewDetail.Rows[rowIndex].Cells["StorageType"].Value.ToString();
                fps.SGTXT = this.dataGridViewDetail.Rows[rowIndex].Cells["ZFIMG"].Value + "/" +
                    this.dataGridViewDetail.Rows[rowIndex].Cells["REALZFIMG"].Value + "/" +
                    this.dataGridViewDetail.Rows[rowIndex].Cells["DFIMG"].Value + "/" +
                    this.dataGridViewDetail.Rows[rowIndex].Cells["LFIMG"].Value + "/" +
                    this.textBoxNet.Text + "/" +
                    this.textBoxCYNUM.Text + "/" +
                    this.textBoxWAGON.Text + "/" +
                    this.dataGridViewDetail.Rows[rowIndex].Cells["StorageType"].Value;
                int count = Sdl_RawMaterialsProcurementAdapter.AddSdl_RawMaterialsProcurement(fps);
                if (count == 1)
                {
                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurement;
                    CompareModelHelper.CompareModel(new Sdl_RawMaterialsProcurement(), fps, CompareModelHelper.EditType.Insert, Common.GetEnumDescription(module));
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
                Sdl_RawMaterialsProcurement fps = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["BKTXT"].ToString(), Convert.ToInt16(dtfps.Rows[rowIndex]["NKEY"].ToString()));

                Sdl_RawMaterialsProcurementAdapter.DeleteSdl_RawMaterialsProcurement(model.TIMEFLAG, dtfps.Rows[rowIndex]["VBELN"].ToString(), dtfps.Rows[rowIndex]["POSNR"].ToString(), dtfps.Rows[rowIndex]["LGORT"].ToString(), dtfps.Rows[rowIndex]["BKTXT"].ToString(), Convert.ToInt16(dtfps.Rows[rowIndex]["NKEY"].ToString()));

                CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialsProcurement;
                CompareModelHelper.CompareModel(fps, new Sdl_RawMaterialsProcurement(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
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
            this.textBoxABLAD.ReadOnly = false;
            this.textBoxCYNUM.ReadOnly = false;
            this.textBoxWAGON.ReadOnly = false;
            this.txtWagonNum.ReadOnly = false;
            this.textBoxDiff.ReadOnly = false;
            this.textBoxTrayWeight.ReadOnly = false;
            this.textBoxTrayQuantity.ReadOnly = false;
            this.dataGridViewDetail.ReadOnly = false;
            this.cbWerks.Enabled = true;
            this.checkBoxCancel.Enabled = true;
            this.checkBoxHSFlag.Enabled = true;
            status = true;
        }

        private void SwitchToInsert()
        {
            this.textBoxGross.ReadOnly = false;
            this.textBoxTare.ReadOnly = false;
            this.textTruckNum.ReadOnly = false;
            this.textBoxRSNUM.ReadOnly = false;
            this.textBoxABLAD.ReadOnly = false;
            this.textBoxCYNUM.ReadOnly = false;
            this.textBoxWAGON.ReadOnly = false;
            this.txtWagonNum.ReadOnly = false;
            this.textBoxDiff.ReadOnly = false;
            this.textBoxTrayWeight.ReadOnly = false;
            this.textBoxTrayQuantity.ReadOnly = false;
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
            this.textBoxABLAD.ReadOnly = true;
            this.textBoxCYNUM.ReadOnly = true;
            this.textBoxWAGON.ReadOnly = true;
            this.txtWagonNum.ReadOnly = true;
            this.textBoxDiff.ReadOnly = true;
            this.textBoxTrayWeight.ReadOnly = true;
            this.textBoxTrayQuantity.ReadOnly = true;
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
            this.textBoxABLAD.Text = string.Empty;
            this.textBoxCYNUM.Text = string.Empty;
            this.textBoxWAGON.Text = string.Empty;
            this.cbWerks.Text = string.Empty;
            this.textTruckNum.Text = string.Empty;
            this.textBoxEnterTime.Text = Common.GetServerDate2();
            this.textBoxExitTime.Text = string.Empty;
            this.textBoxDiff.Text = string.Empty;
            this.textWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitWeignMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxTrayWeight.Text = string.Empty;
            this.textBoxTrayQuantity.Text = string.Empty;
            this.dataGridViewDetail.DataSource = null;
            this.checkBoxCancel.Checked = false;
            this.checkBoxHSFlag.Checked = false;
            this.textFreight.Text = string.Empty;
            this.txtWagonNum.Text = string.Empty;
            this.textBfimg.Text = string.Empty;
        }

        private void BindData()
        {
            string where = "where timeflag='" + model.TIMEFLAG + "' and VBELN='" + model.VBELN + "' ";
            DataTable dt = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurementDataSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.textTruckNum.Text = model.TRUCKNUM;
            this.textWeighMan.Text = model.WEIGHMAN;
            this.textBoxEnterTime.Text = model.TIMEFLAG;
            this.textBoxExitTime.Text = model.EXITTIME.ToString();
            this.textBoxGross.Text = model.GROSS.ToString();
            this.textBoxTare.Text = model.TARE.ToString();
            this.textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            this.textBoxNet.Text = (model.GROSS - model.TARE).ToString();
            this.textBoxRSNUM.Text = model.VBELN;
            this.textBoxABLAD.Text = model.ABLAD;
            this.textBoxCYNUM.Text = model.CYNUM.ToString();
            this.textBoxWAGON.Text = model.WAGON;
            this.textBoxDiff.Text = model.BALANCE.ToString();
            this.textBoxTrayWeight.Text = model.TRAYWEIGHT.ToString();
            this.textBoxTrayQuantity.Text = model.TRAYQUANTITY.ToString();
            this.cbWerks.Text = model.WERKS;
            this.checkBoxCancel.Checked = model.EXITFLAG;
            this.checkBoxHSFlag.Checked = (model.HS_FLAG == "S") ? true : false;
            this.textBfimg.Text = model.BFIMG;
            this.textFreight.Text = model.FREIGHT;
            this.txtWagonNum.Text = model.WAGONNUM;
            dtfps = dt.Copy();
        }

        public void ShowDialog(IWin32Window parent, string truckNum, string VBELN, string timeFlag)
        {
            if (truckNum != "" || timeFlag != "")
            {
                toolStripButtonSave.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripButtonEdit.Visible = true;
                toolStripButtonCancel.Visible = true;
                model = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(truckNum, VBELN, timeFlag);
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
            CalcNet();
        }

        private void CalcNet()
        {
            try
            {
                if (this.textBoxGross.Text.Trim() == "" || this.textBoxTare.Text.Trim() == "")
                {
                    return;
                }
                int tuopan = 0;
                if (ValidateHelper.IsNumber(this.textBoxTrayWeight.Text))
                {
                    tuopan = Convert.ToInt16(this.textBoxTrayWeight.Text);
                }
                int quantity = 0;
                if (ValidateHelper.IsNumber(this.textBoxTrayQuantity.Text))
                {
                    quantity = Convert.ToInt16(this.textBoxTrayQuantity.Text);
                }
                decimal weight = Convert.ToDecimal(tuopan * quantity / 1000.0);
                Decimal gross = Convert.ToDecimal(this.textBoxGross.Text.TrimEnd('.'));
                Decimal tare = Convert.ToDecimal(this.textBoxTare.Text.TrimEnd('.'));
                //读取扣杂
                try
                {
                    matnr = dataGridViewDetail.Rows[0].Cells["MATNR"].Value.ToString();
                    if (!string.IsNullOrEmpty(matnr))
                    {
                        ListDictionary la = new ListDictionary();
                        la.Add("I_MATNR", matnr);
                        ListDictionary lt = new ListDictionary();
                        ListDictionary lr = new ListDictionary();
                        lr.Add("E_DISCOUNT", discount);
                        SAPHelper.InvokSAPFun("Z_SDL_MATERIAL_DISCOUNT", la, ref lr);
                        if (lr != null && lr["E_DISCOUNT"] != null)
                        {
                            if (lr["E_DISCOUNT"].ToString() == "X")
                            {
                                MessageBox.Show(this, "该物料没有维护产品层次，请联系SAP相关人员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                discount = Convert.ToDecimal(lr["E_DISCOUNT"]);
                            }
                        }
                    }
                }
                catch
                {
                }
                this.textBoxNet.Text = Math.Round((gross - tare - weight) * discount, 2).ToString();
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

        private void dataGridViewDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (colIndex == 7 && status)
            {
                CalcNet();
            }
        }
    }
}
