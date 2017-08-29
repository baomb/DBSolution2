using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using SdlDB.Utility;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;

    

namespace DBSolution
{
    public partial class ExcelProgressBar : Form
    {
        public ExcelProgressBar()
        {
            InitializeComponent();
        }

        //public void OutToExcel2(DataGridView m_DataView, System.Data.DataTable ds, string Title)
        //{
        //    this.ToExcelProgress.Value = 0;
        //    this.ToExcelProgress.Maximum = ds.Rows.Count;
            
        //    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();//表示Excel应用程序
        //    if (xlApp == null)
        //    {
        //        MessageBox.Show("无法启动Excel，可能您的电脑未安装Excel！");
        //        return;
        //    }
        //    else
        //    {
        //        SaveFileDialog saveFileDialog = new SaveFileDialog();
        //        saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
        //        saveFileDialog.FilterIndex = 0;
        //        saveFileDialog.RestoreDirectory = true;
        //        saveFileDialog.CreatePrompt = true;
        //        saveFileDialog.Title = "导出Excel文件到";
                
        //        DateTime now = DateTime.Now;
        //        saveFileDialog.FileName = Title + now.Year.ToString().PadLeft(2)
        //        + now.Month.ToString().PadLeft(2, '0')
        //        + now.Day.ToString().PadLeft(2, '0') + "-"
        //        + now.Hour.ToString().PadLeft(2, '0')
        //        + now.Minute.ToString().PadLeft(2, '0')
        //        + now.Second.ToString().PadLeft(2, '0');
        //        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
        //        {
        //            this.Close();
        //            return;
        //        }
        //        Workbooks workbooks = xlApp.Workbooks;  //workbook对象的集合
        //        Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet); //表示一个workbook
        //        Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1]; //返回workbook的第一个worksheet 
        //        if (m_DataView != null && m_DataView.Rows.Count > 0)
        //        {
        //            Microsoft.Office.Interop.Excel.Range range = null;
        //            //写标题     
        //            for (int i = 1; i < m_DataView.ColumnCount; i++)
        //            {
        //                worksheet.Cells[1, i] = m_DataView.Columns[i].HeaderText;
        //                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i];
        //                range.Interior.ColorIndex = 15;//背景颜色
        //                range.Font.Bold = true;//粗体
        //                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
        //                //加边框
        //                range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
        //                range.EntireColumn.AutoFit();//自动调整列宽
        //            }
        //            //写内容
        //            for (int j = 0; j < ds.Rows.Count; j++)
        //            {
        //                this.ToExcelProgress.Value = j + 1;
        //                this.Progresslabel.Text = "正在导出第" + (j + 1) + "条，共" + ToExcelProgress.Maximum + "条";
        //                for (int k = 0; k < ds.Columns.Count; k++)
        //                {
        //                    //worksheet.Cells[j + 2, k + 1] = " "+ds.Tables[0].Rows[j][k].ToString();//日期具体到最后
        //                    worksheet.Cells[j + 2, k + 1] = ds.Rows[j][k].ToString();//日期具体到秒
        //                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[j + 2, k + 1];
        //                    range.EntireColumn.AutoFit();//自动调整列宽
        //                }
        //            }
        //        }
        //        //保存及退出
        //        workbook.Saved = true;
        //        workbook.SaveCopyAs(saveFileDialog.FileName);
        //        xlApp.Quit();
        //        GC.Collect();//强行销毁 
        //        MessageBox.Show("保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.Close();
        //    }
        //}

        public void OutToExcel(DataGridView m_DataView, System.Data.DataTable ds, string Title)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";

            DateTime now = DateTime.Now;
            saveFileDialog.FileName = Title + now.Year.ToString().PadLeft(2)
            + now.Month.ToString().PadLeft(2, '0')
            + now.Day.ToString().PadLeft(2, '0') + "-"
            + now.Hour.ToString().PadLeft(2, '0')
            + now.Minute.ToString().PadLeft(2, '0')
            + now.Second.ToString().PadLeft(2, '0');
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
                return;
            }

            //NPOIExcelHelper.DataGridViewToExcel(dataGridViewCount, "配方速算",saveFileDialog.FileName);
            //buttonOK.Enabled = false;
            System.Diagnostics.Stopwatch timeWatch = System.Diagnostics.Stopwatch.StartNew();
            DataTableToExcel(ds, Title, saveFileDialog.FileName);
            timeWatch.Stop();
            labelSuccess.Text = "导出完成，共计" + ds.Rows.Count + "条。";
            labelSuccess.Visible = true;
            buttonOK.Visible = true;
            buttonOK.Enabled = true;
        }

        public static void DataTableToExcel(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = DataTableToExcel(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream DataTableToExcel(DataTable dtSource, string strHeaderText)
        {
           
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "史丹利电子衡"; //填加xls文件作者信息
                si.ApplicationName = "DBSolution"; //填加xls文件创建程序信息
                si.LastAuthor = "史丹利电子衡"; //填加xls文件最后保存者信息
                si.Comments = "史丹利电子衡"; //填加xls文件作者信息
                si.Title = strHeaderText; //填加xls文件标题信息
                si.CreateDateTime = System.DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        //  headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 15;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        // sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();
                    }
                    #endregion


                    #region 列头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(1);
                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        // headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();
                    newCell.SetCellValue(drValue);
                    //switch (column.DataType.ToString())
                    //{
                    //    case "System.String"://字符串类型
                    //        newCell.SetCellValue(drValue);
                    //        break;
                    //    case "System.DateTime"://日期类型
                    //        System.DateTime dateV;
                    //        System.DateTime.TryParse(drValue, out dateV);
                    //        newCell.SetCellValue(dateV);

                    //        newCell.CellStyle = dateStyle;//格式化显示
                    //        break;
                    //    case "System.Boolean"://布尔型
                    //        bool boolV = false;
                    //        bool.TryParse(drValue, out boolV);
                    //        newCell.SetCellValue(boolV);
                    //        break;
                    //    case "System.Int16"://整型
                    //    case "System.Int32":
                    //    case "System.Int64":
                    //    case "System.Byte":
                    //        int intV = 0;
                    //        int.TryParse(drValue, out intV);
                    //        newCell.SetCellValue(intV);
                    //        break;
                    //    case "System.Decimal"://浮点型
                    //    case "System.Double":
                    //        double doubV = 0;
                    //        double.TryParse(drValue, out doubV);
                    //        newCell.SetCellValue(doubV);
                    //        break;
                    //    case "System.DBNull"://空值处理
                    //        newCell.SetCellValue("");
                    //        break;
                    //    default:
                    //        newCell.SetCellValue("");
                    //        break;
                    //}

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
