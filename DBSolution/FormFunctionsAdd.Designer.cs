namespace DBSolution
{
    partial class FormFunctionsAdd
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
            this.pnlFunctionAdd = new System.Windows.Forms.Panel();
            this.cmbFunctionParent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFunctionKey = new System.Windows.Forms.TextBox();
            this.lbFunctionKey = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbFunctionName = new System.Windows.Forms.TextBox();
            this.lbFunctionName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFunctionAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFunctionAdd
            // 
            this.pnlFunctionAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFunctionAdd.Controls.Add(this.cmbFunctionParent);
            this.pnlFunctionAdd.Controls.Add(this.label1);
            this.pnlFunctionAdd.Controls.Add(this.tbFunctionKey);
            this.pnlFunctionAdd.Controls.Add(this.lbFunctionKey);
            this.pnlFunctionAdd.Controls.Add(this.tbDescription);
            this.pnlFunctionAdd.Controls.Add(this.lbDescription);
            this.pnlFunctionAdd.Controls.Add(this.tbFunctionName);
            this.pnlFunctionAdd.Controls.Add(this.lbFunctionName);
            this.pnlFunctionAdd.Controls.Add(this.btnCancel);
            this.pnlFunctionAdd.Controls.Add(this.btnSave);
            this.pnlFunctionAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFunctionAdd.Location = new System.Drawing.Point(0, 0);
            this.pnlFunctionAdd.Name = "pnlFunctionAdd";
            this.pnlFunctionAdd.Size = new System.Drawing.Size(312, 217);
            this.pnlFunctionAdd.TabIndex = 1;
            // 
            // cmbFunctionParent
            // 
            this.cmbFunctionParent.Enabled = false;
            this.cmbFunctionParent.FormattingEnabled = true;
            this.cmbFunctionParent.Location = new System.Drawing.Point(80, 74);
            this.cmbFunctionParent.Name = "cmbFunctionParent";
            this.cmbFunctionParent.Size = new System.Drawing.Size(203, 20);
            this.cmbFunctionParent.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "上    级";
            // 
            // tbFunctionKey
            // 
            this.tbFunctionKey.Location = new System.Drawing.Point(80, 47);
            this.tbFunctionKey.Name = "tbFunctionKey";
            this.tbFunctionKey.Size = new System.Drawing.Size(203, 21);
            this.tbFunctionKey.TabIndex = 13;
            // 
            // lbFunctionKey
            // 
            this.lbFunctionKey.AutoSize = true;
            this.lbFunctionKey.Location = new System.Drawing.Point(21, 50);
            this.lbFunctionKey.Name = "lbFunctionKey";
            this.lbFunctionKey.Size = new System.Drawing.Size(53, 12);
            this.lbFunctionKey.TabIndex = 12;
            this.lbFunctionKey.Text = "功能键值";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(80, 102);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(203, 67);
            this.tbDescription.TabIndex = 11;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(21, 119);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(53, 12);
            this.lbDescription.TabIndex = 10;
            this.lbDescription.Text = "功能描述";
            // 
            // tbFunctionName
            // 
            this.tbFunctionName.Location = new System.Drawing.Point(80, 16);
            this.tbFunctionName.Name = "tbFunctionName";
            this.tbFunctionName.Size = new System.Drawing.Size(203, 21);
            this.tbFunctionName.TabIndex = 9;
            // 
            // lbFunctionName
            // 
            this.lbFunctionName.AutoSize = true;
            this.lbFunctionName.Location = new System.Drawing.Point(21, 19);
            this.lbFunctionName.Name = "lbFunctionName";
            this.lbFunctionName.Size = new System.Drawing.Size(53, 12);
            this.lbFunctionName.TabIndex = 8;
            this.lbFunctionName.Text = "功能名称";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(81, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormFunctionsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 217);
            this.Controls.Add(this.pnlFunctionAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFunctionsAdd";
            this.Text = "FormFunctionsAdd";
            this.Load += new System.EventHandler(this.FormFunctionsAdd_Load);
            this.pnlFunctionAdd.ResumeLayout(false);
            this.pnlFunctionAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFunctionAdd;
        private System.Windows.Forms.TextBox tbFunctionKey;
        private System.Windows.Forms.Label lbFunctionKey;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbFunctionName;
        private System.Windows.Forms.Label lbFunctionName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbFunctionParent;
        private System.Windows.Forms.Label label1;
    }
}