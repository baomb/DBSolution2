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
    public partial class RawMaterialsSaleDetails : Form
    {
        public RawMaterialsSaleDetails()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(string truckNum, string vbeln, string timeFlag, IWin32Window parent)
        {
            Sdl_RawMaterialsSaleTitle rmst = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitle(truckNum, vbeln, timeFlag);
            textBoxEnterTime.Text = rmst.ENTERTIME.ToString();
            textBoxExitTime.Text = rmst.EXITTIME.ToString();
            textBoxHSFlag.Text = (rmst.HS_FLAG == "H") ? "进厂" : "出厂";
            textBoxGross.Text = rmst.GROSS.ToString();
            textBoxNet.Text = rmst.NET.ToString();
            textBoxTare.Text = rmst.TARE.ToString();
            textBoxTruckNum.Text = rmst.TRUCKNUM.ToString();
            textBoxWerks.Text = rmst.WERKS.ToString();
            textEBELN.Text = rmst.VBELN;
            textWeighMan.Text = rmst.WEIGHMAN;
            textBoxEXWeighMan.Text = rmst.EXITWEIGHMAN;
            textBoxEXFlag.Text = (rmst.EXITFLAG == true) ? "是" : "否";
            textBoxDiff.Text = rmst.BALANCE.ToString();
            string where = "where timeflag='" + timeFlag + "' and vbeln='" + vbeln + "'";
            DataTable dt = Sdl_RawMaterialsSaleAdapter.GetSdl_RawMaterialsSaleDataSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            this.ShowDialog(parent);
        }
    }
}
