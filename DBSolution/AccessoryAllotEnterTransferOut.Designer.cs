namespace DBSolution
{
    partial class AccessoryAllotEnterTransferOut
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessoryAllotEnterTransferOut));
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.panel0 = new System.Windows.Forms.Panel();
            this.groupBoxWeight = new System.Windows.Forms.GroupBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.groupBoxStep1 = new System.Windows.Forms.GroupBox();
            this.textBoxWeighMan = new System.Windows.Forms.TextBox();
            this.labelWeighMan = new System.Windows.Forms.Label();
            this.textBoxTare = new System.Windows.Forms.TextBox();
            this.labelTare = new System.Windows.Forms.Label();
            this.textBoxEbeln = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFactory = new System.Windows.Forms.TextBox();
            this.labelFactory = new System.Windows.Forms.Label();
            this.textBoxEnterTime = new System.Windows.Forms.TextBox();
            this.labelEnterTime = new System.Windows.Forms.Label();
            this.textBoxCar = new System.Windows.Forms.TextBox();
            this.labelCar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxStep3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.EBELN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EBELP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARKTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OVERNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.TARE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WERKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMEFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel0.SuspendLayout();
            this.groupBoxWeight.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            this.groupBoxStep1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxStep3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.SuspendLayout();
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
            this.panel2.TabIndex = 8;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.labelTitle.Location = new System.Drawing.Point(16, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(213, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "史丹利配件调拨(调出)入厂";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton,
            this.toolStripSeparator3,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonQuit,
            this.toolStripSeparator2,
            this.toolStripButtonEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton
            // 
            this.toolStripButton.Image = global::DBSolution2.Properties.Resources.Lock;
            this.toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton.Name = "toolStripButton";
            this.toolStripButton.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton.Text = "锁定";
            this.toolStripButton.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonSave.Text = "保存";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.Enabled = false;
            this.toolStripButtonEdit.Image = global::DBSolution2.Properties.Resources.修改;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonEdit.Text = "编辑";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // panel0
            // 
            this.panel0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel0.Controls.Add(this.groupBoxWeight);
            this.panel0.Controls.Add(this.groupBoxManual);
            this.panel0.Controls.Add(this.groupBoxStep1);
            this.panel0.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel0.Location = new System.Drawing.Point(0, 55);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(1004, 259);
            this.panel0.TabIndex = 10;
            // 
            // groupBoxWeight
            // 
            this.groupBoxWeight.Controls.Add(this.textBoxWeight);
            this.groupBoxWeight.Location = new System.Drawing.Point(702, 17);
            this.groupBoxWeight.Name = "groupBoxWeight";
            this.groupBoxWeight.Size = new System.Drawing.Size(288, 56);
            this.groupBoxWeight.TabIndex = 6;
            this.groupBoxWeight.TabStop = false;
            this.groupBoxWeight.Text = "地磅控制器重量显示";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxWeight.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxWeight.ForeColor = System.Drawing.Color.Red;
            this.textBoxWeight.Location = new System.Drawing.Point(20, 22);
            this.textBoxWeight.Multiline = true;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(248, 25);
            this.textBoxWeight.TabIndex = 1;
            this.textBoxWeight.Text = "12345";
            this.textBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.Controls.Add(this.dataGridViewHistory);
            this.groupBoxManual.Controls.Add(this.textBoxPrompt);
            this.groupBoxManual.Location = new System.Drawing.Point(702, 79);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(288, 168);
            this.groupBoxManual.TabIndex = 5;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "车辆皮重历史";
            // 
            // textBoxPrompt
            // 
            this.textBoxPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrompt.Location = new System.Drawing.Point(20, 15);
            this.textBoxPrompt.Multiline = true;
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.Size = new System.Drawing.Size(248, 147);
            this.textBoxPrompt.TabIndex = 1;
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Controls.Add(this.textBoxWeighMan);
            this.groupBoxStep1.Controls.Add(this.labelWeighMan);
            this.groupBoxStep1.Controls.Add(this.textBoxTare);
            this.groupBoxStep1.Controls.Add(this.labelTare);
            this.groupBoxStep1.Controls.Add(this.textBoxEbeln);
            this.groupBoxStep1.Controls.Add(this.label1);
            this.groupBoxStep1.Controls.Add(this.textBoxFactory);
            this.groupBoxStep1.Controls.Add(this.labelFactory);
            this.groupBoxStep1.Controls.Add(this.textBoxEnterTime);
            this.groupBoxStep1.Controls.Add(this.labelEnterTime);
            this.groupBoxStep1.Controls.Add(this.textBoxCar);
            this.groupBoxStep1.Controls.Add(this.labelCar);
            this.groupBoxStep1.Location = new System.Drawing.Point(11, 17);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(678, 230);
            this.groupBoxStep1.TabIndex = 1;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "出入厂信息";
            // 
            // textBoxWeighMan
            // 
            this.textBoxWeighMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxWeighMan.Location = new System.Drawing.Point(289, 89);
            this.textBoxWeighMan.Name = "textBoxWeighMan";
            this.textBoxWeighMan.ReadOnly = true;
            this.textBoxWeighMan.Size = new System.Drawing.Size(112, 21);
            this.textBoxWeighMan.TabIndex = 14;
            // 
            // labelWeighMan
            // 
            this.labelWeighMan.AutoSize = true;
            this.labelWeighMan.Location = new System.Drawing.Point(242, 94);
            this.labelWeighMan.Name = "labelWeighMan";
            this.labelWeighMan.Size = new System.Drawing.Size(41, 12);
            this.labelWeighMan.TabIndex = 13;
            this.labelWeighMan.Text = "司磅员";
            // 
            // textBoxTare
            // 
            this.textBoxTare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTare.Location = new System.Drawing.Point(79, 89);
            this.textBoxTare.Name = "textBoxTare";
            this.textBoxTare.Size = new System.Drawing.Size(104, 21);
            this.textBoxTare.TabIndex = 12;
            // 
            // labelTare
            // 
            this.labelTare.AutoSize = true;
            this.labelTare.Location = new System.Drawing.Point(30, 94);
            this.labelTare.Name = "labelTare";
            this.labelTare.Size = new System.Drawing.Size(41, 12);
            this.labelTare.TabIndex = 11;
            this.labelTare.Text = "皮  重";
            // 
            // textBoxEbeln
            // 
            this.textBoxEbeln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEbeln.Location = new System.Drawing.Point(289, 38);
            this.textBoxEbeln.Name = "textBoxEbeln";
            this.textBoxEbeln.Size = new System.Drawing.Size(112, 21);
            this.textBoxEbeln.TabIndex = 2;
            this.textBoxEbeln.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEbeln_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "调拨单号";
            // 
            // textBoxFactory
            // 
            this.textBoxFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFactory.Location = new System.Drawing.Point(500, 89);
            this.textBoxFactory.Name = "textBoxFactory";
            this.textBoxFactory.ReadOnly = true;
            this.textBoxFactory.Size = new System.Drawing.Size(130, 21);
            this.textBoxFactory.TabIndex = 5;
            // 
            // labelFactory
            // 
            this.labelFactory.AutoSize = true;
            this.labelFactory.Location = new System.Drawing.Point(453, 94);
            this.labelFactory.Name = "labelFactory";
            this.labelFactory.Size = new System.Drawing.Size(41, 12);
            this.labelFactory.TabIndex = 4;
            this.labelFactory.Text = "工  厂";
            // 
            // textBoxEnterTime
            // 
            this.textBoxEnterTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEnterTime.Location = new System.Drawing.Point(500, 38);
            this.textBoxEnterTime.Name = "textBoxEnterTime";
            this.textBoxEnterTime.ReadOnly = true;
            this.textBoxEnterTime.Size = new System.Drawing.Size(130, 21);
            this.textBoxEnterTime.TabIndex = 3;
            // 
            // labelEnterTime
            // 
            this.labelEnterTime.AutoSize = true;
            this.labelEnterTime.Location = new System.Drawing.Point(441, 44);
            this.labelEnterTime.Name = "labelEnterTime";
            this.labelEnterTime.Size = new System.Drawing.Size(53, 12);
            this.labelEnterTime.TabIndex = 2;
            this.labelEnterTime.Text = "进厂时间";
            // 
            // textBoxCar
            // 
            this.textBoxCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCar.Location = new System.Drawing.Point(79, 38);
            this.textBoxCar.Name = "textBoxCar";
            this.textBoxCar.Size = new System.Drawing.Size(104, 21);
            this.textBoxCar.TabIndex = 1;
            this.textBoxCar.DoubleClick += new System.EventHandler(this.textBoxCar_DoubleClick);
            this.textBoxCar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCar_KeyDown);
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(30, 44);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(41, 12);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "车牌号";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.panel1.Controls.Add(this.groupBoxStep3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 233);
            this.panel1.TabIndex = 11;
            // 
            // groupBoxStep3
            // 
            this.groupBoxStep3.Controls.Add(this.dataGridViewDetails);
            this.groupBoxStep3.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStep3.Name = "groupBoxStep3";
            this.groupBoxStep3.Size = new System.Drawing.Size(980, 194);
            this.groupBoxStep3.TabIndex = 8;
            this.groupBoxStep3.TabStop = false;
            this.groupBoxStep3.Text = "调拨单明细";
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.AllowUserToOrderColumns = true;
            this.dataGridViewDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EBELN,
            this.EBELP,
            this.MATNR,
            this.ARKTX,
            this.MENGE,
            this.OVERNUM,
            this.SENGE});
            this.dataGridViewDetails.Location = new System.Drawing.Point(23, 20);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.ReadOnly = true;
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(930, 155);
            this.dataGridViewDetails.TabIndex = 0;
            // 
            // EBELN
            // 
            this.EBELN.DataPropertyName = "EBELN";
            this.EBELN.HeaderText = "退货单号";
            this.EBELN.Name = "EBELN";
            this.EBELN.ReadOnly = true;
            this.EBELN.Visible = false;
            // 
            // EBELP
            // 
            this.EBELP.DataPropertyName = "EBELP";
            this.EBELP.HeaderText = "项目号";
            this.EBELP.Name = "EBELP";
            this.EBELP.ReadOnly = true;
            // 
            // MATNR
            // 
            this.MATNR.DataPropertyName = "MATNR";
            this.MATNR.HeaderText = "物料编码";
            this.MATNR.Name = "MATNR";
            this.MATNR.ReadOnly = true;
            // 
            // ARKTX
            // 
            this.ARKTX.DataPropertyName = "MAKTX";
            this.ARKTX.HeaderText = "物料描述";
            this.ARKTX.Name = "ARKTX";
            this.ARKTX.ReadOnly = true;
            // 
            // MENGE
            // 
            this.MENGE.DataPropertyName = "MENGE";
            this.MENGE.HeaderText = "可调拨数量";
            this.MENGE.Name = "MENGE";
            this.MENGE.ReadOnly = true;
            // 
            // OVERNUM
            // 
            this.OVERNUM.DataPropertyName = "OVERNUM";
            this.OVERNUM.HeaderText = "已调拨数量";
            this.OVERNUM.Name = "OVERNUM";
            this.OVERNUM.ReadOnly = true;
            // 
            // SENGE
            // 
            this.SENGE.HeaderText = "转出数量";
            this.SENGE.Name = "SENGE";
            this.SENGE.ReadOnly = true;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TARE,
            this.WERKS,
            this.TIMEFLAG});
            this.dataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistory.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.RowHeadersWidth = 4;
            this.dataGridViewHistory.RowTemplate.Height = 23;
            this.dataGridViewHistory.Size = new System.Drawing.Size(282, 148);
            this.dataGridViewHistory.TabIndex = 3;
            // 
            // TARE
            // 
            this.TARE.DataPropertyName = "TARE";
            this.TARE.HeaderText = "皮重";
            this.TARE.Name = "TARE";
            this.TARE.ReadOnly = true;
            this.TARE.Width = 60;
            // 
            // WERKS
            // 
            this.WERKS.DataPropertyName = "WERKS";
            this.WERKS.HeaderText = "工厂";
            this.WERKS.Name = "WERKS";
            this.WERKS.ReadOnly = true;
            this.WERKS.Width = 60;
            // 
            // TIMEFLAG
            // 
            this.TIMEFLAG.DataPropertyName = "TIMEFLAG";
            this.TIMEFLAG.HeaderText = "入厂时间";
            this.TIMEFLAG.Name = "TIMEFLAG";
            this.TIMEFLAG.ReadOnly = true;
            this.TIMEFLAG.Width = 158;
            // 
            // AccessoryAllotEnterTransferOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel0);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "AccessoryAllotEnterTransferOut";
            this.Text = "配件调拨(调出)入厂";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel0.ResumeLayout(false);
            this.groupBoxWeight.ResumeLayout(false);
            this.groupBoxWeight.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxStep3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel0;
        private System.Windows.Forms.GroupBox groupBoxWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.TextBox textBoxWeighMan;
        private System.Windows.Forms.Label labelWeighMan;
        private System.Windows.Forms.TextBox textBoxTare;
        private System.Windows.Forms.Label labelTare;
        private System.Windows.Forms.TextBox textBoxEbeln;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFactory;
        private System.Windows.Forms.Label labelFactory;
        private System.Windows.Forms.TextBox textBoxEnterTime;
        private System.Windows.Forms.Label labelEnterTime;
        private System.Windows.Forms.TextBox textBoxCar;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxStep3;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Timer timer;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn EBELN;
        private System.Windows.Forms.DataGridViewTextBoxColumn EBELP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARKTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OVERNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENGE;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEFLAG;
    }
}