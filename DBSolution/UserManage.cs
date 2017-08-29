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
    public partial class UserManage : Form
    {
        DataTable dtRole;
        string sort = string.Empty;

        public UserManage()
        {
            InitializeComponent();
            dtRole = Sdl_RolesAdapter.GetSdl_RolesDataSet(sort).Tables[0];
        }

        private void BindComboBoxData()
        {
            comboBoxRole.DataSource = dtRole;
            comboBoxRole.ValueMember = "ROLEID";
            comboBoxRole.DisplayMember = "ROLENAME";
        }

        private void BindGridViewData()
        {
            sort = "order by username";
            DataTable dt = Sdl_UsersAdapter.GetSdl_UsersDataSet(sort).Tables[0];
            dt.Columns.Add("ROLEREAD");
            DataGridViewComboBoxColumn cbcpw = (DataGridViewComboBoxColumn)dataGridViewUser.Columns["ROLENAME"];
            cbcpw.DataPropertyName = "rolename";
            cbcpw.DataSource = dtRole;
            cbcpw.ValueMember = "ROLEID";
            cbcpw.DisplayMember = "ROLENAME";
            cbcpw.Name = "ROLENAME";
            cbcpw.HeaderText = "角色";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string roleid = dt.Rows[i]["ROLE"].ToString();
                string rolename = string.Empty;
                for (int j = 0; j < dtRole.Rows.Count; j++)
                {
                    if (roleid == dtRole.Rows[j]["ROLEID"].ToString())
                    {
                        rolename = dtRole.Rows[j]["ROLENAME"].ToString();
                        break;
                    }
                }
                dt.Rows[i]["ROLEREAD"] = rolename;
            }
            this.dataGridViewUser.AutoGenerateColumns = false;
            this.dataGridViewUser.DataSource = dt;
            for (int i = 0; i < dataGridViewUser.Rows.Count; i++)
            {
                DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dataGridViewUser.Rows[i].Cells["ROLENAME"];
                cbc.Style.NullValue = dataGridViewUser.Rows[i].Cells["ROLEREAD"].Value;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPassword.Text.Length < 6)
                {
                    MessageBox.Show(this, "用户密码最少6位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboBoxRole.ValueMember == null)
                {
                    MessageBox.Show(this, "请选择用户角色", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (IsExist(textBoxUserName.Text.ToLower()))
                {
                    MessageBox.Show(this, "该用户名已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxWERKS.Text == string.Empty && comboBoxRole.SelectedValue.ToString() == "406603ba-26b1-44dd-92f2-2cfbe449b9e7")
                {
                    MessageBox.Show(this, "地磅人员必须指定工厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (AddUser())
                    MessageBox.Show(this, "添加用户成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, "添加用户失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BindGridViewData();
            }
            catch
            {
                BindGridViewData();
                MessageBox.Show(this, "添加用户失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsExist(string username)
        {
            try
            {
                if (Sdl_UsersAdapter.ExistsSdl_User(username))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private bool AddUser()
        {
            try
            {
                Sdl_Users user = new Sdl_Users();
                user.ID = Guid.NewGuid().ToString();
                user.ISLOCKED = checkBoxIsLocked.Checked;
                user.PASSWORD = TypeConverter.ToMD5(textBoxPassword.Text);
                user.ROLE = comboBoxRole.SelectedValue.ToString();
                user.USERDESC = textBoxUserInfo.Text;
                user.USERNAME = textBoxUserName.Text.ToLower();
                user.WERKS = textBoxWERKS.Text;
                user.QUERY = textBoxQuery.Text;
                return Sdl_UsersAdapter.AddSdl_Users(user);
            }
            catch
            {
                return false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请选择一个用户", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string username = dataGridViewUser.SelectedRows[0].Cells["USERNAME"].Value.ToString();
            if (textBoxReset.Text.Length < 6)
            {
                MessageBox.Show(this, "用户密码最少6位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password = TypeConverter.ToMD5(textBoxReset.Text);
            Sdl_UsersAdapter.ChangePasswordSdl_Users(username, password);
            MessageBox.Show(this, "修改用户密码成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            if (column == 0)
            {
                dataGridViewUser.Columns["UPDATE"].Visible = true;
                dataGridViewUser.Columns["CANCEL"].Visible = true;
                dataGridViewUser.Columns["EDIT"].Visible = false;
                dataGridViewUser.ReadOnly = false;
            }
            else if (column == 1)
            {
                dataGridViewUser.CurrentCell = dataGridViewUser.Rows[0].Cells[3];
                if (Convert.ToBoolean(dataGridViewUser.Rows[row].Cells["ISLOCKED"].Value) && dataGridViewUser.Rows[row].Cells["USERNAME"].Value.ToString().ToLower() == "admin")
                {
                    MessageBox.Show(this, "管理员不能锁定", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (UpdateUser(row))
                {
                    MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewUser.Columns["UPDATE"].Visible = false;
                    dataGridViewUser.Columns["CANCEL"].Visible = false;
                    dataGridViewUser.Columns["EDIT"].Visible = true;
                    dataGridViewUser.ReadOnly = true;
                    BindGridViewData();
                }
            }
            else if (column == 2)
            {
                dataGridViewUser.Columns["UPDATE"].Visible = false;
                dataGridViewUser.Columns["CANCEL"].Visible = false;
                dataGridViewUser.Columns["EDIT"].Visible = true;
                dataGridViewUser.ReadOnly = true;
                BindGridViewData();
            }
            else if (column == 12)
            {
                DialogResult dr = MessageBox.Show(this, "是否删除该用户？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DeleteUser(row);
                }
            }
        }

        private void DeleteUser(int row)
        {
            try
            {
                string userid = dataGridViewUser.Rows[row].Cells["USERID"].Value.ToString();
                Sdl_UsersAdapter.DeleteSdl_Users(userid);
                MessageBox.Show(this, "删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridViewData();
            }
            catch
            {
                MessageBox.Show(this, "操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdateUser(int row)
        {
            try
            {
                Sdl_Users user = new Sdl_Users();
                user.ID = dataGridViewUser.Rows[row].Cells["USERID"].Value.ToString();
                user.USERNAME = dataGridViewUser.Rows[row].Cells["USERNAME"].Value.ToString().ToLower();
                if (IsExist(user.USERNAME) && user.ID != Sdl_UsersAdapter.GetSdl_Users(user.USERNAME).ID)
                {
                    MessageBox.Show(this, "该用户名已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                user.ISLOCKED = Convert.ToBoolean(dataGridViewUser.Rows[row].Cells["ISLOCKED"].Value);
                string role = string.Empty;
                if (dataGridViewUser.Rows[row].Cells["ROLENAME"].Value == null)
                {
                    role = dataGridViewUser.Rows[row].Cells["ROLEID"].Value.ToString();
                }
                else
                {
                    role = dataGridViewUser.Rows[row].Cells["ROLENAME"].Value.ToString();
                }
                user.ROLE = role;
                user.USERDESC = dataGridViewUser.Rows[row].Cells["USERDESC"].Value.ToString();
                user.WERKS = dataGridViewUser.Rows[row].Cells["WERKS"].Value.ToString();
                user.QUERY = dataGridViewUser.Rows[row].Cells["QUERY"].Value.ToString();
                Sdl_UsersAdapter.UpdateSdl_Users(user);
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请填写所有字段，并确认无误后再次保存", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            BindComboBoxData();
            BindGridViewData();
        }

        private void dataGridViewUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            if (index == 3)
            {
                sort = "order by UserName";
            }
            else if (index == 6)
            {
                sort = "order by WERKS";
            }
            else if (index == 7)
            {
                sort = "order by Query";
            }
            BindGridViewData();
        }
    }
}
