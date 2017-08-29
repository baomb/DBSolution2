using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Security;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Utility;
using SdlDB.Entity;

namespace DBSolution
{
    public partial class Login : Form
    {
        Sdl_SysSetting sys = Sdl_SysSettingAdapter.LoadSdl_SysSetting();

        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.buttonLogin.Enabled = false;
            if (ValidateUser())
            {
                StartForm();
                this.Hide();
            }
            else
            {
                this.buttonLogin.Enabled = true;
            }
        }

        private bool ValidateUser()
        {
            if (this.textBoxUserName.Text == "" || this.textBoxPassword.Text == "")
            {
                MessageBox.Show(this, "请输入用户名和密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    string password = TypeConverter.ToMD5(textBoxPassword.Text);
                    if (Sdl_UsersAdapter.ValidateSdl_Users(textBoxUserName.Text.ToLower(), password))
                    {
                        if (sys != null)
                        {
                            string WERKS = sys.WERKS;
                            Sdl_Users user = Sdl_UsersAdapter.GetSdl_Users(textBoxUserName.Text);
                            if (user.USERNAME.ToLower() == "admin")
                            {
                                if (user.ISLOCKED == true)
                                {
                                    MessageBox.Show(this, "该用户已被锁定", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                else
                                    return true;
                            }
                            else
                            {
                                if (WERKS != user.WERKS)
                                {
                                    MessageBox.Show(this, "该用户不在" + WERKS + "工厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                else
                                {
                                    if (user.ISLOCKED == true)
                                    {
                                        MessageBox.Show(this, "该用户已被锁定", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                    else
                                        return true;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "配置文件读取失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "用户名或密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(this, "连接服务器失败"+e.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void StartForm()
        {
            MainForm form1 = new MainForm();
            IIdentity gi = new GenericIdentity(this.textBoxUserName.Text);
            string[] roles = new string[1];
            Sdl_Users user = Sdl_UsersAdapter.GetSdl_Users(this.textBoxUserName.Text);
            roles[0] = user.ROLE;
            IPrincipal gp = new GenericPrincipal(gi, roles);
            System.Threading.Thread.CurrentPrincipal = gp;
            form1.Show();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
