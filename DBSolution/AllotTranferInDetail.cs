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
    public partial class AllotTranferInDetail : Form
    {
        public AllotTranferInDetail()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_AllotInTitle model = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textWeighMan.Text = model.ENTERWEIGHMAN;
            textBoxExitWeighMan.Text = model.EXITWEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.RESWK;
            textBoxDeductNum.Text = model.DEDUCTNUM.ToString();
            string where = " where B.timeflag='" + timeFlag + "' and B.WERKS ='" + model.WERKS + "'";

            DataTable dt = Sdl_AllotInDetailAdapter.GetSdl_AllotInDetailSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
