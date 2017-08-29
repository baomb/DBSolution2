namespace DBSolution
{
    partial class StorageType
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
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TYPEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPEDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DELETE,
            this.TYPEID,
            this.TYPENAME,
            this.TYPEDESC});
            this.dataGridViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewDetails.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(389, 221);
            this.dataGridViewDetails.TabIndex = 0;
            this.dataGridViewDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetails_CellContentClick);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(93, 230);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(220, 230);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // DELETE
            // 
            this.DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETE.HeaderText = "";
            this.DELETE.Name = "DELETE";
            this.DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DELETE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DELETE.Text = "删除";
            this.DELETE.UseColumnTextForButtonValue = true;
            this.DELETE.Width = 60;
            // 
            // TYPEID
            // 
            this.TYPEID.DataPropertyName = "TYPEID";
            this.TYPEID.HeaderText = "排序";
            this.TYPEID.Name = "TYPEID";
            this.TYPEID.Width = 80;
            // 
            // TYPENAME
            // 
            this.TYPENAME.DataPropertyName = "TYPENAME";
            this.TYPENAME.HeaderText = "仓储类型";
            this.TYPENAME.Name = "TYPENAME";
            this.TYPENAME.Width = 80;
            // 
            // TYPEDESC
            // 
            this.TYPEDESC.DataPropertyName = "TYPEDESC";
            this.TYPEDESC.HeaderText = "说明";
            this.TYPEDESC.Name = "TYPEDESC";
            // 
            // StorageType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 260);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageType";
            this.Text = "仓储类型维护";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPEDESC;
    }
}