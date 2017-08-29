using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;

namespace DBSolution
{
    public partial class FinishedProductsExchangeOutSearchDetail : Form
    {
        private Sdl_FinishedProductsExchangeTitle model = null;
        public FinishedProductsExchangeOutSearchDetail()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWin32Window parent, string truckNum, string timeFlag, string oanum)
        {
            model = Sdl_FinishedProductsExchangeOutTitleAdapter.GetSdl_FinishedProductsExchangeOutTitle(truckNum, oanum, timeFlag);
            textBoxWerks.Text = model.WERKS;
            textTruckNum.Text = model.TRUCKNUM;
            textBoxGross.Text = model.GROSS.ToString();
            textBoxTare.Text = model.TARE.ToString();
            textBoxNet.Text = model.NET.ToString();
            textBoxEnterTime.Text = model.ENTERTIME.ToString();
            textBoxExitTime.Text = model.EXITTIME.ToString();
            textBoxEnterWeight.Text = model.ENTERWEIGHT;
            textBoxExitWeight.Text = model.EXITWEIGHT;
            textBoxNOTE.Text = model.NOTE.ToString();
            textBoxCNum.Text = model.CNUM;
            textBoxCName.Text = model.CNAME;
            textBoxTType.Text = model.TTYPE;
            textBoxFxqd.Text = model.FXQD;
            textBoxYwy.Text = model.YWY;
            textBoxXsqy.Text = model.XSQY;
            textBoxXsks.Text = model.XSKS;
            if (model.HS_FLAG.Equals("S"))
            {
                checkBoxExit.Checked = true;
            }
            else
            {
                checkBoxExit.Checked = false;
            }

            if (model.EXITFLAG == 1)
            {
                checkBoxHeight.Checked = true;
            }
            else
            {
                checkBoxHeight.Checked = false;
            }
            string where = " where timeflag='" + timeFlag + "' and oanum='" + model.OANUM + "' and trucknum='" + model.TRUCKNUM + "' ";

            DataTable dt = Sdl_FinishedProductsExchangeOutAdapter.GetSdl_FinishedProductsExchangeOutDataSet(where).Tables[0];
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

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FinishedProductsExchangeInPrint printer = new FinishedProductsExchangeInPrint();
            printer.StartPosition = FormStartPosition.CenterParent;
            printer.ShowDialog(this, model.TRUCKNUM, model.OANUM, model.TIMEFLAG, "out");
            this.Cursor = Cursors.Default;
        }
    }
}
