namespace DBSolution
{
    partial class ExcelProgressBar
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
            this.Progresslabel = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Progresslabel
            // 
            this.Progresslabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Progresslabel.Location = new System.Drawing.Point(12, 27);
            this.Progresslabel.Name = "Progresslabel";
            this.Progresslabel.Size = new System.Drawing.Size(269, 23);
            this.Progresslabel.TabIndex = 1;
            this.Progresslabel.Text = "正在导出数据到Excel。。。";
            // 
            // labelSuccess
            // 
            this.labelSuccess.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSuccess.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelSuccess.Location = new System.Drawing.Point(12, 63);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(269, 23);
            this.labelSuccess.TabIndex = 2;
            this.labelSuccess.Text = "导出完成";
            this.labelSuccess.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(183, 89);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 29);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "确  定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ExcelProgressBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(293, 147);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.Progresslabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExcelProgressBar";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "progressBar";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Progresslabel;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Button buttonOK;
    }
}