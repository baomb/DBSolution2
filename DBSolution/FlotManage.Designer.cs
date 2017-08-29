namespace DBSolution
{
    partial class FlotManage
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UPDATE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CANCEL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(79, 197);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(79, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(122, 21);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(79, 106);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(122, 21);
            this.textBoxCode.TabIndex = 2;
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.labelCode);
            this.groupBoxAdd.Controls.Add(this.buttonAdd);
            this.groupBoxAdd.Controls.Add(this.labelName);
            this.groupBoxAdd.Controls.Add(this.textBoxName);
            this.groupBoxAdd.Controls.Add(this.textBoxCode);
            this.groupBoxAdd.Location = new System.Drawing.Point(750, 12);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(232, 312);
            this.groupBoxAdd.TabIndex = 3;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "添加货物名称";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(27, 109);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(53, 12);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "货物编码";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(27, 43);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "货物名称";
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDIT,
            this.UPDATE,
            this.CANCEL,
            this.ID,
            this.FlotName,
            this.Code,
            this.CreateBy,
            this.CreateTime,
            this.DELETE});
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewUser.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUser.MultiSelect = false;
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowTemplate.Height = 23;
            this.dataGridViewUser.Size = new System.Drawing.Size(724, 486);
            this.dataGridViewUser.TabIndex = 4;
            this.dataGridViewUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellContentClick);
            this.dataGridViewUser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUser_ColumnHeaderMouseClick);
            // 
            // EDIT
            // 
            this.EDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EDIT.HeaderText = "";
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "修改";
            this.EDIT.UseColumnTextForButtonValue = true;
            // 
            // UPDATE
            // 
            this.UPDATE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UPDATE.HeaderText = "";
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.ReadOnly = true;
            this.UPDATE.Text = "保存";
            this.UPDATE.UseColumnTextForButtonValue = true;
            this.UPDATE.Visible = false;
            // 
            // CANCEL
            // 
            this.CANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CANCEL.HeaderText = "";
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.ReadOnly = true;
            this.CANCEL.Text = "取消";
            this.CANCEL.UseColumnTextForButtonValue = true;
            this.CANCEL.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // FlotName
            // 
            this.FlotName.DataPropertyName = "Name";
            this.FlotName.HeaderText = "货物名称";
            this.FlotName.Name = "FlotName";
            this.FlotName.ReadOnly = true;
            this.FlotName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FlotName.Width = 160;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "货物名称编码";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "创建人";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 120;
            // 
            // DELETE
            // 
            this.DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETE.HeaderText = "";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Text = "删除";
            this.DELETE.UseColumnTextForButtonValue = true;
            // 
            // FlotManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 486);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.groupBoxAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlotManage";
            this.ShowIcon = false;
            this.Text = "废旧物资名称管理";
            this.Load += new System.EventHandler(this.FlotManage_Load);
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn UPDATE;
        private System.Windows.Forms.DataGridViewButtonColumn CANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
    }
}