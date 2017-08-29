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
    public partial class AccessoryAllotTranferInDetail : Form
    {
        public AccessoryAllotTranferInDetail()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_AccessoryAllotInTitle model = Sdl_AccessoryAllotInTitleAdapter.GetSdl_AccessoryAllotInTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textWeighMan.Text = model.ENTERWEIGHMAN;
            textBoxExitWeighMan.Text = model.EXITWEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.WERKS;
            textBoxDeductNum.Text = model.DEDUCTNUM.ToString();
            string where = " where B.timeflag='" + timeFlag + "' and B.werks='" + model.WERKS + "'";

            DataTable dt = Sdl_AccessoryAllotInDetailAdapter.GetSdl_AccessoryAllotInDetailSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
