namespace DBSolution
{
    partial class FinishedProductsExchangeInEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishedProductsExchangeInEnter));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.groupBoxStep1 = new System.Windows.Forms.GroupBox();
            this.textBoxXsks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxXsqy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxYwy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFxqd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFactory = new System.Windows.Forms.TextBox();
            this.labelFactory = new System.Windows.Forms.Label();
            this.textBoxEnterTime = new System.Windows.Forms.TextBox();
            this.labelEnterTime = new System.Windows.Forms.Label();
            this.textBoxCar = new System.Windows.Forms.TextBox();
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
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.CpoyButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DelButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.POSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.textBoxGross = new System.Windows.Forms.TextBox();
            this.labelGross = new System.Windows.Forms.Label();
            this.groupBoxStep3 = new System.Windows.Forms.GroupBox();
            this.textBoxWeighMan = new System.Windows.Forms.TextBox();
            this.labelWeighMan = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.groupBoxStep1.SuspendLayout();
            this.panel0.SuspendLayout();
            this.groupBoxWeight.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBoxStep3.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStripButtonEdit,
            this.toolStripButtonPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 0;
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
            this.toolStripButtonEdit.Image = global::DBSolution2.Properties.Resources.Edit;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonEdit.Text = "编辑";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Controls.Add(this.textBoxXsks);
            this.groupBoxStep1.Controls.Add(this.label7);
            this.groupBoxStep1.Controls.Add(this.textBoxXsqy);
            this.groupBoxStep1.Controls.Add(this.label8);
            this.groupBoxStep1.Controls.Add(this.textBoxYwy);
            this.groupBoxStep1.Controls.Add(this.label6);
            this.groupBoxStep1.Controls.Add(this.textBoxFxqd);
            this.groupBoxStep1.Controls.Add(this.label5);
            this.groupBoxStep1.Controls.Add(this.textBoxTType);
            this.groupBoxStep1.Controls.Add(this.label4);
            this.groupBoxStep1.Controls.Add(this.textBoxCName);
            this.groupBoxStep1.Controls.Add(this.label3);
            this.groupBoxStep1.Controls.Add(this.textBoxCNum);
            this.groupBoxStep1.Controls.Add(this.label2);
            this.groupBoxStep1.Controls.Add(this.textBoxOA);
            this.groupBoxStep1.Controls.Add(this.label1);
            this.groupBoxStep1.Controls.Add(this.textBoxFactory);
            this.groupBoxStep1.Controls.Add(this.labelFactory);
            this.groupBoxStep1.Controls.Add(this.textBoxEnterTime);
            this.groupBoxStep1.Controls.Add(this.labelEnterTime);
            this.groupBoxStep1.Controls.Add(this.textBoxCar);
            this.groupBoxStep1.Controls.Add(this.labelCar);
            this.groupBoxStep1.Location = new System.Drawing.Point(11, 17);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(678, 248);
            this.groupBoxStep1.TabIndex = 1;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "出入厂信息";
            // 
            // textBoxXsks
            // 
            this.textBoxXsks.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxXsks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxXsks.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxXsks.Location = new System.Drawing.Point(291, 135);
            this.textBoxXsks.Name = "textBoxXsks";
            this.textBoxXsks.Size = new System.Drawing.Size(130, 21);
            this.textBoxXsks.TabIndex = 10;
            this.textBoxXsks.Leave += new System.EventHandler(this.textBoxXsks_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "销售科室";
            // 
            // textBoxXsqy
            // 
            this.textBoxXsqy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxXsqy.Location = new System.Drawing.Point(81, 135);
            this.textBoxXsqy.Name = "textBoxXsqy";
            this.textBoxXsqy.Size = new System.Drawing.Size(104, 21);
            this.textBoxXsqy.TabIndex = 9;
            this.textBoxXsqy.Leave += new System.EventHandler(this.textBoxXsqy_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "销售区域";
            // 
            // textBoxYwy
            // 
            this.textBoxYwy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxYwy.Location = new System.Drawing.Point(543, 98);
            this.textBoxYwy.Name = "textBoxYwy";
            this.textBoxYwy.Size = new System.Drawing.Size(120, 21);
            this.textBoxYwy.TabIndex = 8;
            this.textBoxYwy.Leave += new System.EventHandler(this.textBoxYwy_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "业务员";
            // 
            // textBoxFxqd
            // 
            this.textBoxFxqd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFxqd.Location = new System.Drawing.Point(291, 98);
            this.textBoxFxqd.Name = "textBoxFxqd";
            this.textBoxFxqd.Size = new System.Drawing.Size(130, 21);
            this.textBoxFxqd.TabIndex = 7;
            this.textBoxFxqd.Leave += new System.EventHandler(this.textBoxFxqd_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "分销渠道";
            // 
            // textBoxTType
            // 
            this.textBoxTType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTType.Location = new System.Drawing.Point(81, 98);
            this.textBoxTType.Name = "textBoxTType";
            this.textBoxTType.Size = new System.Drawing.Size(104, 21);
            this.textBoxTType.TabIndex = 6;
            this.textBoxTType.Leave += new System.EventHandler(this.textBoxTType_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "发运方式";
            // 
            // textBoxCName
            // 
            this.textBoxCName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCName.Location = new System.Drawing.Point(291, 59);
            this.textBoxCName.Name = "textBoxCName";
            this.textBoxCName.Size = new System.Drawing.Size(130, 21);
            this.textBoxCName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "客户名称";
            // 
            // textBoxCNum
            // 
            this.textBoxCNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCNum.Location = new System.Drawing.Point(81, 59);
            this.textBoxCNum.Name = "textBoxCNum";
            this.textBoxCNum.Size = new System.Drawing.Size(104, 21);
            this.textBoxCNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "客户编码";
            // 
            // textBoxOA
            // 
            this.textBoxOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOA.Location = new System.Drawing.Point(291, 22);
            this.textBoxOA.Name = "textBoxOA";
            this.textBoxOA.Size = new System.Drawing.Size(130, 21);
            this.textBoxOA.TabIndex = 2;
            this.textBoxOA.TextChanged += new System.EventHandler(this.textBoxOA_TextChanged);
            this.textBoxOA.Leave += new System.EventHandler(this.textBoxOA_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "OA单号";
            // 
            // textBoxFactory
            // 
            this.textBoxFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFactory.Location = new System.Drawing.Point(543, 59);
            this.textBoxFactory.Name = "textBoxFactory";
            this.textBoxFactory.ReadOnly = true;
            this.textBoxFactory.Size = new System.Drawing.Size(120, 21);
            this.textBoxFactory.TabIndex = 5;
            // 
            // labelFactory
            // 
            this.labelFactory.AutoSize = true;
            this.labelFactory.Location = new System.Drawing.Point(495, 63);
            this.labelFactory.Name = "labelFactory";
            this.labelFactory.Size = new System.Drawing.Size(29, 12);
            this.labelFactory.TabIndex = 4;
            this.labelFactory.Text = "工厂";
            // 
            // textBoxEnterTime
            // 
            this.textBoxEnterTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEnterTime.Location = new System.Drawing.Point(543, 22);
            this.textBoxEnterTime.Name = "textBoxEnterTime";
            this.textBoxEnterTime.ReadOnly = true;
            this.textBoxEnterTime.Size = new System.Drawing.Size(120, 21);
            this.textBoxEnterTime.TabIndex = 3;
            // 
            // labelEnterTime
            // 
            this.labelEnterTime.AutoSize = true;
            this.labelEnterTime.Location = new System.Drawing.Point(471, 26);
            this.labelEnterTime.Name = "labelEnterTime";
            this.labelEnterTime.Size = new System.Drawing.Size(53, 12);
            this.labelEnterTime.TabIndex = 2;
            this.labelEnterTime.Text = "入场时间";
            // 
            // textBoxCar
            // 
            this.textBoxCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCar.Location = new System.Drawing.Point(81, 22);
            this.textBoxCar.Name = "textBoxCar";
            this.textBoxCar.Size = new System.Drawing.Size(104, 21);
            this.textBoxCar.TabIndex = 1;
            this.textBoxCar.TextChanged += new System.EventHandler(this.textBoxCar_TextChanged);
            this.textBoxCar.DoubleClick += new System.EventHandler(this.textBoxCar_DoubleClick);
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(21, 26);
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
            this.panel0.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel0.Location = new System.Drawing.Point(0, 55);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(1004, 285);
            this.panel0.TabIndex = 4;
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
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToOrderColumns = true;
            this.dataGridViewDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CpoyButton,
            this.DelButton,
            this.POSNR,
            this.MATNR,
            this.MAKTX,
            this.MENGE});
            this.dataGridViewDetails.Location = new System.Drawing.Point(23, 20);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(930, 121);
            this.dataGridViewDetails.TabIndex = 0;
            this.dataGridViewDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetails_CellContentClick);
            this.dataGridViewDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewDetails_DataError);
            // 
            // CpoyButton
            // 
            this.CpoyButton.HeaderText = "复制";
            this.CpoyButton.Name = "CpoyButton";
            this.CpoyButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CpoyButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CpoyButton.Text = "复制";
            this.CpoyButton.ToolTipText = "复制";
            this.CpoyButton.UseColumnTextForButtonValue = true;
            this.CpoyButton.Width = 50;
            // 
            // DelButton
            // 
            this.DelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DelButton.HeaderText = "删除";
            this.DelButton.Name = "DelButton";
            this.DelButton.Text = "删除";
            this.DelButton.ToolTipText = "删除";
            this.DelButton.UseColumnTextForButtonValue = true;
            this.DelButton.Width = 50;
            // 
            // POSNR
            // 
            this.POSNR.DataPropertyName = "POSNR";
            this.POSNR.HeaderText = "项目号";
            this.POSNR.Name = "POSNR";
            this.POSNR.Width = 60;
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
            this.MAKTX.Width = 200;
            // 
            // MENGE
            // 
            this.MENGE.DataPropertyName = "MENGE";
            this.MENGE.HeaderText = "订单数量";
            this.MENGE.Name = "MENGE";
            this.MENGE.Width = 120;
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
            this.panel2.TabIndex = 5;
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
            this.labelTitle.Text = "史丹利产成品换货重车入厂";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.textBoxGross);
            this.panelBottom.Controls.Add(this.labelGross);
            this.panelBottom.Controls.Add(this.groupBoxStep3);
            this.panelBottom.Controls.Add(this.textBoxWeighMan);
            this.panelBottom.Controls.Add(this.labelWeighMan);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 340);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1004, 207);
            this.panelBottom.TabIndex = 6;
            // 
            // textBoxGross
            // 
            this.textBoxGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGross.Location = new System.Drawing.Point(280, 177);
            this.textBoxGross.Name = "textBoxGross";
            this.textBoxGross.Size = new System.Drawing.Size(104, 21);
            this.textBoxGross.TabIndex = 10;
            // 
            // labelGross
            // 
            this.labelGross.AutoSize = true;
            this.labelGross.Location = new System.Drawing.Point(220, 181);
            this.labelGross.Name = "labelGross";
            this.labelGross.Size = new System.Drawing.Size(29, 12);
            this.labelGross.TabIndex = 9;
            this.labelGross.Text = "毛重";
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
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.Enabled = false;
            this.toolStripButtonPrint.Image = global::DBSolution2.Properties.Resources.修改;
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonPrint.Text = "打印";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // FinishedProductsExchangeInEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel0);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "FinishedProductsExchangeInEnter";
            this.Text = "史丹利总公司产成品销售入厂";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.panel0.ResumeLayout(false);
            this.groupBoxWeight.ResumeLayout(false);
            this.groupBoxWeight.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.groupBoxStep3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.TextBox textBoxEnterTime;
        private System.Windows.Forms.Label labelEnterTime;
        private System.Windows.Forms.TextBox textBoxCar;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Panel panel0;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxFactory;
        private System.Windows.Forms.Label labelFactory;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox textBoxWeighMan;
        private System.Windows.Forms.Label labelWeighMan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBoxStep3;
        private System.Windows.Forms.TextBox textBoxGross;
        private System.Windows.Forms.Label labelGross;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.Timer timer;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEFLAG;
        private System.Windows.Forms.TextBox textBoxOA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.DataGridViewButtonColumn CpoyButton;
        private System.Windows.Forms.DataGridViewButtonColumn DelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENGE;
        private System.Windows.Forms.TextBox textBoxCName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFxqd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxXsks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxXsqy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxYwy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
    }
}