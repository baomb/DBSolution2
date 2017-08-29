namespace DBSolution
{
    partial class UserManage
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
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.labelQuery = new System.Windows.Forms.Label();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.checkBoxIsLocked = new System.Windows.Forms.CheckBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.labelIsLocked = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelWERKS = new System.Windows.Forms.Label();
            this.textBoxWERKS = new System.Windows.Forms.TextBox();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.textBoxUserInfo = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxReset = new System.Windows.Forms.GroupBox();
            this.textBoxReset = new System.Windows.Forms.TextBox();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UPDATE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CANCEL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WERKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUERY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLENAME = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ROLEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLEREAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISLOCKED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.groupBoxReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(65, 273);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(65, 26);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(122, 21);
            this.textBoxUserName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(65, 54);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(122, 21);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.labelQuery);
            this.groupBoxAdd.Controls.Add(this.textBoxQuery);
            this.groupBoxAdd.Controls.Add(this.checkBoxIsLocked);
            this.groupBoxAdd.Controls.Add(this.comboBoxRole);
            this.groupBoxAdd.Controls.Add(this.labelIsLocked);
            this.groupBoxAdd.Controls.Add(this.labelRole);
            this.groupBoxAdd.Controls.Add(this.labelWERKS);
            this.groupBoxAdd.Controls.Add(this.textBoxWERKS);
            this.groupBoxAdd.Controls.Add(this.labelUserInfo);
            this.groupBoxAdd.Controls.Add(this.textBoxUserInfo);
            this.groupBoxAdd.Controls.Add(this.labelPassword);
            this.groupBoxAdd.Controls.Add(this.buttonAdd);
            this.groupBoxAdd.Controls.Add(this.labelUserName);
            this.groupBoxAdd.Controls.Add(this.textBoxUserName);
            this.groupBoxAdd.Controls.Add(this.textBoxPassword);
            this.groupBoxAdd.Location = new System.Drawing.Point(782, 12);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(198, 312);
            this.groupBoxAdd.TabIndex = 3;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "添加用户";
            // 
            // labelQuery
            // 
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new System.Drawing.Point(13, 113);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new System.Drawing.Size(53, 12);
            this.labelQuery.TabIndex = 16;
            this.labelQuery.Text = "查询工厂";
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(65, 110);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(122, 21);
            this.textBoxQuery.TabIndex = 15;
            // 
            // checkBoxIsLocked
            // 
            this.checkBoxIsLocked.AutoSize = true;
            this.checkBoxIsLocked.Location = new System.Drawing.Point(65, 169);
            this.checkBoxIsLocked.Name = "checkBoxIsLocked";
            this.checkBoxIsLocked.Size = new System.Drawing.Size(15, 14);
            this.checkBoxIsLocked.TabIndex = 14;
            this.checkBoxIsLocked.UseVisualStyleBackColor = true;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(65, 139);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(122, 20);
            this.comboBoxRole.TabIndex = 13;
            // 
            // labelIsLocked
            // 
            this.labelIsLocked.AutoSize = true;
            this.labelIsLocked.Location = new System.Drawing.Point(13, 169);
            this.labelIsLocked.Name = "labelIsLocked";
            this.labelIsLocked.Size = new System.Drawing.Size(29, 12);
            this.labelIsLocked.TabIndex = 12;
            this.labelIsLocked.Text = "锁定";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(13, 142);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(29, 12);
            this.labelRole.TabIndex = 10;
            this.labelRole.Text = "角色";
            // 
            // labelWERKS
            // 
            this.labelWERKS.AutoSize = true;
            this.labelWERKS.Location = new System.Drawing.Point(13, 85);
            this.labelWERKS.Name = "labelWERKS";
            this.labelWERKS.Size = new System.Drawing.Size(29, 12);
            this.labelWERKS.TabIndex = 8;
            this.labelWERKS.Text = "工厂";
            // 
            // textBoxWERKS
            // 
            this.textBoxWERKS.Location = new System.Drawing.Point(65, 82);
            this.textBoxWERKS.Name = "textBoxWERKS";
            this.textBoxWERKS.Size = new System.Drawing.Size(122, 21);
            this.textBoxWERKS.TabIndex = 3;
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Location = new System.Drawing.Point(13, 196);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(29, 12);
            this.labelUserInfo.TabIndex = 6;
            this.labelUserInfo.Text = "简介";
            // 
            // textBoxUserInfo
            // 
            this.textBoxUserInfo.Location = new System.Drawing.Point(65, 193);
            this.textBoxUserInfo.Multiline = true;
            this.textBoxUserInfo.Name = "textBoxUserInfo";
            this.textBoxUserInfo.Size = new System.Drawing.Size(122, 74);
            this.textBoxUserInfo.TabIndex = 4;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(13, 57);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(29, 12);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "密码";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(13, 29);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(41, 12);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "用户名";
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
            this.USERNAME,
            this.USERID,
            this.USERDESC,
            this.WERKS,
            this.QUERY,
            this.ROLENAME,
            this.ROLEID,
            this.ROLEREAD,
            this.ISLOCKED,
            this.DELETE});
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewUser.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUser.MultiSelect = false;
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowTemplate.Height = 23;
            this.dataGridViewUser.Size = new System.Drawing.Size(766, 486);
            this.dataGridViewUser.TabIndex = 4;
            this.dataGridViewUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellContentClick);
            this.dataGridViewUser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUser_ColumnHeaderMouseClick);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(62, 61);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "重设密码";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxReset
            // 
            this.groupBoxReset.Controls.Add(this.textBoxReset);
            this.groupBoxReset.Controls.Add(this.buttonReset);
            this.groupBoxReset.Location = new System.Drawing.Point(782, 336);
            this.groupBoxReset.Name = "groupBoxReset";
            this.groupBoxReset.Size = new System.Drawing.Size(200, 98);
            this.groupBoxReset.TabIndex = 10;
            this.groupBoxReset.TabStop = false;
            this.groupBoxReset.Text = "重设密码";
            // 
            // textBoxReset
            // 
            this.textBoxReset.Location = new System.Drawing.Point(35, 31);
            this.textBoxReset.Name = "textBoxReset";
            this.textBoxReset.Size = new System.Drawing.Size(131, 21);
            this.textBoxReset.TabIndex = 10;
            this.textBoxReset.UseSystemPasswordChar = true;
            // 
            // EDIT
            // 
            this.EDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EDIT.HeaderText = "";
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "修改";
            this.EDIT.UseColumnTextForButtonValue = true;
            this.EDIT.Width = 60;
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
            this.UPDATE.Width = 60;
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
            this.CANCEL.Width = 60;
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "用户名";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.USERNAME.Width = 80;
            // 
            // USERID
            // 
            this.USERID.DataPropertyName = "USERID";
            this.USERID.HeaderText = "用户ID";
            this.USERID.Name = "USERID";
            this.USERID.ReadOnly = true;
            this.USERID.Visible = false;
            // 
            // USERDESC
            // 
            this.USERDESC.DataPropertyName = "USERDESC";
            this.USERDESC.HeaderText = "用户简介";
            this.USERDESC.Name = "USERDESC";
            this.USERDESC.ReadOnly = true;
            this.USERDESC.Width = 160;
            // 
            // WERKS
            // 
            this.WERKS.DataPropertyName = "WERKS";
            this.WERKS.HeaderText = "工厂";
            this.WERKS.Name = "WERKS";
            this.WERKS.ReadOnly = true;
            this.WERKS.Width = 60;
            // 
            // QUERY
            // 
            this.QUERY.DataPropertyName = "QUERY";
            this.QUERY.HeaderText = "查询工厂";
            this.QUERY.Name = "QUERY";
            this.QUERY.ReadOnly = true;
            // 
            // ROLENAME
            // 
            this.ROLENAME.DataPropertyName = "ROLENAME";
            this.ROLENAME.HeaderText = "角色";
            this.ROLENAME.Name = "ROLENAME";
            this.ROLENAME.ReadOnly = true;
            // 
            // ROLEID
            // 
            this.ROLEID.DataPropertyName = "ROLE";
            this.ROLEID.HeaderText = "角色ID";
            this.ROLEID.Name = "ROLEID";
            this.ROLEID.ReadOnly = true;
            this.ROLEID.Visible = false;
            // 
            // ROLEREAD
            // 
            this.ROLEREAD.DataPropertyName = "ROLEREAD";
            this.ROLEREAD.HeaderText = "角色文本";
            this.ROLEREAD.Name = "ROLEREAD";
            this.ROLEREAD.ReadOnly = true;
            this.ROLEREAD.Visible = false;
            // 
            // ISLOCKED
            // 
            this.ISLOCKED.DataPropertyName = "ISLOCKED";
            this.ISLOCKED.HeaderText = "锁定";
            this.ISLOCKED.Name = "ISLOCKED";
            this.ISLOCKED.ReadOnly = true;
            this.ISLOCKED.Width = 60;
            // 
            // DELETE
            // 
            this.DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETE.HeaderText = "";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Text = "删除";
            this.DELETE.UseColumnTextForButtonValue = true;
            this.DELETE.Width = 60;
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 486);
            this.Controls.Add(this.groupBoxReset);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.groupBoxAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManage";
            this.ShowIcon = false;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.groupBoxReset.ResumeLayout(false);
            this.groupBoxReset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.TextBox textBoxUserInfo;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelWERKS;
        private System.Windows.Forms.TextBox textBoxWERKS;
        private System.Windows.Forms.Label labelIsLocked;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.CheckBox checkBoxIsLocked;
        private System.Windows.Forms.GroupBox groupBoxReset;
        private System.Windows.Forms.TextBox textBoxReset;
        private System.Windows.Forms.Label labelQuery;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn UPDATE;
        private System.Windows.Forms.DataGridViewButtonColumn CANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUERY;
        private System.Windows.Forms.DataGridViewComboBoxColumn ROLENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLEREAD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISLOCKED;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
    }
}