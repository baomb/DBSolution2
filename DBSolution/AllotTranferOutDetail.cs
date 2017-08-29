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
    public partial class AllotTranferOutDetail : Form
    {
        public AllotTranferOutDetail()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_AllotTitle model = Sdl_AllotTitleAdapter.GetSdl_AllotTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textWeighMan.Text = model.ENTERWEIGHMAN;
            textBoxExitWeighMan.Text = model.EXITWEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.RESWK;
            textBoxDeductNum.Text = model.DEDUCTNUM.ToString();
            textBoxTrayWeight.Text = model.TRAYWEIGHT.ToString();
            textBoxTrayNum.Text = model.TRAYNUM.ToString();
            string where = " where B.timeflag='" + timeFlag + "' and B.WERKS='" + model.WERKS + "'";

            DataTable dt = Sdl_AllotDetailAdapter.GetSdl_AllotDetailSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
