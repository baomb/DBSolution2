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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗口提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        public Loading(string message)
        {
            InitializeComponent();
            if (message != string.Empty)
                this.labelMessage.Text = message;
        }
    }
}
