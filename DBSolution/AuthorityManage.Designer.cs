namespace DBSolution
{
    partial class AuthorityManage
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewMember = new System.Windows.Forms.DataGridView();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.checkBoxDibang = new System.Windows.Forms.CheckBox();
            this.checkBoxKuguan = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMember)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(201, 406);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(314, 406);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMember
            // 
            this.dataGridViewMember.AllowUserToAddRows = false;
            this.dataGridViewMember.AllowUserToDeleteRows = false;
            this.dataGridViewMember.AllowUserToOrderColumns = true;
            this.dataGridViewMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewMember.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMember.MultiSelect = false;
            this.dataGridViewMember.Name = "dataGridViewMember";
            this.dataGridViewMember.ReadOnly = true;
            this.dataGridViewMember.RowTemplate.Height = 23;
            this.dataGridViewMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMember.Size = new System.Drawing.Size(591, 368);
            this.dataGridViewMember.TabIndex = 2;
            this.dataGridViewMember.SelectionChanged += new System.EventHandler(this.dataGridViewMember_SelectionChanged);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(121, 381);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(60, 16);
            this.checkBoxAdmin.TabIndex = 3;
            this.checkBoxAdmin.Text = "管理员";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBoxDibang
            // 
            this.checkBoxDibang.AutoSize = true;
            this.checkBoxDibang.Location = new System.Drawing.Point(255, 381);
            this.checkBoxDibang.Name = "checkBoxDibang";
            this.checkBoxDibang.Size = new System.Drawing.Size(72, 16);
            this.checkBoxDibang.TabIndex = 4;
            this.checkBoxDibang.Text = "地磅用户";
            this.checkBoxDibang.UseVisualStyleBackColor = true;
            // 
            // checkBoxKuguan
            // 
            this.checkBoxKuguan.AutoSize = true;
            this.checkBoxKuguan.Location = new System.Drawing.Point(391, 381);
            this.checkBoxKuguan.Name = "checkBoxKuguan";
            this.checkBoxKuguan.Size = new System.Drawing.Size(48, 16);
            this.checkBoxKuguan.TabIndex = 5;
            this.checkBoxKuguan.Text = "库管";
            this.checkBoxKuguan.UseVisualStyleBackColor = true;
            // 
            // AuthorityManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(591, 437);
            this.Controls.Add(this.checkBoxKuguan);
            this.Controls.Add(this.checkBoxDibang);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.dataGridViewMember);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorityManage";
            this.ShowIcon = false;
            this.Text = "权限管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewMember;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.CheckBox checkBoxDibang;
        private System.Windows.Forms.CheckBox checkBoxKuguan;
    }
}