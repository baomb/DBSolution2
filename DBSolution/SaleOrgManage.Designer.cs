namespace DBSolution
{
    partial class SaleOrgManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleOrgManage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUpdateOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.dataCompany = new System.Windows.Forms.DataGridView();
            this.tabFactory = new System.Windows.Forms.TabPage();
            this.dataFactory = new System.Windows.Forms.DataGridView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxZlgobe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxZlgort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxZwerks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxWerks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBukrs = new System.Windows.Forms.TextBox();
            this.tabHouse = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataLgort = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLgortName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxFactory = new System.Windows.Forms.ComboBox();
            this.tabSaleType = new System.Windows.Forms.TabPage();
            this.dataSaleType = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCompany)).BeginInit();
            this.tabFactory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFactory)).BeginInit();
            this.groupBox.SuspendLayout();
            this.tabHouse.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLgort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabSaleType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSaleType)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUpdateOrg,
            this.toolStripSeparator1,
            this.toolStripButtonClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonUpdateOrg
            // 
            this.toolStripButtonUpdateOrg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUpdateOrg.Image")));
            this.toolStripButtonUpdateOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdateOrg.Name = "toolStripButtonUpdateOrg";
            this.toolStripButtonUpdateOrg.Size = new System.Drawing.Size(97, 22);
            this.toolStripButtonUpdateOrg.Text = "更新组织架构";
            this.toolStripButtonUpdateOrg.Click += new System.EventHandler(this.toolStripButtonUpdateOrg_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonClose.Text = "退出";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCompany);
            this.tabControl1.Controls.Add(this.tabFactory);
            this.tabControl1.Controls.Add(this.tabHouse);
            this.tabControl1.Controls.Add(this.tabSaleType);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 356);
            this.tabControl1.TabIndex = 1;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.dataCompany);
            this.tabCompany.Location = new System.Drawing.Point(4, 21);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(647, 331);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "公司信息";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // dataCompany
            // 
            this.dataCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataCompany.Location = new System.Drawing.Point(3, 3);
            this.dataCompany.Name = "dataCompany";
            this.dataCompany.RowTemplate.Height = 23;
            this.dataCompany.Size = new System.Drawing.Size(641, 325);
            this.dataCompany.TabIndex = 0;
            // 
            // tabFactory
            // 
            this.tabFactory.Controls.Add(this.dataFactory);
            this.tabFactory.Controls.Add(this.groupBox);
            this.tabFactory.Location = new System.Drawing.Point(4, 21);
            this.tabFactory.Name = "tabFactory";
            this.tabFactory.Padding = new System.Windows.Forms.Padding(3);
            this.tabFactory.Size = new System.Drawing.Size(647, 331);
            this.tabFactory.TabIndex = 1;
            this.tabFactory.Text = "工厂信息";
            this.tabFactory.UseVisualStyleBackColor = true;
            // 
            // dataFactory
            // 
            this.dataFactory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFactory.Location = new System.Drawing.Point(6, 3);
            this.dataFactory.Name = "dataFactory";
            this.dataFactory.RowTemplate.Height = 23;
            this.dataFactory.Size = new System.Drawing.Size(420, 320);
            this.dataFactory.TabIndex = 1;
            this.dataFactory.CurrentCellChanged += new System.EventHandler(this.dataFactory_CurrentCellChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonSave);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.textBoxZlgobe);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.textBoxZlgort);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.textBoxZwerks);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.textBoxName1);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.textBoxWerks);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.textBoxBukrs);
            this.groupBox.Location = new System.Drawing.Point(432, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(207, 322);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "详细信息";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(63, 244);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "保 存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "虚拟库存名称：";
            // 
            // textBoxZlgobe
            // 
            this.textBoxZlgobe.Location = new System.Drawing.Point(96, 191);
            this.textBoxZlgobe.Name = "textBoxZlgobe";
            this.textBoxZlgobe.Size = new System.Drawing.Size(100, 21);
            this.textBoxZlgobe.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "虚拟库存编码：";
            // 
            // textBoxZlgort
            // 
            this.textBoxZlgort.Location = new System.Drawing.Point(96, 159);
            this.textBoxZlgort.Name = "textBoxZlgort";
            this.textBoxZlgort.Size = new System.Drawing.Size(100, 21);
            this.textBoxZlgort.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "虚拟工厂：";
            // 
            // textBoxZwerks
            // 
            this.textBoxZwerks.Location = new System.Drawing.Point(96, 126);
            this.textBoxZwerks.Name = "textBoxZwerks";
            this.textBoxZwerks.ReadOnly = true;
            this.textBoxZwerks.Size = new System.Drawing.Size(100, 21);
            this.textBoxZwerks.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "工厂名称：";
            // 
            // textBoxName1
            // 
            this.textBoxName1.Location = new System.Drawing.Point(96, 95);
            this.textBoxName1.Name = "textBoxName1";
            this.textBoxName1.ReadOnly = true;
            this.textBoxName1.Size = new System.Drawing.Size(100, 21);
            this.textBoxName1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "工厂代码：";
            // 
            // textBoxWerks
            // 
            this.textBoxWerks.Location = new System.Drawing.Point(96, 62);
            this.textBoxWerks.Name = "textBoxWerks";
            this.textBoxWerks.ReadOnly = true;
            this.textBoxWerks.Size = new System.Drawing.Size(100, 21);
            this.textBoxWerks.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "公司代码：";
            // 
            // textBoxBukrs
            // 
            this.textBoxBukrs.Location = new System.Drawing.Point(96, 29);
            this.textBoxBukrs.Name = "textBoxBukrs";
            this.textBoxBukrs.ReadOnly = true;
            this.textBoxBukrs.Size = new System.Drawing.Size(100, 21);
            this.textBoxBukrs.TabIndex = 0;
            // 
            // tabHouse
            // 
            this.tabHouse.Controls.Add(this.groupBox2);
            this.tabHouse.Controls.Add(this.groupBox1);
            this.tabHouse.Location = new System.Drawing.Point(4, 21);
            this.tabHouse.Name = "tabHouse";
            this.tabHouse.Size = new System.Drawing.Size(647, 331);
            this.tabHouse.TabIndex = 2;
            this.tabHouse.Text = "库存地信息";
            this.tabHouse.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataLgort);
            this.groupBox2.Location = new System.Drawing.Point(5, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 269);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataLgort
            // 
            this.dataLgort.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataLgort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLgort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLgort.Location = new System.Drawing.Point(3, 17);
            this.dataLgort.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dataLgort.Name = "dataLgort";
            this.dataLgort.RowTemplate.Height = 23;
            this.dataLgort.Size = new System.Drawing.Size(630, 249);
            this.dataLgort.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBoxCompany);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLgortName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.comboBoxFactory);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查 询";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "公司:";
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(54, 16);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCompany.TabIndex = 7;
            this.comboBoxCompany.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompany_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "工厂名称:";
            // 
            // txtLgortName
            // 
            this.txtLgortName.Location = new System.Drawing.Point(429, 14);
            this.txtLgortName.Name = "txtLgortName";
            this.txtLgortName.Size = new System.Drawing.Size(100, 21);
            this.txtLgortName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "工厂:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(538, 13);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "查 询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxFactory
            // 
            this.comboBoxFactory.FormattingEnabled = true;
            this.comboBoxFactory.Location = new System.Drawing.Point(231, 16);
            this.comboBoxFactory.Name = "comboBoxFactory";
            this.comboBoxFactory.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFactory.TabIndex = 1;
            // 
            // tabSaleType
            // 
            this.tabSaleType.Controls.Add(this.dataSaleType);
            this.tabSaleType.Location = new System.Drawing.Point(4, 21);
            this.tabSaleType.Name = "tabSaleType";
            this.tabSaleType.Size = new System.Drawing.Size(647, 331);
            this.tabSaleType.TabIndex = 3;
            this.tabSaleType.Text = "销售渠道信息";
            this.tabSaleType.UseVisualStyleBackColor = true;
            // 
            // dataSaleType
            // 
            this.dataSaleType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataSaleType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSaleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSaleType.Location = new System.Drawing.Point(0, 0);
            this.dataSaleType.Name = "dataSaleType";
            this.dataSaleType.RowTemplate.Height = 23;
            this.dataSaleType.Size = new System.Drawing.Size(647, 331);
            this.dataSaleType.TabIndex = 0;
            // 
            // SaleOrgManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 381);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaleOrgManage";
            this.Text = "SaleOrgManage";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabCompany.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataCompany)).EndInit();
            this.tabFactory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataFactory)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tabHouse.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLgort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSaleType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSaleType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdateOrg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.DataGridView dataCompany;
        private System.Windows.Forms.TabPage tabFactory;
        private System.Windows.Forms.DataGridView dataFactory;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TabPage tabHouse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataLgort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabSaleType;
        private System.Windows.Forms.DataGridView dataSaleType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxFactory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLgortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBukrs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxWerks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxZlgobe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxZlgort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxZwerks;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxCompany;
    }
}