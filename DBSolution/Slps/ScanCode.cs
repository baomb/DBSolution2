using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBSolution
{
    public partial class ScanCode : Form
    {
        private string[] codeArray;
        private int scanIndex = 0;
        public ScanCode()
        {
            InitializeComponent();
            textQrCode.Focus();
            buttonReScan.Visible = false;
            buttonNext.Visible = false;
        }
        
        //用户通过扫码枪扫描完成或使用键盘输入完成点击回车时触发
        private void textQrCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(textQrCode.Text))
                {
                    MessageBox.Show(this, "输入的二维码编号不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else
                {
                    //二维码不为空调用WebService查询入场信息
                    codeArray[scanIndex] = textQrCode.Text.ToString();
                    buttonReScan.Visible = true;
                    buttonNext.Visible = true;
                    scanIndex++;
                    textQrCode.Text = string.Empty;
                }

                //重置二维码文本内容
                textQrCode.Clear();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            //检查选中项数量是否大于0
            if (listViewCars.Items.Count > 0)
            {
                //有选中项时查询选中项参数
                string sapOrder = listViewCars.Items[0].SubItems[1].Text;
                string carNo = listViewCars.Items[0].SubItems[2].Text;
                string orderType = listViewCars.Items[0].SubItems[3].Text;
                              
                //调用过磅界面
                if (orderType == "ZOR")
                {
                    SlpsFinishedProductsSaleEnter finishedEnter = new SlpsFinishedProductsSaleEnter();
                    finishedEnter.BindEnterData(codeArray);
                }
            }
            else
            {
                //无选中项时提示请选择
                MessageBox.Show(this, "请选择一项后再点击下一步！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
