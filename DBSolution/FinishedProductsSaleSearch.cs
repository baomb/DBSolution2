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
using Microsoft.Office.Interop.Excel;

namespace DBSolution
{
    public partial class FinishedProductsSaleSearch : Form
    {
        public FinishedProductsSaleSearch()
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
                condition += " and ( CONTRACT = '' or CONTRACT is NULL ) ";
            }
            SearchDataBind(1,condition);
            pager.BindData();
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
            if (textVbeln.Text != string.Empty)
            {
                condition += " and Vbeln = '" + textVbeln.Text + "'";
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
            condition += " and ( CONTRACT = '' or CONTRACT is NULL ) ";

            return condition;

        }
        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = Common.GetPageSize();
            DataSet ds = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1 && !dataGridViewDetail.Rows[e.RowIndex].IsNewRow)
            {
                string truckNum = dataGridViewDetail.Rows[e.RowIndex].Cells["TRUCKNUM"].Value as string;
                string timeFlag = dataGridViewDetail.Rows[e.RowIndex].Cells["TIMEFLAG"].Value as string;
                if (truckNum != null)
                {
                    this.ViewDetail(truckNum, timeFlag);
                }
            }
        }


        private void ViewDetail(string truckNum, string timeFlag)
        {
            this.Cursor = Cursors.WaitCursor;
            FinishedProSaleSearchDetail proDetail = new FinishedProSaleSearchDetail();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(truckNum,this, timeFlag);

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

        private void textTruckNum_TextChanged(object sender, EventArgs e)
        {
            textTruckNum.Text = textTruckNum.Text.ToUpper();
            textTruckNum.SelectionStart = textTruckNum.Text.Length;
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            SearchDataBind(pager.PageIndex, GetWhereStr());
        }

        //导出excel

        private void buttnOutExcel_Click(object sender, EventArgs e)
        {
            string Title = "史丹利产成品查询";
            DataSet ds = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitleExcelData(GetWhereStr());
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("工厂");
            dt.Columns.Add("车牌号");
            dt.Columns.Add("交货单");
            dt.Columns.Add("入厂司磅员");
            dt.Columns.Add("出厂司磅员");
            dt.Columns.Add("经销商编码");
            dt.Columns.Add("经销商名称");
            dt.Columns.Add("皮重");
            dt.Columns.Add("毛重");
            dt.Columns.Add("净重");
            dt.Columns.Add("托盘标重");
            dt.Columns.Add("托盘数量");
            dt.Columns.Add("入场时间");
            dt.Columns.Add("出场时间");
            dt.Columns.Add("时间标识");
            dt.Columns.Add("空车出厂");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                DataRow dr = dt.NewRow();
                dr["工厂"] = ds.Tables[0].Rows[i]["WERKS"].ToString();
                dr["车牌号"] = ds.Tables[0].Rows[i]["TRUCKNUM"].ToString();
                dr["交货单"] = ds.Tables[0].Rows[i]["VBELN"].ToString();
                dr["入厂司磅员"] = ds.Tables[0].Rows[i]["WEIGHMAN"].ToString();
                dr["出厂司磅员"] = ds.Tables[0].Rows[i]["EXITWEIGHMAN"].ToString();
                dr["经销商编码"] = ds.Tables[0].Rows[i]["KUNNR"].ToString();
                dr["经销商名称"] = ds.Tables[0].Rows[i]["NAME1"].ToString();
                dr["皮重"] = ds.Tables[0].Rows[i]["TARE"].ToString();
                dr["毛重"] = ds.Tables[0].Rows[i]["GROSS"].ToString();
                dr["净重"] = ds.Tables[0].Rows[i]["NETVALUE"].ToString();
                dr["托盘标重"] = ds.Tables[0].Rows[i]["TRAYWEIGHT"].ToString();
                dr["托盘数量"] = ds.Tables[0].Rows[i]["TRAYQUANTITY"].ToString();
                dr["入场时间"] = ds.Tables[0].Rows[i]["ENTERTIME"].ToString();
                dr["出场时间"] = ds.Tables[0].Rows[i]["EXITTIME"].ToString();
                dr["时间标识"] = ds.Tables[0].Rows[i]["TIMEFLAG"].ToString();
                dr["空车出厂"] = ds.Tables[0].Rows[i]["EXITFLAG"].ToString() == "1" ? "是" : "否";
                dt.Rows.Add(dr);
            }
            ExcelProgressBar ep = new ExcelProgressBar();
            ep.Show();
            ep.OutToExcel(dataGridViewDetail, dt, Title);
        }
    }
}
