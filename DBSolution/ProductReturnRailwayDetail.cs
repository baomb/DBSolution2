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

namespace DBSolution
{
    public partial class ProductReturnRailwayDetail : Form
    {
        public ProductReturnRailwayDetail()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_ProductReturnRailway model = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailway(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textBoxWerks.Text = model.KUNNR;
            textWeighMan.Text = model.ENTERWEIGHMAN;
            textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.WERKS;
            textBoxExitWeignMan.Text = model.EXITWEIGHMAN;

            string where = " where B.timeflag='" + timeFlag + "' and werks='" + model.WERKS + "'";

            DataTable dt = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void btnCloseA_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
