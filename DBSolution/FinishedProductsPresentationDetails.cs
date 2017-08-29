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
    public partial class FinishedProductsPresentationDetails : Form
    {
        public FinishedProductsPresentationDetails()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, string rsnum, string timeFlag, IWin32Window parent)
        {
            Sdl_FinishedProductsPresentationTitle fppt = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitle(truckNum, rsnum, timeFlag);
            textBoxEnterTime.Text = fppt.ENTERTIME.ToString();
            textBoxExitTime.Text = fppt.EXITTIME.ToString();
            textBoxFlag.Text = fppt.HS_FLAG;
            textBoxGross.Text = fppt.GROSS.ToString();
            textBoxNet.Text = fppt.NET.ToString();
            textBoxTare.Text = fppt.TARE.ToString();
            textBoxTruckNum.Text = fppt.TRUCKNUM.ToString();
            textBoxWerks.Text = fppt.WERKS.ToString();
            textBoxRSNUM.Text = fppt.RSNUM;
            textWeighMan.Text = fppt.ENTERWEIGHMAN;
            textBoxExitWeignMan.Text = fppt.EXITWEIGHMAN;
            string where = "where timeflag='" + timeFlag + "' and rsnum='" + rsnum + "'";
            DataTable dt = Sdl_FinishedProductsPresentationAdapter.GetSdl_FinishedProductsPresentationDataSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            this.ShowDialog(parent);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
