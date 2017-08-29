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
    public partial class RawMaterialReturnDetail : Form
    {
        public RawMaterialReturnDetail()
        {
            InitializeComponent();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_RawMaterialReturnTitle model = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textWeighMan.Text = model.WEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.WERKS;
            textBoxExitWeighman.Text = model.EXITWEIGHMAN;
            textBoxDeductNum.Text = model.DEDUCTNUM.ToString();
            textBoxTrayWeight.Text = model.TRAYWEIGHT.ToString();
            textBoxTrayQuantity.Text = model.TRAYQUANTITY.ToString();
            string where = " where B.timeflag='" + timeFlag + "' and werks='" + model.WERKS + "'";

            DataTable dt = Sdl_RawMaterialReturnDetailAdapter.GetSdl_RawMaterialReturnDetailSearchSet(where).Tables[0];
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
