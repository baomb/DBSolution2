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

namespace DBSolution
{
    public partial class FlotsamDetailPrint : Form
    {
        public FlotsamDetailPrint()
        {
            InitializeComponent();
            this.printDocument1.OriginAtMargins = true;//启用页边距
            this.labelRemarks.Height = 30;
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            sdl_FloatsamEnter model = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(truckNum, timeFlag);
            labelWerk.Text = Sdl_FactoryAdapter.GetSdl_Factory(model.Werks).NAME1;
            labelTruckNum.Text = model.TruckNum;
            labelExitTime.Text = model.ExitTime.ToString();
            labelBuyer.Text = model.Buyer;
            labelFloatsamID.Text = model.FloatsamID;
            labelFloatsamName.Text = Sdl_FloatsamNameItemAdapter.Getsdl_FloatsamNameItem(model.FloatsamName).Name;
            //labelGross.Text =( Convert.ToSingle(model.Gross)-Convert.ToSingle( model.Stuff)).ToString();//去掉扣杂重毛重
            labelGross.Text = (Convert.ToSingle(model.Gross)).ToString();//未去扣杂重毛重
            labelTare.Text = Convert.ToSingle(model.Tare).ToString();
            //labelStuff.Text =Convert.ToSingle( model.Stuff).ToString();
            labelNet.Text = Convert.ToSingle(model.Net).ToString();
            labelLgort.Text = model.Lgort;
            labelRemarks.Text = model.Remarks.Trim();
            labelExitWeightMan.Text = model.ExitWeightMan;
            labelSaleMan.Text = model.SaleMan;
            labelPasser.Text = model.Passer;
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
