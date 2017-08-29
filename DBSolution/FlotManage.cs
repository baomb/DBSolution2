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
using System.Threading;

namespace DBSolution
{
    public partial class FlotManage : Form
    {
        //构造函数
        public FlotManage()
        {
            InitializeComponent();
        }
        //表单加载
        private void FlotManage_Load(object sender, EventArgs e)
        {
            string sort = "order by Name";
            BindGridViewData(sort);
        }
        //绑定数据
        private void BindGridViewData(string sort)
        {
            DataTable dt = Sdl_FloatsamNameItemAdapter.GetSdl_FloatsamNameItemDataSet(sort).Tables[0];
            this.dataGridViewUser.AutoGenerateColumns = false;
            this.dataGridViewUser.DataSource = dt;
        }

        //添加按钮
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxName.Text) )
                {
                    MessageBox.Show(this, "货物名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
                if (IsExist(textBoxCode.Text.ToLower()))
                {
                    MessageBox.Show(this, "该货物编码已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             
                if (AddFloatsamItem())
                    MessageBox.Show(this, "添加货物名称成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, "添加货物名称失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BindGridViewData("order by Name");
            }
            catch
            {
                BindGridViewData("order by Name");
                MessageBox.Show(this, "添加货物名称失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //货物编码是否存在
        private bool IsExist(string code)
        {
            try
            {
                if (Sdl_FloatsamNameItemAdapter.ExistsFloatsamNameItem(code))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        //添加货物
        private bool AddFloatsamItem()
        {
            try
            {
                sdl_FloatsamNameItem item = new sdl_FloatsamNameItem();
                item.ID = Guid.NewGuid().ToString();
                item.Code = this.textBoxCode.Text.Trim();
                item.Name = this.textBoxName.Text.Trim();
                item.CreateBy = Thread.CurrentPrincipal.Identity.Name.ToString();
                item.CreateTime = DateTime.Now;
                return Sdl_FloatsamNameItemAdapter.AddFloatsamNameItem(item);
            }
            catch
            {
                return false;
            }
        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex; 
            if (column == 0)
            {
                int cnt = sdl_FloatsamEnterAdapter.Getsdl_FlotsamEnterCount(" where  FloatsamName='" + dataGridViewUser.Rows[row].Cells["Code"].Value.ToString() + "'");
                if (cnt > 0)
                {
                    MessageBox.Show(this, "该货物名称已存在相关数据，不能修改！建议添加新的货物名称", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewUser.Columns["UPDATE"].Visible = true;
                    dataGridViewUser.Columns["CANCEL"].Visible = true;
                    dataGridViewUser.Columns["EDIT"].Visible = false;
                    dataGridViewUser.ReadOnly = false;
                    dataGridViewUser.Columns[6].ReadOnly = true;
                    dataGridViewUser.Columns[7].ReadOnly = true;
                }
            }
            else if (column == 1)
            {
                if (UpdateFloatsamItem(row))
                {
                    MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewUser.Columns["UPDATE"].Visible = false;
                    dataGridViewUser.Columns["CANCEL"].Visible = false;
                    dataGridViewUser.Columns["EDIT"].Visible = true;
                    dataGridViewUser.ReadOnly = true;
                    BindGridViewData("order by Name");
                }
            }
            else if (column == 2)
            {
                dataGridViewUser.Columns["UPDATE"].Visible = false;
                dataGridViewUser.Columns["CANCEL"].Visible = false;
                dataGridViewUser.Columns["EDIT"].Visible = true;
                dataGridViewUser.ReadOnly = true;
                BindGridViewData("order by Name");
            }
            else if (column == 8)
            {
                int cnt = sdl_FloatsamEnterAdapter.Getsdl_FlotsamEnterCount(" where  FloatsamName='" + dataGridViewUser.Rows[row].Cells["Code"].Value.ToString() + "'");
                if (cnt > 0)
                {
                    MessageBox.Show(this, "该货物名称已存在相关数据，不能删除！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult dr = MessageBox.Show(this, "是否删除该货物类型？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        DeleteFloatsamItem(row);
                    }
                }
            }
        }
        //删除
        private void DeleteFloatsamItem(int row)
        {
            try
            {
                string ID = dataGridViewUser.Rows[row].Cells["ID"].Value.ToString();
                Sdl_FloatsamNameItemAdapter.Deletesdl_FloatsamNameItem(ID);
                MessageBox.Show(this, "删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridViewData("order by Name");
            }
            catch
            {
                MessageBox.Show(this, "操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdateFloatsamItem(int row)
        {
            try
            {
                sdl_FloatsamNameItem item = new sdl_FloatsamNameItem();
                item.ID = dataGridViewUser.Rows[row].Cells["ID"].Value.ToString();
                item.Code = dataGridViewUser.Rows[row].Cells["Code"].Value.ToString();
                if (IsExist(item.Code) && item.ID != Sdl_FloatsamNameItemAdapter.Getsdl_FloatsamNameItem(item.Code).ID)
                {
                    MessageBox.Show(this, "该货物编码已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                item.Name = dataGridViewUser.Rows[row].Cells["FlotName"].Value.ToString();
                //item.CreateBy = dataGridViewUser.Rows[row].Cells["CreateBy"].Value.ToString();
                //item.CreateTime =Convert.ToDateTime(dataGridViewUser.Rows[row].Cells["CreateTime"].Value);
                Sdl_FloatsamNameItemAdapter.Updatesdl_FloatsamNameItem(item);
                return true;
            }
            catch
            {
                MessageBox.Show(this, "请填写所有字段，并确认无误后再次保存", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dataGridViewUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sort = "order by Name";
            int index = e.ColumnIndex;
            if (index == 4)
            {
                sort = "order by Name";
            }
            else if (index == 5)
            {
                sort = "order by Code";
            }
            else if (index == 7)
            {
                sort = "order by CreateTime";
            }
            BindGridViewData(sort);
        }
    }
}
