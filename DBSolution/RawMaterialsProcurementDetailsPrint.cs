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
    public partial class RawMaterialsProcurementDetailsPrint : Form
    {
        double cynum = 0.000;
        double gross = 0.000;
        double tare = 0.000;
        double net = 0.000;
        int realzfimg = 0;
        double lfimg = 0.000;
        int zfimg = 0;
        double pweight = 0.0;
        public RawMaterialsProcurementDetailsPrint()
        {
            InitializeComponent();
            this.printDocument1.OriginAtMargins = true;//启用页边距
        }

        public void ShowDialog(string truckNum, string timeFlag, string ebeln,int lag, IWin32Window parent)
        {
            Sdl_RawMaterialsProcurementTitle modelTitle = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(truckNum, ebeln, timeFlag);
            Sdl_RawMaterialsProcurement model = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurement(timeFlag, ebeln);
            string where = "where timeflag='" + timeFlag + "' and vbeln='" + ebeln + "'";
            DataTable dt = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurementDataSet(where).Tables[0];
            labelPaperTitle.Text = Sdl_CompanyAdapter.GetSdl_Company(Sdl_FactoryAdapter.GetSdl_Factory(modelTitle.WERKS).BUKRS.ToString()).BUTXT.ToString() + "物料到货通知单（一）";
            labelWerks.Text = Sdl_FactoryAdapter.GetSdl_Factory(modelTitle.WERKS).NAME1.ToString();     //工厂
            labelTruckNum.Text = modelTitle.TRUCKNUM.ToString();    //车号
            labelEnterTime.Text = modelTitle.ENTERTIME.ToString() + " --> " + modelTitle.EXITTIME.ToString();      //时间
            labelVbeln.Text = modelTitle.VBELN.ToString();       //订单编号
            labelLifnr.Text = model.LIFNR.ToString();       //供应商编码
            labelMCOD1.Text = model.MCOD1.ToString();       //供应商
            labelAblad.Text = modelTitle.ABLAD.ToString();      //发货地点
            labelBktxt.Text = model.BKTXT.ToString();           //产地品牌
            labelPstyp.Text = model.PSTYP.ToString();            //标准
            textBoxWagon.Text = modelTitle.WAGON.ToString();         //车皮号
            textBoxWagonNum.Text = modelTitle.WAGONNUM.ToString();        //包车皮车号
            labelLgort.Text = string.Empty ;           //收货仓库
            labelMatnr.Text = model.MATNR.ToString();       //物料编号
            labelMaktx.Text = model.MAKTX.ToString();       //物料描述 
            labelSPweight.Text = model.PWEIGHT.ToString();       //特殊包重
            textBfimg.Text = modelTitle.BFIMG.ToString();      //破件
            textFreight.Text = modelTitle.FREIGHT.ToString();      // 运费
            if (modelTitle.WEIGHMAN == modelTitle.EXITWEIGHMAN)
            {
                labelExitWeightMan.Text = modelTitle.EXITWEIGHMAN.ToString();
            } 
            else
            {
                labelExitWeightMan.Text = modelTitle.WEIGHMAN.ToString() + " " +modelTitle.EXITWEIGHMAN.ToString();
            }

            realzfimg = 0;
            net = Convert.ToDouble(modelTitle.NET.ToString());
            gross = Convert.ToDouble(modelTitle.GROSS.ToString());
            tare = Convert.ToDouble(modelTitle.TARE.ToString());
            lfimg = Convert.ToDouble(model.LFIMG.ToString());
            zfimg = Convert.ToInt32(model.ZFIMG.ToString());
            cynum = Convert.ToDouble(modelTitle.CYNUM.ToString());
            pweight = Convert.ToDouble(model.PWEIGHT.ToString()) / 1000;
            if (dt.Rows.Count != 0)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (0 < i && i < dt.Rows.Count && dt.Rows[i]["LGORT"].ToString() != "" && dt.Rows[i]["LGORT"].ToString() != dt.Rows[i - 1]["LGORT"].ToString())
                    {
                        DataTable dtLgort = Sdl_WarehouseAdapter.GetSdl_WarehouseSet("where LGORT =" + dt.Rows[i]["LGORT"].ToString() + " and WERKS = " + modelTitle.WERKS.ToString()).Tables[0];
                        labelLgort.Text = labelLgort.Text.ToString() + dtLgort.Rows[0]["LGOBE"].ToString() + "  ";
                    }
                    else
                    {
                        DataTable dtLgort = Sdl_WarehouseAdapter.GetSdl_WarehouseSet("where LGORT =" + dt.Rows[i]["LGORT"].ToString() + " and WERKS = " + modelTitle.WERKS.ToString()).Tables[0];
                        labelLgort.Text = dtLgort.Rows[0]["LGOBE"].ToString() + "  ";
                    }
                    if (0 < i && i < dt.Rows.Count && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                    {
                        lfimg += Convert.ToDouble(dt.Rows[i]["LFIMG"].ToString());
                        zfimg += Convert.ToInt32(dt.Rows[i]["ZFIMG"].ToString());
                        labelSPweight.Text += ("/" + dt.Rows[i]["PWEIGHT"].ToString());
                    }
                    else
                    {
                        lfimg = Convert.ToDouble(dt.Rows[i]["LFIMG"].ToString());
                        zfimg = Convert.ToInt32(dt.Rows[i]["ZFIMG"].ToString());
                        labelSPweight.Text = dt.Rows[i]["PWEIGHT"].ToString();
                    }
                    if (model.KG == "1")
                    {
                        lfimg = lfimg / 1000;
                    }
                    realzfimg += Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                }
            }
            if (lag == 1)
            {
                countNet(gross, tare, net, lfimg, realzfimg, zfimg, pweight, cynum, dt);
            }
            else
            {
                countNetNoBfimg(gross, tare, net, lfimg, realzfimg, zfimg, pweight, cynum, dt);
            }
            this.ShowDialog(parent);
        }

        public void ShowDialog(DataTable paper, DataTable table,int lag, IWin32Window parent)
        {
            for (int i = 0; i < paper.Rows.Count; i++)
            {
                labelPaperTitle.Text = Sdl_CompanyAdapter.GetSdl_Company(Sdl_FactoryAdapter.GetSdl_Factory(paper.Rows[i]["Werks"].ToString()).BUKRS.ToString()).BUTXT.ToString() + "物料到货通知单（一）";
                labelWerks.Text = Sdl_FactoryAdapter.GetSdl_Factory(paper.Rows[i]["Werks"].ToString()).NAME1.ToString();
                labelTruckNum.Text = paper.Rows[i]["Car"].ToString();
                labelVbeln.Text = paper.Rows[i]["VBELN"].ToString();
                labelEnterTime.Text = paper.Rows[i]["ENTERTIME"].ToString() + " --> " + paper.Rows[i]["EXITTIME"].ToString();      //入厂时间
                labelAblad.Text = paper.Rows[i]["ABLAD"].ToString();
                textBoxWagon.Text = paper.Rows[i]["Wagon"].ToString();
                textBoxWagonNum.Text = paper.Rows[i]["WagonNum"].ToString();
                labelLgort.Text = string.Empty;
                textBfimg.Text = paper.Rows[i]["Bfimg"].ToString();
                textFreight.Text = paper.Rows[i]["Freight"].ToString();
                labelExitWeightMan.Text = paper.Rows[i]["WeighMan"].ToString();
                gross = Convert.ToDouble(paper.Rows[i]["Gross"].ToString());
                tare = Convert.ToDouble(paper.Rows[i]["Tare"].ToString());
                net = Convert.ToDouble(paper.Rows[i]["Net"].ToString());
                 
                if (table.Rows.Count != 0)
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        if (table.Rows[j]["LGORT"].ToString() != "")
                        {
                            DataTable dtLgort = Sdl_WarehouseAdapter.GetSdl_WarehouseSet("where LGORT =" + table.Rows[j]["LGORT"].ToString() + " and WERKS =" + paper.Rows[i]["Werks"].ToString()+"").Tables[0];
                            labelLgort.Text = labelLgort.Text.ToString() + dtLgort.Rows[0]["LGOBE"].ToString() + "  ";
                        }
                        labelMCOD1.Text = table.Rows[j]["NAME1"].ToString();
                        labelBktxt.Text = table.Rows[j]["BKTXT"].ToString();
                        labelPstyp.Text = table.Rows[j]["PTEXT"].ToString();
                        labelMatnr.Text = table.Rows[j]["MATNR"].ToString();
                        labelMaktx.Text = table.Rows[j]["MAKTX"].ToString();
                        labelLifnr.Text = table.Rows[j]["LIFNR"].ToString();
                        if (0 < j && j < table.Rows.Count && table.Rows[j]["PWEIGHT"].ToString() != table.Rows[j - 1]["PWEIGHT"].ToString())
                        {
                            lfimg += Convert.ToDouble(table.Rows[j]["LFIMG"].ToString());
                            zfimg += Convert.ToInt32(table.Rows[j]["ZFIMG"].ToString());
                            labelSPweight.Text += ("/" + table.Rows[j]["PWEIGHT"].ToString());
                        }
                        else
                        {
                            lfimg = Convert.ToDouble(table.Rows[j]["LFIMG"].ToString());
                            zfimg = Convert.ToInt32(table.Rows[j]["ZFIMG"].ToString());
                            labelSPweight.Text = table.Rows[j]["PWEIGHT"].ToString();
                        }
                        
                        pweight = Convert.ToDouble(table.Rows[j]["PWEIGHT"].ToString()) / 1000;
                        realzfimg += Convert.ToInt32(table.Rows[j]["REALZFIMG"].ToString());
                        if (paper.Rows[i]["KG"].ToString() == "1")
                        {
                            lfimg = lfimg / 1000;
                        }
                    }
                }
                if (lag == 1)
                {
                    countNet(gross, tare, net, lfimg, realzfimg, zfimg, pweight, cynum, table);
                }
                else
                {
                    countNetNoBfimg(gross, tare, net, lfimg, realzfimg, zfimg, pweight, cynum, table);
                }
            }
            
            this.ShowDialog(parent);
        }

        private void countNet(double gross, double tare, double net, double lfimg, int realzfimg, int zfimg, double pweight, double cynum, DataTable dt)
        {
            double nett = 0;
            int realzfimgt = 0;
            double lfimgt = 0.000;
            int zfimgt = 0;
            double pweightt = 0.0;
            if (net <= lfimg && realzfimg == zfimg)   //净重小于原发吨数，数量相等1
            {
                net = net + (net-lfimg) / zfimg;
                gross = net + tare;
                cynum = net - lfimg;
            }
            if (net >= lfimg && realzfimg < zfimg)  //净重大于或等于原发吨数，实收小于原发数量2
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                    {
                        realzfimgt = Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                        pweightt = Convert.ToDouble(dt.Rows[i]["PWEIGHT"].ToString()) / 1000;
                        nett = Convert.ToDouble(dt.Rows[i]["Net"].ToString());
                        lfimgt = Convert.ToDouble(dt.Rows[i]["LFIMG"].ToString());
                        zfimgt = Convert.ToInt32(dt.Rows[i]["ZFIMG"].ToString());
                        net = nett + (realzfimgt * pweightt + ((nett - lfimgt) / zfimgt));
                    }
                    else if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() == dt.Rows[i - 1]["PWEIGHT"].ToString())
                    {
                        break;
                    }
                    else
                    {
                        net = realzfimg * pweight + ((net - lfimg) / zfimg);
                    }
                }
                gross = net + tare;
                cynum = net - lfimg;
            }
            if (net > lfimg && realzfimg >= zfimg)  //净重大于原发吨数，实收大于或等于原发数量3
            {
                net = lfimg + ((net - lfimg) / zfimg);
                gross = net + tare;
                realzfimg = zfimg;
                cynum = 0;
            }
            if (net < lfimg && realzfimg < zfimg)       //净重小于原发吨数，实收小于原发数量
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                    {
                        realzfimgt = Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                        pweightt = Convert.ToDouble(dt.Rows[i]["PWEIGHT"].ToString()) / 1000;
                        lfimgt += realzfimgt * pweightt;
                    }
                    else
                    {
                        lfimgt += realzfimg * pweight;
                    }
                }
                if (net > lfimgt)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                        {
                            realzfimgt = Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                            pweightt = Convert.ToDouble(dt.Rows[i]["PWEIGHT"].ToString()) / 1000;
                            net += realzfimgt * pweightt;
                        }
                        else
                        {
                            net = realzfimg * pweight;
                        }
                    }
                }
                cynum = net - lfimg;
                gross = net + tare;
            }
            if (net <= lfimg && realzfimg > zfimg)       //净重小于原发吨数，实收大于原发数量
            {
                realzfimg = zfimg;
                cynum = net - lfimg;
                gross = net + tare;
            }
            //else
            //{
            //    gross = net + tare;
            //}
            textGross.Text = gross.ToString("f2");     //毛重
            textTare.Text = tare.ToString("f2");       //皮重
            textNet.Text = net.ToString("f2");     //净重
            textCYNum.Text = cynum.ToString("f2");      //亏吨
            textLfimg.Text = lfimg.ToString();       //原发吨数
            textZfimg.Text = zfimg.ToString();       //原发件数
            textRealzfimg.Text = realzfimg.ToString();       //实收件数
            textDfimg.Text = (realzfimg - zfimg).ToString();       //亏件
            labelRealzfimgB.Text = TryConverRMBCharToChar(realzfimg.ToString());
        }

        private void countNetNoBfimg(double gross, double tare, double net, double lfimg, int realzfimg, int zfimg, double pweight, double cynum, DataTable dt)
        {
            double nett = 0;
            int realzfimgt = 0;
            double lfimgt = 0.000;
            int zfimgt = 0;
            double pweightt = 0.0;
            if (net < lfimg && realzfimg == zfimg)   //净重小于原发吨数，数量相等1
            {
                net = net + (net - lfimg) / zfimg;
                gross = net + tare;
                cynum = net - lfimg;
            }
            if (net >= lfimg && realzfimg < zfimg)  //净重大于或等于原发吨数，实收小于原发数量2
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                        {
                            realzfimgt = Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                            pweightt = Convert.ToDouble(dt.Rows[i]["PWEIGHT"].ToString()) / 1000;
                            nett = Convert.ToDouble(dt.Rows[i]["Net"].ToString());
                            lfimgt = Convert.ToDouble(dt.Rows[i]["LFIMG"].ToString());
                            zfimgt = Convert.ToInt32(dt.Rows[i]["ZFIMG"].ToString());
                            net = nett + (realzfimgt * pweightt + ((nett - lfimgt) / zfimgt));
                        }
                        else if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() == dt.Rows[i - 1]["PWEIGHT"].ToString())
                        {
                            break;
                        }
                        else
                        {
                            net = realzfimg * pweight + ((net - lfimg) / zfimg);
                        }
                    }
                gross = net + tare;
                cynum = net - lfimg;
            }
            if (net < lfimg && realzfimg < zfimg)       //净重小于原发吨数，实收小于原发数量
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                    {
                        realzfimgt = Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                        pweightt = Convert.ToDouble(dt.Rows[i]["PWEIGHT"].ToString()) / 1000;
                        lfimgt += realzfimgt * pweightt;
                    }
                    else
                    {
                        lfimgt += realzfimg * pweight;
                    }
                }
                if (net > lfimgt)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i > 0 && dt.Rows[i]["PWEIGHT"].ToString() != dt.Rows[i - 1]["PWEIGHT"].ToString())
                        {
                            realzfimgt = Convert.ToInt32(dt.Rows[i]["REALZFIMG"].ToString());
                            pweightt = Convert.ToDouble(dt.Rows[i]["PWEIGHT"].ToString()) / 1000;
                            net += realzfimgt * pweightt;
                        }
                        else
                        {
                            net = realzfimg * pweight;
                        }
                    }
                }
                cynum = net - lfimg;
            }
            //else
            //{
            //    gross = net + tare;
            //}
            textGross.Text = gross.ToString("f2");     //毛重
            textTare.Text = tare.ToString("f2");       //皮重
            textNet.Text = net.ToString("f2");     //净重
            textCYNum.Text = cynum.ToString("f2");      //亏吨
            textLfimg.Text = lfimg.ToString();       //原发吨数
            textZfimg.Text = zfimg.ToString();       //原发件数
            textRealzfimg.Text = realzfimg.ToString();       //实收件数
            textDfimg.Text = (realzfimg - zfimg).ToString();       //亏件
            labelRealzfimgB.Text = TryConverRMBCharToChar(realzfimg.ToString());
        }

        //打印
        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            labelRealzfimgB.Focus();
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

        private void Mouse_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ReadOnly = false;    
        }

        private void Fouse_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ReadOnly = true;
        }

        private void textRealzfimg_TextChanged(object sender, EventArgs e)
        {
            labelRealzfimgB.Text = TryConverRMBCharToChar(textRealzfimg.Text.ToString()); 
        }

        private string TryConverRMBCharToChar(string p)
            {
                string RMBStr = "";
                double money;
                if (double.TryParse(p, out money))
                {
                    double temp= money*100;
                    string cent = (temp % 10).ToString();
                    temp/= 10;
                    string _10cent = temp>=1?((int)(temp % 10)).ToString():(cent == "￥"||cent == string.Empty?string.Empty:"￥");
                    temp/=10;
                    string yuan = temp >= 1 ? ((int)(temp % 10)).ToString() : (_10cent == "￥" || _10cent == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _10 = temp >= 1 ? ((int)(temp % 10)).ToString() : (yuan == "￥" || yuan == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _100 = temp >= 1 ? ((int)(temp % 10)).ToString() : (_10 == "￥" || _10 == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _K = temp >= 1 ? ((int)(temp % 10)).ToString() : (_100 == "￥" || _100 == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _10K = temp >= 1 ? ((int)(temp % 10)).ToString() : (_K == "￥" || _K == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _100K = temp >= 1 ? ((int)(temp % 10)).ToString() : (_10K == "￥" || _10K == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _M = temp >= 1 ? ((int)(temp % 10)).ToString() : (_100K == "￥" || _100K == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _10M = temp >= 1 ? ((int)(temp % 10)).ToString() : (_M == "￥" || _M == string.Empty ? string.Empty : "￥");
                    temp /= 10;
                    string _100M = temp >= 1 ? ((int)(temp % 10)).ToString() : (_10M == "￥" || _10M == string.Empty ? string.Empty : "￥");
                    

                    string output = _100M.ToString() + _10M.ToString() + _M.ToString() + _100K.ToString()+_10K.ToString()
                        + _K.ToString() + _100.ToString() + _10.ToString() + yuan.ToString() + _10cent.ToString() + cent.ToString();
                    
                    if (!string.IsNullOrEmpty(_100M) && _100M != "￥")
                    {
                        if (_100M == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_100M) + "亿";
                        }
                    }
                    if (!string.IsNullOrEmpty(_10M) && _10M != "￥")
                    {
                        if (_10M == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_10M) + "仟";
                        }
                    }
                    if (!string.IsNullOrEmpty(_M) && _M != "￥")
                    {
                        if (_M == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_M) + "佰";
                        }
                    }
                    if (!string.IsNullOrEmpty(_100K) && _100K != "￥")
                    {
                        if (_100K == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_100K) + "拾";
                        }
                    }
                    if (!string.IsNullOrEmpty(_10K) && _10K != "￥")
                    {
                        if (_10K == "0")
                        {
                            RMBStr += "万零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_10K) + "万";
                        }
                    }
                    if (!string.IsNullOrEmpty(_K) && _K != "￥")
                    {
                        if (_K == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_K) + "仟";
                        }
                    }
                    if (!string.IsNullOrEmpty(_100) && _100 != "￥")
                    {
                        if (_100 == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_100) + "佰";
                        }
                    }
                    if (!string.IsNullOrEmpty(_10) && _10 != "￥")
                    {
                        if (_10 == "0")
                        {
                            RMBStr += "零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(_10) + "拾";
                        }
                    }
                    if (!string.IsNullOrEmpty(yuan) && yuan != "￥")
                    {
                        if (yuan == "0")
                        {
                            RMBStr += "件零";
                        }
                        else
                        {
                            RMBStr += ConverRMBNOToStr(yuan) + "件";
                        }
                    }
                   
                        if (!string.IsNullOrEmpty(_10cent) && _10cent != "￥")
                        {
                            if(_10cent == "0")
                            {
                                RMBStr += "零";
                            }
                            else
                            {
                                RMBStr += ConverRMBNOToStr(_10cent) + "角";
                            }
                        }
                        if (!string.IsNullOrEmpty(cent) && cent != "￥")
                        {
                            if (cent == "0")
                            {
                                RMBStr += "零";
                            }
                            else
                            {
                                RMBStr += ConverRMBNOToStr(cent) + "分";
                            }
                        }
                   
                    if (string.IsNullOrEmpty(cent) || cent == "0")
                    {
                        RMBStr += "整";
                    }
                    RMBStr = RemoveZero(RMBStr);
                    RMBStr = RemoveLastZero(RMBStr);
                }
                return RMBStr;
            }
        private string RemoveLastZero(string RMBStr)
        {
            if (RMBStr.Substring(RMBStr.Length - 1) == "零")
            {
                return RMBStr.Remove(RMBStr.Length - 1);
            }
            else
                return RMBStr;
        }
        private string RemoveZero(string RMBStr)
        {
            if (RMBStr.IndexOf("零零") > 0)
            {
                RMBStr = RMBStr.Replace("零零", "零");
                return RemoveZero(RMBStr);
            }
            else if (RMBStr.IndexOf("零万零") > 0)
            {
                RMBStr = RMBStr.Replace("零万零", "万零");
                return RemoveZero(RMBStr);
            }
            else if (RMBStr.IndexOf("零件零") > 0)
            {
                RMBStr = RMBStr.Replace("零件零", "件零");
                return RemoveZero(RMBStr);
            }
            else if (RMBStr.IndexOf("零整") > 0)
            {
                RMBStr = RMBStr.Replace("零整", "整");
                return RemoveZero(RMBStr);
            }
            else
            {
                return RMBStr;
            }
        }
        private string ConverRMBNOToStr(string p)
        {
            switch (p)
            {
                case "1": return "壹"; break;
                case "2": return "贰"; break;
                case "3": return "叁"; break;
                case "4": return "肆"; break;
                case "5": return "伍"; break;
                case "6": return "陆"; break;
                case "7": return "柒"; break;
                case "8": return "捌"; break;
                case "9": return "玖"; break;
                default: return " "; break;
            }
        }

    }
}
