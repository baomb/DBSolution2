using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;

namespace DBSolution
{
    public partial class AccessoryProcurementSearch : Form
    {
        public AccessoryProcurementSearch()
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
            if (textEbeln.Text != string.Empty)
            {
                condition += " and ebeln = '" + textEbeln.Text + "'";
            }
            if (textWeighMan.Text != string.Empty)
            {
                condition += " and ENTERWeighMan like '%" + textWeighMan.Text + "%'";
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
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            pager.PageIndex = 1;
            SearchDataBind(1, GetWhereStr());
            pager.BindData();
        }

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = Common.GetPageSize();
            DataSet ds = Sdl_AccessoryProcurementTitleAdapter.GetSdl_AccessoryProcurementTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewRawReturn.AutoGenerateColumns = false;
            dataGridViewRawReturn.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }


        private void SearchDataBind(string condition)
        {
            DataTable dt = Sdl_AccessoryProcurementTitleAdapter.GetSdl_AccessoryProcurementTitleSet(condition).Tables[0];
            dataGridViewRawReturn.AutoGenerateColumns = false;
            dataGridViewRawReturn.DataSource = dt;
        }

        private void ViewDetail(string truckNum, string timeFlag)
        {
            this.Cursor = Cursors.WaitCursor;
            AccessoryProcurementDetail proDetail = new AccessoryProcurementDetail();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(truckNum, this, timeFlag);


            this.Cursor = Cursors.Default;
        }

        private void dataGridViewRawReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1 && !dataGridViewRawReturn.Rows[e.RowIndex].IsNewRow)
            {
                string truckNum = dataGridViewRawReturn.Rows[e.RowIndex].Cells["TRUCKNUM"].Value as string;
                string timeFlag = dataGridViewRawReturn.Rows[e.RowIndex].Cells["TIMEFLAG"].Value as string;
                if (truckNum != null)
                {
                    this.ViewDetail(truckNum, timeFlag);
                }
            }
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

        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            string Title = labelTitle.Text;
            DataSet ds = Sdl_AccessoryProcurementTitleAdapter.GetSdl_AccessoryProcurementTitleSet(GetWhereStr());
            DataTable dt = new DataTable();
            dt.Columns.Add("工厂");
            dt.Columns.Add("车牌号");
            dt.Columns.Add("采购订单");
            dt.Columns.Add("毛重");
            dt.Columns.Add("皮重");
            dt.Columns.Add("入厂时间");
            dt.Columns.Add("出厂时间");
            dt.Columns.Add("时间标识");
            dt.Columns.Add("入厂司磅员");
            dt.Columns.Add("出厂司磅员");
            dt.Columns.Add("进出厂标识");
            dt.Columns.Add("重车出厂");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["工厂"] = ds.Tables[0].Rows[i]["WERKS"].ToString();
                dr["车牌号"] = ds.Tables[0].Rows[i]["TRUCKNUM"].ToString();
                dr["采购订单"] = ds.Tables[0].Rows[i]["EBELN"].ToString();
                dr["毛重"] = ds.Tables[0].Rows[i]["GROSS"].ToString();
                dr["皮重"] = ds.Tables[0].Rows[i]["TARE"].ToString();
                dr["入厂时间"] = ds.Tables[0].Rows[i]["ENTERTIME"].ToString();
                dr["出厂时间"] = ds.Tables[0].Rows[i]["EXITTIME"].ToString();
                dr["时间标识"] = ds.Tables[0].Rows[i]["TIMEFLAG"].ToString();
                dr["入厂司磅员"] = ds.Tables[0].Rows[i]["ENTERWEIGHMAN"].ToString();
                dr["出厂司磅员"] = ds.Tables[0].Rows[i]["EXITWEIGHMAN"].ToString();
                dr["进出厂标识"] = ds.Tables[0].Rows[i]["HSFLAG"].ToString() == "H" ? "进厂" : (ds.Tables[0].Rows[i]["HSFLAG"].ToString() == "S" ? "出厂" : "");
                dr["重车出厂"] = ds.Tables[0].Rows[i]["EXITFLAG"].ToString() == "1" ? "是" : "否";
                dt.Rows.Add(dr);
            }
            ExcelProgressBar ep = new ExcelProgressBar();
            ep.Show();
            ep.OutToExcel(dataGridViewRawReturn, dt, Title);
        }
    }
}
