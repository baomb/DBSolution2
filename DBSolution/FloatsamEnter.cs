using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Utility;
using SdlDB.Entity;
using SdlDB.Data;
using System.Threading;
using System.Collections.Specialized;
using System.Collections;

namespace DBSolution
{
    public partial class FloatsamEnter : Form
    {
        private string[] father = new string[] { "", "","","","","" };
        SerialPortHelper s = null;
        private bool readPort = true;
        public FloatsamEnter()
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
                textBoxTare.ReadOnly = true;
            }
            else
            {
                textBoxTare.ReadOnly = false;
            }
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            s = new SerialPortHelper(ref serialPort);
            this.textBoxFactory.Text = sysSetting.WERKS;
            this.textBoxWeighMan.Text = Thread.CurrentPrincipal.Identity.Name.ToString();
            this.textBoxEnterTime.Text = Common.GetServerDate();
            this.textBoxPrompt.Text = Common.GetHelpStr("废旧物资入厂");
            this.textBoxPrompt.Visible = false;
            BindComboBoxData();
            this.timer.Start();
        }
        //绑定下拉框
        private void BindComboBoxData()
        {
            comboBoxFlotName.DataSource = Sdl_FloatsamNameItemAdapter.GetSdl_FloatsamNameItemDataSet("order by Name").Tables[0];
            comboBoxFlotName.ValueMember = "Code";
            comboBoxFlotName.DisplayMember = "Name";
            comboBoxFlotName.SelectedIndex = -1;
        }

        //退出按钮
        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出该界面吗?", "史丹利地磅系统-废旧物资入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //保存按钮
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要保存吗?", "史丹利地磅系统-废旧物资入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolStripButton.Text != "解锁")
                {
                    MessageBox.Show(this, "请先锁定地磅读数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxTruckNum.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxBuyer.Text))
                {
                    MessageBox.Show(this, "输入的购买商不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboBoxFlotName.SelectedIndex<0)
                {
                    MessageBox.Show(this, "请选择货物名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!(ValidateHelper.IsDecimal(textBoxTare.Text) || ValidateHelper.IsNumber(textBoxTare.Text)))
                {
                    MessageBox.Show(this, "皮重数据应为数值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterExitFlag(textBoxTruckNum.Text.ToUpper()) == 0)
                {
                    MessageBox.Show(this, "该车已经进厂尚未出厂,不能再次进厂！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    int maxnum = sdl_FloatsamEnterAdapter.GetMaxSortNum(DateTime.Now.ToString("yyyyMM"));
                    sdl_FloatsamEnter fs = new sdl_FloatsamEnter();
                    fs.FloatsamID = textBoxFactory.Text.Trim() + DateTime.Now.ToString("yyyyMM") + Common.GetNextNum(maxnum);
                    fs.TruckNum = textBoxTruckNum.Text.ToUpper();
                    fs.Werks = textBoxFactory.Text.Trim();
                    fs.Buyer = textBoxBuyer.Text.Trim();
                    fs.FloatsamName =comboBoxFlotName.SelectedValue.ToString();
                    //fs.Unit = comboBoxUnit.SelectedText;
                    fs.Tare = Convert.ToSingle(textBoxTare.Text);
                    fs.EnterWeightMan = textBoxWeighMan.Text.Trim();
                    fs.EnterTime = DateTime.Parse(textBoxEnterTime.Text);
                    fs.ExitFlag = 0;
                    fs.EnterDBNum = Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID;
                    fs.SortNum = maxnum + 1;
                    fs.TimeFlag = DateTime.Now.ToString("yyyyMM");
                    sdl_FloatsamEnterAdapter.Addsdl_FloatsamEnter(fs);
                    Sdl_TruckWeight tw = new Sdl_TruckWeight();
                    tw.ENTERTIME = fs.EnterTime;
                    tw.TARE = Convert.ToSingle(textBoxTare.Text);
                    tw.TIMEFLAG = textBoxEnterTime.Text;
                    tw.TRUCKNUM = fs.TruckNum;
                    tw.WERKS = fs.Werks;
                    Sdl_TruckWeightAdapter.AddSdl_TruckWeight(tw);
                    MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        //timer_Trick
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!readPort)
            {
                return;
            }
            DBStatus status = DBStatus.Normal;
            double showNum = s.ShowWeight(ref status);
            this.textBoxTare.Text = showNum.ToString();
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

        //输入车号回车以后显示车皮历史
        private void textBoxTruckNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Common.ShowTruckWeight(this.textBoxTruckNum.Text, dataGridViewHistory);
            }
        }
        
        //双击车牌textBox
        private void textBoxTruckNum_DoubleClick(object sender, EventArgs e)
        {
            string temp = string.Empty;
            TruckSelect ts = new TruckSelect(father, "FlotsamExit");
            DialogResult dr = ts.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                timer.Stop();
                this.textBoxTruckNum.Text = father[0].ToString();
                this.comboBoxFlotName.SelectedValue= father[3].ToString();
                this.textBoxBuyer.Text = father[4].ToString();
                textBoxTare.Text = father[5].ToString();
                if (textBoxTruckNum.Text.Trim() != "")
                {
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonEdit.Enabled = true;
                    textBoxTare.ReadOnly = true;
                    Common.ShowTruckWeight(this.textBoxTruckNum.Text, dataGridViewHistory);
                }
            }
        }

        //修改
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改吗?", "史丹利地磅系统-废旧物资入厂", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (father[0].ToString() == "")
                {
                    MessageBox.Show(this, "请选择要编辑的入厂信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxTruckNum.Text))
                {
                    MessageBox.Show(this, "输入的车牌号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxBuyer.Text))
                {
                    MessageBox.Show(this, "输入的购买商不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboBoxFlotName.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "请选择货物名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    sdl_FloatsamEnter fs = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnter(father[0].ToString(), father[1].ToString());
                    fs.FloatsamID = fs.FloatsamID;
                    fs.TruckNum = this.textBoxTruckNum.Text.Trim();
                    fs.Werks = this.textBoxFactory.Text;
                    fs.Buyer = this.textBoxBuyer.Text;
                    fs.FloatsamName = this.comboBoxFlotName.SelectedValue.ToString();
                    //fs.Unit=
                    fs.Tare = Convert.ToSingle(this.textBoxTare.Text);
                    sdl_FloatsamEnterAdapter.Updatesdl_FloatsamEnter(fs);
                    MessageBox.Show(this, "修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //车牌变化时
        private void textBoxTruckNum_TextChanged(object sender, EventArgs e)
        {
            textBoxTruckNum.Text = textBoxTruckNum.Text.ToUpper();
            textBoxTruckNum.SelectionStart = textBoxTruckNum.Text.Length;
        }

        private void dataGridViewHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
