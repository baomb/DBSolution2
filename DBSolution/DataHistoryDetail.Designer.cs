namespace DBSolution
{
    partial class DataHistoryDetail
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
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.EditTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditTime,
            this.Random,
            this.UserName,
            this.Type,
            this.Module,
            this.TableName,
            this.Field,
            this.OldValue,
            this.NewValue,
            this.Col1,
            this.Col2,
            this.Col3,
            this.Col4,
            this.Col5,
            this.Col6,
            this.ColField});
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.Size = new System.Drawing.Size(994, 574);
            this.dataGridViewDetail.TabIndex = 0;
            // 
            // EditTime
            // 
            this.EditTime.DataPropertyName = "EditTime";
            this.EditTime.HeaderText = "修改时间";
            this.EditTime.Name = "EditTime";
            this.EditTime.ReadOnly = true;
            this.EditTime.Width = 140;
            // 
            // Random
            // 
            this.Random.DataPropertyName = "Random";
            this.Random.HeaderText = "Random";
            this.Random.Name = "Random";
            this.Random.ReadOnly = true;
            this.Random.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "修改人";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 80;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 60;
            // 
            // Module
            // 
            this.Module.DataPropertyName = "Module";
            this.Module.HeaderText = "模块";
            this.Module.Name = "Module";
            this.Module.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "表名";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            this.TableName.Width = 200;
            // 
            // Field
            // 
            this.Field.DataPropertyName = "Field";
            this.Field.HeaderText = "字段";
            this.Field.Name = "Field";
            this.Field.ReadOnly = true;
            this.Field.Width = 80;
            // 
            // OldValue
            // 
            this.OldValue.DataPropertyName = "OldValue";
            this.OldValue.HeaderText = "原值";
            this.OldValue.Name = "OldValue";
            this.OldValue.ReadOnly = true;
            this.OldValue.Width = 140;
            // 
            // NewValue
            // 
            this.NewValue.DataPropertyName = "NewValue";
            this.NewValue.HeaderText = "新值";
            this.NewValue.Name = "NewValue";
            this.NewValue.ReadOnly = true;
            this.NewValue.Width = 140;
            // 
            // Col1
            // 
            this.Col1.DataPropertyName = "Col1";
            this.Col1.HeaderText = "参数一";
            this.Col1.Name = "Col1";
            this.Col1.ReadOnly = true;
            this.Col1.Visible = false;
            // 
            // Col2
            // 
            this.Col2.DataPropertyName = "Col2";
            this.Col2.HeaderText = "参数二";
            this.Col2.Name = "Col2";
            this.Col2.ReadOnly = true;
            this.Col2.Visible = false;
            // 
            // Col3
            // 
            this.Col3.DataPropertyName = "Col3";
            this.Col3.HeaderText = "参数三";
            this.Col3.Name = "Col3";
            this.Col3.ReadOnly = true;
            this.Col3.Visible = false;
            // 
            // Col4
            // 
            this.Col4.DataPropertyName = "Col4";
            this.Col4.HeaderText = "参数四";
            this.Col4.Name = "Col4";
            this.Col4.ReadOnly = true;
            this.Col4.Visible = false;
            // 
            // Col5
            // 
            this.Col5.DataPropertyName = "Col5";
            this.Col5.HeaderText = "参数五";
            this.Col5.Name = "Col5";
            this.Col5.ReadOnly = true;
            this.Col5.Visible = false;
            // 
            // Col6
            // 
            this.Col6.DataPropertyName = "Col6";
            this.Col6.HeaderText = "参数六";
            this.Col6.Name = "Col6";
            this.Col6.ReadOnly = true;
            this.Col6.Visible = false;
            // 
            // ColField
            // 
            this.ColField.DataPropertyName = "ColField";
            this.ColField.HeaderText = "参数字段";
            this.ColField.Name = "ColField";
            this.ColField.ReadOnly = true;
            this.ColField.Visible = false;
            // 
            // DataHistoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 574);
            this.Controls.Add(this.dataGridViewDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataHistoryDetail";
            this.Text = "数据维护明细";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColField;
    }
}