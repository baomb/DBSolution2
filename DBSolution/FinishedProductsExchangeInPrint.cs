using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;

namespace DBSolution
{
    public partial class FinishedProductsExchangeInPrint : Form
    {
        public FinishedProductsExchangeInPrint()
        {
            InitializeComponent();
            this.printDocument1.OriginAtMargins = true;//启用页边距
        }

        public void ShowDialog( IWin32Window parent, string truckNum, string oanum, string timeFlag, string flag)
        {
            Sdl_FinishedProductsExchangeTitle model = null;
            if (flag.Equals("in"))
            {
                //重车入厂
                labelTittle.Text = "换货通知单（入厂）";
                model = Sdl_FinishedProductsExchangeInTitleAdapter.GetSdl_FinishedProductsExchangeInTitle(truckNum, oanum, timeFlag);
            }
            else
            {
                //空车入厂
                labelTittle.Text = "换货通知单（出厂）";
                model = Sdl_FinishedProductsExchangeOutTitleAdapter.GetSdl_FinishedProductsExchangeOutTitle(truckNum, oanum, timeFlag);
            }
            
            labelDate.Text = model.ENTERTIME.ToString();
            labelWerks.Text = Sdl_FactoryAdapter.GetSdl_Factory(model.WERKS).NAME1;
            labelCNum.Text = model.CNUM;
            labelCName.Text = model.CNAME;
            labelTType.Text = model.TTYPE;
            labelYwy.Text = model.YWY;
            labelFxqd.Text = model.FXQD;
            labelXsqy.Text = model.XSQY;
            labelXsks.Text = model.XSKS;
            labelMan.Text = model.ENTERWEIGHT;
            string where = "where timeflag = '" + model.TIMEFLAG + "' and oanum = '" + model.OANUM + "' and trucknum = '" + model.TRUCKNUM + "' ";
            DataTable dt = null;
            if (flag.Equals("in"))
            {
                dt = Sdl_FinishedProductsExchangeInAdapter.GetSdl_FinishedProductsExchangeInDataSet(where).Tables[0];
            }
            else
            {
                labelJS.Text = "实发件数";
                labelDS.Text = "实发吨数";
                dt = Sdl_FinishedProductsExchangeOutAdapter.GetSdl_FinishedProductsExchangeOutDataSet(where).Tables[0];
            }
            
            // 行项目
            if (dt.Rows.Count > 0)
            {
                decimal sumWeight = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        labelMatnr1.Text = dt.Rows[i]["MATNR"].ToString();
                        labelMaktx1.Text = dt.Rows[i]["MAKTX"].ToString();
                        labelWeight1.Text = dt.Rows[i]["MENGE"].ToString();
                    }else if(i == 1)
                    {
                        labelMatnr2.Text = dt.Rows[i]["MATNR"].ToString();
                        labelMaktx2.Text = dt.Rows[i]["MAKTX"].ToString();
                        labelWeight2.Text = dt.Rows[i]["MENGE"].ToString();
                    }
                    else
                    {
                        break;
                    }
                    if (dt.Rows[i]["MENGE"].ToString() != "")
                    {
                        sumWeight = sumWeight + decimal.Parse(dt.Rows[i]["MENGE"].ToString());
                    }
                    labelSumWeight.Text = sumWeight.ToString();
                    
                    if (dt.Rows.Count == 1)
                    {
                        labelMatnr2.Text = "";
                        labelMaktx2.Text = "";
                        labelWeight2.Text = "";

                    }
                }
            }
            this.ShowDialog(parent);
        }
        //打印
        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            this.Close();
            //this.Parent.FindForm().Close();
        }

        //打印内容的设置
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //打印内容 为 局部的 this.panel1
            Bitmap _NewBitmap = new Bitmap(this.panel1.Width, panel1.Height);
            panel1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            e.Graphics.DrawImage(_NewBitmap, -80, -70, _NewBitmap.Width, _NewBitmap.Height);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs pE)
        {
            //// 单元格重绘
            //Pen pp = new Pen(Color.Black);
            //pE.Graphics.DrawRectangle(pp, pE.CellBounds.X, pE.CellBounds.Y, pE.CellBounds.Width, pE.CellBounds.Height);
            //pE.Graphics.DrawRectangle(pp, pE.ClipRectangle.X, pE.ClipRectangle.Y, pE.ClipRectangle.Width - 1, pE.ClipRectangle.Height - 1); 
            PaintLine(Color.Black,pE);
        }

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            PaintLine(Color.Black, e);
        }

        private void PaintLine(Color color, TableLayoutCellPaintEventArgs pE)
        {
             // 单元格重绘
            Pen pp = new Pen(color);
            pE.Graphics.DrawRectangle(pp, pE.CellBounds.X, pE.CellBounds.Y, pE.CellBounds.Width, pE.CellBounds.Height);
            pE.Graphics.DrawRectangle(pp, pE.ClipRectangle.X, pE.ClipRectangle.Y, pE.ClipRectangle.Width - 1, pE.ClipRectangle.Height - 1); 
        }
    }
}
