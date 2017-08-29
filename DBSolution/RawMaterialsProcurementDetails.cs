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
    public partial class RawMaterialsProcurementDetails : Form
    {
        string tempTimeFlag = "";
        Sdl_RawMaterialsProcurementTitle rmpt = new Sdl_RawMaterialsProcurementTitle();
        public RawMaterialsProcurementDetails()
        {
            InitializeComponent();
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            //是否启用打印功能
            //string dateStart = "2014-09-01 00:00:00";
            //if (Convert.ToDateTime(Common.GetServerDate()).CompareTo(Convert.ToDateTime(dateStart)) > 0)
            //{
            //    if (sysSetting.WERKS == "2401" || sysSetting.WERKS == "2501" || sysSetting.WERKS == "2601" || sysSetting.WERKS == "2003" || sysSetting.WERKS == "2002" || sysSetting.WERKS == "2101")
            //    {
            //        toolStripButtonPrint.Visible = true;
            //    }
            //}
            //else
            //{
            //}
        }

        public void ShowDialog(string truckNum, string ebeln, string timeFlag, IWin32Window parent)
        {
            rmpt = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitle(truckNum, ebeln, timeFlag);
            textBoxEnterTime.Text = rmpt.ENTERTIME.ToString();
            textBoxExitTime.Text = rmpt.EXITTIME.ToString();
            textBoxHSFlag.Text = (rmpt.HS_FLAG == "H") ? "进厂" : "出厂";
            textBoxGross.Text = rmpt.GROSS.ToString();
            textBoxNet.Text = rmpt.NET.ToString();
            textBoxTare.Text = rmpt.TARE.ToString();
            textBoxTruckNum.Text = rmpt.TRUCKNUM.ToString();
            textBoxWerks.Text = rmpt.WERKS.ToString();
            textEBELN.Text = rmpt.VBELN;
            textWeighMan.Text = rmpt.WEIGHMAN;
            textBoxEXWeighMan.Text = rmpt.EXITWEIGHMAN;
            textBoxEXFlag.Text = (rmpt.EXITFLAG == true) ? "是" : "否";
            textBoxDiff.Text = rmpt.BALANCE.ToString();
            txtCYNum.Text = rmpt.CYNUM.ToString();
            txtWagon.Text = rmpt.WAGON;
            txtWagonNum.Text = rmpt.WAGONNUM;
            textBoxTrayWeight.Text = rmpt.TRAYWEIGHT.ToString();
            textBoxTrayQuantity.Text = rmpt.TRAYQUANTITY.ToString();
            txtWagonNum.Text = rmpt.WAGONNUM.ToString();
            textBfimg.Text = rmpt.BFIMG.ToString();
            textFreight.Text = rmpt.FREIGHT.ToString();
            string where = "where timeflag='" + timeFlag + "' and vbeln='" + ebeln + "'";
            DataTable dt = Sdl_RawMaterialsProcurementAdapter.GetSdl_RawMaterialsProcurementDataSet(where).Tables[0];
            dataGridViewDetail.AutoGenerateColumns = false;
            dataGridViewDetail.DataSource = dt;
            tempTimeFlag = timeFlag;
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
            if (textBoxHSFlag.Text.ToString() == "出厂")
            {
                int lag = 0;
                if (MessageBox.Show("是否抹除涨件？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lag = 1;
                    }
                this.Cursor = Cursors.WaitCursor;
                RawMaterialsProcurementDetailsPrint proDetail = new RawMaterialsProcurementDetailsPrint();
                proDetail.StartPosition = FormStartPosition.CenterParent;
                proDetail.ShowDialog(this.textBoxTruckNum.Text.Trim(), tempTimeFlag, this.textEBELN.Text.Trim(), lag, this);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("该车尚未出厂");
            }
        }
    }
}