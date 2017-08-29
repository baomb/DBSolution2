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
using SdlDB.Utility;

namespace DBSolution
{
    public partial class RawMaterialReturnManage : Form
    {
        string whereCondition = string.Empty;

        public RawMaterialReturnManage()
        {
            InitializeComponent();
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.TimePickerBegin.Format = DateTimePickerFormat.Custom;
            this.TimePickerEnd.Format = DateTimePickerFormat.Custom;
            TimePickerBegin.CustomFormat = " ";
            TimePickerEnd.CustomFormat = " ";
            Sdl_SysSetting sys = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            string condition = string.Empty;
            Common.BindCBox(cbWerks);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            pager.PageIndex = 1;
            SearchDataBind(1, GetWhereStr());
            pager.BindData();
        }

        private string GetWhereStr()
        {
            string condition = " where 1=1 ";
            Sdl_SysSetting sys = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            if (sys != null)
            {
                condition += " and werks = '" + cbWerks.Text + "'";
            }
            if (textTruckNum.Text != string.Empty)
            {
                condition += " and trucknum like '%" + textTruckNum.Text + "%'";
            }
            if (textRSNUM.Text != string.Empty)
            {
                condition += " and EBELN = '" + textRSNUM.Text + "'";
            }
            if (textWeighMan.Text != string.Empty)
            {
                condition += " and WeighMan like '%" + textWeighMan.Text + "%'";
            }
            if (TimePickerBegin.Text != " ")
            {
                condition += " and Entertime >= '" + TimePickerBegin.Text + "'";
            }
            if (TimePickerEnd.Text != " ")
            {
                condition += " and Entertime <= '" + Common.GetAddOneDayDate(TimePickerEnd.Text) + "'";
            }
            return condition;
        }

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = Common.GetPageSize();
            DataSet ds = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.whereCondition = whereCondition;
        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            string truckNum, timeFlag, EBELN;
            if (columnIndex == 1)
            {
                if (MessageBox.Show("确认要删除该行数据吗？", "删除确认",
                    MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        truckNum = dataGridViewDetail.Rows[rowIndex].Cells["TRUCKNUM"].Value as string;
                        timeFlag = dataGridViewDetail.Rows[rowIndex].Cells["TIMEFLAG"].Value as string;
                        EBELN = dataGridViewDetail.Rows[rowIndex].Cells["EBELN"].Value as string;
                        Sdl_RawMaterialReturnTitle model = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitle(truckNum, EBELN, timeFlag);

                        Sdl_RawMaterialReturnTitleAdapter.DeleteSdl_RawMaterialReturnTitle(timeFlag, EBELN, truckNum);

                        CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.RawMaterialReturnTitle;
                        CompareModelHelper.CompareModel(model, new Sdl_RawMaterialReturnTitle(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));

                        DataTable dt = Sdl_RawMaterialReturnDetailAdapter.GetSdl_RawMaterialReturnDetailSet("where timeflag = '" + model.TIMEFLAG + "' and EBELN = '" + EBELN + "'").Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Sdl_RawMaterialReturnDetail fpp = Sdl_RawMaterialReturnDetailAdapter.GetSdl_RawMaterialReturnDetail(timeFlag, EBELN, dt.Rows[i]["ebelp"].ToString(), dt.Rows[i]["lgort"].ToString());
                            Sdl_RawMaterialReturnDetailAdapter.DeleteSdl_RawMaterialReturnDetail(timeFlag, EBELN, dt.Rows[i]["ebelp"].ToString(), dt.Rows[i]["lgort"].ToString());
                            module = CompareModelHelper.SdlDB_Modules.RawMaterialReturnDetail;
                            CompareModelHelper.CompareModel(fpp, new Sdl_RawMaterialReturnDetail(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
                        }

                        SearchDataBind(1, whereCondition);
                        MessageBox.Show(this, "操作成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        SearchDataBind(1, whereCondition);
                        MessageBox.Show(this, "操作失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (columnIndex == 0 && rowIndex != -1 && !dataGridViewDetail.Rows[rowIndex].IsNewRow)
            {
                truckNum = dataGridViewDetail.Rows[rowIndex].Cells["TRUCKNUM"].Value as string;
                EBELN = dataGridViewDetail.Rows[rowIndex].Cells["EBELN"].Value as string;
                timeFlag = dataGridViewDetail.Rows[rowIndex].Cells["TIMEFLAG"].Value as string;
                if (truckNum != null)
                {
                    this.EditDetail(truckNum, EBELN, timeFlag);
                }
            }
        }

        private void EditDetail(string truckNum, string EBELN, string timeFlag)
        {
            this.Cursor = Cursors.WaitCursor;
            RawMaterialReturnEdit edit = new RawMaterialReturnEdit();
            edit.StartPosition = FormStartPosition.CenterParent;
            edit.ShowDialog(this, truckNum, EBELN, timeFlag);
            this.Cursor = Cursors.Default;
            SearchDataBind(1, whereCondition);
        }

        private void TimePickerBegin_ValueChanged(object sender, EventArgs e)
        {
            this.TimePickerBegin.Format = DateTimePickerFormat.Custom;
            this.TimePickerBegin.CustomFormat = "yyyy-MM-dd";
        }

        private void TimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            this.TimePickerEnd.Format = DateTimePickerFormat.Custom;
            this.TimePickerEnd.CustomFormat = "yyyy-MM-dd";
        }

        private void textTruckNum_TextChanged(object sender, EventArgs e)
        {
            textTruckNum.Text = textTruckNum.Text.ToUpper();
            textTruckNum.SelectionStart = textTruckNum.Text.Length;
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            SearchDataBind(pager.PageIndex, GetWhereStr());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RawMaterialReturnEdit edit = new RawMaterialReturnEdit();
            edit.StartPosition = FormStartPosition.CenterParent;
            edit.ShowDialog(this, "", "", "");
            this.Cursor = Cursors.Default;
            SearchDataBind(1, whereCondition);
        }
    }
}
