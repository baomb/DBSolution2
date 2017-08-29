namespace DBSolution
{
    partial class ControlPanel
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
            this.labelRole = new System.Windows.Forms.Label();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.labelNew = new System.Windows.Forms.Label();
            this.textBoxConfirm = new System.Windows.Forms.TextBox();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxOld = new System.Windows.Forms.TextBox();
            this.labelOld = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(49, 22);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(65, 12);
            this.labelRole.TabIndex = 1;
            this.labelRole.Text = "您的用户组";
            // 
            // textBoxRole
            // 
            this.textBoxRole.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRole.Location = new System.Drawing.Point(131, 19);
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.ReadOnly = true;
            this.textBoxRole.Size = new System.Drawing.Size(147, 21);
            this.textBoxRole.TabIndex = 0;
            // 
            // textBoxNew
            // 
            this.textBoxNew.Location = new System.Drawing.Point(106, 72);
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.Size = new System.Drawing.Size(147, 21);
            this.textBoxNew.TabIndex = 20;
            this.textBoxNew.UseSystemPasswordChar = true;
            // 
            // labelNew
            // 
            this.labelNew.AutoSize = true;
            this.labelNew.Location = new System.Drawing.Point(36, 75);
            this.labelNew.Name = "labelNew";
            this.labelNew.Size = new System.Drawing.Size(41, 12);
            this.labelNew.TabIndex = 3;
            this.labelNew.Text = "新密码";
            // 
            // textBoxConfirm
            // 
            this.textBoxConfirm.Location = new System.Drawing.Point(106, 106);
            this.textBoxConfirm.Name = "textBoxConfirm";
            this.textBoxConfirm.Size = new System.Drawing.Size(147, 21);
            this.textBoxConfirm.TabIndex = 30;
            this.textBoxConfirm.UseSystemPasswordChar = true;
            // 
            // labelConfirm
            // 
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Location = new System.Drawing.Point(36, 109);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(53, 12);
            this.labelConfirm.TabIndex = 5;
            this.labelConfirm.Text = "确认密码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxOld);
            this.groupBox1.Controls.Add(this.labelOld);
            this.groupBox1.Controls.Add(this.buttonChange);
            this.groupBox1.Controls.Add(this.textBoxNew);
            this.groupBox1.Controls.Add(this.textBoxConfirm);
            this.groupBox1.Controls.Add(this.labelNew);
            this.groupBox1.Controls.Add(this.labelConfirm);
            this.groupBox1.Location = new System.Drawing.Point(25, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 178);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改密码";
            // 
            // textBoxOld
            // 
            this.textBoxOld.Location = new System.Drawing.Point(106, 38);
            this.textBoxOld.Name = "textBoxOld";
            this.textBoxOld.Size = new System.Drawing.Size(147, 21);
            this.textBoxOld.TabIndex = 10;
            this.textBoxOld.UseSystemPasswordChar = true;
            // 
            // labelOld
            // 
            this.labelOld.AutoSize = true;
            this.labelOld.Location = new System.Drawing.Point(36, 41);
            this.labelOld.Name = "labelOld";
            this.labelOld.Size = new System.Drawing.Size(41, 12);
            this.labelOld.TabIndex = 9;
            this.labelOld.Text = "旧密码";
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(106, 141);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 40;
            this.buttonChange.Text = "修改密码";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(131, 254);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 50;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 287);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxRole);
            this.Controls.Add(this.labelRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlPanel";
            this.ShowIcon = false;
            this.Text = "用户控制面板";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.TextBox textBoxRole;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.Label labelNew;
        private System.Windows.Forms.TextBox textBoxConfirm;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxOld;
        private System.Windows.Forms.Label labelOld;

    }
}