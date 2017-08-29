namespace DBSolution
{
    partial class FinishProductSaleContractEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishProductSaleContractEnter));
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxFactory = new System.Windows.Forms.TextBox();
            this.labelFactory = new System.Windows.Forms.Label();
            this.labelEnterTime = new System.Windows.Forms.Label();
            this.textBoxCar = new System.Windows.Forms.TextBox();
            this.KUNNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.textBoxTare = new System.Windows.Forms.TextBox();
            this.labelTare = new System.Windows.Forms.Label();
            this.groupBoxStep3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.DELIVERY_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETAILS_POSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARKTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFMNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETAILS_KWMENG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REAL_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LGORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxWeighMan = new System.Windows.Forms.TextBox();
            this.labelWeighMan = new System.Windows.Forms.Label();
            this.VBELN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelCar = new System.Windows.Forms.Label();
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
            this.textBoxEnterTime = new System.Windows.Forms.DateTimePicker();
            this.groupBoxStep2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panelBottom.SuspendLayout();
            this.groupBoxStep3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.panel0.SuspendLayout();
            this.groupBoxWeight.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.groupBoxStep1.SuspendLayout();
            this.groupBoxStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk
            // 
            this.chk.FillWeight = 45.40953F;
            this.chk.HeaderText = "选择";
            this.chk.Name = "chk";
            // 
            // textBoxFactory
            // 
            this.textBoxFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFactory.Location = new System.Drawing.Point(549, 26);
            this.textBoxFactory.Name = "textBoxFactory";
            this.textBoxFactory.ReadOnly = true;
            this.textBoxFactory.Size = new System.Drawing.Size(104, 21);
            this.textBoxFactory.TabIndex = 5;
            // 
            // labelFactory
            // 
            this.labelFactory.AutoSize = true;
            this.labelFactory.Location = new System.Drawing.Point(506, 30);
            this.labelFactory.Name = "labelFactory";
            this.labelFactory.Size = new System.Drawing.Size(29, 12);
            this.labelFactory.TabIndex = 4;
            this.labelFactory.Text = "工厂";
            // 
            // labelEnterTime
            // 
            this.labelEnterTime.AutoSize = true;
            this.labelEnterTime.Location = new System.Drawing.Point(235, 30);
            this.labelEnterTime.Name = "labelEnterTime";
            this.labelEnterTime.Size = new System.Drawing.Size(53, 12);
            this.labelEnterTime.TabIndex = 2;
            this.labelEnterTime.Text = "进厂时间";
            // 
            // textBoxCar
            // 
            this.textBoxCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCar.Location = new System.Drawing.Point(66, 24);
            this.textBoxCar.Name = "textBoxCar";
            this.textBoxCar.Size = new System.Drawing.Size(104, 21);
            this.textBoxCar.TabIndex = 1;
            this.textBoxCar.TextChanged += new System.EventHandler(this.textBoxCar_TextChanged);
            this.textBoxCar.DoubleClick += new System.EventHandler(this.textBoxCar_DoubleClick);
            this.textBoxCar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCar_KeyDown);
            // 
            // KUNNR
            // 
            this.KUNNR.DataPropertyName = "KUNNR";
            this.KUNNR.FillWeight = 65.07049F;
            this.KUNNR.HeaderText = "客户编码";
            this.KUNNR.Name = "KUNNR";
            this.KUNNR.ReadOnly = true;
            // 
            // NAME1
            // 
            this.NAME1.DataPropertyName = "NAME1";
            this.NAME1.FillWeight = 137.9255F;
            this.NAME1.HeaderText = "客户名称";
            this.NAME1.Name = "NAME1";
            this.NAME1.ReadOnly = true;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.textBoxNote);
            this.panelBottom.Controls.Add(this.textBoxTare);
            this.panelBottom.Controls.Add(this.labelTare);
            this.panelBottom.Controls.Add(this.groupBoxStep3);
            this.panelBottom.Controls.Add(this.textBoxWeighMan);
            this.panelBottom.Controls.Add(this.labelWeighMan);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 340);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1003, 210);
            this.panelBottom.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "备注";
            // 
            // textBoxNote
            // 
            this.textBoxNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNote.Location = new System.Drawing.Point(495, 177);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(146, 21);
            this.textBoxNote.TabIndex = 11;
            // 
            // textBoxTare
            // 
            this.textBoxTare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTare.Location = new System.Drawing.Point(280, 177);
            this.textBoxTare.Name = "textBoxTare";
            this.textBoxTare.Size = new System.Drawing.Size(104, 21);
            this.textBoxTare.TabIndex = 10;
            // 
            // labelTare
            // 
            this.labelTare.AutoSize = true;
            this.labelTare.Location = new System.Drawing.Point(220, 181);
            this.labelTare.Name = "labelTare";
            this.labelTare.Size = new System.Drawing.Size(29, 12);
            this.labelTare.TabIndex = 9;
            this.labelTare.Text = "皮重";
            // 
            // groupBoxStep3
            // 
            this.groupBoxStep3.Controls.Add(this.dataGridViewDetails);
            this.groupBoxStep3.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStep3.Name = "groupBoxStep3";
            this.groupBoxStep3.Size = new System.Drawing.Size(980, 155);
            this.groupBoxStep3.TabIndex = 8;
            this.groupBoxStep3.TabStop = false;
            this.groupBoxStep3.Text = "交货单明细";
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.AllowUserToOrderColumns = true;
            this.dataGridViewDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DELIVERY_NUM,
            this.DETAILS_POSNR,
            this.MATNR,
            this.ARKTX,
            this.RFMNG,
            this.DETAILS_KWMENG,
            this.REAL_NUM,
            this.LGORT});
            this.dataGridViewDetails.Location = new System.Drawing.Point(23, 20);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.ReadOnly = true;
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(930, 121);
            this.dataGridViewDetails.TabIndex = 0;
            this.dataGridViewDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewDetails_DataError);
            // 
            // DELIVERY_NUM
            // 
            this.DELIVERY_NUM.DataPropertyName = "VBELN";
            this.DELIVERY_NUM.HeaderText = "交货单号";
            this.DELIVERY_NUM.Name = "DELIVERY_NUM";
            this.DELIVERY_NUM.ReadOnly = true;
            // 
            // DETAILS_POSNR
            // 
            this.DETAILS_POSNR.DataPropertyName = "POSNR";
            this.DETAILS_POSNR.HeaderText = "项目号";
            this.DETAILS_POSNR.Name = "DETAILS_POSNR";
            this.DETAILS_POSNR.ReadOnly = true;
            this.DETAILS_POSNR.Width = 60;
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
            this.ARKTX.Width = 200;
            // 
            // RFMNG
            // 
            this.RFMNG.DataPropertyName = "LFIMG";
            this.RFMNG.HeaderText = "原发吨数";
            this.RFMNG.Name = "RFMNG";
            this.RFMNG.ReadOnly = true;
            this.RFMNG.Width = 60;
            // 
            // DETAILS_KWMENG
            // 
            this.DETAILS_KWMENG.DataPropertyName = "ZFIMG";
            this.DETAILS_KWMENG.HeaderText = "原发件数";
            this.DETAILS_KWMENG.Name = "DETAILS_KWMENG";
            this.DETAILS_KWMENG.ReadOnly = true;
            this.DETAILS_KWMENG.Width = 60;
            // 
            // REAL_NUM
            // 
            this.REAL_NUM.HeaderText = "实发件数";
            this.REAL_NUM.Name = "REAL_NUM";
            this.REAL_NUM.ReadOnly = true;
            this.REAL_NUM.Width = 60;
            // 
            // LGORT
            // 
            this.LGORT.DataPropertyName = "LGORT";
            this.LGORT.HeaderText = "发货仓库";
            this.LGORT.Name = "LGORT";
            this.LGORT.ReadOnly = true;
            this.LGORT.Width = 200;
            // 
            // textBoxWeighMan
            // 
            this.textBoxWeighMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxWeighMan.Location = new System.Drawing.Point(80, 177);
            this.textBoxWeighMan.Name = "textBoxWeighMan";
            this.textBoxWeighMan.ReadOnly = true;
            this.textBoxWeighMan.Size = new System.Drawing.Size(104, 21);
            this.textBoxWeighMan.TabIndex = 7;
            // 
            // labelWeighMan
            // 
            this.labelWeighMan.AutoSize = true;
            this.labelWeighMan.Location = new System.Drawing.Point(22, 181);
            this.labelWeighMan.Name = "labelWeighMan";
            this.labelWeighMan.Size = new System.Drawing.Size(41, 12);
            this.labelWeighMan.TabIndex = 6;
            this.labelWeighMan.Text = "司磅员";
            // 
            // VBELN
            // 
            this.VBELN.DataPropertyName = "VBELN";
            this.VBELN.FillWeight = 72.0666F;
            this.VBELN.HeaderText = "交货单号";
            this.VBELN.Name = "VBELN";
            this.VBELN.ReadOnly = true;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(12, 28);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(41, 12);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "车牌号";
            // 
            // panel0
            // 
            this.panel0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel0.Controls.Add(this.groupBoxWeight);
            this.panel0.Controls.Add(this.groupBoxManual);
            this.panel0.Controls.Add(this.groupBoxStep1);
            this.panel0.Controls.Add(this.groupBoxStep2);
            this.panel0.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel0.Location = new System.Drawing.Point(0, 55);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(1003, 285);
            this.panel0.TabIndex = 12;
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
            this.textBoxPrompt.Size = new System.Drawing.Size(248, 140);
            this.textBoxPrompt.TabIndex = 1;
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Controls.Add(this.textBoxEnterTime);
            this.groupBoxStep1.Controls.Add(this.textBoxFactory);
            this.groupBoxStep1.Controls.Add(this.labelFactory);
            this.groupBoxStep1.Controls.Add(this.labelEnterTime);
            this.groupBoxStep1.Controls.Add(this.textBoxCar);
            this.groupBoxStep1.Controls.Add(this.labelCar);
            this.groupBoxStep1.Location = new System.Drawing.Point(11, 17);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(678, 62);
            this.groupBoxStep1.TabIndex = 1;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "出入厂信息";
            // 
            // textBoxEnterTime
            // 
            this.textBoxEnterTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.textBoxEnterTime.Location = new System.Drawing.Point(308, 24);
            this.textBoxEnterTime.Name = "textBoxEnterTime";
            this.textBoxEnterTime.Size = new System.Drawing.Size(130, 21);
            this.textBoxEnterTime.TabIndex = 15;
            this.textBoxEnterTime.ValueChanged += new System.EventHandler(this.textBoxEnterTime_ValueChanged);
            // 
            // groupBoxStep2
            // 
            this.groupBoxStep2.Controls.Add(this.dataGridViewSelect);
            this.groupBoxStep2.Location = new System.Drawing.Point(11, 90);
            this.groupBoxStep2.Name = "groupBoxStep2";
            this.groupBoxStep2.Size = new System.Drawing.Size(678, 178);
            this.groupBoxStep2.TabIndex = 2;
            this.groupBoxStep2.TabStop = false;
            this.groupBoxStep2.Text = "选择交货单号";
            // 
            // dataGridViewSelect
            // 
            this.dataGridViewSelect.AllowUserToAddRows = false;
            this.dataGridViewSelect.AllowUserToDeleteRows = false;
            this.dataGridViewSelect.AllowUserToOrderColumns = true;
            this.dataGridViewSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.VBELN,
            this.KUNNR,
            this.NAME1});
            this.dataGridViewSelect.Location = new System.Drawing.Point(23, 23);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.RowTemplate.Height = 23;
            this.dataGridViewSelect.Size = new System.Drawing.Size(630, 142);
            this.dataGridViewSelect.TabIndex = 0;
            this.dataGridViewSelect.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelect_CellContentClick);
            this.dataGridViewSelect.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewSelect_DataError);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.labelTitle.Location = new System.Drawing.Point(16, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(229, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "史丹利公司合同订单销售入厂";
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
            this.toolStrip1.Size = new System.Drawing.Size(1003, 25);
            this.toolStrip1.TabIndex = 11;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 30);
            this.panel2.TabIndex = 10;
            // 
            // FinishProductSaleContractEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 550);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel0);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "FinishProductSaleContractEnter";
            this.Text = "合同订单销售入厂";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.groupBoxStep3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.panel0.ResumeLayout(false);
            this.groupBoxWeight.ResumeLayout(false);
            this.groupBoxWeight.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.groupBoxStep2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.TextBox textBoxFactory;
        private System.Windows.Forms.Label labelFactory;
        private System.Windows.Forms.Label labelEnterTime;
        private System.Windows.Forms.TextBox textBoxCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn KUNNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.TextBox textBoxTare;
        private System.Windows.Forms.Label labelTare;
        private System.Windows.Forms.GroupBox groupBoxStep3;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERY_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETAILS_POSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARKTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFMNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETAILS_KWMENG;
        private System.Windows.Forms.DataGridViewTextBoxColumn REAL_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn LGORT;
        private System.Windows.Forms.TextBox textBoxWeighMan;
        private System.Windows.Forms.Label labelWeighMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn VBELN;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Panel panel0;
        private System.Windows.Forms.GroupBox groupBoxWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEFLAG;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.GroupBox groupBoxStep2;
        private System.Windows.Forms.DataGridView dataGridViewSelect;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.Panel panel2;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DateTimePicker textBoxEnterTime;
    }
}