namespace DBSolution
{
    partial class RawMaterialsSaleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawMaterialsSaleDetails));
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.POSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KUNNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFIMG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REALZFIMG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PWEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LGORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxCondition = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxDiff = new System.Windows.Forms.TextBox();
            this.textBoxEXFlag = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxHSFlag = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxEXWeighMan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTruckNum = new System.Windows.Forms.TextBox();
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
            this.textEBELN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxCondition.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POSNR,
            this.MATNR,
            this.MAKTX,
            this.KUNNR,
            this.NAME1,
            this.SFIMG,
            this.REALZFIMG,
            this.PWEIGHT,
            this.LGORT});
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.Size = new System.Drawing.Size(1004, 360);
            this.dataGridViewDetail.TabIndex = 0;
            // 
            // POSNR
            // 
            this.POSNR.DataPropertyName = "POSNR";
            this.POSNR.HeaderText = "行项目";
            this.POSNR.Name = "POSNR";
            this.POSNR.ReadOnly = true;
            // 
            // MATNR
            // 
            this.MATNR.DataPropertyName = "MATNR";
            this.MATNR.HeaderText = "物料编码";
            this.MATNR.Name = "MATNR";
            this.MATNR.ReadOnly = true;
            // 
            // MAKTX
            // 
            this.MAKTX.DataPropertyName = "MAKTX";
            this.MAKTX.HeaderText = "物料描述";
            this.MAKTX.Name = "MAKTX";
            this.MAKTX.ReadOnly = true;
            // 
            // KUNNR
            // 
            this.KUNNR.DataPropertyName = "KUNNR";
            this.KUNNR.HeaderText = "客户编码";
            this.KUNNR.Name = "KUNNR";
            this.KUNNR.ReadOnly = true;
            // 
            // NAME1
            // 
            this.NAME1.DataPropertyName = "NAME1";
            this.NAME1.HeaderText = "客户名称";
            this.NAME1.Name = "NAME1";
            this.NAME1.ReadOnly = true;
            // 
            // SFIMG
            // 
            this.SFIMG.DataPropertyName = "SFIMG";
            this.SFIMG.HeaderText = "实发吨数";
            this.SFIMG.Name = "SFIMG";
            this.SFIMG.ReadOnly = true;
            // 
            // REALZFIMG
            // 
            this.REALZFIMG.DataPropertyName = "REALZFIMG";
            this.REALZFIMG.HeaderText = "实发件数";
            this.REALZFIMG.Name = "REALZFIMG";
            this.REALZFIMG.ReadOnly = true;
            // 
            // PWEIGHT
            // 
            this.PWEIGHT.DataPropertyName = "PWEIGHT";
            this.PWEIGHT.HeaderText = "包重";
            this.PWEIGHT.Name = "PWEIGHT";
            this.PWEIGHT.ReadOnly = true;
            // 
            // LGORT
            // 
            this.LGORT.DataPropertyName = "LGORT";
            this.LGORT.HeaderText = "仓库";
            this.LGORT.Name = "LGORT";
            this.LGORT.ReadOnly = true;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.labelTitle.Location = new System.Drawing.Point(16, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(212, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "史丹利原材料销售详细信息";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 360);
            this.panel3.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 30);
            this.panel2.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxCondition);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 132);
            this.panel1.TabIndex = 19;
            // 
            // groupBoxCondition
            // 
            this.groupBoxCondition.Controls.Add(this.label13);
            this.groupBoxCondition.Controls.Add(this.textBoxDiff);
            this.groupBoxCondition.Controls.Add(this.textBoxEXFlag);
            this.groupBoxCondition.Controls.Add(this.label12);
            this.groupBoxCondition.Controls.Add(this.textBoxHSFlag);
            this.groupBoxCondition.Controls.Add(this.label10);
            this.groupBoxCondition.Controls.Add(this.label11);
            this.groupBoxCondition.Controls.Add(this.textBoxEXWeighMan);
            this.groupBoxCondition.Controls.Add(this.label9);
            this.groupBoxCondition.Controls.Add(this.textBoxNet);
            this.groupBoxCondition.Controls.Add(this.label8);
            this.groupBoxCondition.Controls.Add(this.textBoxTruckNum);
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
            this.groupBoxCondition.Controls.Add(this.textEBELN);
            this.groupBoxCondition.Location = new System.Drawing.Point(20, 12);
            this.groupBoxCondition.Name = "groupBoxCondition";
            this.groupBoxCondition.Size = new System.Drawing.Size(962, 103);
            this.groupBoxCondition.TabIndex = 0;
            this.groupBoxCondition.TabStop = false;
            this.groupBoxCondition.Text = "订单信息";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(588, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 71;
            this.label13.Text = "差异";
            // 
            // textBoxDiff
            // 
            this.textBoxDiff.Location = new System.Drawing.Point(632, 46);
            this.textBoxDiff.Name = "textBoxDiff";
            this.textBoxDiff.ReadOnly = true;
            this.textBoxDiff.Size = new System.Drawing.Size(100, 21);
            this.textBoxDiff.TabIndex = 70;
            // 
            // textBoxEXFlag
            // 
            this.textBoxEXFlag.Location = new System.Drawing.Point(348, 73);
            this.textBoxEXFlag.Name = "textBoxEXFlag";
            this.textBoxEXFlag.ReadOnly = true;
            this.textBoxEXFlag.Size = new System.Drawing.Size(100, 21);
            this.textBoxEXFlag.TabIndex = 69;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(251, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 68;
            this.label12.Text = "重车出厂标识";
            // 
            // textBoxHSFlag
            // 
            this.textBoxHSFlag.Location = new System.Drawing.Point(104, 73);
            this.textBoxHSFlag.Name = "textBoxHSFlag";
            this.textBoxHSFlag.ReadOnly = true;
            this.textBoxHSFlag.Size = new System.Drawing.Size(100, 21);
            this.textBoxHSFlag.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 66;
            this.label10.Text = "进出厂标识";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(758, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 65;
            this.label11.Text = "出厂司磅员";
            // 
            // textBoxEXWeighMan
            // 
            this.textBoxEXWeighMan.Location = new System.Drawing.Point(836, 74);
            this.textBoxEXWeighMan.Name = "textBoxEXWeighMan";
            this.textBoxEXWeighMan.ReadOnly = true;
            this.textBoxEXWeighMan.Size = new System.Drawing.Size(100, 21);
            this.textBoxEXWeighMan.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 63;
            this.label9.Text = "净重";
            // 
            // textBoxNet
            // 
            this.textBoxNet.Location = new System.Drawing.Point(442, 47);
            this.textBoxNet.Name = "textBoxNet";
            this.textBoxNet.ReadOnly = true;
            this.textBoxNet.Size = new System.Drawing.Size(100, 21);
            this.textBoxNet.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 61;
            this.label8.Text = "车牌号";
            // 
            // textBoxTruckNum
            // 
            this.textBoxTruckNum.Location = new System.Drawing.Point(442, 19);
            this.textBoxTruckNum.Name = "textBoxTruckNum";
            this.textBoxTruckNum.ReadOnly = true;
            this.textBoxTruckNum.Size = new System.Drawing.Size(100, 21);
            this.textBoxTruckNum.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "皮重";
            // 
            // textBoxTare
            // 
            this.textBoxTare.Location = new System.Drawing.Point(252, 47);
            this.textBoxTare.Name = "textBoxTare";
            this.textBoxTare.ReadOnly = true;
            this.textBoxTare.Size = new System.Drawing.Size(100, 21);
            this.textBoxTare.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 57;
            this.label6.Text = "毛重";
            // 
            // textBoxGross
            // 
            this.textBoxGross.Location = new System.Drawing.Point(62, 46);
            this.textBoxGross.Name = "textBoxGross";
            this.textBoxGross.ReadOnly = true;
            this.textBoxGross.Size = new System.Drawing.Size(100, 21);
            this.textBoxGross.TabIndex = 56;
            // 
            // textBoxExitTime
            // 
            this.textBoxExitTime.Location = new System.Drawing.Point(836, 21);
            this.textBoxExitTime.Name = "textBoxExitTime";
            this.textBoxExitTime.ReadOnly = true;
            this.textBoxExitTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxExitTime.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(758, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "出厂时间";
            // 
            // textBoxEnterTime
            // 
            this.textBoxEnterTime.Location = new System.Drawing.Point(632, 21);
            this.textBoxEnterTime.Name = "textBoxEnterTime";
            this.textBoxEnterTime.ReadOnly = true;
            this.textBoxEnterTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxEnterTime.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "工厂";
            // 
            // textBoxWerks
            // 
            this.textBoxWerks.Location = new System.Drawing.Point(62, 19);
            this.textBoxWerks.Name = "textBoxWerks";
            this.textBoxWerks.ReadOnly = true;
            this.textBoxWerks.Size = new System.Drawing.Size(100, 21);
            this.textBoxWerks.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "进厂时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(506, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "进厂司磅员";
            // 
            // textWeighMan
            // 
            this.textWeighMan.Location = new System.Drawing.Point(592, 74);
            this.textWeighMan.Name = "textWeighMan";
            this.textWeighMan.ReadOnly = true;
            this.textWeighMan.Size = new System.Drawing.Size(100, 21);
            this.textWeighMan.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "采购订单";
            // 
            // textEBELN
            // 
            this.textEBELN.Location = new System.Drawing.Point(252, 19);
            this.textEBELN.Name = "textEBELN";
            this.textEBELN.ReadOnly = true;
            this.textEBELN.Size = new System.Drawing.Size(100, 21);
            this.textEBELN.TabIndex = 46;
            // 
            // RawMaterialsSaleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "RawMaterialsSaleDetails";
            this.Text = "史丹利原材料销售详细信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxCondition.ResumeLayout(false);
            this.groupBoxCondition.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxCondition;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn KUNNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFIMG;
        private System.Windows.Forms.DataGridViewTextBoxColumn REALZFIMG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PWEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LGORT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxDiff;
        private System.Windows.Forms.TextBox textBoxEXFlag;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxHSFlag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxEXWeighMan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTruckNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGross;
        private System.Windows.Forms.TextBox textBoxExitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEnterTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxWerks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textWeighMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEBELN;
    }
}