using System;
using System.Windows.Forms;
using SdlDB.Utility;
using SdlDB.Data;
using SdlDB.Entity;
using System.Threading;

namespace DBSolution
{
    public partial class FlotsamExit : Form
    {
        private string[] father = new string[] { "", "" };
        SerialPortHelper s = null;
        private bool readPort = true;
        public FlotsamExit()
        {
            InitializeComponent();
            InitForm();
            if (!readPort)
            {
                MessageBox.Show(this, DBSolution2.Properties.Resources.PortFlag, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //初始化表单
        private void InitForm()
        {
            //以下代码可使该窗口加载时最大化，因不好看，暂时去掉
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
            readPort = Common.GetReadPortFlag();
            if (readPort)
            {
                textBoxGross.ReadOnly = true;
            }
            else
            {
                textBoxGross.ReadOnly = false;
            }

            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxExitTime.Text = Common.GetServerDate();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxPrompt.Text = Common.GetHelpStr("废旧物资出厂");
            this.textBoxPrompt.Visible = false;
            this.timer.Start();
            this.toolStripButtonPrint.Enabled = false;
        }

        //双击车牌号时
        private void textBoxCar_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "FlotsamExit");
            ts.ShowDialog();
            this.textBoxCar.Text = father[0].ToString();
            Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
            BindEnterData();
        }

        //车牌号回车时
        private void textBoxCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string truckNum = textBoxCar.Text;
                Common.ShowTruckWeight(this.textBoxCar.Text, dataGridViewHistory);
                BindEnterData();
            }
        }

        //绑定录入数据
        private void BindEnterData()
        {
            sdl_FloatsamEnter title = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(textBoxCar.Text, father[1].ToString());
            if (title != null)
            {
                if (!CheckDB(title))
                {
                    return;
                }
                this.textBoxDBNum.Text = title.EnterDBNum;
                this.textBoxTare.Text = Convert.ToSingle(title.Tare).ToString();
                this.textBoxBuyer.Text = title.Buyer.ToString();
                this.textBoxCode.Text = title.FloatsamName;
                this.textBoxFlotsamName.Text = Sdl_FloatsamNameItemAdapter.Getsdl_FloatsamNameItem(title.FloatsamName).Name;
                this.textBoxNum.Text = title.FloatsamID;
            }
        }

        //检查出入厂地磅是否相同
        private bool CheckDB(sdl_FloatsamEnter title)
        {
            string enterDB = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
            string exitDB = title.EnterDBNum;
            if (enterDB != exitDB)
            {
                DialogResult dr = MessageBox.Show(this, "入厂地磅与出厂地磅不同，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        //检测窗体数据
        private bool ValidateControl()
        {
            if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
            {
                MessageBox.Show(this, "净重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
            {
                MessageBox.Show(this, "毛重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
            {
                MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(textBoxFHY.Text))
            {
                MessageBox.Show(this, "发货员不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(textBoxLgort.Text))
            {
                MessageBox.Show(this, "库存地不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(textBoxPasser.Text))
            {
                MessageBox.Show(this, "经办人不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //保存按钮
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-废旧物资出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterExitFlag(textBoxCar.Text.ToUpper()) != 0)
                {
                    MessageBox.Show(this, "该车尚未进厂，不能出厂！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //检测窗体数据
                if (!ValidateControl())
                    return;
                //进厂重量需小于出厂重量
                decimal diff = Convert.ToDecimal(textBoxGross.Text) - Convert.ToDecimal(textBoxTare.Text);
                if (diff < 0)
                {
                    if (MessageBox.Show(this, "进厂重量比出厂重量重" + (-diff).ToString() + "吨，点击是继续，点击否返回", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                try
                {
                    sdl_FloatsamEnter fs = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(textBoxCar.Text, father[1].ToString());
                    fs.FloatsamID = this.textBoxNum.Text;
                    fs.TruckNum = this.textBoxCar.Text.Trim();
                    fs.Werks = this.textBoxFactory.Text;
                    fs.Buyer = this.textBoxBuyer.Text;
                    //fs.FloatsamName = this.textBoxFlotsamName.Text;
                    //fs.Unit=
                    fs.Tare = Convert.ToSingle(this.textBoxTare.Text);
                    fs.Gross = Convert.ToSingle(this.textBoxGross.Text);
                    fs.Stuff = Convert.ToSingle(this.textBoxStaff.Text);
                    fs.Net = Convert.ToSingle(this.textBoxNet.Text);
                    fs.SaleMan = this.textBoxFHY.Text.Trim();
                    fs.EnterDBNum = this.textBoxDBNum.Text;
                    fs.ExitWeightMan = this.textBoxWeighMan.Text;
                    fs.ExitTime = Convert.ToDateTime(this.textBoxExitTime.Text);
                    fs.Remarks = this.textBoxRemarks.Text.Trim();
                    fs.Lgort = this.textBoxLgort.Text.Trim();
                    fs.Passer = this.textBoxPasser.Text.Trim();
                    fs.ExitFlag = 1;
                    fs.IsEmptyOut = "0";
                    sdl_FloatsamEnterAdapter.Updatesdl_FloatsamEnter(fs);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.toolStripButton.Enabled = false;
                    this.toolStripButtonSave.Enabled = false;
                    this.toolStripButtonCancel.Enabled = false;
                    this.toolStripButtonPrint.Enabled = true;
                    //this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        //退出
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-废旧物资出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //空车出厂
        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认空车出厂操作吗?", "史丹利地磅系统-废旧物资出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterExitFlag(textBoxCar.Text.ToUpper()) != 0)
                {
                    MessageBox.Show(this, "该车尚未进厂，不能出厂！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxPasser.Text))
                {
                    MessageBox.Show(this, "经办人不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsNumberSign(textBoxNet.Text) || ValidateHelper.IsDecimalSign(textBoxNet.Text)))
                {
                    MessageBox.Show(this, "净重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxGross.Text) || ValidateHelper.IsNumber(textBoxGross.Text)))
                {
                    MessageBox.Show(this, "毛重数据不能为空或者字符，应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxStaff.Text) || ValidateHelper.IsNumber(textBoxStaff.Text)))
                {
                    MessageBox.Show(this, "扣杂重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double netValue = double.Parse(textBoxNet.Text);
                if (Math.Round(Math.Abs(netValue), 3) > 0)
                {
                    if (MessageBox.Show("空车出厂时，毛重与皮重数值应该相等，确认放行吗？", "史丹利地磅系统-废料出厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }
                sdl_FloatsamEnter modelEnter = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(textBoxCar.Text, father[1].ToString());
                if (modelEnter == null)
                {
                    MessageBox.Show(this, "该车没有入厂信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (modelEnter.ExitFlag == 1)
                {
                    MessageBox.Show(this, "该车已经出厂，不能再次出厂，请核实！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    modelEnter.FloatsamID = this.textBoxNum.Text;
                    modelEnter.TruckNum = this.textBoxCar.Text.Trim();
                    modelEnter.Werks = this.textBoxFactory.Text;
                    modelEnter.Buyer = this.textBoxBuyer.Text;
                    //modelEnter.FloatsamName = this.textBoxFlotsamName.Text;
                    //fs.Unit=
                    modelEnter.Tare = Convert.ToSingle(this.textBoxTare.Text);
                    modelEnter.Gross = Convert.ToSingle(this.textBoxGross.Text);
                    modelEnter.Stuff = Convert.ToSingle(this.textBoxStaff.Text);
                    modelEnter.Net = Convert.ToSingle(this.textBoxNet.Text);
                    modelEnter.SaleMan = this.textBoxFHY.Text.Trim();
                    modelEnter.EnterDBNum = this.textBoxDBNum.Text;
                    modelEnter.ExitWeightMan = this.textBoxWeighMan.Text;
                    modelEnter.ExitTime = Convert.ToDateTime(this.textBoxExitTime.Text);
                    modelEnter.Remarks = this.textBoxRemarks.Text.Trim();
                    modelEnter.ExitFlag = 1;
                    modelEnter.IsEmptyOut = "1";
                    modelEnter.Passer = this.textBoxPasser.Text.Trim();
                    sdl_FloatsamEnterAdapter.Updatesdl_FloatsamEnter(modelEnter);
                    MessageBox.Show(this, "空车出厂成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "空车出厂失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        //timer_Tick
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!readPort)
            {
                return;
            }
            DBStatus status = DBStatus.Normal;
            double showNum = s.ShowWeight(ref status);
            this.textBoxGross.Text = showNum.ToString();
            if (status == DBStatus.Normal)
            {
                textBoxWeight.Text = showNum.ToString();
            }
            else
            {
                textBoxWeight.Text = Common.GetEnumDescription(status);
            }
        }

        //锁定或解锁地磅读数
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            if (toolStripButton.Text == "锁定")
            {
                timer.Stop();
                toolStripButton.Text = "解锁";
                toolStripButton.Image = DBSolution2.Properties.Resources.Unlock;
            }
            else
            {
                timer.Start();
                toolStripButton.Text = "锁定";
                toolStripButton.Image = DBSolution2.Properties.Resources.Lock;
            }
        }
        //车牌变化时
        private void textBoxCar_TextChanged(object sender, EventArgs e)
        {
            textBoxCar.Text = textBoxCar.Text.ToUpper();
            textBoxCar.SelectionStart = textBoxCar.Text.Length;
        }

        private void dataGridViewHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //毛重变化
        private void textBoxGross_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - double.Parse(textBoxStaff.Text), 2).ToString();
            }
            catch
            {
            }
        }

        //皮重变化
        private void textBoxTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text) - double.Parse(textBoxStaff.Text), 2).ToString();
            }
            catch
            {
            }
        }

        //扣杂重变化
        private void textBoxStaff_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNet.Text = Math.Round(double.Parse(textBoxGross.Text) - double.Parse(textBoxTare.Text)-double.Parse(textBoxStaff.Text), 2).ToString();
            }
            catch
            {
            }
        }
        //打印
        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FlotsamDetailPrint proDetail = new FlotsamDetailPrint();
            proDetail.StartPosition = FormStartPosition.CenterParent;
            proDetail.ShowDialog(this.textBoxCar.Text.Trim(), this, father[1].ToString());
            this.Cursor = Cursors.Default;
        }
    }
}
