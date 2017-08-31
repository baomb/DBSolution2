namespace DBSolution
{
    partial class SlpsFinishedProductsPresentationExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlpsFinishedProductsPresentationExit));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxStep3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.textBoxTotalSfimg = new System.Windows.Forms.TextBox();
            this.labelBalance = new System.Windows.Forms.Label();
            this.textBoxNet = new System.Windows.Forms.TextBox();
            this.labelNet = new System.Windows.Forms.Label();
            this.textBoxTare = new System.Windows.Forms.TextBox();
            this.labelTare = new System.Windows.Forms.Label();
            this.textBoxGross = new System.Windows.Forms.TextBox();
            this.labelGross = new System.Windows.Forms.Label();
            this.textBoxWeighMan = new System.Windows.Forms.TextBox();
            this.labelWeighMan = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTitle = new System.Windows.Forms.Label();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxFactory = new System.Windows.Forms.TextBox();
            this.panel0 = new System.Windows.Forms.Panel();
            this.groupBoxWeight = new System.Windows.Forms.GroupBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.TARE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WERKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMEFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.groupBoxStep1 = new System.Windows.Forms.GroupBox();
            this.textBoxDBNum = new System.Windows.Forms.TextBox();
            this.labelDBNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSgtxt = new System.Windows.Forms.TextBox();
            this.labelFactory = new System.Windows.Forms.Label();
            this.textBoxCar = new System.Windows.Forms.TextBox();
            this.labelCar = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.qrcodeScanResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sapOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maktx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdmng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pweight = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.realMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfimg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lgort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom.SuspendLayout();
            this.groupBoxStep3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel0.SuspendLayout();
            this.groupBoxWeight.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.groupBoxStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.panelBottom.Controls.Add(this.groupBoxStep3);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 340);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1004, 207);
            this.panelBottom.TabIndex = 18;
            // 
            // groupBoxStep3
            // 
            this.groupBoxStep3.Controls.Add(this.dataGridViewDetails);
            this.groupBoxStep3.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStep3.Name = "groupBoxStep3";
            this.groupBoxStep3.Size = new System.Drawing.Size(980, 183);
            this.groupBoxStep3.TabIndex = 8;
            this.groupBoxStep3.TabStop = false;
            this.groupBoxStep3.Text = "预留单明细";
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qrcodeScanResult,
            this.sapOrderNo,
            this.lineItemNo,
            this.matnr,
            this.maktx,
            this.bdmng,
            this.pweight,
            this.realMenge,
            this.sfimg,
            this.lgort});
            this.dataGridViewDetails.Location = new System.Drawing.Point(23, 25);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(930, 135);
            this.dataGridViewDetails.TabIndex = 0;
            this.dataGridViewDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetails_CellContentClick);
            this.dataGridViewDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewDetails_CurrentCellDirtyStateChanged);
            // 
            // textBoxTotalSfimg
            // 
            this.textBoxTotalSfimg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalSfimg.Location = new System.Drawing.Point(469, 114);
            this.textBoxTotalSfimg.Name = "textBoxTotalSfimg";
            this.textBoxTotalSfimg.ReadOnly = true;
            this.textBoxTotalSfimg.Size = new System.Drawing.Size(104, 21);
            this.textBoxTotalSfimg.TabIndex = 16;
            this.textBoxTotalSfimg.Text = "0";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(408, 118);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(53, 12);
            this.labelBalance.TabIndex = 15;
            this.labelBalance.Text = "实发合计";
            // 
            // textBoxNet
            // 
            this.textBoxNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNet.Location = new System.Drawing.Point(469, 169);
            this.textBoxNet.Name = "textBoxNet";
            this.textBoxNet.ReadOnly = true;
            this.textBoxNet.Size = new System.Drawing.Size(104, 21);
            this.textBoxNet.TabIndex = 14;
            this.textBoxNet.Text = "0";
            // 
            // labelNet
            // 
            this.labelNet.AutoSize = true;
            this.labelNet.Location = new System.Drawing.Point(432, 173);
            this.labelNet.Name = "labelNet";
            this.labelNet.Size = new System.Drawing.Size(29, 12);
            this.labelNet.TabIndex = 13;
            this.labelNet.Text = "净重";
            // 
            // textBoxTare
            // 
            this.textBoxTare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTare.Location = new System.Drawing.Point(267, 169);
            this.textBoxTare.Name = "textBoxTare";
            this.textBoxTare.ReadOnly = true;
            this.textBoxTare.Size = new System.Drawing.Size(104, 21);
            this.textBoxTare.TabIndex = 12;
            this.textBoxTare.Text = "0";
            this.textBoxTare.TextChanged += new System.EventHandler(this.textBoxTare_TextChanged);
            // 
            // labelTare
            // 
            this.labelTare.AutoSize = true;
            this.labelTare.Location = new System.Drawing.Point(226, 173);
            this.labelTare.Name = "labelTare";
            this.labelTare.Size = new System.Drawing.Size(29, 12);
            this.labelTare.TabIndex = 11;
            this.labelTare.Text = "皮重";
            // 
            // textBoxGross
            // 
            this.textBoxGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGross.Location = new System.Drawing.Point(87, 169);
            this.textBoxGross.Name = "textBoxGross";
            this.textBoxGross.Size = new System.Drawing.Size(84, 21);
            this.textBoxGross.TabIndex = 10;
            this.textBoxGross.Text = "0";
            this.textBoxGross.TextChanged += new System.EventHandler(this.textBoxGross_TextChanged);
            // 
            // labelGross
            // 
            this.labelGross.AutoSize = true;
            this.labelGross.Location = new System.Drawing.Point(49, 173);
            this.labelGross.Name = "labelGross";
            this.labelGross.Size = new System.Drawing.Size(29, 12);
            this.labelGross.TabIndex = 9;
            this.labelGross.Text = "毛重";
            // 
            // textBoxWeighMan
            // 
            this.textBoxWeighMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxWeighMan.Location = new System.Drawing.Point(87, 114);
            this.textBoxWeighMan.Name = "textBoxWeighMan";
            this.textBoxWeighMan.ReadOnly = true;
            this.textBoxWeighMan.Size = new System.Drawing.Size(84, 21);
            this.textBoxWeighMan.TabIndex = 7;
            // 
            // labelWeighMan
            // 
            this.labelWeighMan.AutoSize = true;
            this.labelWeighMan.Location = new System.Drawing.Point(37, 118);
            this.labelWeighMan.Name = "labelWeighMan";
            this.labelWeighMan.Size = new System.Drawing.Size(41, 12);
            this.labelWeighMan.TabIndex = 6;
            this.labelWeighMan.Text = "司磅员";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.labelTitle.Location = new System.Drawing.Point(16, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(178, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "史丹利产成品赠送出厂";
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
            // toolStripButtonReturn
            // 
            this.toolStripButtonReturn.Image = global::DBSolution2.Properties.Resources.取消;
            this.toolStripButtonReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReturn.Name = "toolStripButtonReturn";
            this.toolStripButtonReturn.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonReturn.Text = "空车出厂";
            this.toolStripButtonReturn.Click += new System.EventHandler(this.toolStripButtonReturn_Click);
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
            this.toolStripButtonReturn,
            this.toolStripSeparator2,
            this.toolStripButtonQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 15;
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
            // toolStripButtonQuit
            // 
            this.toolStripButtonQuit.Image = global::DBSolution2.Properties.Resources.Close;
            this.toolStripButtonQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuit.Name = "toolStripButtonQuit";
            this.toolStripButtonQuit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQuit.Text = "退出";
            this.toolStripButtonQuit.Click += new System.EventHandler(this.toolStripButtonQuit_Click);
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
            // textBoxFactory
            // 
            this.textBoxFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFactory.Location = new System.Drawing.Point(267, 56);
            this.textBoxFactory.Name = "textBoxFactory";
            this.textBoxFactory.ReadOnly = true;
            this.textBoxFactory.Size = new System.Drawing.Size(104, 21);
            this.textBoxFactory.TabIndex = 5;
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
            this.panel0.Size = new System.Drawing.Size(1004, 285);
            this.panel0.TabIndex = 16;
            // 
            // groupBoxWeight
            // 
            this.groupBoxWeight.Controls.Add(this.textBoxWeight);
            this.groupBoxWeight.Location = new System.Drawing.Point(702, 17);
            this.groupBoxWeight.Name = "groupBoxWeight";
            this.groupBoxWeight.Size = new System.Drawing.Size(288, 62);
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
            this.groupBoxManual.Location = new System.Drawing.Point(702, 90);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(288, 178);
            this.groupBoxManual.TabIndex = 5;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "车辆皮重历史";
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
            this.dataGridViewHistory.Size = new System.Drawing.Size(282, 158);
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
            // textBoxPrompt
            // 
            this.textBoxPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrompt.Location = new System.Drawing.Point(20, 22);
            this.textBoxPrompt.Multiline = true;
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.ReadOnly = true;
            this.textBoxPrompt.Size = new System.Drawing.Size(248, 140);
            this.textBoxPrompt.TabIndex = 1;
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Controls.Add(this.textBoxDBNum);
            this.groupBoxStep1.Controls.Add(this.labelDBNum);
            this.groupBoxStep1.Controls.Add(this.textBoxTotalSfimg);
            this.groupBoxStep1.Controls.Add(this.labelBalance);
            this.groupBoxStep1.Controls.Add(this.label1);
            this.groupBoxStep1.Controls.Add(this.textBoxSgtxt);
            this.groupBoxStep1.Controls.Add(this.textBoxFactory);
            this.groupBoxStep1.Controls.Add(this.labelGross);
            this.groupBoxStep1.Controls.Add(this.labelWeighMan);
            this.groupBoxStep1.Controls.Add(this.labelFactory);
            this.groupBoxStep1.Controls.Add(this.textBoxNet);
            this.groupBoxStep1.Controls.Add(this.labelNet);
            this.groupBoxStep1.Controls.Add(this.textBoxCar);
            this.groupBoxStep1.Controls.Add(this.textBoxWeighMan);
            this.groupBoxStep1.Controls.Add(this.textBoxTare);
            this.groupBoxStep1.Controls.Add(this.labelCar);
            this.groupBoxStep1.Controls.Add(this.labelTare);
            this.groupBoxStep1.Controls.Add(this.textBoxGross);
            this.groupBoxStep1.Location = new System.Drawing.Point(11, 17);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(678, 251);
            this.groupBoxStep1.TabIndex = 1;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "出入厂信息";
            // 
            // textBoxDBNum
            // 
            this.textBoxDBNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDBNum.Location = new System.Drawing.Point(469, 56);
            this.textBoxDBNum.Name = "textBoxDBNum";
            this.textBoxDBNum.ReadOnly = true;
            this.textBoxDBNum.Size = new System.Drawing.Size(104, 21);
            this.textBoxDBNum.TabIndex = 18;
            this.textBoxDBNum.Text = "0";
            // 
            // labelDBNum
            // 
            this.labelDBNum.AutoSize = true;
            this.labelDBNum.Location = new System.Drawing.Point(408, 60);
            this.labelDBNum.Name = "labelDBNum";
            this.labelDBNum.Size = new System.Drawing.Size(53, 12);
            this.labelDBNum.TabIndex = 17;
            this.labelDBNum.Text = "地磅编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "领料人";
            // 
            // textBoxSgtxt
            // 
            this.textBoxSgtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSgtxt.Location = new System.Drawing.Point(267, 114);
            this.textBoxSgtxt.Name = "textBoxSgtxt";
            this.textBoxSgtxt.Size = new System.Drawing.Size(104, 21);
            this.textBoxSgtxt.TabIndex = 8;
            // 
            // labelFactory
            // 
            this.labelFactory.AutoSize = true;
            this.labelFactory.Location = new System.Drawing.Point(226, 60);
            this.labelFactory.Name = "labelFactory";
            this.labelFactory.Size = new System.Drawing.Size(29, 12);
            this.labelFactory.TabIndex = 4;
            this.labelFactory.Text = "工厂";
            // 
            // textBoxCar
            // 
            this.textBoxCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCar.Location = new System.Drawing.Point(87, 56);
            this.textBoxCar.Name = "textBoxCar";
            this.textBoxCar.ReadOnly = true;
            this.textBoxCar.Size = new System.Drawing.Size(84, 21);
            this.textBoxCar.TabIndex = 1;
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(37, 60);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(41, 12);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "车牌号";
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // qrcodeScanResult
            // 
            this.qrcodeScanResult.DataPropertyName = "qrcodeScanResult";
            this.qrcodeScanResult.HeaderText = "二维码";
            this.qrcodeScanResult.Name = "qrcodeScanResult";
            this.qrcodeScanResult.Visible = false;
            // 
            // sapOrderNo
            // 
            this.sapOrderNo.DataPropertyName = "sapOrderNo";
            this.sapOrderNo.HeaderText = "预留单号";
            this.sapOrderNo.Name = "sapOrderNo";
            this.sapOrderNo.ReadOnly = true;
            this.sapOrderNo.Width = 60;
            // 
            // lineItemNo
            // 
            this.lineItemNo.DataPropertyName = "lineItemNo";
            this.lineItemNo.HeaderText = "项目号";
            this.lineItemNo.Name = "lineItemNo";
            this.lineItemNo.ReadOnly = true;
            this.lineItemNo.Width = 60;
            // 
            // matnr
            // 
            this.matnr.DataPropertyName = "matnr";
            this.matnr.HeaderText = "物料编码";
            this.matnr.Name = "matnr";
            this.matnr.ReadOnly = true;
            // 
            // maktx
            // 
            this.maktx.DataPropertyName = "maktx";
            this.maktx.HeaderText = "物料描述";
            this.maktx.Name = "maktx";
            this.maktx.ReadOnly = true;
            this.maktx.Width = 180;
            // 
            // bdmng
            // 
            this.bdmng.DataPropertyName = "bdmng";
            this.bdmng.HeaderText = "预留剩余数量";
            this.bdmng.Name = "bdmng";
            // 
            // pweight
            // 
            this.pweight.HeaderText = "包重";
            this.pweight.Name = "pweight";
            this.pweight.Width = 80;
            // 
            // realMenge
            // 
            this.realMenge.DataPropertyName = "realMenge";
            this.realMenge.HeaderText = "实发件数";
            this.realMenge.Name = "realMenge";
            this.realMenge.Width = 60;
            // 
            // sfimg
            // 
            this.sfimg.DataPropertyName = "sfimg";
            this.sfimg.HeaderText = "实发吨数";
            this.sfimg.Name = "sfimg";
            this.sfimg.ReadOnly = true;
            this.sfimg.Width = 60;
            // 
            // lgort
            // 
            this.lgort.DataPropertyName = "lgort";
            this.lgort.HeaderText = "收货仓库";
            this.lgort.Name = "lgort";
            // 
            // SlpsFinishedProductsPresentationExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel0);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "SlpsFinishedProductsPresentationExit";
            this.Text = "史丹利产成品赠送出厂";
            this.panelBottom.ResumeLayout(false);
            this.groupBoxStep3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel0.ResumeLayout(false);
            this.groupBoxWeight.ResumeLayout(false);
            this.groupBoxWeight.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox textBoxTotalSfimg;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.TextBox textBoxNet;
        private System.Windows.Forms.Label labelNet;
        private System.Windows.Forms.TextBox textBoxTare;
        private System.Windows.Forms.Label labelTare;
        private System.Windows.Forms.TextBox textBoxGross;
        private System.Windows.Forms.Label labelGross;
        private System.Windows.Forms.GroupBox groupBoxStep3;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.TextBox textBoxWeighMan;
        private System.Windows.Forms.Label labelWeighMan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonReturn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxFactory;
        private System.Windows.Forms.Panel panel0;
        private System.Windows.Forms.GroupBox groupBoxWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.Label labelFactory;
        private System.Windows.Forms.TextBox textBoxCar;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.TextBox textBoxSgtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox textBoxDBNum;
        private System.Windows.Forms.Label labelDBNum;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEFLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn qrcodeScanResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn sapOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn matnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn maktx;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdmng;
        private System.Windows.Forms.DataGridViewComboBoxColumn pweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMenge;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfimg;
        private System.Windows.Forms.DataGridViewTextBoxColumn lgort;
    }
}