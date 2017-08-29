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
    public partial class DataHistorySearch : Form
    {
        public DataHistorySearch()
        {
            InitializeComponent();
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

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = Common.GetPageSize();
            DataSet ds = Sdl_DataHistoryAdapter.GetSdl_DataHistoryPageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("Type");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["InsertFlag"].ToString() == "True")
                {
                    dt.Rows[i]["Type"] = "添加";
                }
                else if (dt.Rows[i]["EditFlag"].ToString() == "True")
                {
                    dt.Rows[i]["Type"] = "修改";
                }
                else if (dt.Rows[i]["DeleteFlag"].ToString() == "True")
                {
                    dt.Rows[i]["Type"] = "删除";
                }
            }
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }

        private string GetWhereStr()
        {
            string condition = " where 1=1 ";
            if (radioButtonAdd.Checked)
            {
                condition += " and InsertFlag = 1";
            }
            if (radioButtonEdit.Checked)
            {
                condition += " and EditFlag = 1";
            }
            if (radioButtonDelete.Checked)
            {
                condition += " and DeleteFlag = 1";
            }
            if (TimePickerBegin.Value.ToString().Trim() != "")
            {
                condition += " and Time >= '" + TimePickerBegin.Value + "'";
            }
            if (TimePickerEnd.Value.ToString().Trim() != "")
            {
                condition += " and Time <= '" + Common.GetAddOneDayDate(TimePickerEnd.Value.ToString()) + "'";
            }
            return condition;
        }

        private void DataHistorySearch_Load(object sender, EventArgs e)
        {
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
            TimePickerBegin.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            TimePickerEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            string condition = " where Time >= '" + TimePickerBegin.Value + "' and Time <= '" + Common.GetAddOneDayDate(TimePickerEnd.Value.ToString()) + "'";
            SearchDataBind(1, condition);
            pager.BindData();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            pager.PageIndex = 1;
            SearchDataBind(1, GetWhereStr());
            pager.BindData();
        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0 && !dataGridViewDetail.Rows[e.RowIndex].IsNewRow)
            {
                string editTime = dataGridViewDetail.Rows[e.RowIndex].Cells["EDITTIME"].Value.ToString();
                string tableName = dataGridViewDetail.Rows[e.RowIndex].Cells["TABLENAME"].Value.ToString();
                DataHistoryDetail dhd = new DataHistoryDetail();
                dhd.ShowDialog(this, editTime, tableName);
            }
        }
    }
}
