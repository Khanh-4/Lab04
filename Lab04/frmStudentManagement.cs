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
    public partial class frmStudentManagement : Form
    {
        // Khai báo context để làm việc với Entity Framework
        StudentContextDB context = new StudentContextDB();

        public frmStudentManagement()
        {
            InitializeComponent();
        }

        #region Form Load Event
        private void frmStudentManagement_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách khoa và sinh viên từ database
                List<Faculty> listFaculties = context.Faculty.ToList();
                List<Student> listStudents = context.Student.ToList();

                // Binding dữ liệu lên ComboBox và DataGridView
                FillFacultyCombobox(listFaculties);
                BindGrid(listStudents);
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
        /// Binding ComboBox Khoa với danh sách Faculty
        /// </summary>
        private void FillFacultyCombobox(List<Faculty> listFaculties)
        {
            this.cboKhoa.DataSource = listFaculties;
            this.cboKhoa.DisplayMember = "FacultyName";
            this.cboKhoa.ValueMember = "FacultyID";
        }

        /// <summary>
        /// Binding DataGridView từ danh sách sinh viên
        /// </summary>
        private void BindGrid(List<Student> listStudents)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells["colMaSV"].Value = item.StudentID;
                dgvStudent.Rows[index].Cells["colHoTen"].Value = item.FullName;
                dgvStudent.Rows[index].Cells["colTenKhoa"].Value = item.Faculty != null ? item.Faculty.FacultyName : "";
                dgvStudent.Rows[index].Cells["colDiemTB"].Value = item.AverageScore;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào hợp lệ
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiemTB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra mã sinh viên phải có 10 ký tự
            if (txtMaSV.Text.Trim().Length != 10)
            {
                MessageBox.Show("Mã số sinh viên phải có 10 kí tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }

            // Kiểm tra điểm trung bình phải là số
            float score;
            if (!float.TryParse(txtDiemTB.Text, out score))
            {
                MessageBox.Show("Điểm trung bình phải là số!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemTB.Focus();
                return false;
            }

            // Kiểm tra điểm trong khoảng hợp lệ (0-10)
            if (score < 0 || score > 10)
            {
                MessageBox.Show("Điểm trung bình phải từ 0 đến 10!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemTB.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Reset các TextBox về giá trị ban đầu
        /// </summary>
        private void ResetForm()
        {
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            txtDiemTB.Text = "";
            if (cboKhoa.Items.Count > 0)
            {
                cboKhoa.SelectedIndex = 0;
            }
            txtMaSV.Focus();
        }

        /// <summary>
        /// Reload lại danh sách sinh viên từ database
        /// </summary>
        private void ReloadData()
        {
            // Tạo context mới để lấy dữ liệu mới nhất
            context = new StudentContextDB();
            List<Student> listStudents = context.Student.ToList();
            BindGrid(listStudents);
        }

        /// <summary>
        /// Reload lại ComboBox Khoa sau khi có thay đổi từ form Quản lý Khoa
        /// </summary>
        private void ReloadComboBoxKhoa()
        {
            try
            {
                context = new StudentContextDB();
                List<Faculty> listFaculties = context.Faculty.ToList();
                FillFacultyCombobox(listFaculties);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload ComboBox: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Sự kiện nút Thêm - Thêm sinh viên mới vào database
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (!ValidateInput())
                    return;

                string studentID = txtMaSV.Text.Trim();

                // Kiểm tra mã sinh viên đã tồn tại chưa
                Student existingStudent = context.Student.FirstOrDefault(p => p.StudentID == studentID);
                if (existingStudent != null)
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                // Tạo đối tượng sinh viên mới
                Student newStudent = new Student()
                {
                    StudentID = studentID,
                    FullName = txtHoTen.Text.Trim(),
                    AverageScore = double.Parse(txtDiemTB.Text),
                    FacultyID = Convert.ToInt32(cboKhoa.SelectedValue)
                };

                // Thêm vào database
                context.Student.Add(newStudent);
                context.SaveChanges();

                // Thông báo thành công
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        /// Sự kiện nút Sửa - Cập nhật thông tin sinh viên
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (!ValidateInput())
                    return;

                string studentID = txtMaSV.Text.Trim();

                // Tìm sinh viên cần sửa
                Student studentToUpdate = context.Student.FirstOrDefault(p => p.StudentID == studentID);

                if (studentToUpdate == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin
                studentToUpdate.FullName = txtHoTen.Text.Trim();
                studentToUpdate.AverageScore = double.Parse(txtDiemTB.Text);
                studentToUpdate.FacultyID = Convert.ToInt32(cboKhoa.SelectedValue);

                // Lưu thay đổi
                context.SaveChanges();

                // Thông báo thành công
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        /// Sự kiện nút Xóa - Xóa sinh viên khỏi database
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtMaSV.Text.Trim();

                // Kiểm tra nếu chưa nhập MSSV
                if (string.IsNullOrWhiteSpace(studentID))
                {
                    MessageBox.Show("Vui lòng nhập mã số sinh viên cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm sinh viên cần xóa
                Student studentToDelete = context.Student.FirstOrDefault(p => p.StudentID == studentID);

                if (studentToDelete == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị cảnh báo xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sinh viên '{studentToDelete.FullName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa sinh viên
                    context.Student.Remove(studentToDelete);
                    context.SaveChanges();

                    // Thông báo thành công
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo",
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
        #endregion

        #region Menu Events
        /// <summary>
        /// Menu Quản lý khoa (F2)
        /// </summary>
        private void quanLyKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormQuanLyKhoa();
        }

        /// <summary>
        /// Menu Tìm kiếm (Ctrl+F)
        /// </summary>
        private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTimKiem();
        }

        /// <summary>
        /// Menu Thoát
        /// </summary>
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region ToolStrip Events
        /// <summary>
        /// ToolStrip Button Quản lý khoa
        /// </summary>
        private void tsbQuanLyKhoa_Click(object sender, EventArgs e)
        {
            OpenFormQuanLyKhoa();
        }

        /// <summary>
        /// ToolStrip Button Tìm kiếm
        /// </summary>
        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            OpenFormTimKiem();
        }
        #endregion

        #region Helper Methods for Opening Forms
        /// <summary>
        /// Mở form Quản lý Khoa
        /// </summary>
        private void OpenFormQuanLyKhoa()
        {
            frmFaculty frmKhoa = new frmFaculty();
            frmKhoa.ShowDialog();

            // Sau khi đóng form Khoa, reload lại ComboBox Khoa và DataGridView
            ReloadComboBoxKhoa();
            ReloadData();
        }

        /// <summary>
        /// Mở form Tìm kiếm
        /// </summary>
        private void OpenFormTimKiem()
        {
            frmSearch frmTimKiem = new frmSearch();
            frmTimKiem.ShowDialog();
        }
        #endregion

        #region DataGridView Events
        /// <summary>
        /// Sự kiện khi click vào một dòng trong DataGridView
        /// Hiển thị thông tin sinh viên được chọn lên các TextBox
        /// </summary>
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào header hoặc dòng trống
                if (e.RowIndex < 0 || e.RowIndex >= dgvStudent.Rows.Count)
                    return;

                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];

                // Kiểm tra dòng có dữ liệu không
                if (row.Cells["colMaSV"].Value == null)
                    return;

                // Hiển thị lên các TextBox
                txtMaSV.Text = row.Cells["colMaSV"].Value?.ToString() ?? "";
                txtHoTen.Text = row.Cells["colHoTen"].Value?.ToString() ?? "";
                txtDiemTB.Text = row.Cells["colDiemTB"].Value?.ToString() ?? "";

                // Tìm và chọn đúng Khoa trong ComboBox
                string studentID = row.Cells["colMaSV"].Value?.ToString();
                if (!string.IsNullOrEmpty(studentID))
                {
                    Student student = context.Student.FirstOrDefault(p => p.StudentID == studentID);
                    if (student != null && student.FacultyID.HasValue)
                    {
                        cboKhoa.SelectedValue = student.FacultyID.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}