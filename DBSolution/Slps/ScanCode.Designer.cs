namespace DBSolution
{
    partial class ScanCode
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("q");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("w");
            this.textQrCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewCars = new System.Windows.Forms.ListView();
            this.rowNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.carNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sapOrderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonReScan = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.orderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qrcodeScanResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textQrCode
            // 
            this.textQrCode.Font = new System.Drawing.Font("宋体", 20F);
            this.textQrCode.ForeColor = System.Drawing.Color.Crimson;
            this.textQrCode.Location = new System.Drawing.Point(293, 114);
            this.textQrCode.Name = "textQrCode";
            this.textQrCode.Size = new System.Drawing.Size(385, 38);
            this.textQrCode.TabIndex = 0;
            this.textQrCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textQrCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textQrCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(290, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "请使用扫码枪扫描单据二维码";
            // 
            // listViewCars
            // 
            this.listViewCars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rowNo,
            this.carNo,
            this.sapOrderNo,
            this.orderType,
            this.orderStatus,
            this.qrcodeScanResult});
            this.listViewCars.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewCars.Font = new System.Drawing.Font("宋体", 15F);
            this.listViewCars.FullRowSelect = true;
            this.listViewCars.GridLines = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.listViewCars.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listViewCars.LabelWrap = false;
            this.listViewCars.Location = new System.Drawing.Point(0, 200);
            this.listViewCars.Name = "listViewCars";
            this.listViewCars.Size = new System.Drawing.Size(1011, 277);
            this.listViewCars.TabIndex = 3;
            this.listViewCars.UseCompatibleStateImageBehavior = false;
            this.listViewCars.View = System.Windows.Forms.View.Details;
            // 
            // rowNo
            // 
            this.rowNo.Text = "序号";
            this.rowNo.Width = 100;
            // 
            // carNo
            // 
            this.carNo.Text = "车牌号";
            this.carNo.Width = 200;
            // 
            // sapOrderNo
            // 
            this.sapOrderNo.Text = "SAP订单号";
            this.sapOrderNo.Width = 400;
            // 
            // orderStatus
            // 
            this.orderStatus.Text = "状态";
            this.orderStatus.Width = 80;
            // 
            // buttonReScan
            // 
            this.buttonReScan.Font = new System.Drawing.Font("宋体", 10F);
            this.buttonReScan.Location = new System.Drawing.Point(684, 114);
            this.buttonReScan.Name = "buttonReScan";
            this.buttonReScan.Size = new System.Drawing.Size(103, 38);
            this.buttonReScan.TabIndex = 4;
            this.buttonReScan.Text = "重新扫描";
            this.buttonReScan.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNext.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonNext.Location = new System.Drawing.Point(793, 114);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(103, 38);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "下一步";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // orderType
            // 
            this.orderType.Text = "订单类型";
            this.orderType.Width = 100;
            // 
            // qrcodeScanResult
            // 
            this.qrcodeScanResult.Text = "二维码";
            this.qrcodeScanResult.Width = 96;
            // 
            // ScanCode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1011, 477);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonReScan);
            this.Controls.Add(this.listViewCars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textQrCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScanCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanCode";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textQrCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewCars;
        private System.Windows.Forms.ColumnHeader rowNo;
        private System.Windows.Forms.ColumnHeader sapOrderNo;
        private System.Windows.Forms.ColumnHeader carNo;
        private System.Windows.Forms.ColumnHeader orderStatus;
        private System.Windows.Forms.Button buttonReScan;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.ColumnHeader orderType;
        private System.Windows.Forms.ColumnHeader qrcodeScanResult;
    }
}