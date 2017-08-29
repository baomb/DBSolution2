using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;


namespace SdlDB.Utility
{
    public class DataToExcel
    {
        public static void OutToExcel(DataGridView m_DataView, System.Data.DataTable ds, string Title){

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();//表示Excel应用程序
            if (xlApp == null)
            {
                MessageBox.Show("无法启动Excel，可能您的电脑未安装Excel！");
                return;
            }
            else
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
                saveFileDialog.ShowDialog();
                Workbooks workbooks = xlApp.Workbooks;  //workbook对象的集合
                Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet); //表示一个workbook
                Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1]; //返回workbook的第一个worksheet 
                MessageBox.Show("数据进行导出过程可能较慢，提示成功前请不要进行操作。", "警告");
                if (m_DataView != null && m_DataView.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Range range = null;
                    //写标题     
                    for (int i = 1; i < m_DataView.ColumnCount; i++)
                    {
                        worksheet.Cells[1, i] = m_DataView.Columns[i].HeaderText;
                        range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i];
                        range.Interior.ColorIndex = 15;//背景颜色
                        range.Font.Bold = true;//粗体
                        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
                        //加边框
                        range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.EntireColumn.AutoFit();//自动调整列宽
                    }
                    //写内容
                    for (int j = 0; j < ds.Rows.Count; j++)
                    {
                        for (int k = 0; k < ds.Columns.Count; k++)
                        {
                            //worksheet.Cells[j + 2, k + 1] = " "+ds.Tables[0].Rows[j][k].ToString();//日期具体到最后
                            worksheet.Cells[j + 2, k + 1] = ds.Rows[j][k].ToString();//日期具体到秒
                            range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[j + 2, k + 1];
                            range.EntireColumn.AutoFit();//自动调整列宽
                        }
                    }
                }
                //保存及退出
                workbook.Saved = true;
                workbook.SaveCopyAs(saveFileDialog.FileName);
                xlApp.Quit();
                GC.Collect();//强行销毁 
                MessageBox.Show("保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //public static void OutToExcel1(DataGridView m_DataView, string Title)
        //{
        //    SaveFileDialog kk = new SaveFileDialog();
        //    kk.Title = "保存EXECL文件";
        //    kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
        //    kk.FilterIndex = 1;
        //    DateTime now = DateTime.Now;
        //    kk.FileName = Title + now.Year.ToString().PadLeft(2)
        //    + now.Month.ToString().PadLeft(2, '0')
        //    + now.Day.ToString().PadLeft(2, '0') + "-"
        //    + now.Hour.ToString().PadLeft(2, '0')
        //    + now.Minute.ToString().PadLeft(2, '0')
        //    + now.Second.ToString().PadLeft(2, '0');
        //    if (kk.ShowDialog() == DialogResult.OK)
        //    {
        //        string FileName = kk.FileName;
        //        if (File.Exists(FileName))
        //            File.Delete(FileName);
        //        FileStream objFileStream;
        //        StreamWriter objStreamWriter;
        //        string strLine = "";
        //        objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
        //        objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
        //        for (int i = 1; i < m_DataView.Columns.Count; i++)
        //        {
        //            if (m_DataView.Columns[i].Visible == true)
        //            {
        //                strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);

        //            }
        //        }
        //        objStreamWriter.WriteLine(strLine);
        //        strLine = "";

        //        for (int i = 0; i < m_DataView.Rows.Count; i++)
        //        {
        //            if (m_DataView.Columns[0].Visible == true)
        //            {
        //                if (m_DataView.Rows[i].Cells[0].Value == null)
        //                    strLine = strLine + " " + Convert.ToChar(9);
        //                else
        //                    strLine = strLine + m_DataView.Rows[i].Cells[1].Value.ToString() + Convert.ToChar(9);
        //            }
        //            for (int j = 2; j < m_DataView.Columns.Count; j++)
        //            {
        //                if (m_DataView.Columns[j].Visible == true)
        //                {
        //                    if (m_DataView.Rows[i].Cells[j].Value == null)
        //                        strLine = strLine + " " + Convert.ToChar(9);
        //                    else
        //                    {
        //                        string rowstr = "";
        //                        rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
        //                        if (rowstr.IndexOf("\r\n") > 0)
        //                            rowstr = rowstr.Replace("\r\n", " ");
        //                        if (rowstr.IndexOf("\t") > 0)
        //                            rowstr = rowstr.Replace("\t", " ");
        //                        strLine = strLine + rowstr + Convert.ToChar(9);
        //                    }
        //                }
        //            }
        //            objStreamWriter.WriteLine(strLine);
        //            strLine = "";
        //        }
        //        objStreamWriter.Close();
        //        objFileStream.Close();
        //        MessageBox.Show( "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
