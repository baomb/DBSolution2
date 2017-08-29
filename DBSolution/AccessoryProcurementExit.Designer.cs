namespace DBSolution
{
    partial class AccessoryProcurementExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessoryProcurementExit));
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.panel0 = new System.Windows.Forms.Panel();
            this.groupBoxStep1 = new System.Windows.Forms.GroupBox();
            this.textBoxDBNum = new System.Windows.Forms.TextBox();
            this.labelDBNum = new System.Windows.Forms.Label();
            this.textBoxDeductNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTares = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxExitWeighMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGross = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEbeln = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFactory = new System.Windows.Forms.TextBox();
            this.labelFactory = new System.Windows.Forms.Label();
            this.textBoxExitTime = new System.Windows.Forms.TextBox();
            this.labelEnterTime = new System.Windows.Forms.Label();
            this.textBoxTruckNum = new System.Windows.Forms.TextBox();
            this.labelCar = new System.Windows.Forms.Label();
            this.groupBoxWeight = new System.Windows.Forms.GroupBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxStep3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EBELN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EBELP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIFNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBoxStep1.SuspendLayout();
            this.groupBoxWeight.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            this.panelBottom.SuspendLayout();
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
            this.labelTitle.Size = new System.Drawing.Size(161, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "史丹利配件采购出厂";
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
            this.toolStripButtonCancel});
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
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonCancel.Text = "重车出厂";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // panel0
            // 
            this.panel0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel0.Controls.Add(this.groupBoxStep1);
            this.panel0.Controls.Add(this.groupBoxWeight);
            this.panel0.Controls.Add(this.groupBoxManual);
            this.panel0.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel0.Location = new System.Drawing.Point(0, 55);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(1004, 268);
            this.panel0.TabIndex = 10;
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Controls.Add(this.textBoxDBNum);
            this.groupBoxStep1.Controls.Add(this.labelDBNum);
            this.groupBoxStep1.Controls.Add(this.textBoxDeductNum);
            this.groupBoxStep1.Controls.Add(this.label6);
            this.groupBoxStep1.Controls.Add(this.textBoxNet);
            this.groupBoxStep1.Controls.Add(this.label5);
            this.groupBoxStep1.Controls.Add(this.textBoxTares);
            this.groupBoxStep1.Controls.Add(this.label4);
            this.groupBoxStep1.Controls.Add(this.textBoxExitWeighMan);
            this.groupBoxStep1.Controls.Add(this.label1);
            this.groupBoxStep1.Controls.Add(this.textBoxGross);
            this.groupBoxStep1.Controls.Add(this.label2);
            this.groupBoxStep1.Controls.Add(this.textBoxEbeln);
            this.groupBoxStep1.Controls.Add(this.label3);
            this.groupBoxStep1.Controls.Add(this.textBoxFactory);
            this.groupBoxStep1.Controls.Add(this.labelFactory);
            this.groupBoxStep1.Controls.Add(this.textBoxExitTime);
            this.groupBoxStep1.Controls.Add(this.labelEnterTime);
            this.groupBoxStep1.Controls.Add(this.textBoxTruckNum);
            this.groupBoxStep1.Controls.Add(this.labelCar);
            this.groupBoxStep1.Location = new System.Drawing.Point(11, 17);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(678, 235);
            this.groupBoxStep1.TabIndex = 7;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "出入厂信息";
            // 
            // textBoxDBNum
            // 
            this.textBoxDBNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDBNum.Location = new System.Drawing.Point(500, 89);
            this.textBoxDBNum.Name = "textBoxDBNum";
            this.textBoxDBNum.ReadOnly = true;
            this.textBoxDBNum.Size = new System.Drawing.Size(130, 21);
            this.textBoxDBNum.TabIndex = 22;
            // 
            // labelDBNum
            // 
            this.labelDBNum.AutoSize = true;
            this.labelDBNum.Location = new System.Drawing.Point(417, 94);
            this.labelDBNum.Name = "labelDBNum";
            this.labelDBNum.Size = new System.Drawing.Size(77, 12);
            this.labelDBNum.TabIndex = 21;
            this.labelDBNum.Text = "入厂地磅编号";
            // 
            // textBoxDeductNum
            // 
            this.textBoxDeductNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDeductNum.CausesValidation = false;
            this.textBoxDeductNum.Location = new System.Drawing.Point(289, 194);
            this.textBoxDeductNum.Name = "textBoxDeductNum";
            this.textBoxDeductNum.ReadOnly = true;
            this.textBoxDeductNum.Size = new System.Drawing.Size(112, 21);
            this.textBoxDeductNum.TabIndex = 20;
            this.textBoxDeductNum.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "差  异";
            // 
            // textBoxNet
            // 
            this.textBoxNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNet.CausesValidation = false;
            this.textBoxNet.Location = new System.Drawing.Point(79, 194);
            this.textBoxNet.Name = "textBoxNet";
            this.textBoxNet.ReadOnly = true;
            this.textBoxNet.Size = new System.Drawing.Size(104, 21);
            this.textBoxNet.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "净  重";
            // 
            // textBoxTares
            // 
            this.textBoxTares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTares.Location = new System.Drawing.Point(79, 140);
            this.textBoxTares.Name = "textBoxTares";
            this.textBoxTares.Size = new System.Drawing.Size(104, 21);
            this.textBoxTares.TabIndex = 16;
            this.textBoxTares.Text = "0";
            this.textBoxTares.TextChanged += new System.EventHandler(this.textBoxTares_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "皮  重";
            // 
            // textBoxExitWeighMan
            // 
            this.textBoxExitWeighMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExitWeighMan.Location = new System.Drawing.Point(79, 89);
            this.textBoxExitWeighMan.Name = "textBoxExitWeighMan";
            this.textBoxExitWeighMan.ReadOnly = true;
            this.textBoxExitWeighMan.Size = new System.Drawing.Size(104, 21);
            this.textBoxExitWeighMan.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "司磅员";
            // 
            // textBoxGross
            // 
            this.textBoxGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGross.CausesValidation = false;
            this.textBoxGross.Location = new System.Drawing.Point(289, 140);
            this.textBoxGross.Name = "textBoxGross";
            this.textBoxGross.ReadOnly = true;
            this.textBoxGross.Size = new System.Drawing.Size(112, 21);
            this.textBoxGross.TabIndex = 12;
            this.textBoxGross.Text = "0";
            this.textBoxGross.TextChanged += new System.EventHandler(this.textBoxGross_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "毛  重";
            // 
            // textBoxEbeln
            // 
            this.textBoxEbeln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEbeln.Location = new System.Drawing.Point(289, 38);
            this.textBoxEbeln.Name = "textBoxEbeln";
            this.textBoxEbeln.ReadOnly = true;
            this.textBoxEbeln.Size = new System.Drawing.Size(112, 21);
            this.textBoxEbeln.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "采购订单号";
            // 
            // textBoxFactory
            // 
            this.textBoxFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFactory.Location = new System.Drawing.Point(289, 89);
            this.textBoxFactory.Name = "textBoxFactory";
            this.textBoxFactory.ReadOnly = true;
            this.textBoxFactory.Size = new System.Drawing.Size(112, 21);
            this.textBoxFactory.TabIndex = 5;
            // 
            // labelFactory
            // 
            this.labelFactory.AutoSize = true;
            this.labelFactory.Location = new System.Drawing.Point(242, 94);
            this.labelFactory.Name = "labelFactory";
            this.labelFactory.Size = new System.Drawing.Size(41, 12);
            this.labelFactory.TabIndex = 4;
            this.labelFactory.Text = "工  厂";
            // 
            // textBoxExitTime
            // 
            this.textBoxExitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExitTime.Location = new System.Drawing.Point(500, 38);
            this.textBoxExitTime.Name = "textBoxExitTime";
            this.textBoxExitTime.ReadOnly = true;
            this.textBoxExitTime.Size = new System.Drawing.Size(130, 21);
            this.textBoxExitTime.TabIndex = 3;
            // 
            // labelEnterTime
            // 
            this.labelEnterTime.AutoSize = true;
            this.labelEnterTime.Location = new System.Drawing.Point(441, 44);
            this.labelEnterTime.Name = "labelEnterTime";
            this.labelEnterTime.Size = new System.Drawing.Size(53, 12);
            this.labelEnterTime.TabIndex = 2;
            this.labelEnterTime.Text = "出厂时间";
            // 
            // textBoxTruckNum
            // 
            this.textBoxTruckNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTruckNum.Location = new System.Drawing.Point(79, 38);
            this.textBoxTruckNum.Name = "textBoxTruckNum";
            this.textBoxTruckNum.ReadOnly = true;
            this.textBoxTruckNum.Size = new System.Drawing.Size(104, 21);
            this.textBoxTruckNum.TabIndex = 1;
            this.textBoxTruckNum.DoubleClick += new System.EventHandler(this.textBoxTruckNum_DoubleClick);
            this.textBoxTruckNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTruckNum_KeyDown);
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
            // groupBoxWeight
            // 
            this.groupBoxWeight.Controls.Add(this.textBoxWeight);
            this.groupBoxWeight.Location = new System.Drawing.Point(702, 17);
            this.groupBoxWeight.Name = "groupBoxWeight";
            this.groupBoxWeight.Size = new System.Drawing.Size(288, 50);
            this.groupBoxWeight.TabIndex = 6;
            this.groupBoxWeight.TabStop = false;
            this.groupBoxWeight.Text = "地磅控制器重量显示";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxWeight.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxWeight.ForeColor = System.Drawing.Color.Red;
            this.textBoxWeight.Location = new System.Drawing.Point(20, 17);
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
            this.groupBoxManual.Location = new System.Drawing.Point(702, 73);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(288, 179);
            this.groupBoxManual.TabIndex = 5;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "车辆皮重历史";
            // 
            // textBoxPrompt
            // 
            this.textBoxPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrompt.Location = new System.Drawing.Point(20, 14);
            this.textBoxPrompt.Multiline = true;
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.Size = new System.Drawing.Size(248, 159);
            this.textBoxPrompt.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.panelBottom.Controls.Add(this.groupBoxStep3);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 323);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1004, 224);
            this.panelBottom.TabIndex = 11;
            // 
            // groupBoxStep3
            // 
            this.groupBoxStep3.Controls.Add(this.dataGridViewDetails);
            this.groupBoxStep3.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStep3.Name = "groupBoxStep3";
            this.groupBoxStep3.Size = new System.Drawing.Size(980, 181);
            this.groupBoxStep3.TabIndex = 8;
            this.groupBoxStep3.TabStop = false;
            this.groupBoxStep3.Text = "采购单明细";
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.EBELN,
            this.EBELP,
            this.MATNR,
            this.MAKTX,
            this.LIFNR,
            this.NAME1,
            this.SENGE});
            this.dataGridViewDetails.Location = new System.Drawing.Point(23, 20);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(930, 155);
            this.dataGridViewDetails.TabIndex = 0;
            this.dataGridViewDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetails_CellContentClick);
            this.dataGridViewDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewDetails_CurrentCellDirtyStateChanged);
            // 
            // chk
            // 
            this.chk.HeaderText = "选择";
            this.chk.Name = "chk";
            this.chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chk.ToolTipText = "选择";
            // 
            // EBELN
            // 
            this.EBELN.DataPropertyName = "EBELN";
            this.EBELN.HeaderText = "采购单号";
            this.EBELN.Name = "EBELN";
            // 
            // EBELP
            // 
            this.EBELP.DataPropertyName = "EBELP";
            this.EBELP.HeaderText = "项目号";
            this.EBELP.Name = "EBELP";
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
            // LIFNR
            // 
            this.LIFNR.DataPropertyName = "LIFNR";
            this.LIFNR.HeaderText = "供应商帐号";
            this.LIFNR.Name = "LIFNR";
            // 
            // NAME1
            // 
            this.NAME1.DataPropertyName = "NAME1";
            this.NAME1.HeaderText = "供应商名称";
            this.NAME1.Name = "NAME1";
            // 
            // SENGE
            // 
            this.SENGE.DataPropertyName = "SENGE";
            this.SENGE.HeaderText = "实收数量";
            this.SENGE.Name = "SENGE";
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
            this.dataGridViewHistory.Size = new System.Drawing.Size(282, 159);
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
            // AccessoryProcurementExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel0);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "AccessoryProcurementExit";
            this.Text = "史丹利配件采购出厂";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel0.ResumeLayout(false);
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.groupBoxWeight.ResumeLayout(false);
            this.groupBoxWeight.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            this.panelBottom.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel0;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.TextBox textBoxNet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTares;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxExitWeighMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGross;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEbeln;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFactory;
        private System.Windows.Forms.Label labelFactory;
        private System.Windows.Forms.TextBox textBoxExitTime;
        private System.Windows.Forms.Label labelEnterTime;
        private System.Windows.Forms.TextBox textBoxTruckNum;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.GroupBox groupBoxWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBoxStep3;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Timer timer;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox textBoxDeductNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn EBELN;
        private System.Windows.Forms.DataGridViewTextBoxColumn EBELP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIFNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENGE;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.TextBox textBoxDBNum;
        private System.Windows.Forms.Label labelDBNum;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEFLAG;
    }
}