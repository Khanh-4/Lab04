namespace Lab04_BT4
{
    partial class frmOrderInfo
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
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.chkXemTatCa = new System.Windows.Forms.CheckBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayDatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayGiaoHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblDen);
            this.grpThongTin.Controls.Add(this.dtpToDate);
            this.grpThongTin.Controls.Add(this.dtpFromDate);
            this.grpThongTin.Controls.Add(this.lblThoiGian);
            this.grpThongTin.Controls.Add(this.chkXemTatCa);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(560, 80);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông Tin Đơn Hàng";
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(310, 52);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(19, 13);
            this.lblDen.TabIndex = 4;
            this.lblDen.Text = "~";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(340, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 20);
            this.dtpToDate.TabIndex = 3;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(180, 48);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 20);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(60, 52);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(107, 13);
            this.lblThoiGian.TabIndex = 1;
            this.lblThoiGian.Text = "Thời Gian Giao Hàng";
            // 
            // chkXemTatCa
            // 
            this.chkXemTatCa.AutoSize = true;
            this.chkXemTatCa.Location = new System.Drawing.Point(63, 25);
            this.chkXemTatCa.Name = "chkXemTatCa";
            this.chkXemTatCa.Size = new System.Drawing.Size(125, 17);
            this.chkXemTatCa.TabIndex = 0;
            this.chkXemTatCa.Text = "Xem tất cả trong tháng";
            this.chkXemTatCa.UseVisualStyleBackColor = true;
            this.chkXemTatCa.CheckedChanged += new System.EventHandler(this.chkXemTatCa_CheckedChanged);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colSoHD,
            this.colNgayDatHang,
            this.colNgayGiaoHang,
            this.colThanhTien});
            this.dgvOrders.Location = new System.Drawing.Point(12, 100);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(560, 200);
            this.dgvOrders.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colSoHD
            // 
            this.colSoHD.HeaderText = "Số HĐ";
            this.colSoHD.Name = "colSoHD";
            this.colSoHD.ReadOnly = true;
            this.colSoHD.Width = 100;
            // 
            // colNgayDatHang
            // 
            this.colNgayDatHang.HeaderText = "Ngày Đặt Hàng";
            this.colNgayDatHang.Name = "colNgayDatHang";
            this.colNgayDatHang.ReadOnly = true;
            this.colNgayDatHang.Width = 120;
            // 
            // colNgayGiaoHang
            // 
            this.colNgayGiaoHang.HeaderText = "Ngày Giao Hàng";
            this.colNgayGiaoHang.Name = "colNgayGiaoHang";
            this.colNgayGiaoHang.ReadOnly = true;
            this.colNgayGiaoHang.Width = 120;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành Tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 120;
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(380, 315);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(62, 13);
            this.lblTongCong.TabIndex = 2;
            this.lblTongCong.Text = "Tổng Cộng:";
            // 
            // txtTongCong
            // 
            this.txtTongCong.Location = new System.Drawing.Point(450, 312);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.ReadOnly = true;
            this.txtTongCong.Size = new System.Drawing.Size(122, 20);
            this.txtTongCong.TabIndex = 3;
            this.txtTongCong.Text = "0";
            this.txtTongCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 351);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.grpThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Đơn Hàng";
            this.Load += new System.EventHandler(this.frmOrderInfo_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.CheckBox chkXemTatCa;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayDatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayGiaoHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.TextBox txtTongCong;
    }
}