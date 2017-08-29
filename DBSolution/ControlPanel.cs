using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Utility;
using SdlDB.Entity;

namespace DBSolution
{
    public partial class ControlPanel : Form
    {
        string userName = string.Empty;

        public ControlPanel()
        {
            InitializeComponent();
            userName = System.Threading.Thread.CurrentPrincipal.Identity.Name.ToString();
            Sdl_Users user = Sdl_UsersAdapter.GetSdl_Users(userName);
            Sdl_Roles role = Sdl_RolesAdapter.GetSdl_Roles(user.ROLE);
            textBoxRole.Text = role.ROLENAME;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNew.Text != textBoxConfirm.Text)
                {
                    MessageBox.Show(this, "新密码和确认密码必须相同", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBoxNew.Text.Length < 6)
                {
                    MessageBox.Show(this, "用户密码最少6位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string password = TypeConverter.ToMD5(textBoxOld.Text);
                if (!Sdl_UsersAdapter.ValidateSdl_Users(userName, password))
                {
                    MessageBox.Show(this, "旧密码输入错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                password = TypeConverter.ToMD5(textBoxNew.Text);
                Sdl_UsersAdapter.ChangePasswordSdl_Users(userName, password);
                MessageBox.Show(this, "修改密码成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "修改密码失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
