using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class RawMaterialsSaleSearch : Form
    {
        public RawMaterialsSaleSearch()
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
            if (textVBELN.Text != string.Empty)
            {
                condition += " and vbeln = '" + textVBELN.Text + "'";
            }
            if (textWeighMan.Text != string.Empty)
            {
                condition += " and weighman like '%" + textWeighMan.Text + "%'";
            }
            if (TimePickerBegin.Text != string.Empty)
            {
                condition += " and entertime >= '" + TimePickerBegin.Text + "'";
            }
            if (TimePickerEnd.Text != string.Empty)
            {
                condition += " and entertime < '" + Common.AddOneDay(TimePickerEnd.Text) + "'";
            }
            return condition;
        }

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = 20;
            DataSet ds = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = ds.Tables[0];
            pager.DataSourceCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }

        private void ShowDetails(DataGridViewCellEventArgs e)
        {
            string truckNum = dataGridViewDetail.Rows[e.RowIndex].Cells["TRUCKNUM"].Value.ToString();
            string timeFlag = dataGridViewDetail.Rows[e.RowIndex].Cells["TIMEFLAG"].Value.ToString();
            string vbeln = dataGridViewDetail.Rows[e.RowIndex].Cells["VBELN"].Value.ToString();
            if (truckNum != null)
            {
                RawMaterialsSaleDetails rmpd = new RawMaterialsSaleDetails();
                rmpd.ShowDialog(truckNum, vbeln, timeFlag, this);
            }
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

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            SearchDataBind(pager.PageIndex, GetWhereStr());
        }

        private void dataGridViewDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridViewDetail.Rows.Count; i++)
            {
                if (dataGridViewDetail.Rows[i].Cells["EXF"].Value != null)
                {
                    if (dataGridViewDetail.Rows[i].Cells["EXF"].Value.ToString() == "True")
                    {
                        dataGridViewDetail.Rows[i].Cells["EXITFLAG"].Value = "是";
                    }
                    else if (dataGridViewDetail.Rows[i].Cells["EXF"].Value.ToString() == "False")
                    {
                        dataGridViewDetail.Rows[i].Cells["EXITFLAG"].Value = "否";
                    }
                }
                if (dataGridViewDetail.Rows[i].Cells["HSF"].Value != null)
                {
                    if (dataGridViewDetail.Rows[i].Cells["HSF"].Value.ToString() == "H")
                    {
                        dataGridViewDetail.Rows[i].Cells["HS_FLAG"].Value = "进厂";
                    }
                    else if (dataGridViewDetail.Rows[i].Cells["HSF"].Value.ToString() == "S")
                    {
                        dataGridViewDetail.Rows[i].Cells["HS_FLAG"].Value = "出厂";
                    }
                }
            }
        }

        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            string Title = labelTitle.Text;
            DataSet ds = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitleDataSet(GetWhereStr());
            DataTable dt = new DataTable();
            dt.Columns.Add("工厂");
            dt.Columns.Add("销售订单");
            dt.Columns.Add("车牌号");
            dt.Columns.Add("皮重");
            dt.Columns.Add("毛重");
            dt.Columns.Add("净重");
            dt.Columns.Add("差异");
            dt.Columns.Add("进出厂标识");
            dt.Columns.Add("空车出厂标识");
            dt.Columns.Add("进厂时间");
            dt.Columns.Add("出厂时间");
            dt.Columns.Add("进厂司磅员");
            dt.Columns.Add("出厂司磅员");
            dt.Columns.Add("时间戳");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["工厂"] = ds.Tables[0].Rows[i]["WERKS"].ToString();
                dr["销售订单"] = ds.Tables[0].Rows[i]["VBELN"].ToString();
                dr["车牌号"] = ds.Tables[0].Rows[i]["TRUCKNUM"].ToString();
                dr["皮重"] = ds.Tables[0].Rows[i]["TARE"].ToString();
                dr["毛重"] = ds.Tables[0].Rows[i]["GROSS"].ToString();
                dr["净重"] = ds.Tables[0].Rows[i]["NET"].ToString();
                dr["差异"] = ds.Tables[0].Rows[i]["BALANCE"].ToString();
                dr["进出厂标识"] = ds.Tables[0].Rows[i]["HS_FLAG"].ToString() == "H" ? "进厂" : (ds.Tables[0].Rows[i]["HS_FLAG"].ToString() == "S" ? "出厂" : "");
                dr["空车出厂标识"] = ds.Tables[0].Rows[i]["EXITFLAG"].ToString() == "True" ? "是" : "否";
                dr["进厂时间"] = ds.Tables[0].Rows[i]["ENTERTIME"].ToString();
                dr["出厂时间"] = ds.Tables[0].Rows[i]["EXITTIME"].ToString();
                dr["进厂司磅员"] = ds.Tables[0].Rows[i]["WEIGHMAN"].ToString();
                dr["出厂司磅员"] = ds.Tables[0].Rows[i]["EXITWEIGHMAN"].ToString();
                dr["时间戳"] = ds.Tables[0].Rows[i]["TIMEFLAG"].ToString();
                dt.Rows.Add(dr);
            }
            ExcelProgressBar ep = new ExcelProgressBar();
            ep.Show();
            ep.OutToExcel(dataGridViewDetail, dt, Title);
        }
    }
}
