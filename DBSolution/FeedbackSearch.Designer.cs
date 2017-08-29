namespace DBSolution
{
    partial class FeedbackSearch
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.TimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewComments = new System.Windows.Forms.DataGridView();
            this.TimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBoxCondition = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.comboBoxResolved = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxResult = new System.Windows.Forms.ComboBox();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SAVE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CANCEL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESPONSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESPTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESOLVED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RESULT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBoxCondition.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(866, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "查 询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // TimePickerEnd
            // 
            this.TimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerEnd.Location = new System.Drawing.Point(725, 24);
            this.TimePickerEnd.Name = "TimePickerEnd";
            this.TimePickerEnd.Size = new System.Drawing.Size(114, 21);
            this.TimePickerEnd.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewComments);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 382);
            this.panel3.TabIndex = 21;
            // 
            // dataGridViewComments
            // 
            this.dataGridViewComments.AllowUserToAddRows = false;
            this.dataGridViewComments.AllowUserToDeleteRows = false;
            this.dataGridViewComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDIT,
            this.SAVE,
            this.CANCEL,
            this.ID,
            this.USERNAME,
            this.DATETIME,
            this.TITLE,
            this.COMMENT,
            this.RESPONSE,
            this.RESPNAME,
            this.RESPTIME,
            this.RESOLVED,
            this.RESULT});
            this.dataGridViewComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewComments.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewComments.Name = "dataGridViewComments";
            this.dataGridViewComments.RowTemplate.Height = 23;
            this.dataGridViewComments.Size = new System.Drawing.Size(1004, 382);
            this.dataGridViewComments.TabIndex = 0;
            this.dataGridViewComments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellContentClick);
            // 
            // TimePickerBegin
            // 
            this.TimePickerBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerBegin.Location = new System.Drawing.Point(579, 24);
            this.TimePickerBegin.Name = "TimePickerBegin";
            this.TimePickerBegin.Size = new System.Drawing.Size(114, 21);
            this.TimePickerBegin.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(701, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "反馈时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "标题:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(240, 24);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(254, 21);
            this.textBoxTitle.TabIndex = 9;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.labelTitle.Location = new System.Drawing.Point(16, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(110, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "反馈建议管理";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonQuit
            // 
            this.toolStripButtonQuit.Image = global::DBSolution2.Properties.Resources.Close;
            this.toolStripButtonQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuit.Name = "toolStripButtonQuit";
            this.toolStripButtonQuit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQuit.Text = "退出";
            this.toolStripButtonQuit.Click += new System.EventHandler(this.toolStripButtonQuit_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "查看详细";
            this.dataGridViewImageColumn1.Image = global::DBSolution2.Properties.Resources.修改1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // groupBoxCondition
            // 
            this.groupBoxCondition.Controls.Add(this.label7);
            this.groupBoxCondition.Controls.Add(this.comboBoxResult);
            this.groupBoxCondition.Controls.Add(this.label6);
            this.groupBoxCondition.Controls.Add(this.comboBoxResolved);
            this.groupBoxCondition.Controls.Add(this.label1);
            this.groupBoxCondition.Controls.Add(this.textBoxUsername);
            this.groupBoxCondition.Controls.Add(this.label5);
            this.groupBoxCondition.Controls.Add(this.textBoxID);
            this.groupBoxCondition.Controls.Add(this.buttonSearch);
            this.groupBoxCondition.Controls.Add(this.TimePickerEnd);
            this.groupBoxCondition.Controls.Add(this.TimePickerBegin);
            this.groupBoxCondition.Controls.Add(this.label4);
            this.groupBoxCondition.Controls.Add(this.label3);
            this.groupBoxCondition.Controls.Add(this.label2);
            this.groupBoxCondition.Controls.Add(this.textBoxTitle);
            this.groupBoxCondition.Location = new System.Drawing.Point(16, 32);
            this.groupBoxCondition.Name = "groupBoxCondition";
            this.groupBoxCondition.Size = new System.Drawing.Size(972, 90);
            this.groupBoxCondition.TabIndex = 0;
            this.groupBoxCondition.TabStop = false;
            this.groupBoxCondition.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxCondition);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 135);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 30);
            this.panel2.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "编号:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(72, 24);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 21);
            this.textBoxID.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "用户名:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(72, 56);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 21);
            this.textBoxUsername.TabIndex = 21;
            // 
            // comboBoxResolved
            // 
            this.comboBoxResolved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolved.FormattingEnabled = true;
            this.comboBoxResolved.Items.AddRange(new object[] {
            "全部",
            "未解决",
            "已解决"});
            this.comboBoxResolved.Location = new System.Drawing.Point(264, 56);
            this.comboBoxResolved.Name = "comboBoxResolved";
            this.comboBoxResolved.Size = new System.Drawing.Size(121, 20);
            this.comboBoxResolved.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "解决状态:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "关闭状态:";
            // 
            // comboBoxResult
            // 
            this.comboBoxResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResult.FormattingEnabled = true;
            this.comboBoxResult.Items.AddRange(new object[] {
            "全部",
            "未关闭",
            "已关闭"});
            this.comboBoxResult.Location = new System.Drawing.Point(488, 56);
            this.comboBoxResult.Name = "comboBoxResult";
            this.comboBoxResult.Size = new System.Drawing.Size(121, 20);
            this.comboBoxResult.TabIndex = 25;
            // 
            // EDIT
            // 
            this.EDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EDIT.HeaderText = "";
            this.EDIT.Name = "EDIT";
            this.EDIT.Text = "回复";
            this.EDIT.UseColumnTextForButtonValue = true;
            this.EDIT.Width = 40;
            // 
            // SAVE
            // 
            this.SAVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAVE.HeaderText = "";
            this.SAVE.Name = "SAVE";
            this.SAVE.Text = "保存";
            this.SAVE.UseColumnTextForButtonValue = true;
            this.SAVE.Visible = false;
            this.SAVE.Width = 40;
            // 
            // CANCEL
            // 
            this.CANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CANCEL.HeaderText = "";
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Text = "取消";
            this.CANCEL.UseColumnTextForButtonValue = true;
            this.CANCEL.Visible = false;
            this.CANCEL.Width = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "编号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 60;
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "反馈人";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 70;
            // 
            // DATETIME
            // 
            this.DATETIME.DataPropertyName = "DATETIME";
            this.DATETIME.HeaderText = "反馈时间";
            this.DATETIME.Name = "DATETIME";
            this.DATETIME.ReadOnly = true;
            this.DATETIME.Width = 110;
            // 
            // TITLE
            // 
            this.TITLE.DataPropertyName = "TITLE";
            this.TITLE.HeaderText = "标题";
            this.TITLE.Name = "TITLE";
            this.TITLE.ReadOnly = true;
            this.TITLE.Width = 120;
            // 
            // COMMENT
            // 
            this.COMMENT.DataPropertyName = "COMMENT";
            this.COMMENT.HeaderText = "内容";
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.ReadOnly = true;
            this.COMMENT.Width = 180;
            // 
            // RESPONSE
            // 
            this.RESPONSE.DataPropertyName = "RESPONSE";
            this.RESPONSE.HeaderText = "回复";
            this.RESPONSE.Name = "RESPONSE";
            this.RESPONSE.ReadOnly = true;
            // 
            // RESPNAME
            // 
            this.RESPNAME.DataPropertyName = "RESPNAME";
            this.RESPNAME.HeaderText = "回复人";
            this.RESPNAME.Name = "RESPNAME";
            this.RESPNAME.ReadOnly = true;
            this.RESPNAME.Width = 70;
            // 
            // RESPTIME
            // 
            this.RESPTIME.DataPropertyName = "RESPTIME";
            this.RESPTIME.HeaderText = "回复时间";
            this.RESPTIME.Name = "RESPTIME";
            this.RESPTIME.ReadOnly = true;
            this.RESPTIME.Width = 110;
            // 
            // RESOLVED
            // 
            this.RESOLVED.DataPropertyName = "RESOLVED";
            this.RESOLVED.FillWeight = 50F;
            this.RESOLVED.HeaderText = "解决";
            this.RESOLVED.Name = "RESOLVED";
            this.RESOLVED.ReadOnly = true;
            this.RESOLVED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RESOLVED.Width = 60;
            // 
            // RESULT
            // 
            this.RESULT.DataPropertyName = "RESULT";
            this.RESULT.FillWeight = 50F;
            this.RESULT.HeaderText = "关闭";
            this.RESULT.Name = "RESULT";
            this.RESULT.ReadOnly = true;
            this.RESULT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RESULT.Width = 60;
            // 
            // FeedbackSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FeedbackSearch";
            this.Text = "反馈建议管理";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxCondition.ResumeLayout(false);
            this.groupBoxCondition.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker TimePickerEnd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewComments;
        private System.Windows.Forms.DateTimePicker TimePickerBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.GroupBox groupBoxCondition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxResolved;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxResult;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn SAVE;
        private System.Windows.Forms.DataGridViewButtonColumn CANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TITLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESPONSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESPTIME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RESOLVED;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RESULT;

    }
}