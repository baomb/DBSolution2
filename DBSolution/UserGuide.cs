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
    public partial class UserGuide : Form
    {
        public static Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();

        public UserGuide()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            string where = "where 1 = 1";
            DataTable dt = Sdl_ManualAdapter.GetSdl_ManualDataSet(where).Tables[0];
            comboBoxSelect.DataSource = dt;
            comboBoxSelect.ValueMember = "TYPE";
            comboBoxSelect.SelectedIndex = -1;
            textBoxEdit.Text = string.Empty;
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type = comboBoxSelect.Text;
                if (type != string.Empty)
                {
                    Sdl_Manual m = Sdl_ManualAdapter.GetSdl_Manual(type);
                    textBoxEdit.Text = m.MANUAL;
                }
            }
            catch
            {
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSelect.Text == string.Empty)
                return;
            try
            {
                Sdl_Manual m = new Sdl_Manual();
                m.TYPE = comboBoxSelect.Text;
                m.MANUAL = textBoxEdit.Text;
                Sdl_ManualAdapter.AddSdl_Manual(m);
                BindData();
                MessageBox.Show(this, "添加成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Sdl_Manual m = new Sdl_Manual();
                m.TYPE = comboBoxSelect.Text;
                m.MANUAL = textBoxEdit.Text;
                Sdl_ManualAdapter.UpdateSdl_Manual(m);
                BindData();
                MessageBox.Show(this, "修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxSelect.Text == string.Empty)
                return;
            try
            {
                Sdl_ManualAdapter.DeleteSdl_Manual(comboBoxSelect.Text);
                BindData();
                MessageBox.Show(this, "删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
