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
    public partial class frmSearch : Form
    {
        // Khai báo context để làm việc với Entity Framework
        StudentContextDB context = new StudentContextDB();

        public frmSearch()
        {
            InitializeComponent();
        }

        #region Form Load Event
        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách khoa vào ComboBox
                LoadComboBoxKhoa();

                // Reset form về giá trị mặc định
                ResetForm();
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
        /// Load danh sách khoa vào ComboBox với item rỗng đầu tiên
        /// </summary>
        private void LoadComboBoxKhoa()
        {
            // Lấy danh sách khoa từ database
            List<Faculty> listFaculties = context.Faculty.ToList();

            // Tạo một item rỗng để thêm vào đầu danh sách
            Faculty emptyFaculty = new Faculty()
            {
                FacultyID = 0,
                FacultyName = ""
            };

            // Tạo danh sách mới với item rỗng ở đầu
            List<Faculty> listWithEmpty = new List<Faculty>();
            listWithEmpty.Add(emptyFaculty);
            listWithEmpty.AddRange(listFaculties);

            // Binding vào ComboBox
            cboKhoa.DataSource = listWithEmpty;
            cboKhoa.DisplayMember = "FacultyName";
            cboKhoa.ValueMember = "FacultyID";
            cboKhoa.SelectedIndex = 0; // Mặc định chọn item rỗng
        }

        /// <summary>
        /// Binding DataGridView từ danh sách sinh viên
        /// </summary>
        private void BindGrid(List<Student> listStudents)
        {
            dgvResult.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvResult.Rows.Add();
                dgvResult.Rows[index].Cells["colMaSV"].Value = item.StudentID;
                dgvResult.Rows[index].Cells["colHoTen"].Value = item.FullName;
                dgvResult.Rows[index].Cells["colTenKhoa"].Value = item.Faculty != null ? item.Faculty.FacultyName : "";
                dgvResult.Rows[index].Cells["colDiemTB"].Value = item.AverageScore;
            }

            // Cập nhật số lượng kết quả tìm kiếm
            txtKetQua.Text = listStudents.Count.ToString();
        }

        /// <summary>
        /// Reset form về giá trị mặc định
        /// </summary>
        private void ResetForm()
        {
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            cboKhoa.SelectedIndex = 0; // Chọn item rỗng
            dgvResult.Rows.Clear();
            txtKetQua.Text = "0";
            txtMaSV.Focus();
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Sự kiện nút Tìm Kiếm
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị tìm kiếm
                string maSV = txtMaSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                int? facultyID = null;

                // Kiểm tra nếu có chọn khoa (không phải item rỗng)
                if (cboKhoa.SelectedIndex > 0)
                {
                    facultyID = Convert.ToInt32(cboKhoa.SelectedValue);
                }

                // Tạo context mới để lấy dữ liệu mới nhất
                context = new StudentContextDB();

                // Bắt đầu với toàn bộ danh sách sinh viên
                IQueryable<Student> query = context.Student;

                // Áp dụng điều kiện tìm kiếm theo Mã SV (nếu có nhập)
                if (!string.IsNullOrEmpty(maSV))
                {
                    query = query.Where(s => s.StudentID.Contains(maSV));
                }

                // Áp dụng điều kiện tìm kiếm theo Họ Tên (nếu có nhập)
                if (!string.IsNullOrEmpty(hoTen))
                {
                    query = query.Where(s => s.FullName.Contains(hoTen));
                }

                // Áp dụng điều kiện tìm kiếm theo Khoa (nếu có chọn)
                if (facultyID.HasValue && facultyID.Value > 0)
                {
                    query = query.Where(s => s.FacultyID == facultyID.Value);
                }

                // Thực thi query và lấy kết quả
                List<Student> result = query.ToList();

                // Hiển thị kết quả lên DataGridView
                BindGrid(result);

                // Thông báo nếu không tìm thấy
                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào phù hợp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện nút Xóa - Reset form về giá trị mặc định
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Sự kiện nút Trở về - Đóng form
        /// </summary>
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}