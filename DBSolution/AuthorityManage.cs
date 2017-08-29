using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;

namespace DBSolution
{
    public partial class AuthorityManage : Form
    {
        public AuthorityManage()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            string sql = "SELECT a.UserName as 用户名, c.RoleName as 角色 FROM aspnet_Users AS a LEFT JOIN aspnet_UsersInRoles AS b ON a.UserId = b.UserId LEFT JOIN aspnet_Roles AS c ON b.RoleId = c.RoleId";
            DataSet ds = SdlDB.Data.SQLServerHelper.Query(sql);
            dataGridViewMember.DataSource = ds.Tables[0];
            dataGridViewMember.Rows[0].Selected = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string username = dataGridViewMember.SelectedRows[0].Cells[0].Value.ToString();
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked)
                    {
                        try
                        {
                            Roles.AddUserToRole(username, c.Text);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        try
                        {
                            Roles.RemoveUserFromRole(username, c.Text);
                        }
                        catch
                        { }
                    }
                }
            }
            BindData();
        }

        private void dataGridViewMember_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMember.SelectedRows.Count == 0)
            {
                return;
            }
            string username = dataGridViewMember.SelectedRows[0].Cells[0].Value.ToString();
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    if (Roles.IsUserInRole(username, c.Text))
                    {
                        ((CheckBox)c).Checked = true;
                    }
                    else
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }
    }
}
