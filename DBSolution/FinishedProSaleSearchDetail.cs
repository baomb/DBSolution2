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
    public partial class FinishedProSaleSearchDetail : Form
    {
        public FinishedProSaleSearchDetail()
        {
            InitializeComponent();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_FinishedProductsSaleTitle model = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textBoxWerks.Text = model.KUNNR;
            textWeighMan.Text = model.WEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.WERKS;
            textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            txtNetValue.Text = decimal.Parse((model.GROSS - model.TARE - ((model.TRAYWEIGHT * model.TRAYQUANTITY)/1000.0)).ToString()).ToString("#0.00");
            textBoxTrayWeight.Text = model.TRAYWEIGHT.ToString();
            textBoxTrayQuantity.Text = model.TRAYQUANTITY.ToString();
            textBoxNOTE.Text = model.NOTE.ToString();
            string where = " where B.timeflag='" + timeFlag + "' and werks='" + model.WERKS + "' ";

            DataTable dt = Sdl_FinishedProductsSaleAdapter.GetSdl_FinishedProductsSaleSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

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
    }
}
