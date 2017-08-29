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
    public partial class FinishedProductsPresentationSearch : Form
    {
        public FinishedProductsPresentationSearch()
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
            string condition = " where 1=1 ";
            Sdl_SysSetting sys = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            Common.BindCBox(cbWerks);
            if (sys != null)
            {
                condition += " and werks = '" + sys.WERKS + "'";
            }
            SearchDataBind(1, condition);
            pager.BindData();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (textEBELN.Text != string.Empty)
            {
                condition += " and rsnum = '" + textEBELN.Text + "'";
            }
            if (textWeighMan.Text != string.Empty)
            {
                condition += " and ENTERWEIGHMAN like '%" + textWeighMan.Text + "%'";
            }
            if (TimePickerBegin.Text.Trim() != string.Empty)
            {
                condition += " and entertime >= '" + TimePickerBegin.Text + "'";
            }
            if (TimePickerEnd.Text.Trim() != string.Empty)
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

        private void SearchDataBind(string condition)
        {
            DataTable dt = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitleDataSet(condition).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
        }

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = Common.GetPageSize();
            DataSet ds = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0 && !dataGridViewDetail.Rows[e.RowIndex].IsNewRow)
            {
                ShowDetails(e);
            }
        }

        private void dataGridViewDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && !dataGridViewDetail.Rows[e.RowIndex].IsNewRow)
            {
                ShowDetails(e);
            }
        }

        private void ShowDetails(DataGridViewCellEventArgs e)
        {
            string truckNum = dataGridViewDetail.Rows[e.RowIndex].Cells["TRUCKNUM"].Value as string;
            string timeFlag = dataGridViewDetail.Rows[e.RowIndex].Cells["TIMEFLAG"].Value as string;
            string ebeln = dataGridViewDetail.Rows[e.RowIndex].Cells["RSNUM"].Value as string;
            if (truckNum != null)
            {
                FinishedProductsPresentationDetails rmpd = new FinishedProductsPresentationDetails();
                rmpd.StartPosition = FormStartPosition.CenterParent;
                rmpd.ShowDialog(truckNum, ebeln, timeFlag, this);
            }
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            SearchDataBind(pager.PageIndex, GetWhereStr());
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

        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            string Title = labelTitle.Text;
            DataSet ds = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitleDataSet(GetWhereStr());
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("工厂");
            dt.Columns.Add("预留单号");
            dt.Columns.Add("车牌号");
            dt.Columns.Add("皮重");
            dt.Columns.Add("毛重");
            dt.Columns.Add("净重");
            dt.Columns.Add("进厂标识");
            dt.Columns.Add("入场时间");
            dt.Columns.Add("出场时间");
            dt.Columns.Add("入厂司磅员");
            dt.Columns.Add("出厂司磅员");
            dt.Columns.Add("时间戳");
            dt.Columns.Add("空车出厂");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["工厂"] = ds.Tables[0].Rows[i]["WERKS"].ToString();
                dr["预留单号"] = ds.Tables[0].Rows[i]["RSNUM"].ToString();
                dr["车牌号"] = ds.Tables[0].Rows[i]["TRUCKNUM"].ToString();
                dr["皮重"] = ds.Tables[0].Rows[i]["TARE"].ToString();
                dr["毛重"] = ds.Tables[0].Rows[i]["GROSS"].ToString();
                dr["净重"] = ds.Tables[0].Rows[i]["NET"].ToString();
                dr["进厂标识"] = ds.Tables[0].Rows[i]["HS_FLAG"].ToString() == "H" ? "进厂" : (ds.Tables[0].Rows[i]["HS_FLAG"].ToString() == "S" ? "出厂" : "");
                dr["入场时间"] = ds.Tables[0].Rows[i]["ENTERTIME"].ToString();
                dr["出场时间"] = ds.Tables[0].Rows[i]["EXITTIME"].ToString();
                dr["入厂司磅员"] = ds.Tables[0].Rows[i]["ENTERWEIGHMAN"].ToString();
                dr["出厂司磅员"] = ds.Tables[0].Rows[i]["EXITWEIGHMAN"].ToString();
                dr["时间戳"] = ds.Tables[0].Rows[i]["TIMEFLAG"].ToString();
                dr["空车出厂"] = ds.Tables[0].Rows[i]["EXITFLAG"].ToString()=="1"?"是":"否";
                dt.Rows.Add(dr);
            }
            ExcelProgressBar ep = new ExcelProgressBar();
            ep.Show();
            ep.OutToExcel(dataGridViewDetail, dt, Title);
        }
    }
}
