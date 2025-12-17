namespace Lab04
{
    partial class frmFaculty
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtTongSoGS = new System.Windows.Forms.TextBox();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.lblTongSoGS = new System.Windows.Forms.Label();
            this.lblTenKhoa = new System.Windows.Forms.Label();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.colMaKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongSoGS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThemSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(200, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Khoa";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtTongSoGS);
            this.grpThongTin.Controls.Add(this.txtTenKhoa);
            this.grpThongTin.Controls.Add(this.txtMaKhoa);
            this.grpThongTin.Controls.Add(this.lblTongSoGS);
            this.grpThongTin.Controls.Add(this.lblTenKhoa);
            this.grpThongTin.Controls.Add(this.lblMaKhoa);
            this.grpThongTin.ForeColor = System.Drawing.Color.Blue;
            this.grpThongTin.Location = new System.Drawing.Point(12, 50);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(220, 150);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông Tin Khoa";
            // 
            // txtTongSoGS
            // 
            this.txtTongSoGS.Location = new System.Drawing.Point(80, 110);
            this.txtTongSoGS.Name = "txtTongSoGS";
            this.txtTongSoGS.Size = new System.Drawing.Size(120, 20);
            this.txtTongSoGS.TabIndex = 5;
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Location = new System.Drawing.Point(80, 70);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(120, 20);
            this.txtTenKhoa.TabIndex = 4;
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.Location = new System.Drawing.Point(80, 30);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Size = new System.Drawing.Size(120, 20);
            this.txtMaKhoa.TabIndex = 3;
            // 
            // lblTongSoGS
            // 
            this.lblTongSoGS.AutoSize = true;
            this.lblTongSoGS.ForeColor = System.Drawing.Color.Black;
            this.lblTongSoGS.Location = new System.Drawing.Point(15, 113);
            this.lblTongSoGS.Name = "lblTongSoGS";
            this.lblTongSoGS.Size = new System.Drawing.Size(60, 13);
            this.lblTongSoGS.TabIndex = 2;
            this.lblTongSoGS.Text = "Tổng số GS";
            // 
            // lblTenKhoa
            // 
            this.lblTenKhoa.AutoSize = true;
            this.lblTenKhoa.ForeColor = System.Drawing.Color.Black;
            this.lblTenKhoa.Location = new System.Drawing.Point(15, 73);
            this.lblTenKhoa.Name = "lblTenKhoa";
            this.lblTenKhoa.Size = new System.Drawing.Size(55, 13);
            this.lblTenKhoa.TabIndex = 1;
            this.lblTenKhoa.Text = "Tên Khoa";
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.ForeColor = System.Drawing.Color.Black;
            this.lblMaKhoa.Location = new System.Drawing.Point(15, 33);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(50, 13);
            this.lblMaKhoa.TabIndex = 0;
            this.lblMaKhoa.Text = "Mã Khoa";
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.AllowUserToAddRows = false;
            this.dgvFaculty.AllowUserToDeleteRows = false;
            this.dgvFaculty.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKhoa,
            this.colTenKhoa,
            this.colTongSoGS});
            this.dgvFaculty.Location = new System.Drawing.Point(250, 50);
            this.dgvFaculty.MultiSelect = false;
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.ReadOnly = true;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(320, 150);
            this.dgvFaculty.TabIndex = 2;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            // 
            // colMaKhoa
            // 
            this.colMaKhoa.HeaderText = "Mã Khoa";
            this.colMaKhoa.Name = "colMaKhoa";
            this.colMaKhoa.ReadOnly = true;
            this.colMaKhoa.Width = 70;
            // 
            // colTenKhoa
            // 
            this.colTenKhoa.HeaderText = "Tên Khoa";
            this.colTenKhoa.Name = "colTenKhoa";
            this.colTenKhoa.ReadOnly = true;
            this.colTenKhoa.Width = 140;
            // 
            // colTongSoGS
            // 
            this.colTongSoGS.HeaderText = "Tổng số GS";
            this.colTongSoGS.Name = "colTongSoGS";
            this.colTongSoGS.ReadOnly = true;
            this.colTongSoGS.Width = 80;
            // 
            // btnThemSua
            // 
            this.btnThemSua.Location = new System.Drawing.Point(30, 220);
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(90, 30);
            this.btnThemSua.TabIndex = 3;
            this.btnThemSua.Text = "Thêm / Sửa";
            this.btnThemSua.UseVisualStyleBackColor = true;
            this.btnThemSua.Click += new System.EventHandler(this.btnThemSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(140, 220);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(495, 220);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 30);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 271);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThemSua);
            this.Controls.Add(this.dgvFaculty);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFaculty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khoa";
            this.Load += new System.EventHandler(this.frmFaculty_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtTongSoGS;
        private System.Windows.Forms.TextBox txtTenKhoa;
        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.Label lblTongSoGS;
        private System.Windows.Forms.Label lblTenKhoa;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.DataGridView dgvFaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongSoGS;
        private System.Windows.Forms.Button btnThemSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
    }
}