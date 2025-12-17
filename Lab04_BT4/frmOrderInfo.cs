using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_BT4.Models;

namespace Lab04_BT4
{
    public partial class frmOrderInfo : Form
    {
        // Khai báo context để làm việc với Entity Framework
        ProductOrderContext context = new ProductOrderContext();

        public frmOrderInfo()
        {
            InitializeComponent();
        }

        #region Form Load Event
        private void frmOrderInfo_Load(object sender, EventArgs e)
        {
            try
            {
                // Set ngày mặc định là ngày hiện tại
                dtpFromDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;

                // Tự động tìm kiếm dữ liệu trong ngày hiện tại
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Load dữ liệu đơn hàng theo khoảng thời gian giao hàng
        /// </summary>
        private void LoadData()
        {
            try
            {
                // Tạo context mới để lấy dữ liệu mới nhất
                context = new ProductOrderContext();

                // Lấy ngày từ DateTimePicker
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1); // Đến cuối ngày

                // Query lấy danh sách hóa đơn theo khoảng thời gian giao hàng
                var query = from inv in context.Invoice
                            where inv.DeliveryDate >= fromDate && inv.DeliveryDate <= toDate
                            select new
                            {
                                inv.InvoiceNo,
                                inv.OrderDate,
                                inv.DeliveryDate,
                                // Tính thành tiền = SUM(Price * Quantity) của các Order thuộc Invoice này
                                ThanhTien = context.Order
                                            .Where(o => o.InvoiceNo == inv.InvoiceNo)
                                            .Sum(o => o.Price * o.Quantity)
                            };

                var result = query.ToList();

                // Binding DataGridView
                dgvOrders.Rows.Clear();
                int stt = 1;
                decimal tongCong = 0;

                foreach (var item in result)
                {
                    int index = dgvOrders.Rows.Add();
                    dgvOrders.Rows[index].Cells["colSTT"].Value = stt++;
                    dgvOrders.Rows[index].Cells["colSoHD"].Value = item.InvoiceNo;
                    dgvOrders.Rows[index].Cells["colNgayDatHang"].Value = item.OrderDate.ToString("dd/MM/yyyy");
                    dgvOrders.Rows[index].Cells["colNgayGiaoHang"].Value = item.DeliveryDate.ToString("dd/MM/yyyy");
                    dgvOrders.Rows[index].Cells["colThanhTien"].Value = item.ThanhTien;

                    // Cộng dồn tổng cộng
                    if (item.ThanhTien != null)
                        tongCong += (decimal)item.ThanhTien;
                }

                // Hiển thị tổng cộng
                txtTongCong.Text = tongCong.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set thời gian từ đầu tháng đến cuối tháng hiện tại
        /// </summary>
        private void SetMonthRange()
        {
            // Ngày đầu tháng
            DateTime firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            // Ngày cuối tháng
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtpFromDate.Value = firstDayOfMonth;
            dtpToDate.Value = lastDayOfMonth;
        }

        /// <summary>
        /// Set thời gian về ngày hiện tại
        /// </summary>
        private void SetTodayRange()
        {
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Sự kiện khi thay đổi ngày bắt đầu
        /// </summary>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            // Tự động load lại dữ liệu khi thay đổi ngày
            LoadData();
        }

        /// <summary>
        /// Sự kiện khi thay đổi ngày kết thúc
        /// </summary>
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            // Tự động load lại dữ liệu khi thay đổi ngày
            LoadData();
        }

        /// <summary>
        /// Sự kiện khi check/uncheck CheckBox "Xem tất cả trong tháng"
        /// </summary>
        private void chkXemTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXemTatCa.Checked)
            {
                // Nếu check: Set từ đầu tháng đến cuối tháng
                SetMonthRange();
            }
            else
            {
                // Nếu uncheck: Set về ngày hiện tại
                SetTodayRange();
            }

            // Load lại dữ liệu
            LoadData();
        }
        #endregion
    }
}