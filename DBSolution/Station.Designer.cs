namespace DBSolution
{
    partial class Station
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BUKRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATIONDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(345, 304);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(174, 304);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.AllowUserToOrderColumns = true;
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DELETE,
            this.BUKRS,
            this.CITY,
            this.STAT,
            this.STATIONDESC});
            this.dataGridViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewDetails.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(594, 298);
            this.dataGridViewDetails.TabIndex = 3;
            this.dataGridViewDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetails_CellContentClick);
            // 
            // DELETE
            // 
            this.DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETE.HeaderText = "";
            this.DELETE.Name = "DELETE";
            this.DELETE.Text = "删除";
            this.DELETE.UseColumnTextForButtonValue = true;
            this.DELETE.Width = 50;
            // 
            // BUKRS
            // 
            this.BUKRS.DataPropertyName = "BUKRS";
            this.BUKRS.HeaderText = "公司代码";
            this.BUKRS.Name = "BUKRS";
            // 
            // CITY
            // 
            this.CITY.DataPropertyName = "CITY";
            this.CITY.HeaderText = "工厂地区";
            this.CITY.Name = "CITY";
            // 
            // STAT
            // 
            this.STAT.DataPropertyName = "STATION";
            this.STAT.HeaderText = "站点";
            this.STAT.Name = "STAT";
            // 
            // STATIONDESC
            // 
            this.STATIONDESC.DataPropertyName = "STATIONDESC";
            this.STATIONDESC.HeaderText = "文本";
            this.STATIONDESC.Name = "STATIONDESC";
            this.STATIONDESC.Width = 180;
            // 
            // Station
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 334);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Station";
            this.Text = "卸货站点维护";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUKRS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATIONDESC;
    }
}