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
    public partial class RolesManage : Form
    {
        private string roleID = string.Empty;
        public RolesManage()
        {
            InitializeComponent();
            ShowFunctionsTreeNode();
            GetRoleInfo();
        }

        private void ShowFunctionsTreeNode()
        {
            tvFunction.Nodes.Clear();
            TreeNode td = new TreeNode();
            td.Text = "所有功能";
            td.Name = "Root";
            td.ContextMenuStrip = cmsTvFunctionRootNode;
            td.ImageIndex = 0;
            td.SelectedImageIndex = 0;
            ShowChildNodes(td);
            tvFunction.Nodes.Add(td);
            //展开所有子节点
            tvFunction.ExpandAll();

        }

        private void GetRoleInfo()
        {
            DataTable dt = Sdl_RolesAdapter.GetSdl_RolesDataSet("").Tables[0];
            dataGridViewRole.AutoGenerateColumns = false;
            dataGridViewRole.DataSource = dt;
        }

        private void ShowChildNodes(TreeNode tnParent)
        {
            TreeNode tdChild = null;
            DataTable dtChild = null;
            dtChild = Sdl_FunctionsAdapter.GetSdl_FunctionsDataSet(" WHERE FUNCTIONPARENT='" + tnParent.Name + "'").Tables[0];
            foreach (DataRow dr in dtChild.Rows)
            {
                tdChild = new TreeNode();
                tdChild.Text = dr["FunctionName"].ToString();
                tdChild.Name = dr["FunctionID"].ToString();
                tdChild.ImageIndex = tnParent.ImageIndex + 1;
                tdChild.SelectedImageIndex = tnParent.SelectedImageIndex + 1;
                tdChild.ContextMenuStrip = cmsTvFunctionRootNode;
                ShowChildNodes(tdChild);
                tnParent.Nodes.Add(tdChild);
            }
        }

        private void tsmiAddTvRootNode_Click(object sender, EventArgs e)
        {
            if (tvFunction.SelectedNode == null)
            {
                MessageBox.Show(this, "请选择一项功能", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormFunctionsAdd formFunctionsAdd = new FormFunctionsAdd();
            formFunctionsAdd.FunctionParent = tvFunction.SelectedNode.Name;
            formFunctionsAdd.IsModify = false;
            if (formFunctionsAdd.ShowDialog() == DialogResult.OK)
            {
                ShowFunctionsTreeNode();
            }
        }

        private void tsmiModifyTvRootNode_Click(object sender, EventArgs e)
        {
            if (tvFunction.SelectedNode==null)
            {
                MessageBox.Show(this, "请选择一项功能", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tvFunction.SelectedNode.Name == "Root")
            {
                MessageBox.Show(this, "该功能不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormFunctionsAdd formFunctionsAdd = new FormFunctionsAdd();
            formFunctionsAdd.FunctionID = tvFunction.SelectedNode.Name;
            formFunctionsAdd.FunctionParent = tvFunction.SelectedNode.Parent.Name;
            formFunctionsAdd.IsModify = true;
            if (formFunctionsAdd.ShowDialog() == DialogResult.OK)
            {
                ShowFunctionsTreeNode();
            }
        }

        private void tsmiDeleteTvRootNode_Click(object sender, EventArgs e)
        {
            if (tvFunction.SelectedNode==null)
            {
                MessageBox.Show(this, "请选择一项功能", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tvFunction.SelectedNode.Name == "Root")
            {
                MessageBox.Show(this, "该功能不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("您确定要删除该项?", "功能管理",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                if (Sdl_FunctionsInRolesAdapter.IsExistFunction(tvFunction.SelectedNode.Name))
                {
                    MessageBox.Show(this, "该功能已经被使用，不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Sdl_FunctionsAdapter.IsExistChildFunction(tvFunction.SelectedNode.Name))
                {
                    MessageBox.Show(this, "请先删除子功能", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Sdl_FunctionsAdapter.DeleteSdl_Functions(tvFunction.SelectedNode.Name);
               
                MessageBox.Show("删除该项功能成功!", "功能管理",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowFunctionsTreeNode();
            }
        }

        private void buttonRoleModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(roleID))
            {
                MessageBox.Show(this, "请选择角色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Sdl_Roles orole=Sdl_RolesAdapter.GetSdl_RolesByRoleName(textBoxRoleName.Text);
            if (orole != null && orole.ROLEID != roleID)
            {
                MessageBox.Show(this, "该角色名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Sdl_Roles role = Sdl_RolesAdapter.GetSdl_Roles(roleID);
            role.ROLENAME = textBoxRoleName.Text;
            role.ROLEDESC = textBoxRoleDesc.Text;
            Sdl_RolesAdapter.UpdateSdl_Roles(role);
            GetRoleInfo();
            MessageBox.Show(this, "修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRoleAdd_Click(object sender, EventArgs e)
        {
            if (Sdl_RolesAdapter.GetSdl_RolesByRoleName(textBoxRoleName.Text)!=null)
            {
                MessageBox.Show(this, "该角色名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Sdl_Roles role = new Sdl_Roles();
            role.ROLEID = Guid.NewGuid().ToString();
            role.ROLENAME = textBoxRoleName.Text;
            role.ROLEDESC = textBoxRoleDesc.Text;
            Sdl_RolesAdapter.AddSdl_Roles(role);
            GetRoleInfo();
            MessageBox.Show(this, "新增成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridViewRole_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((dataGridViewRole.CurrentRow != null) && (dataGridViewRole.CurrentRow.Cells["ROLE_ID"].Value != null) && (dataGridViewRole.CurrentCell.ColumnIndex!=3))
            {
                string roleId = dataGridViewRole.CurrentRow.Cells["ROLE_ID"].Value.ToString();
                Sdl_Roles role = Sdl_RolesAdapter.GetSdl_Roles(roleId);
                if (role != null)
                {
                    ShowRoleInfo(role);
                    ShowRoleFunctionsTreeNode(roleId);
                }
            }
        }

        private void ShowRoleFunctionsTreeNode(string roleId)
        {
            DataTable dtCheck = Sdl_FunctionsInRolesAdapter.GetSdl_FunctionsInRolesDataSet(roleId).Tables[0];
            TreeNode nodeP= tvFunction.Nodes[0];
            for (int i = 0; i < nodeP.Nodes.Count;i++ )
            {
                nodeP.Nodes[i].Checked = false;
                for (int n = 0; n < dtCheck.Rows.Count; n++)
                {
                    if (dtCheck.Rows[n]["FUNCTIONID"].ToString() == nodeP.Nodes[i].Name)
                    {
                        nodeP.Nodes[i].Checked = true;
                    }
                }
                ShowRoleFunctionsTreeNode(nodeP.Nodes[i], dtCheck);
            }
        }

        private void ShowRoleFunctionsTreeNode(TreeNode node, DataTable dtCheck)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Checked = false;
                for (int n = 0; n < dtCheck.Rows.Count; n++)
                {
                    if (dtCheck.Rows[n]["FUNCTIONID"].ToString() == node.Nodes[i].Name)
                    {
                        node.Nodes[i].Checked = true;
                    }
                }
                if (node.Nodes[i].Nodes.Count > 0)
                    ShowRoleFunctionsTreeNode(node.Nodes[i], dtCheck);
            }
        }

        private void ShowRoleInfo(Sdl_Roles role)
        {
            textBoxRoleDesc.Text = role.ROLEDESC;
            textBoxRoleName.Text = role.ROLENAME;
            roleID = role.ROLEID;
        }

        private void dataGridViewRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string roleId = dataGridViewRole.CurrentRow.Cells["ROLE_ID"].Value.ToString();
                if(Sdl_UsersAdapter.IsExistUserInFun(roleId))
                {
                    MessageBox.Show(this, "该角色已经被使用，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Sdl_FunctionsInRolesAdapter.DeleteSdl_FunctionsInRoles(roleId);
                Sdl_RolesAdapter.DeleteSdl_Roles(roleId);
                GetRoleInfo();
                MessageBox.Show(this, "删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tvFunction_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                CheckedParent(e.Node);
            }
            else
            {
                UnCheckedChild(e.Node);
            }
        }

        private void CheckedParent(TreeNode td)
        {
            if (td.Parent != null)
            {
                td.Parent.Checked = true;
                CheckedParent(td.Parent);
            }
        }

        private void UnCheckedChild(TreeNode td)
        {
            foreach (TreeNode tdChild in td.Nodes)
            {
                tdChild.Checked = false;
            }
        }

        private void toolStripButtonSetFun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(roleID))
            {
                MessageBox.Show(this, "请选择角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Sdl_FunctionsInRolesAdapter.DeleteSdl_FunctionsInRoles(roleID);
            SetFun(tvFunction.Nodes[0],roleID);
            MessageBox.Show(this, "更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetFun(TreeNode tnParent,string roleId)
        {
            if (tnParent.Nodes == null)
                return;
            Sdl_FunctionsInRoles roleFun = new Sdl_FunctionsInRoles();
            foreach (TreeNode tdChild in tnParent.Nodes)
            {
                if (tdChild.Checked)
                {
                    roleFun.ROLEID = roleID;
                    roleFun.FUNCTIONID = tdChild.Name;
                    Sdl_FunctionsInRolesAdapter.AddSdl_FunctionsInRoles(roleFun);
                }
                SetFun(tdChild, roleId);
            }
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
