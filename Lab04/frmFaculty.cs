using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04.Models;

namespace Lab04
{
    public partial class frmFaculty : Form
    {
        // Khai báo context để làm việc với Entity Framework
        StudentContextDB context = new StudentContextDB();

        public frmFaculty()
        {
            InitializeComponent();
        }

        #region Form Load Event
        private void frmFaculty_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách khoa từ database
                List<Faculty> listFaculties = context.Faculty.ToList();

                // Binding dữ liệu lên DataGridView
                BindGrid(listFaculties);
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
        /// Binding DataGridView từ danh sách khoa
        /// </summary>
        private void BindGrid(List<Faculty> listFaculties)
        {
            dgvFaculty.Rows.Clear();
            foreach (var item in listFaculties)
            {
                int index = dgvFaculty.Rows.Add();
                dgvFaculty.Rows[index].Cells["colMaKhoa"].Value = item.FacultyID;
                dgvFaculty.Rows[index].Cells["colTenKhoa"].Value = item.FacultyName;
                dgvFaculty.Rows[index].Cells["colTongSoGS"].Value = item.TotalProfessor;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào hợp lệ
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra mã khoa
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khoa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Focus();
                return false;
            }

            // Kiểm tra mã khoa phải là số
            int maKhoa;
            if (!int.TryParse(txtMaKhoa.Text, out maKhoa))
            {
                MessageBox.Show("Mã khoa phải là số!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Focus();
                return false;
            }

            // Kiểm tra tên khoa
            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khoa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
                return false;
            }

            // Kiểm tra tổng số GS nếu có nhập thì phải là số
            if (!string.IsNullOrWhiteSpace(txtTongSoGS.Text))
            {
                int tongSoGS;
                if (!int.TryParse(txtTongSoGS.Text, out tongSoGS))
                {
                    MessageBox.Show("Tổng số giáo sư phải là số!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTongSoGS.Focus();
                    return false;
                }

                if (tongSoGS < 0)
                {
                    MessageBox.Show("Tổng số giáo sư không được âm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTongSoGS.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Reset các TextBox về giá trị ban đầu
        /// </summary>
        private void ResetForm()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtTongSoGS.Text = "";
            txtMaKhoa.Focus();
        }

        /// <summary>
        /// Reload lại danh sách khoa từ database
        /// </summary>
        private void ReloadData()
        {
            // Tạo context mới để lấy dữ liệu mới nhất
            context = new StudentContextDB();
            List<Faculty> listFaculties = context.Faculty.ToList();
            BindGrid(listFaculties);
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Sự kiện nút Thêm/Sửa - Thêm mới hoặc cập nhật khoa
        /// </summary>
        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (!ValidateInput())
                    return;

                int facultyID = int.Parse(txtMaKhoa.Text.Trim());

                // Kiểm tra khoa đã tồn tại chưa
                Faculty existingFaculty = context.Faculty.FirstOrDefault(p => p.FacultyID == facultyID);

                if (existingFaculty == null)
                {
                    // THÊM MỚI
                    Faculty newFaculty = new Faculty()
                    {
                        FacultyID = facultyID,
                        FacultyName = txtTenKhoa.Text.Trim(),
                        TotalProfessor = string.IsNullOrWhiteSpace(txtTongSoGS.Text) ?
                                         (int?)null : int.Parse(txtTongSoGS.Text)
                    };

                    context.Faculty.Add(newFaculty);
                    context.SaveChanges();

                    MessageBox.Show("Thêm mới khoa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // CẬP NHẬT
                    existingFaculty.FacultyName = txtTenKhoa.Text.Trim();
                    existingFaculty.TotalProfessor = string.IsNullOrWhiteSpace(txtTongSoGS.Text) ?
                                                     (int?)null : int.Parse(txtTongSoGS.Text);

                    context.SaveChanges();

                    MessageBox.Show("Cập nhật khoa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reload lại DataGridView và reset form
                ReloadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện nút Xóa - Xóa khoa khỏi database
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu chưa nhập mã khoa
                if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khoa cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int facultyID;
                if (!int.TryParse(txtMaKhoa.Text, out facultyID))
                {
                    MessageBox.Show("Mã khoa phải là số!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm khoa cần xóa
                Faculty facultyToDelete = context.Faculty.FirstOrDefault(p => p.FacultyID == facultyID);

                if (facultyToDelete == null)
                {
                    MessageBox.Show("Không tìm thấy mã khoa cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem khoa có sinh viên không
                bool hasStudents = context.Student.Any(s => s.FacultyID == facultyID);
                if (hasStudents)
                {
                    MessageBox.Show("Không thể xóa khoa này vì đang có sinh viên thuộc khoa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị cảnh báo xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khoa '{facultyToDelete.FacultyName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa khoa
                    context.Faculty.Remove(facultyToDelete);
                    context.SaveChanges();

                    MessageBox.Show("Xóa khoa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload lại DataGridView và reset form
                    ReloadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện nút Đóng - Đóng form
        /// </summary>
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region DataGridView Events
        /// <summary>
        /// Sự kiện khi click vào một dòng trong DataGridView
        /// Hiển thị thông tin khoa được chọn lên các TextBox
        /// </summary>
        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào header hoặc dòng trống
                if (e.RowIndex < 0 || e.RowIndex >= dgvFaculty.Rows.Count)
                    return;

                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow row = dgvFaculty.Rows[e.RowIndex];

                // Kiểm tra dòng có dữ liệu không
                if (row.Cells["colMaKhoa"].Value == null)
                    return;

                // Hiển thị lên các TextBox
                txtMaKhoa.Text = row.Cells["colMaKhoa"].Value?.ToString() ?? "";
                txtTenKhoa.Text = row.Cells["colTenKhoa"].Value?.ToString() ?? "";
                txtTongSoGS.Text = row.Cells["colTongSoGS"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}