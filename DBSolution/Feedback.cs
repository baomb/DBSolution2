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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == string.Empty)
            {
                MessageBox.Show(this, "请填写标题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBoxContent.Text == string.Empty)
            {
                MessageBox.Show(this, "请填写内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Sdl_Feedback feedback = new Sdl_Feedback();
            feedback.TITLE = textBoxTitle.Text;
            feedback.COMMENT = textBoxContent.Text;
            feedback.DATETIME = DateTime.Parse(Common.GetServerDate());
            feedback.USERNAME = System.Threading.Thread.CurrentPrincipal.Identity.Name.ToString();
            Sdl_FeedbackAdapter.AddSdl_Feedback(feedback);
            MessageBox.Show(this, "感谢您的反馈！", "谢谢", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
