namespace DBSolution
{
    partial class FinishedProSaleSearchDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishedProSaleSearchDetail));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxCondition = new System.Windows.Forms.GroupBox();
            this.textBoxTrayQuantity = new System.Windows.Forms.TextBox();
            this.labelTrayQuantity = new System.Windows.Forms.Label();
            this.textBoxTrayWeight = new System.Windows.Forms.TextBox();
            this.labelTrayWeight = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNetValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxExitWeignMan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTare = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGross = new System.Windows.Forms.TextBox();
            this.textBoxExitTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEnterTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxWerks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textWeighMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textTruckNum = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.VBELN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KUNNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LFIMG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZFIMG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REALZFIMG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LGORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNOTE = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxCondition.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButtonQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(856, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonQuit
            // 
            this.toolStripButtonQuit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQuit.Image")));
            this.toolStripButtonQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuit.Name = "toolStripButtonQuit";
            this.toolStripButtonQuit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQuit.Text = "退出";
            this.toolStripButtonQuit.Click += new System.EventHandler(this.toolStripButtonQuit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxCondition);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 126);
            this.panel1.TabIndex = 9;
            // 
            // groupBoxCondition
            // 
            this.groupBoxCondition.Controls.Add(this.label10);
            this.groupBoxCondition.Controls.Add(this.textBoxNOTE);
            this.groupBoxCondition.Controls.Add(this.textBoxTrayQuantity);
            this.groupBoxCondition.Controls.Add(this.labelTrayQuantity);
            this.groupBoxCondition.Controls.Add(this.textBoxTrayWeight);
            this.groupBoxCondition.Controls.Add(this.labelTrayWeight);
            this.groupBoxCondition.Controls.Add(this.label9);
            this.groupBoxCondition.Controls.Add(this.txtNetValue);
            this.groupBoxCondition.Controls.Add(this.label8);
            this.groupBoxCondition.Controls.Add(this.textBoxExitWeignMan);
            this.groupBoxCondition.Controls.Add(this.label7);
            this.groupBoxCondition.Controls.Add(this.textBoxTare);
            this.groupBoxCondition.Controls.Add(this.label6);
            this.groupBoxCondition.Controls.Add(this.textBoxGross);
            this.groupBoxCondition.Controls.Add(this.textBoxExitTime);
            this.groupBoxCondition.Controls.Add(this.label2);
            this.groupBoxCondition.Controls.Add(this.textBoxEnterTime);
            this.groupBoxCondition.Controls.Add(this.label4);
            this.groupBoxCondition.Controls.Add(this.textBoxWerks);
            this.groupBoxCondition.Controls.Add(this.label3);
            this.groupBoxCondition.Controls.Add(this.label5);
            this.groupBoxCondition.Controls.Add(this.textWeighMan);
            this.groupBoxCondition.Controls.Add(this.label1);
            this.groupBoxCondition.Controls.Add(this.textTruckNum);
            this.groupBoxCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCondition.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCondition.Name = "groupBoxCondition";
            this.groupBoxCondition.Size = new System.Drawing.Size(835, 126);
            this.groupBoxCondition.TabIndex = 0;
            this.groupBoxCondition.TabStop = false;
            this.groupBoxCondition.Text = "详细信息";
            // 
            // textBoxTrayQuantity
            // 
            this.textBoxTrayQuantity.Location = new System.Drawing.Point(245, 95);
            this.textBoxTrayQuantity.Name = "textBoxTrayQuantity";
            this.textBoxTrayQuantity.ReadOnly = true;
            this.textBoxTrayQuantity.Size = new System.Drawing.Size(100, 21);
            this.textBoxTrayQuantity.TabIndex = 61;
            // 
            // labelTrayQuantity
            // 
            this.labelTrayQuantity.AutoSize = true;
            this.labelTrayQuantity.Location = new System.Drawing.Point(180, 98);
            this.labelTrayQuantity.Name = "labelTrayQuantity";
            this.labelTrayQuantity.Size = new System.Drawing.Size(59, 12);
            this.labelTrayQuantity.TabIndex = 60;
            this.labelTrayQuantity.Text = "托盘数量:";
            // 
            // textBoxTrayWeight
            // 
            this.textBoxTrayWeight.Location = new System.Drawing.Point(72, 94);
            this.textBoxTrayWeight.Name = "textBoxTrayWeight";
            this.textBoxTrayWeight.ReadOnly = true;
            this.textBoxTrayWeight.Size = new System.Drawing.Size(100, 21);
            this.textBoxTrayWeight.TabIndex = 59;
            // 
            // labelTrayWeight
            // 
            this.labelTrayWeight.AutoSize = true;
            this.labelTrayWeight.Location = new System.Drawing.Point(7, 98);
            this.labelTrayWeight.Name = "labelTrayWeight";
            this.labelTrayWeight.Size = new System.Drawing.Size(59, 12);
            this.labelTrayWeight.TabIndex = 58;
            this.labelTrayWeight.Text = "托盘标重:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(705, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "净重:";
            // 
            // txtNetValue
            // 
            this.txtNetValue.Location = new System.Drawing.Point(746, 28);
            this.txtNetValue.Name = "txtNetValue";
            this.txtNetValue.ReadOnly = true;
            this.txtNetValue.Size = new System.Drawing.Size(70, 21);
            this.txtNetValue.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(534, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "出厂司榜员:";
            // 
            // textBoxExitWeignMan
            // 
            this.textBoxExitWeignMan.Location = new System.Drawing.Point(611, 61);
            this.textBoxExitWeignMan.Name = "textBoxExitWeignMan";
            this.textBoxExitWeignMan.ReadOnly = true;
            this.textBoxExitWeignMan.Size = new System.Drawing.Size(71, 21);
            this.textBoxExitWeignMan.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(569, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "皮重:";
            // 
            // textBoxTare
            // 
            this.textBoxTare.Location = new System.Drawing.Point(610, 28);
            this.textBoxTare.Name = "textBoxTare";
            this.textBoxTare.ReadOnly = true;
            this.textBoxTare.Size = new System.Drawing.Size(72, 21);
            this.textBoxTare.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "毛重:";
            // 
            // textBoxGross
            // 
            this.textBoxGross.Location = new System.Drawing.Point(428, 28);
            this.textBoxGross.Name = "textBoxGross";
            this.textBoxGross.ReadOnly = true;
            this.textBoxGross.Size = new System.Drawing.Size(100, 21);
            this.textBoxGross.TabIndex = 26;
            // 
            // textBoxExitTime
            // 
            this.textBoxExitTime.Location = new System.Drawing.Point(245, 61);
            this.textBoxExitTime.Name = "textBoxExitTime";
            this.textBoxExitTime.ReadOnly = true;
            this.textBoxExitTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxExitTime.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "出厂时间:";
            // 
            // textBoxEnterTime
            // 
            this.textBoxEnterTime.Location = new System.Drawing.Point(72, 61);
            this.textBoxEnterTime.Name = "textBoxEnterTime";
            this.textBoxEnterTime.ReadOnly = true;
            this.textBoxEnterTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxEnterTime.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "工 厂:";
            // 
            // textBoxWerks
            // 
            this.textBoxWerks.Location = new System.Drawing.Point(72, 26);
            this.textBoxWerks.Name = "textBoxWerks";
            this.textBoxWerks.ReadOnly = true;
            this.textBoxWerks.Size = new System.Drawing.Size(100, 21);
            this.textBoxWerks.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "进厂时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "进厂司榜员:";
            // 
            // textWeighMan
            // 
            this.textWeighMan.Location = new System.Drawing.Point(428, 60);
            this.textWeighMan.Name = "textWeighMan";
            this.textWeighMan.ReadOnly = true;
            this.textWeighMan.Size = new System.Drawing.Size(100, 21);
            this.textWeighMan.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "车牌号:";
            // 
            // textTruckNum
            // 
            this.textTruckNum.Location = new System.Drawing.Point(245, 26);
            this.textTruckNum.Name = "textTruckNum";
            this.textTruckNum.ReadOnly = true;
            this.textTruckNum.Size = new System.Drawing.Size(100, 21);
            this.textTruckNum.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.dataGridViewDetail);
            this.panel3.Location = new System.Drawing.Point(12, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 324);
            this.panel3.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(520, -41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VBELN,
            this.KUNNR,
            this.NAME1,
            this.POSNR,
            this.MATNR,
            this.MAKTX,
            this.LFIMG,
            this.ZFIMG,
            this.REALZFIMG,
            this.LGORT});
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.Size = new System.Drawing.Size(835, 324);
            this.dataGridViewDetail.TabIndex = 0;
            // 
            // VBELN
            // 
            this.VBELN.DataPropertyName = "VBELN";
            this.VBELN.HeaderText = "交货单";
            this.VBELN.Name = "VBELN";
            // 
            // KUNNR
            // 
            this.KUNNR.DataPropertyName = "KUNNR";
            this.KUNNR.HeaderText = "客户编码";
            this.KUNNR.Name = "KUNNR";
            // 
            // NAME1
            // 
            this.NAME1.DataPropertyName = "NAME1";
            this.NAME1.HeaderText = "客户名称";
            this.NAME1.Name = "NAME1";
            // 
            // POSNR
            // 
            this.POSNR.DataPropertyName = "POSNR";
            this.POSNR.HeaderText = "交货项目";
            this.POSNR.Name = "POSNR";
            // 
            // MATNR
            // 
            this.MATNR.DataPropertyName = "MATNR";
            this.MATNR.HeaderText = "物料编码";
            this.MATNR.Name = "MATNR";
            // 
            // MAKTX
            // 
            this.MAKTX.DataPropertyName = "MAKTX";
            this.MAKTX.HeaderText = "物料描述";
            this.MAKTX.Name = "MAKTX";
            // 
            // LFIMG
            // 
            this.LFIMG.DataPropertyName = "LFIMG";
            this.LFIMG.HeaderText = "原发吨数";
            this.LFIMG.Name = "LFIMG";
            // 
            // ZFIMG
            // 
            this.ZFIMG.DataPropertyName = "ZFIMG";
            this.ZFIMG.HeaderText = "原发件数";
            this.ZFIMG.Name = "ZFIMG";
            // 
            // REALZFIMG
            // 
            this.REALZFIMG.DataPropertyName = "REALZFIMG";
            this.REALZFIMG.HeaderText = "实发件数";
            this.REALZFIMG.Name = "REALZFIMG";
            // 
            // LGORT
            // 
            this.LGORT.DataPropertyName = "LGORT";
            this.LGORT.HeaderText = "库存地";
            this.LGORT.Name = "LGORT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(375, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "备  注:";
            // 
            // textBoxNOTE
            // 
            this.textBoxNOTE.Location = new System.Drawing.Point(428, 95);
            this.textBoxNOTE.Name = "textBoxNOTE";
            this.textBoxNOTE.ReadOnly = true;
            this.textBoxNOTE.Size = new System.Drawing.Size(100, 21);
            this.textBoxNOTE.TabIndex = 62;
            // 
            // FinishedProSaleSearchDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(856, 489);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FinishedProSaleSearchDetail";
            this.Text = "产出品销售详细信息";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxCondition.ResumeLayout(false);
            this.groupBoxCondition.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textWeighMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTruckNum;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxWerks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEnterTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn VBELN;
        private System.Windows.Forms.DataGridViewTextBoxColumn KUNNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LFIMG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZFIMG;
        private System.Windows.Forms.DataGridViewTextBoxColumn REALZFIMG;
        private System.Windows.Forms.DataGridViewTextBoxColumn LGORT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxExitWeignMan;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNetValue;
        private System.Windows.Forms.TextBox textBoxTrayQuantity;
        private System.Windows.Forms.Label labelTrayQuantity;
        private System.Windows.Forms.TextBox textBoxTrayWeight;
        private System.Windows.Forms.Label labelTrayWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxNOTE;
    }
}