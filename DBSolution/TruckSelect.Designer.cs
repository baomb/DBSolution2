namespace DBSolution
{
    partial class TruckSelect
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
            this.dataGridViewTruckSelect = new System.Windows.Forms.DataGridView();
            this.btnCose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTruckSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTruckSelect
            // 
            this.dataGridViewTruckSelect.AllowUserToAddRows = false;
            this.dataGridViewTruckSelect.AllowUserToDeleteRows = false;
            this.dataGridViewTruckSelect.AllowUserToOrderColumns = true;
            this.dataGridViewTruckSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTruckSelect.ColumnHeadersHeight = 28;
            this.dataGridViewTruckSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTruckSelect.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTruckSelect.MultiSelect = false;
            this.dataGridViewTruckSelect.Name = "dataGridViewTruckSelect";
            this.dataGridViewTruckSelect.ReadOnly = true;
            this.dataGridViewTruckSelect.RowTemplate.Height = 28;
            this.dataGridViewTruckSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTruckSelect.Size = new System.Drawing.Size(974, 574);
            this.dataGridViewTruckSelect.TabIndex = 0;
            this.dataGridViewTruckSelect.DoubleClick += new System.EventHandler(this.dataGridViewTruckSelect_DoubleClick);
            // 
            // btnCose
            // 
            this.btnCose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCose.Location = new System.Drawing.Point(419, 271);
            this.btnCose.Name = "btnCose";
            this.btnCose.Size = new System.Drawing.Size(75, 23);
            this.btnCose.TabIndex = 1;
            this.btnCose.Text = "关闭";
            this.btnCose.UseVisualStyleBackColor = true;
            this.btnCose.Click += new System.EventHandler(this.btnCose_Click);
            // 
            // TruckSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCose;
            this.ClientSize = new System.Drawing.Size(974, 574);
            this.Controls.Add(this.dataGridViewTruckSelect);
            this.Controls.Add(this.btnCose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TruckSelect";
            this.Text = "请选择车牌号";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTruckSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTruckSelect;
        private System.Windows.Forms.Button btnCose;
    }
}