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
    public partial class FlotsamManageDetail : Form
    {
        private bool EDIT = false;
        public FlotsamManageDetail()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            comboBoxFlotName.DataSource = Sdl_FloatsamNameItemAdapter.GetSdl_FloatsamNameItemDataSet("order by Name").Tables[0];
            comboBoxFlotName.ValueMember = "Code";
            comboBoxFlotName.DisplayMember = "Name";
            comboBoxFlotName.SelectedIndex = -1;
        }

        public void ShowDialog(string truckNum, IWin32Window parent, string timeFlag)
        {
            sdl_FloatsamEnter model = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(truckNum, timeFlag);
            textBoxFlotsamID.Text = model.FloatsamID;
            textTruckNum.Text = model.TruckNum;
            textBoxWerks.Text = model.Werks;
            textBoxBuyer.Text = model.Buyer;
            textBoxCode.Text = model.FloatsamName;
            comboBoxFlotName.Text = Sdl_FloatsamNameItemAdapter.Getsdl_FloatsamNameItem(model.FloatsamName).Name;
            textBoxGross.Text = Convert.ToSingle(model.Gross).ToString() ;
            textBoxTare.Text = Convert.ToSingle(model.Tare).ToString();
            textBoxStuff.Text = Convert.ToSingle(model.Stuff).ToString();
            textBoxNet.Text = Convert.ToSingle(model.Net).ToString();
            textBoxSaleMan.Text = model.SaleMan;
            textBoxRemarks.Text = model.Remarks;
            textBoxEnterTime.Text = model.EnterTime.ToString();
            textBoxExitTime.Text = model.ExitTime.ToString();
            textBoxEnterWeighMan.Text = model.EnterWeightMan;
            textBoxExitWeignMan.Text = model.ExitWeightMan;
            textBoxEnterDBNum.Text = model.EnterDBNum;
            checkBoxIsEmptyOut.Checked = model.IsEmptyOut == "1" ? true : false;
            checkBoxExitFlag.Checked = model.ExitFlag == 1 ? true : false;
            textBoxLgort.Text = model.Lgort;
            textBoxPasser.Text = model.Passer;
            this.ShowDialog(parent);
        }

        public void SetReadOnlyTrue()
        {
            textTruckNum.ReadOnly = true;
            textBoxBuyer.ReadOnly = true;
            textBoxPasser.ReadOnly = true;
            textBoxGross.ReadOnly = true;
            textBoxTare.ReadOnly = true;
            textBoxStuff.ReadOnly = true;
            textBoxSaleMan.ReadOnly = true;
            textBoxLgort.ReadOnly = true;
            textBoxRemarks.ReadOnly = true;

            checkBoxIsEmptyOut.Enabled = false;
            comboBoxFlotName.Enabled = false;
            checkBoxExitFlag.Enabled = false;
            
            toolStripButtonSave.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripButtonEdit.Visible = true;
            toolStripSeparator4.Visible = true;
            toolStripButtonCancel.Visible = false;
            toolStripSeparator5.Visible = false;
            EDIT = false;
        }

        public void SetReadOnlyFalse()
        {
            textTruckNum.ReadOnly = false;
            textBoxBuyer.ReadOnly = false;
            textBoxPasser.ReadOnly = false;
            textBoxGross.ReadOnly = false;
            textBoxTare.ReadOnly = false;
            textBoxStuff.ReadOnly = false;
            textBoxSaleMan.ReadOnly = false;
            textBoxLgort.ReadOnly = false;
            textBoxRemarks.ReadOnly = false;

            checkBoxIsEmptyOut.Enabled = true;
            comboBoxFlotName.Enabled = true;
            checkBoxExitFlag.Enabled = true;

            toolStripButtonSave.Visible = true;
            toolStripSeparator2.Visible = true;
            toolStripButtonEdit.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripButtonCancel.Visible = true;
            toolStripSeparator5.Visible = true;
            EDIT = true;
        }

        //退出
        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        
        //保存数据
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                sdl_FloatsamEnter sfe = new sdl_FloatsamEnter();
                sfe.FloatsamID = textBoxFlotsamID.Text.ToString();
                sfe.TruckNum = textTruckNum.Text.ToString().Trim();
                sfe.Werks = textBoxWerks.Text.ToString();
                sfe.Buyer = textBoxBuyer.Text.ToString().Trim();
                sfe.FloatsamName = textBoxCode.Text.ToString().Trim();
                sfe.Passer = textBoxPasser.Text.ToString().Trim();
                sfe.Gross = Convert.ToSingle(textBoxGross.Text.ToString().Trim());
                sfe.Net = Convert.ToSingle(textBoxNet.Text.ToString().Trim());
                sfe.Tare = Convert.ToSingle(textBoxTare.Text.ToString().Trim());
                sfe.Stuff = Convert.ToSingle(textBoxStuff.Text.ToString().Trim());
                sfe.SaleMan = textBoxSaleMan.Text.ToString();
                sfe.EnterDBNum = textBoxEnterDBNum.Text.ToString();
                sfe.Lgort = textBoxLgort.Text.ToString();
                sfe.Remarks = textBoxRemarks.Text.ToString().Trim();
                sfe.EnterTime = Convert.ToDateTime(textBoxEnterTime.Text.ToString());
                sfe.ExitTime = Convert.ToDateTime(textBoxExitTime.Text.ToString());
                sfe.EnterWeightMan = textBoxEnterWeighMan.Text.ToString();
                sfe.ExitWeightMan = textBoxExitWeignMan.Text.ToString();

                if (checkBoxIsEmptyOut.Checked == true)
                {
                    sfe.IsEmptyOut = "1";
                }
                else
                {
                    sfe.IsEmptyOut = "0";
                }
                if (checkBoxExitFlag.Checked == true)
                {
                    sfe.ExitFlag = 1;
                }
                else
                {
                    sfe.ExitFlag = 0;
                }
                try
                {
                    sdl_FloatsamEnterAdapter.Updatesdl_FloatsamEnter(sfe);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show(this, "保存异常","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //激活修改
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            SetReadOnlyFalse();
            
        }

        //撤销修改
        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            SetReadOnlyTrue();
            
        }

        private void comboBoxFlotName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFlotName.SelectedIndex != -1 && EDIT == true)
            {
                this.textBoxCode.Text = this.comboBoxFlotName.SelectedValue.ToString();
            }
            
        }

        //计算净重
        private void countNet()
        {
            try
            {
                if (EDIT == true)
                {
                    textBoxNet.Text = Math.Round(
                        double.Parse(textBoxGross.Text.ToString()) - double.Parse(textBoxTare.Text.ToString()) - double.Parse(textBoxStuff.Text.ToString()), 3
                        ).ToString();
                }
                
            }
            catch (Exception)
            {
                
            }
        }
        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            countNet();
        }

        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            countNet();
        }

        private void textBoxStuff_TextChanged(object sender, EventArgs e)
        {
            countNet();
        }
    }
}
