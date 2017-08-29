namespace DBSolution
{
    partial class HouseKeeperManage
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewLgort = new System.Windows.Forms.DataGridView();
            this.werks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lgort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lgobe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.house_keeper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLgort)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-2, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewLgort);
            this.splitContainer1.Size = new System.Drawing.Size(647, 371);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(249, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelTitle.Size = new System.Drawing.Size(135, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "库管员维护";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewLgort
            // 
            this.dataGridViewLgort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLgort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.werks,
            this.lgort,
            this.lgobe,
            this.house_keeper});
            this.dataGridViewLgort.Location = new System.Drawing.Point(0, 3);
            this.dataGridViewLgort.Name = "dataGridViewLgort";
            this.dataGridViewLgort.RowTemplate.Height = 23;
            this.dataGridViewLgort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewLgort.Size = new System.Drawing.Size(656, 354);
            this.dataGridViewLgort.TabIndex = 0;
            // 
            // werks
            // 
            this.werks.DataPropertyName = "werks";
            this.werks.HeaderText = "工厂编码";
            this.werks.Name = "werks";
            this.werks.ReadOnly = true;
            this.werks.Width = 150;
            // 
            // lgort
            // 
            this.lgort.DataPropertyName = "lgort";
            this.lgort.HeaderText = "库存编码";
            this.lgort.Name = "lgort";
            this.lgort.ReadOnly = true;
            this.lgort.Width = 151;
            // 
            // lgobe
            // 
            this.lgobe.DataPropertyName = "lgobe";
            this.lgobe.HeaderText = "库存名称";
            this.lgobe.Name = "lgobe";
            this.lgobe.ReadOnly = true;
            this.lgobe.Width = 150;
            // 
            // house_keeper
            // 
            this.house_keeper.DataPropertyName = "house_keeper";
            this.house_keeper.HeaderText = "库管员";
            this.house_keeper.Name = "house_keeper";
            this.house_keeper.Width = 150;
            // 
            // HouseKeeperManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 393);
            this.Controls.Add(this.splitContainer1);
            this.Name = "HouseKeeperManage";
            this.Text = "HouseKeeperManage";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLgort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewLgort;
        private System.Windows.Forms.DataGridViewTextBoxColumn werks;
        private System.Windows.Forms.DataGridViewTextBoxColumn lgort;
        private System.Windows.Forms.DataGridViewTextBoxColumn lgobe;
        private System.Windows.Forms.DataGridViewTextBoxColumn house_keeper;
    }
}