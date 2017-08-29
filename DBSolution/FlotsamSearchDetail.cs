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
    public partial class FlotsamSearchDetail : Form
    {
        public FlotsamSearchDetail()
        {
            InitializeComponent();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            sdl_FloatsamEnter model = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(truckNum, timeFlag);
            textBoxFlotsamID.Text = model.FloatsamID;
            textTruckNum.Text = model.TruckNum;
            textBoxWerks.Text = model.Werks;
            textBoxBuyer.Text = model.Buyer;
            textBoxCode.Text = model.FloatsamName;
            textBoxFloatsamName.Text = Sdl_FloatsamNameItemAdapter.Getsdl_FloatsamNameItem(model.FloatsamName).Name;
            textBoxGross.Text = Convert.ToSingle(model.Gross).ToString() ;
            textBoxTare.Text = Convert.ToSingle(model.Tare).ToString();
            textBoxStuff.Text = Convert.ToSingle(model.Stuff).ToString();
            txtNet.Text = Convert.ToSingle(model.Net).ToString();
            textBoxSaleMan.Text = model.SaleMan;
            textBoxRemarks.Text = model.Remarks;
            textBoxEnterTime.Text = model.EnterTime.ToString();
            textBoxExitTime.Text = model.ExitTime.ToString();
            textWeighMan.Text = model.EnterWeightMan;
            textBoxExitWeignMan.Text = model.ExitWeightMan;
            textBoxEnterDBNum.Text = model.EnterDBNum;
            textBoxIsEmptyOut.Text = model.IsEmptyOut == "1" ? "是" : "否";
            this.textBoxLgort.Text = model.Lgort;
            textBoxPasser.Text = model.Passer;
            this.ShowDialog(parent);
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FlotsamDetailPrint proDetail = new FlotsamDetailPrint();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(textTruckNum.Text, this, textBoxEnterTime.Text);
            this.Cursor = Cursors.Default;
        }
    }
}
