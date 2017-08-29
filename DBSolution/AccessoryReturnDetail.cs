using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;

namespace DBSolution
{
    public partial class AccessoryReturnDetail : Form
    {
        public AccessoryReturnDetail()
        {
            InitializeComponent();
        }


        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {

            Sdl_AccessoryReturnTitle model = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitle(truckNum, timeFlag);
            textTruckNum.Text = model.TRUCKNUM;
            textWeighMan.Text = model.ENTERWEIGHMAN;
            textBoxExitWeignMan.Text = model.EXITWEIGHMAN;
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxWerks.Text = model.WERKS;
            textBoxDeductNum.Text = model.DEDUCTNUM.ToString();
            string where = " where B.timeflag='" + timeFlag + "'";

            DataTable dt = Sdl_AccessoryReturnDetailAdapter.GetSdl_AccessoryReturnDetailSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClsoe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
