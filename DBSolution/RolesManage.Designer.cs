namespace DBSolution
{
    partial class RolesManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesManage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSetFun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRole = new System.Windows.Forms.DataGridView();
            this.ROLE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLEDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvFunction = new System.Windows.Forms.TreeView();
            this.ilFunctions = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonRoleModify = new System.Windows.Forms.Button();
            this.buttonRoleAdd = new System.Windows.Forms.Button();
            this.textBoxRoleDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRoleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsTvFunctionRootNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddTvRootNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModifyTvRootNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteTvRootNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRole)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsTvFunctionRootNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButtonQuit,
            this.toolStripSeparator2,
            this.toolStripButtonSetFun,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(690, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonQuit
            // 
            this.toolStripButtonQuit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQuit.Image")));
            this.toolStripButtonQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuit.Name = "toolStripButtonQuit";
            this.toolStripButtonQuit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQuit.Text = "退出";
            this.toolStripButtonQuit.Click += new System.EventHandler(this.toolStripButtonQuit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSetFun
            // 
            this.toolStripButtonSetFun.Image = global::DBSolution2.Properties.Resources.Edit;
            this.toolStripButtonSetFun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetFun.Name = "toolStripButtonSetFun";
            this.toolStripButtonSetFun.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSetFun.Text = "功能更新";
            this.toolStripButtonSetFun.Click += new System.EventHandler(this.toolStripButtonSetFun_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewRole);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 242);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "角色维护";
            // 
            // dataGridViewRole
            // 
            this.dataGridViewRole.AllowUserToAddRows = false;
            this.dataGridViewRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROLE_ID,
            this.ROLENAME,
            this.ROLEDESC,
            this.DELETE});
            this.dataGridViewRole.Location = new System.Drawing.Point(6, 17);
            this.dataGridViewRole.Name = "dataGridViewRole";
            this.dataGridViewRole.RowTemplate.Height = 23;
            this.dataGridViewRole.Size = new System.Drawing.Size(318, 216);
            this.dataGridViewRole.TabIndex = 0;
            this.dataGridViewRole.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRole_CellContentClick);
            this.dataGridViewRole.CurrentCellChanged += new System.EventHandler(this.dataGridViewRole_CurrentCellChanged);
            // 
            // ROLE_ID
            // 
            this.ROLE_ID.DataPropertyName = "ROLEID";
            this.ROLE_ID.HeaderText = "ROLE_ID";
            this.ROLE_ID.Name = "ROLE_ID";
            this.ROLE_ID.Visible = false;
            // 
            // ROLENAME
            // 
            this.ROLENAME.DataPropertyName = "ROLENAME";
            this.ROLENAME.HeaderText = "角色名称";
            this.ROLENAME.Name = "ROLENAME";
            this.ROLENAME.ToolTipText = "角色名称";
            // 
            // ROLEDESC
            // 
            this.ROLEDESC.DataPropertyName = "ROLEDESC";
            this.ROLEDESC.HeaderText = "角色描述";
            this.ROLEDESC.Name = "ROLEDESC";
            // 
            // DELETE
            // 
            this.DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETE.HeaderText = "删除";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Text = "删除";
            this.DELETE.ToolTipText = "删除";
            this.DELETE.UseColumnTextForButtonValue = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tvFunction);
            this.groupBox2.Location = new System.Drawing.Point(361, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 449);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能维护";
            // 
            // tvFunction
            // 
            this.tvFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFunction.CheckBoxes = true;
            this.tvFunction.ImageIndex = 0;
            this.tvFunction.ImageList = this.ilFunctions;
            this.tvFunction.Location = new System.Drawing.Point(7, 17);
            this.tvFunction.Name = "tvFunction";
            this.tvFunction.SelectedImageIndex = 0;
            this.tvFunction.Size = new System.Drawing.Size(303, 426);
            this.tvFunction.TabIndex = 4;
            this.tvFunction.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvFunction_AfterCheck);
            // 
            // ilFunctions
            // 
            this.ilFunctions.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilFunctions.ImageSize = new System.Drawing.Size(19, 19);
            this.ilFunctions.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonRoleModify);
            this.groupBox3.Controls.Add(this.buttonRoleAdd);
            this.groupBox3.Controls.Add(this.textBoxRoleDesc);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxRoleName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 192);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "角色信息";
            // 
            // buttonRoleModify
            // 
            this.buttonRoleModify.Location = new System.Drawing.Point(193, 157);
            this.buttonRoleModify.Name = "buttonRoleModify";
            this.buttonRoleModify.Size = new System.Drawing.Size(75, 23);
            this.buttonRoleModify.TabIndex = 5;
            this.buttonRoleModify.Text = "修 改";
            this.buttonRoleModify.UseVisualStyleBackColor = true;
            this.buttonRoleModify.Click += new System.EventHandler(this.buttonRoleModify_Click);
            // 
            // buttonRoleAdd
            // 
            this.buttonRoleAdd.Location = new System.Drawing.Point(95, 157);
            this.buttonRoleAdd.Name = "buttonRoleAdd";
            this.buttonRoleAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonRoleAdd.TabIndex = 4;
            this.buttonRoleAdd.Text = "新 增";
            this.buttonRoleAdd.UseVisualStyleBackColor = true;
            this.buttonRoleAdd.Click += new System.EventHandler(this.buttonRoleAdd_Click);
            // 
            // textBoxRoleDesc
            // 
            this.textBoxRoleDesc.Location = new System.Drawing.Point(72, 55);
            this.textBoxRoleDesc.Multiline = true;
            this.textBoxRoleDesc.Name = "textBoxRoleDesc";
            this.textBoxRoleDesc.Size = new System.Drawing.Size(245, 89);
            this.textBoxRoleDesc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "角色描述";
            // 
            // textBoxRoleName
            // 
            this.textBoxRoleName.Location = new System.Drawing.Point(72, 25);
            this.textBoxRoleName.Name = "textBoxRoleName";
            this.textBoxRoleName.Size = new System.Drawing.Size(245, 21);
            this.textBoxRoleName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "角色名称";
            // 
            // cmsTvFunctionRootNode
            // 
            this.cmsTvFunctionRootNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddTvRootNode,
            this.tsmiModifyTvRootNode,
            this.tsmiDeleteTvRootNode});
            this.cmsTvFunctionRootNode.Name = "cmsTvFunctionRootNode";
            this.cmsTvFunctionRootNode.Size = new System.Drawing.Size(95, 70);
            // 
            // tsmiAddTvRootNode
            // 
            this.tsmiAddTvRootNode.Name = "tsmiAddTvRootNode";
            this.tsmiAddTvRootNode.Size = new System.Drawing.Size(94, 22);
            this.tsmiAddTvRootNode.Text = "增加";
            this.tsmiAddTvRootNode.Click += new System.EventHandler(this.tsmiAddTvRootNode_Click);
            // 
            // tsmiModifyTvRootNode
            // 
            this.tsmiModifyTvRootNode.Name = "tsmiModifyTvRootNode";
            this.tsmiModifyTvRootNode.Size = new System.Drawing.Size(94, 22);
            this.tsmiModifyTvRootNode.Text = "修改";
            this.tsmiModifyTvRootNode.Click += new System.EventHandler(this.tsmiModifyTvRootNode_Click);
            // 
            // tsmiDeleteTvRootNode
            // 
            this.tsmiDeleteTvRootNode.Name = "tsmiDeleteTvRootNode";
            this.tsmiDeleteTvRootNode.Size = new System.Drawing.Size(94, 22);
            this.tsmiDeleteTvRootNode.Text = "删除";
            this.tsmiDeleteTvRootNode.Click += new System.EventHandler(this.tsmiDeleteTvRootNode_Click);
            // 
            // RolesManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RolesManage";
            this.Text = "史丹利地磅系统-角色功能维护";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRole)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cmsTvFunctionRootNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewRole;
        private System.Windows.Forms.Button buttonRoleModify;
        private System.Windows.Forms.Button buttonRoleAdd;
        private System.Windows.Forms.TextBox textBoxRoleDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRoleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvFunction;
        private System.Windows.Forms.ContextMenuStrip cmsTvFunctionRootNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddTvRootNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiModifyTvRootNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteTvRootNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLEDESC;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetFun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList ilFunctions;
    }
}