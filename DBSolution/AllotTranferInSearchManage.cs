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

namespace DBSolution
{
    public partial class AllotTranferInSearchManage : Form
    {
        public AllotTranferInSearchManage()
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
            if (sys != null)
            {
                condition += " where werks = '" + sys.WERKS + "'";
            }
            SearchDataBind(1, condition);
            pager.BindData();
        }

        private string GetWhereStr()
        {
            string condition = " where 1=1 ";
            Sdl_SysSetting sys = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            if (sys != null)
            {
                condition += " and Werks = '" + cbWerks.Text + "'";
            }
            if (textTruckNum.Text != string.Empty)
            {
                condition += " and trucknum like '%" + textTruckNum.Text + "%'";
            }
            if (textEbeln.Text != string.Empty)
            {
                condition += " and ebeln = '" + textEbeln.Text + "'";
            }
            if (textWeighMan.Text != string.Empty)
            {
                condition += " and (ENTERWeighMan like '%" + textWeighMan.Text + "%' or EXITWEIGHMAN like '%" + textWeighMan.Text + "%' ) ";
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
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            pager.PageIndex = 1;
            SearchDataBind(1, GetWhereStr());
            pager.BindData();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = Common.GetPageSize();
            DataSet ds = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewRawReturn.AutoGenerateColumns = false;
            dataGridViewRawReturn.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }

        private void SearchDataBind(string condition)
        {
            DataTable dt = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitleSet(condition).Tables[0];
            dataGridViewRawReturn.AutoGenerateColumns = false;
            dataGridViewRawReturn.DataSource = dt;
        }

        private void dataGridViewRawReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string truckNum = dataGridViewRawReturn.Rows[e.RowIndex].Cells["TRUCKNUM"].Value as string;
            string timeFlag = dataGridViewRawReturn.Rows[e.RowIndex].Cells["TIMEFLAG"].Value as string;
            if (e.ColumnIndex == 0 && e.RowIndex != -1 && !dataGridViewRawReturn.Rows[e.RowIndex].IsNewRow)
            {
                if (MessageBox.Show("确认要删除该行数据吗？", "删除确认",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Sdl_AllotInTitle modelO = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(dataGridViewRawReturn.Rows[e.RowIndex].Cells["TRUCKNUM"].Value.ToString(), dataGridViewRawReturn.Rows[e.RowIndex].Cells["EBELN"].Value.ToString(), dataGridViewRawReturn.Rows[e.RowIndex].Cells["TIMEFLAG"].Value.ToString());
                    CompareModelHelper.SdlDB_Modules modulet = CompareModelHelper.SdlDB_Modules.AllotInTitle;
                    CompareModelHelper.SdlDB_Modules module = CompareModelHelper.SdlDB_Modules.AllotInDetail;
                    string where = " where B.timeflag='" + timeFlag + "' and B.WERKS ='" + cbWerks.Text + "'";
                    DataTable dt = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetailSearchSet(where).Tables[0];
                    Sdl_AllotInTitleAdapter.DeleteSdl_AllotInTitle(dataGridViewRawReturn.Rows[e.RowIndex].Cells["TIMEFLAG"].Value.ToString(), dataGridViewRawReturn.Rows[e.RowIndex].Cells["EBELN"].Value.ToString(), dataGridViewRawReturn.Rows[e.RowIndex].Cells["TRUCKNUM"].Value.ToString());
                    CompareModelHelper.CompareModel(modelO, new Sdl_AllotInTitle(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(modulet));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Sdl_AllotInDetail fps = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetail(dt.Rows[i]["timeflag"].ToString(), dt.Rows[i]["ebeln"].ToString(), dt.Rows[i]["ebelp"].ToString(), dt.Rows[i]["lgort"].ToString());
                        module = CompareModelHelper.SdlDB_Modules.AllotDetail;
                        CompareModelHelper.CompareModel(fps, new Sdl_AllotInDetail(), CompareModelHelper.EditType.Delete, Common.GetEnumDescription(module));
                    }
                    Sdl_AllotInDetailAdapter.DeleteSdl_AllotInDetail(dataGridViewRawReturn.Rows[e.RowIndex].Cells["TIMEFLAG"].Value.ToString(), dataGridViewRawReturn.Rows[e.RowIndex].Cells["EBELN"].Value.ToString());
                    this.dataGridViewRawReturn.Rows.RemoveAt(e.RowIndex);
                }
            }
            if (e.ColumnIndex == 1 && e.RowIndex != -1 && !dataGridViewRawReturn.Rows[e.RowIndex].IsNewRow)
            {
                truckNum = dataGridViewRawReturn.Rows[e.RowIndex].Cells["TRUCKNUM"].Value as string;
               timeFlag = dataGridViewRawReturn.Rows[e.RowIndex].Cells["TIMEFLAG"].Value as string;
                if (truckNum != null)
                {
                    this.ViewDetail(truckNum, timeFlag);
                }
            }
        }

        private void ViewDetail(string truckNum, string timeFlag)
        {
            this.Cursor = Cursors.WaitCursor;
            AllotTranferInEdit proDetail = new AllotTranferInEdit();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(truckNum, this, timeFlag);
            SearchDataBind(GetWhereStr());
            this.Cursor = Cursors.Default;
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

        private void pager_PageChanged(object sender, EventArgs e)
        {
            SearchDataBind(pager.PageIndex, GetWhereStr());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.ViewDetail("", "");

        }
    }
}
