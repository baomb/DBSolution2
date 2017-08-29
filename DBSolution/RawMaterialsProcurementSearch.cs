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
    public partial class RawMaterialsProcurementSearch : Form
    {
        public RawMaterialsProcurementSearch()
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
            this.TimePickerBegin.CustomFormat = "yyyy-MM-dd";

            this.TimePickerEnd.Format = DateTimePickerFormat.Custom;
            this.TimePickerEnd.CustomFormat = "yyyy-MM-dd";

            Common.BindCBox(cbWerks);
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
                condition += " and rmpt.werks = '" + cbWerks.Text + "'";
            }
            if (textTruckNum.Text != string.Empty)
            {
                condition += " and rmpt.trucknum like '%" + textTruckNum.Text + "%'";
            }
            if (textEBELN.Text != string.Empty)
            {
                condition += " and rmpt.vbeln = '" + textEBELN.Text + "'";
            }
            if (textWeighMan.Text != string.Empty)
            {
                condition += " and rmpt.weighman like '%" + textWeighMan.Text + "%'";
            }
            if (TimePickerBegin.Text != string.Empty)
            {
                condition += " and rmpt.entertime >= '" + TimePickerBegin.Text + "'";
            }
            if (chkContract.Checked)
            {
                condition += " and rmpt.contract = '2'";
            }
            if (TimePickerEnd.Text != string.Empty)
            {
                condition += " and rmpt.entertime < '" + Common.AddOneDay(TimePickerEnd.Text) + "'";
            }

            condition += " and ( rmpt.CONTRACT = '' or rmpt.CONTRACT is NULL or rmpt.CONTRACT = '2' ) ";
            return condition;
        }

        private void SearchDataBind(int pageIndex, string whereCondition)
        {
            pager.PageSize = 20;
            DataSet ds = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementAndTitlePageData(pageIndex.ToString(), pager.PageSize, whereCondition);
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
            string ebeln = dataGridViewDetail.Rows[e.RowIndex].Cells["VBELN"].Value as string;
            if (truckNum != null)
            {
                RawMaterialsProcurementDetails rmpd = new RawMaterialsProcurementDetails();
                rmpd.ShowDialog(truckNum, ebeln, timeFlag, this);
            }
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
            DataSet ds = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementAndTitleDataSet(GetWhereStr());
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("工厂");
            dt.Columns.Add("采购订单");
            dt.Columns.Add("物料名称");
            dt.Columns.Add("供应商名称");
            dt.Columns.Add("车牌号");
            dt.Columns.Add("皮重");
            dt.Columns.Add("毛重");
            dt.Columns.Add("净重");
            dt.Columns.Add("差异");
            dt.Columns.Add("车皮号");
            dt.Columns.Add("承运人亏吨");
            dt.Columns.Add("进出厂标识");
            dt.Columns.Add("重车出厂标识");
            dt.Columns.Add("入场时间");
            dt.Columns.Add("出场时间");
            dt.Columns.Add("司磅员");
            dt.Columns.Add("时间戳");
            dt.Columns.Add("卸货点");
            dt.Columns.Add("托盘标重");
            dt.Columns.Add("托盘数量");
            dt.Columns.Add("虚拟标识");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["工厂"] = ds.Tables[0].Rows[i]["WERKS"].ToString();
                dr["采购订单"] = ds.Tables[0].Rows[i]["VBELN"].ToString();
                dr["物料名称"] = ds.Tables[0].Rows[i]["MAKTX"].ToString();
                dr["供应商名称"] = ds.Tables[0].Rows[i]["MCOD1"].ToString();
                dr["车牌号"] = ds.Tables[0].Rows[i]["TRUCKNUM"].ToString();
                dr["皮重"] = ds.Tables[0].Rows[i]["TARE"].ToString();
                dr["毛重"] = ds.Tables[0].Rows[i]["GROSS"].ToString();
                dr["净重"] = ds.Tables[0].Rows[i]["NET"].ToString();
                dr["差异"] = ds.Tables[0].Rows[i]["BALANCE"].ToString();
                dr["车皮号"] = ds.Tables[0].Rows[i]["WAGON"].ToString();
                dr["承运人亏吨"] = ds.Tables[0].Rows[i]["CYNUM"].ToString();
                dr["进出厂标识"] = ds.Tables[0].Rows[i]["HS_FLAG"].ToString() == "H" ? "进厂" : (ds.Tables[0].Rows[i]["HS_FLAG"].ToString() == "S" ? "出厂" : "");
                dr["重车出厂标识"] = ds.Tables[0].Rows[i]["EXITFLAG"].ToString() == "True" ? "是" : "否";
                dr["入场时间"] = ds.Tables[0].Rows[i]["ENTERTIME"].ToString();
                dr["出场时间"] = ds.Tables[0].Rows[i]["EXITTIME"].ToString();
                dr["司磅员"] = ds.Tables[0].Rows[i]["WEIGHMAN"].ToString();
                dr["时间戳"] = ds.Tables[0].Rows[i]["TIMEFLAG"].ToString();
                dr["卸货点"] = ds.Tables[0].Rows[i]["ABLAD"].ToString();
                dr["托盘标重"] = ds.Tables[0].Rows[i]["TRAYWEIGHT"].ToString();
                dr["托盘数量"] = ds.Tables[0].Rows[i]["TRAYQUANTITY"].ToString();
                dr["虚拟标识"] = ds.Tables[0].Rows[i]["CONTRACT"].ToString();
                dt.Rows.Add(dr);
            }
            ExcelProgressBar ep = new ExcelProgressBar();
            ep.Show();
            ep.OutToExcel(dataGridViewDetail, dt, Title);
        }
    }
}
