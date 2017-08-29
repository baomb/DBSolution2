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
    public partial class Settings : Form
    {
        public static Sdl_SysSetting settings;

        public Settings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSettings()
        {
            settings = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            bool Tray = Sdl_SysSettingAdapter.GetSdl_Tray(settings.WERKS);
            bool existsTray = Sdl_SysSettingAdapter.ExistsSdl_Tray(settings.WERKS);
            DataTable dt = Sdl_SysSettingAdapter.GetSdl_SysSettingDataTable();
            this.comboBoxWerks.DataSource = dt;
            this.comboBoxWerks.ValueMember = "db";
            this.comboBoxWerks.DisplayMember = "id";
            this.comboBoxWerks.Text = settings.ID;
            this.textBoxSerial.Text = settings.Com;
            this.textBoxWerks.Text = settings.WERKS;
            this.checkBoxTray.Checked = Tray;
            if (existsTray == false)
            {
                Sdl_SysSettingAdapter.AddSdl_Tray(settings.WERKS, "0");
            }
        }

        private void SaveSettings()
        {
            string model = this.comboBoxWerks.SelectedValue.ToString();
            settings = Sdl_SysSettingAdapter.GetSdl_SysSetting(model);
            settings.Com = this.textBoxSerial.Text;
            settings.DB = model;
            settings.WERKS = this.textBoxWerks.Text;
            if (this.checkBoxTray.Checked == true)
            {
                Sdl_SysSettingAdapter.SaveSdl_Tray(this.textBoxWerks.Text,"1");
            }
            else
            {
                Sdl_SysSettingAdapter.SaveSdl_Tray(this.textBoxWerks.Text, "0");
            }
            
            if (Sdl_SysSettingAdapter.SaveSdl_SysSetting(settings))
            {
                MessageBox.Show(this, "保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxWerks_TextChanged(object sender, EventArgs e)
        {
            settings = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            bool Tray = Sdl_SysSettingAdapter.GetSdl_Tray(textBoxWerks.Text);
            this.checkBoxTray.Checked = Tray;
        }
    }
}
