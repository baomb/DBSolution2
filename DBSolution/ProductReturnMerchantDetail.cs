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
    public partial class ProductReturnMerchantDetail : Form
    {
        public ProductReturnMerchantDetail()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            Sdl_ProductReturnMerchant model = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchant(truckNum, timeFlag);
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

            DataTable dt = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchantSearchSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;

            this.ShowDialog(parent);
        }

        private void btncloseform_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
