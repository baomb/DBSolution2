using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;

namespace DBSolution
{
    public partial class AccessoryProcurementDetail : Form
    {
        public AccessoryProcurementDetail()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {

            Sdl_AccessoryProcurementTitle model = Sdl_AccessoryProcurementTitleAdapter.GetSdl_AccessoryProcurementTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textWeighMan.Text = model.ENTERWEIGHMAN;
            textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.WERKS;
            textBoxDeductNum.Text = model.DEDUCTNUM.ToString();
            string where = " where B.timeflag='" + timeFlag + "' and werks='" + model.WERKS + "'";

            DataTable dt = Sdl_AccessoryProcurementDetailAdapter.GetSdl_AccessoryProcurementDetailSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void buttonCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

    }
}
