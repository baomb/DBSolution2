namespace DBSolution
{
    partial class DataHistorySearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataHistorySearch));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBoxCondition = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonEdit = new System.Windows.Forms.RadioButton();
            this.radioButtonAdd = new System.Windows.Forms.RadioButton();
            this.TimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.TimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pager = new SdlDB.Utility.PageNavigator();
            this.View = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxCondition.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(757, 21);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(59, 23);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "查 询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBoxCondition
            // 
            this.groupBoxCondition.Controls.Add(this.label1);
            this.groupBoxCondition.Controls.Add(this.radioButtonDelete);
            this.groupBoxCondition.Controls.Add(this.radioButtonEdit);
            this.groupBoxCondition.Controls.Add(this.radioButtonAdd);
            this.groupBoxCondition.Controls.Add(this.buttonSearch);
            this.groupBoxCondition.Controls.Add(this.TimePickerEnd);
            this.groupBoxCondition.Controls.Add(this.TimePickerBegin);
            this.groupBoxCondition.Controls.Add(this.label4);
            this.groupBoxCondition.Controls.Add(this.label3);
            this.groupBoxCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCondition.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCondition.Name = "groupBoxCondition";
            this.groupBoxCondition.Size = new System.Drawing.Size(860, 53);
            this.groupBoxCondition.TabIndex = 0;
            this.groupBoxCondition.TabStop = false;
            this.groupBoxCondition.Text = "查询条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "修改类型:";
            // 
            // radioButtonDelete
            // 
            this.radioButtonDelete.AutoSize = true;
            this.radioButtonDelete.Location = new System.Drawing.Point(296, 26);
            this.radioButtonDelete.Name = "radioButtonDelete";
            this.radioButtonDelete.Size = new System.Drawing.Size(47, 16);
            this.radioButtonDelete.TabIndex = 25;
            this.radioButtonDelete.TabStop = true;
            this.radioButtonDelete.Text = "删除";
            this.radioButtonDelete.UseVisualStyleBackColor = true;
            // 
            // radioButtonEdit
            // 
            this.radioButtonEdit.AutoSize = true;
            this.radioButtonEdit.Location = new System.Drawing.Point(213, 26);
            this.radioButtonEdit.Name = "radioButtonEdit";
            this.radioButtonEdit.Size = new System.Drawing.Size(47, 16);
            this.radioButtonEdit.TabIndex = 24;
            this.radioButtonEdit.TabStop = true;
            this.radioButtonEdit.Text = "修改";
            this.radioButtonEdit.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdd
            // 
            this.radioButtonAdd.AutoSize = true;
            this.radioButtonAdd.Location = new System.Drawing.Point(130, 26);
            this.radioButtonAdd.Name = "radioButtonAdd";
            this.radioButtonAdd.Size = new System.Drawing.Size(47, 16);
            this.radioButtonAdd.TabIndex = 23;
            this.radioButtonAdd.TabStop = true;
            this.radioButtonAdd.Text = "添加";
            this.radioButtonAdd.UseVisualStyleBackColor = true;
            // 
            // TimePickerEnd
            // 
            this.TimePickerEnd.Location = new System.Drawing.Point(620, 22);
            this.TimePickerEnd.Name = "TimePickerEnd";
            this.TimePickerEnd.Size = new System.Drawing.Size(110, 21);
            this.TimePickerEnd.TabIndex = 15;
            this.TimePickerEnd.ValueChanged += new System.EventHandler(this.TimePickerEnd_ValueChanged);
            // 
            // TimePickerBegin
            // 
            this.TimePickerBegin.Location = new System.Drawing.Point(467, 23);
            this.TimePickerBegin.Name = "TimePickerBegin";
            this.TimePickerBegin.Size = new System.Drawing.Size(110, 21);
            this.TimePickerBegin.TabIndex = 14;
            this.TimePickerBegin.ValueChanged += new System.EventHandler(this.TimePickerBegin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(590, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "修改时间:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dataGridViewDetail);
            this.panel3.Location = new System.Drawing.Point(12, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(860, 462);
            this.panel3.TabIndex = 16;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.View,
            this.EditTime,
            this.UserName,
            this.Type,
            this.Module,
            this.TableName});
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.Size = new System.Drawing.Size(860, 462);
            this.dataGridViewDetail.TabIndex = 0;
            this.dataGridViewDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "查看详细";
            this.dataGridViewImageColumn1.Image = global::DBSolution2.Properties.Resources.修改1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBoxCondition);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 53);
            this.panel1.TabIndex = 15;
            // 
            // pager
            // 
            this.pager.DataSourceCount = 0;
            this.pager.Dock = System.Windows.Forms.DockStyle.None;
            this.pager.Location = new System.Drawing.Point(12, 64);
            this.pager.Name = "pager";
            this.pager.PageIndex = 1;
            this.pager.PageSize = 0;
            this.pager.Size = new System.Drawing.Size(385, 25);
            this.pager.TabIndex = 14;
            this.pager.Text = "pageNavigator1";
            this.pager.PageChanged += new System.EventHandler(this.pager_PageChanged);
            // 
            // View
            // 
            this.View.HeaderText = "";
            this.View.Image = ((System.Drawing.Image)(resources.GetObject("View.Image")));
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.ToolTipText = "修改详细";
            this.View.Width = 60;
            // 
            // EditTime
            // 
            this.EditTime.DataPropertyName = "EditTime";
            this.EditTime.HeaderText = "修改时间";
            this.EditTime.Name = "EditTime";
            this.EditTime.ReadOnly = true;
            this.EditTime.Width = 160;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "修改人";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 160;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "修改类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 160;
            // 
            // Module
            // 
            this.Module.DataPropertyName = "Module";
            this.Module.HeaderText = "业务";
            this.Module.Name = "Module";
            this.Module.ReadOnly = true;
            this.Module.Width = 160;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "表名";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            this.TableName.Visible = false;
            this.TableName.Width = 160;
            // 
            // DataHistorySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.pager);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "DataHistorySearch";
            this.Text = "数据修改历史查询";
            this.Load += new System.EventHandler(this.DataHistorySearch_Load);
            this.groupBoxCondition.ResumeLayout(false);
            this.groupBoxCondition.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SdlDB.Utility.PageNavigator pager;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxCondition;
        private System.Windows.Forms.DateTimePicker TimePickerEnd;
        private System.Windows.Forms.DateTimePicker TimePickerBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonDelete;
        private System.Windows.Forms.RadioButton radioButtonEdit;
        private System.Windows.Forms.RadioButton radioButtonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn View;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
    }
}