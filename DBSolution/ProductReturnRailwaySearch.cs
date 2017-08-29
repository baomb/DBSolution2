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
    public partial class ProductReturnRailwaySearch : Form
    {
        public ProductReturnRailwaySearch()
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

        private void SearchDataBind(string condition)
        {
            DataTable dt = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySet(condition).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
        }

        private void ViewDetail(string truckNum, string timeFlag)
        {
            this.Cursor = Cursors.WaitCursor;

            ProductReturnRailwayDetail proDetail = new ProductReturnRailwayDetail();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(truckNum, this, timeFlag);

            this.Cursor = Cursors.Default;
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                condition += " and EnterWeighMan like '%" + textWeighMan.Text + "%'";
            }
            if (textBoxExitWeignMan.Text != string.Empty)
            {
                condition += " and ExitWeighMan like '%" + textBoxExitWeignMan.Text + "%'";
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
            DataSet ds = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwayPageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
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

        private void pager_PageChanged(object sender, EventArgs e)
        {
            SearchDataBind(pager.PageIndex, GetWhereStr());
        }

        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            string Title = labelTitle.Text;
            DataSet ds = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySet(GetWhereStr());
            DataTable dt = new DataTable();
            dt.Columns.Add("工厂");
            dt.Columns.Add("车牌号");
            dt.Columns.Add("退货单");
            dt.Columns.Add("入厂司磅员");
            dt.Columns.Add("出厂司磅员");
            dt.Columns.Add("经销商编码");
            dt.Columns.Add("经销商名称");
            dt.Columns.Add("皮重");
            dt.Columns.Add("毛重");
            dt.Columns.Add("入厂时间");
            dt.Columns.Add("出厂时间");
            dt.Columns.Add("时间标识");
            dt.Columns.Add("重车出厂");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["工厂"] = ds.Tables[0].Rows[i]["WERKS"].ToString();
                dr["车牌号"] = ds.Tables[0].Rows[i]["TRUCKNUM"].ToString();
                dr["退货单"] = ds.Tables[0].Rows[i]["VBELN"].ToString();
                dr["入厂司磅员"] = ds.Tables[0].Rows[i]["ENTERWEIGHMAN"].ToString();
                dr["出厂司磅员"] = ds.Tables[0].Rows[i]["EXITWEIGHMAN"].ToString();
                dr["经销商编码"] = ds.Tables[0].Rows[i]["KUNNR"].ToString();
                dr["经销商名称"] = ds.Tables[0].Rows[i]["NAME1"].ToString();
                dr["皮重"] = ds.Tables[0].Rows[i]["TARE"].ToString();
                dr["毛重"] = ds.Tables[0].Rows[i]["GROSS"].ToString();
                dr["入厂时间"] = ds.Tables[0].Rows[i]["ENTERTIME"].ToString();
                dr["出厂时间"] = ds.Tables[0].Rows[i]["EXITTIME"].ToString();
                dr["时间标识"] = ds.Tables[0].Rows[i]["TIMEFLAG"].ToString();
                dr["重车出厂"] = ds.Tables[0].Rows[i]["TYPEID"].ToString() == "1" ? "是" : "否";
                dt.Rows.Add(dr);
            }
            ExcelProgressBar ep = new ExcelProgressBar();
            ep.Show();
            ep.OutToExcel(dataGridViewDetail, dt, Title);
        }
    }
}
