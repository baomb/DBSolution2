namespace DBSolution
{
    partial class RawMaterialsSaleSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawMaterialsSaleSearch));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.View = new System.Windows.Forms.DataGridViewImageColumn();
            this.WERKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VBELN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRUCKNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXITFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENTERTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXITTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WEIGHMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXITWEIGHMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMEFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOutExcel = new System.Windows.Forms.Button();
            this.pager = new SdlDB.Utility.PageNavigator();
            this.groupBoxCondition = new System.Windows.Forms.GroupBox();
            this.cbWerks = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textWeighMan = new System.Windows.Forms.TextBox();
            this.TimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.TimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textVBELN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textTruckNum = new System.Windows.Forms.TextBox();
            this.toolStripButtonQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxCondition.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 396);
            this.panel3.TabIndex = 17;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.AllowUserToOrderColumns = true;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.View,
            this.WERKS,
            this.VBELN,
            this.TRUCKNUM,
            this.TARE,
            this.GROSS,
            this.NET,
            this.BALANCE,
            this.HS_FLAG,
            this.EXITFLAG,
            this.ENTERTIME,
            this.EXITTIME,
            this.WEIGHMAN,
            this.EXITWEIGHMAN,
            this.TIMEFLAG,
            this.HSF,
            this.EXF});
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.Size = new System.Drawing.Size(1004, 396);
            this.dataGridViewDetail.TabIndex = 0;
            this.dataGridViewDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellContentClick);
            this.dataGridViewDetail.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellContentDoubleClick);
            this.dataGridViewDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewDetail_DataBindingComplete);
            // 
            // View
            // 
            this.View.HeaderText = "查看详细";
            this.View.Image = ((System.Drawing.Image)(resources.GetObject("View.Image")));
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Width = 60;
            // 
            // WERKS
            // 
            this.WERKS.DataPropertyName = "WERKS";
            this.WERKS.HeaderText = "工厂";
            this.WERKS.Name = "WERKS";
            this.WERKS.ReadOnly = true;
            this.WERKS.Width = 60;
            // 
            // VBELN
            // 
            this.VBELN.DataPropertyName = "VBELN";
            this.VBELN.HeaderText = "销售订单";
            this.VBELN.Name = "VBELN";
            this.VBELN.ReadOnly = true;
            // 
            // TRUCKNUM
            // 
            this.TRUCKNUM.DataPropertyName = "TRUCKNUM";
            this.TRUCKNUM.HeaderText = "车牌号";
            this.TRUCKNUM.Name = "TRUCKNUM";
            this.TRUCKNUM.ReadOnly = true;
            // 
            // TARE
            // 
            this.TARE.DataPropertyName = "TARE";
            this.TARE.HeaderText = "皮重";
            this.TARE.Name = "TARE";
            this.TARE.ReadOnly = true;
            this.TARE.Width = 60;
            // 
            // GROSS
            // 
            this.GROSS.DataPropertyName = "GROSS";
            this.GROSS.HeaderText = "毛重";
            this.GROSS.Name = "GROSS";
            this.GROSS.ReadOnly = true;
            this.GROSS.Width = 60;
            // 
            // NET
            // 
            this.NET.DataPropertyName = "NET";
            this.NET.HeaderText = "净重";
            this.NET.Name = "NET";
            this.NET.ReadOnly = true;
            this.NET.Width = 60;
            // 
            // BALANCE
            // 
            this.BALANCE.DataPropertyName = "BALANCE";
            this.BALANCE.HeaderText = "差异";
            this.BALANCE.Name = "BALANCE";
            this.BALANCE.ReadOnly = true;
            // 
            // HS_FLAG
            // 
            this.HS_FLAG.HeaderText = "进出厂标识";
            this.HS_FLAG.Name = "HS_FLAG";
            this.HS_FLAG.ReadOnly = true;
            this.HS_FLAG.Width = 90;
            // 
            // EXITFLAG
            // 
            this.EXITFLAG.HeaderText = "空车出厂标识";
            this.EXITFLAG.Name = "EXITFLAG";
            this.EXITFLAG.ReadOnly = true;
            // 
            // ENTERTIME
            // 
            this.ENTERTIME.DataPropertyName = "ENTERTIME";
            this.ENTERTIME.HeaderText = "入厂时间";
            this.ENTERTIME.Name = "ENTERTIME";
            this.ENTERTIME.ReadOnly = true;
            // 
            // EXITTIME
            // 
            this.EXITTIME.DataPropertyName = "EXITTIME";
            this.EXITTIME.HeaderText = "出厂时间";
            this.EXITTIME.Name = "EXITTIME";
            this.EXITTIME.ReadOnly = true;
            // 
            // WEIGHMAN
            // 
            this.WEIGHMAN.DataPropertyName = "WEIGHMAN";
            this.WEIGHMAN.HeaderText = "进厂司磅员";
            this.WEIGHMAN.Name = "WEIGHMAN";
            this.WEIGHMAN.ReadOnly = true;
            // 
            // EXITWEIGHMAN
            // 
            this.EXITWEIGHMAN.DataPropertyName = "EXITWEIGHMAN";
            this.EXITWEIGHMAN.HeaderText = "出厂司磅员";
            this.EXITWEIGHMAN.Name = "EXITWEIGHMAN";
            this.EXITWEIGHMAN.ReadOnly = true;
            // 
            // TIMEFLAG
            // 
            this.TIMEFLAG.DataPropertyName = "TIMEFLAG";
            this.TIMEFLAG.HeaderText = "时间戳";
            this.TIMEFLAG.Name = "TIMEFLAG";
            this.TIMEFLAG.ReadOnly = true;
            this.TIMEFLAG.Visible = false;
            // 
            // HSF
            // 
            this.HSF.DataPropertyName = "HS_FLAG";
            this.HSF.HeaderText = "HSF";
            this.HSF.Name = "HSF";
            this.HSF.ReadOnly = true;
            this.HSF.Visible = false;
            // 
            // EXF
            // 
            this.EXF.DataPropertyName = "EXITFLAG";
            this.EXF.HeaderText = "EXF";
            this.EXF.Name = "EXF";
            this.EXF.ReadOnly = true;
            this.EXF.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOutExcel);
            this.panel1.Controls.Add(this.pager);
            this.panel1.Controls.Add(this.groupBoxCondition);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 96);
            this.panel1.TabIndex = 16;
            // 
            // btnOutExcel
            // 
            this.btnOutExcel.Location = new System.Drawing.Point(385, 71);
            this.btnOutExcel.Name = "btnOutExcel";
            this.btnOutExcel.Size = new System.Drawing.Size(75, 23);
            this.btnOutExcel.TabIndex = 20;
            this.btnOutExcel.Text = "导出Excel";
            this.btnOutExcel.UseVisualStyleBackColor = true;
            this.btnOutExcel.Click += new System.EventHandler(this.btnOutExcel_Click);
            // 
            // pager
            // 
            this.pager.DataSourceCount = 0;
            this.pager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager.Location = new System.Drawing.Point(0, 71);
            this.pager.Name = "pager";
            this.pager.PageIndex = 1;
            this.pager.PageSize = 0;
            this.pager.Size = new System.Drawing.Size(1004, 25);
            this.pager.TabIndex = 1;
            this.pager.Text = "pageNavigator1";
            this.pager.PageChanged += new System.EventHandler(this.pager_PageChanged);
            // 
            // groupBoxCondition
            // 
            this.groupBoxCondition.Controls.Add(this.cbWerks);
            this.groupBoxCondition.Controls.Add(this.label7);
            this.groupBoxCondition.Controls.Add(this.buttonSearch);
            this.groupBoxCondition.Controls.Add(this.label5);
            this.groupBoxCondition.Controls.Add(this.textWeighMan);
            this.groupBoxCondition.Controls.Add(this.TimePickerEnd);
            this.groupBoxCondition.Controls.Add(this.TimePickerBegin);
            this.groupBoxCondition.Controls.Add(this.label4);
            this.groupBoxCondition.Controls.Add(this.label3);
            this.groupBoxCondition.Controls.Add(this.label2);
            this.groupBoxCondition.Controls.Add(this.textVBELN);
            this.groupBoxCondition.Controls.Add(this.label1);
            this.groupBoxCondition.Controls.Add(this.textTruckNum);
            this.groupBoxCondition.Location = new System.Drawing.Point(16, 6);
            this.groupBoxCondition.Name = "groupBoxCondition";
            this.groupBoxCondition.Size = new System.Drawing.Size(972, 58);
            this.groupBoxCondition.TabIndex = 0;
            this.groupBoxCondition.TabStop = false;
            this.groupBoxCondition.Text = "查询条件";
            // 
            // cbWerks
            // 
            this.cbWerks.AllowDrop = true;
            this.cbWerks.FormattingEnabled = true;
            this.cbWerks.Location = new System.Drawing.Point(48, 24);
            this.cbWerks.Name = "cbWerks";
            this.cbWerks.Size = new System.Drawing.Size(72, 20);
            this.cbWerks.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "工厂:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(874, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "查 询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "司磅员:";
            // 
            // textWeighMan
            // 
            this.textWeighMan.Location = new System.Drawing.Point(503, 24);
            this.textWeighMan.Name = "textWeighMan";
            this.textWeighMan.Size = new System.Drawing.Size(73, 21);
            this.textWeighMan.TabIndex = 16;
            // 
            // TimePickerEnd
            // 
            this.TimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerEnd.Location = new System.Drawing.Point(771, 24);
            this.TimePickerEnd.Name = "TimePickerEnd";
            this.TimePickerEnd.Size = new System.Drawing.Size(86, 21);
            this.TimePickerEnd.TabIndex = 15;
            // 
            // TimePickerBegin
            // 
            this.TimePickerBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerBegin.Location = new System.Drawing.Point(649, 24);
            this.TimePickerBegin.Name = "TimePickerBegin";
            this.TimePickerBegin.Size = new System.Drawing.Size(97, 21);
            this.TimePickerBegin.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(749, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "进厂时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "销售订单:";
            // 
            // textVBELN
            // 
            this.textVBELN.Location = new System.Drawing.Point(344, 24);
            this.textVBELN.Name = "textVBELN";
            this.textVBELN.Size = new System.Drawing.Size(100, 21);
            this.textVBELN.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "车牌号:";
            // 
            // textTruckNum
            // 
            this.textTruckNum.Location = new System.Drawing.Point(173, 24);
            this.textTruckNum.Name = "textTruckNum";
            this.textTruckNum.Size = new System.Drawing.Size(100, 21);
            this.textTruckNum.TabIndex = 7;
            // 
            // toolStripButtonQuit
            // 
            this.toolStripButtonQuit.Image = global::DBSolution2.Properties.Resources.Close;
            this.toolStripButtonQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuit.Name = "toolStripButtonQuit";
            this.toolStripButtonQuit.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonQuit.Text = "退出";
            this.toolStripButtonQuit.Click += new System.EventHandler(this.toolStripButtonQuit_Click);
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
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
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
            this.labelTitle.Text = "史丹利原材料销售明细查询";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "查看详细";
            this.dataGridViewImageColumn1.Image = global::DBSolution2.Properties.Resources.修改1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
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
            this.panel2.TabIndex = 14;
            // 
            // RawMaterialsSaleSearch
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 547);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "RawMaterialsSaleSearch";
            this.Text = "史丹利原材料销售明细查询";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxCondition.ResumeLayout(false);
            this.groupBoxCondition.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxCondition;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textWeighMan;
        private System.Windows.Forms.DateTimePicker TimePickerEnd;
        private System.Windows.Forms.DateTimePicker TimePickerBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textVBELN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTruckNum;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel2;
        private SdlDB.Utility.PageNavigator pager;
        private System.Windows.Forms.DataGridViewImageColumn View;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn VBELN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRUCKNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NET;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HS_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXITFLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTERTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXITTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WEIGHMAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXITWEIGHMAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEFLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXF;
        private System.Windows.Forms.ComboBox cbWerks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOutExcel;
    }
}