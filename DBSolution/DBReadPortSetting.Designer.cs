namespace DBSolution
{
    partial class DBReadPortSetting
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
            this.chkReadFlag = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkReadFlag
            // 
            this.chkReadFlag.AutoSize = true;
            this.chkReadFlag.Location = new System.Drawing.Point(63, 23);
            this.chkReadFlag.Name = "chkReadFlag";
            this.chkReadFlag.Size = new System.Drawing.Size(108, 16);
            this.chkReadFlag.TabIndex = 0;
            this.chkReadFlag.Text = "数据是否读串口";
            this.chkReadFlag.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(192, 16);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "修 改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // textBoxPrompt
            // 
            this.textBoxPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrompt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPrompt.Location = new System.Drawing.Point(48, 56);
            this.textBoxPrompt.Multiline = true;
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.Size = new System.Drawing.Size(248, 121);
            this.textBoxPrompt.TabIndex = 2;
            this.textBoxPrompt.Text = "本功能用户地磅异常情况的补录，如遇到停电等情况，管理员可以打开此功能，此时地磅数据不再从串口读入，需手工录入过账";
            // 
            // DBReadPortSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(363, 195);
            this.Controls.Add(this.textBoxPrompt);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkReadFlag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DBReadPortSetting";
            this.Text = "地磅串口设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkReadFlag;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox textBoxPrompt;
    }
}