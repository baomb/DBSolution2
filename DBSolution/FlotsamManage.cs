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
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DBSolution
{
    public partial class FlotsamManage : Form
    {
        public FlotsamManage()
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
            BindComboBoxData();
            if (sys != null)
            {
                condition += " where Werks = '" + sys.WERKS + "'";
            }
            SearchDataBind(1, condition);
            pager.BindData();
        }

        //绑定下拉框
        private void BindComboBoxData()
        {
            comboBoxFlotName.DataSource = Sdl_FloatsamNameItemAdapter.GetSdl_FloatsamNameItemDataSet("order by Name").Tables[0];
            comboBoxFlotName.ValueMember = "Code";
            comboBoxFlotName.DisplayMember = "Name";
            comboBoxFlotName.SelectedIndex = -1;
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
                if (cbWerks.Text.Trim() != string.Empty)
                {
                    condition += " and Werks = '" + cbWerks.Text.Trim() + "'";
                }
                else
                {
                    condition += " and Werks = '" + sys.WERKS + "'";
                }
            }
            if (textTruckNum.Text != string.Empty)
            {
                condition += " and TruckNum like '%" + textTruckNum.Text.Trim() + "%'";
            }
            if (comboBoxFlotName.SelectedIndex >= 0)
            {
                condition += " and FloatsamName like '%" + comboBoxFlotName.SelectedValue + "'";
            }
            if (textBuyer.Text != string.Empty)
            {
                condition += " and Buyer like '%" + textBuyer.Text.Trim() + "%'";
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
            DataSet ds = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterPageData(pageIndex.ToString(), pager.PageSize, whereCondition);
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
                string timeFlag = dataGridViewDetail.Rows[e.RowIndex].Cells["ENTERTIME"].Value.ToString();
                if (truckNum != null)
                {
                    this.ViewDetail(truckNum, timeFlag);
                }
            }
        }

        private void ViewDetail(string truckNum, string timeFlag)
        {
            this.Cursor = Cursors.WaitCursor;
            FlotsamManageDetail proDetail = new FlotsamManageDetail();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(truckNum, this, timeFlag);
            this.Cursor = Cursors.Default;
            pager.PageIndex = 1;
            SearchDataBind(1, GetWhereStr());
            pager.BindData();
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

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //导出excel，需要本机安装excel，否则无法导出
        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();//表示Excel应用程序
            if (xlApp == null)
            {
                MessageBox.Show("无法启动Excel，可能您的电脑未安装Excel！");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            DateTime now = DateTime.Now;
            saveFileDialog.FileName = "史丹利废旧物资查询导出" + now.Year.ToString().PadLeft(2)
            + now.Month.ToString().PadLeft(2, '0')
            + now.Day.ToString().PadLeft(2, '0') + "-"
            + now.Hour.ToString().PadLeft(2, '0')
            + now.Minute.ToString().PadLeft(2, '0')
            + now.Second.ToString().PadLeft(2, '0');
            saveFileDialog.ShowDialog();
            Workbooks workbooks = xlApp.Workbooks;  //workbook对象的集合
            Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet); //表示一个workbook
            Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1]; //返回workbook的第一个worksheet 
            DataSet ds = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterData(GetWhereStr());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Range range = null;
                //写标题     
                for (int i = 1; i < dataGridViewDetail.ColumnCount; i++)
                {
                    worksheet.Cells[1, i] = dataGridViewDetail.Columns[i].HeaderText;
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i];
                    range.Interior.ColorIndex = 15;//背景颜色
                    range.Font.Bold = true;//粗体
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
                    //加边框
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.EntireColumn.AutoFit();//自动调整列宽

                }
                //写内容
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {
                        //worksheet.Cells[j + 2, k + 1] = " "+ds.Tables[0].Rows[j][k].ToString();//日期具体到最后
                        worksheet.Cells[j + 2, k + 1] = ds.Tables[0].Rows[j][k].ToString();//日期具体到秒
                        range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[j + 2, k + 1];
                        range.EntireColumn.AutoFit();//自动调整列宽
                        if (k == 0)
                        {
                            range.NumberFormat = "00000000000000";
                        }
                        if (k == 7 || k == 8 || k == 9)
                        {
                            range.NumberFormat = "0.000";
                        }
                    }
                }
            }
            //保存及退出
            workbook.Saved = true;
            workbook.SaveCopyAs(saveFileDialog.FileName);
            xlApp.Quit();
            GC.Collect();//强行销毁 
        }

        #region 从数据流中导出excel，勿删
        ////速度较快，但长数字格式不好控制 
        //private void btnOutExcel_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
        //    saveFileDialog.FilterIndex = 0;
        //    saveFileDialog.RestoreDirectory = true;
        //    saveFileDialog.CreatePrompt = true;
        //    saveFileDialog.Title = "导出Excel文件到";
        //    DateTime now = DateTime.Now;
        //    saveFileDialog.FileName = "史丹利废旧物资查询导出" + now.Year.ToString().PadLeft(2)
        //    + now.Month.ToString().PadLeft(2, '0')
        //    + now.Day.ToString().PadLeft(2, '0') + "-"
        //    + now.Hour.ToString().PadLeft(2, '0')
        //    + now.Minute.ToString().PadLeft(2, '0')
        //    + now.Second.ToString().PadLeft(2, '0');
        //    saveFileDialog.ShowDialog();
        //    Stream myStream = saveFileDialog.OpenFile();
        //    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
        //    string str = "";
        //    try
        //    {
        //        DataSet ds = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterData(GetWhereStr());
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            //写标题     
        //            for (int i = 1; i < dataGridViewDetail.ColumnCount; i++)
        //            {
        //                if (i > 1)
        //                {
        //                    str += "\t";
        //                }
        //                str += dataGridViewDetail.Columns[i].HeaderText;
        //            }
        //            sw.WriteLine(str);
        //            //写内容   

        //            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        //            {
        //                string tempStr = "";
        //                for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
        //                {
        //                    if (k == 0)
        //                    {
        //                        tempStr += "'";
        //                    }
        //                    if (k > 0)
        //                    {
        //                        tempStr += "\t";
        //                    }
        //                    tempStr += " " + ds.Tables[0].Rows[j][k].ToString();
        //                }
        //                sw.WriteLine(tempStr);
        //            }
        //            sw.Close();
        //            myStream.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sw.Close();
        //        myStream.Close();
        //    }
        //}
        #endregion
    }
}