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
    public partial class DBReadPortSetting : Form
    {
        public DBReadPortSetting()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            Sdl_SysSetting settings = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            if (settings != null)
            {
                if (settings.PORTFLAG == "1")
                    chkReadFlag.Checked = true;
                else
                    chkReadFlag.Checked = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Sdl_SysSetting settings = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            string flag = string.Empty;
            if (chkReadFlag.Checked)
                flag = "1";
            else
                flag = "0";
            settings.PORTFLAG = flag;
            Sdl_SysSettingAdapter.SaveSdl_SysSetting(settings);
            MessageBox.Show("修改成功！");
        }
    }
}
