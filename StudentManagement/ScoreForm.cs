using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class ScoreForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";
        string currentRole;

        public ScoreForm(string role, string studentID = null)
        {
            InitializeComponent();
            currentRole = role;

            LoadSubjects(); // Tải danh sách môn vào CB
            LoadScores();   // Tải toàn bộ điểm

            // Điền sẵn mã SV nếu được truyền từ Dashboard
            if (!string.IsNullOrEmpty(studentID))
            {
                txtStudentID.Text = studentID;
                // Nếu là sinh viên, tự động lọc để chỉ hiện điểm của mình
                // (Logic này có thể mở rộng sau, hiện tại ta lọc theo môn)
            }

            // Phân quyền
            if (currentRole == "Student")
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtStudentID.ReadOnly = true;
            }

            // Gán sự kiện cho các nút chức năng
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvScore.CellClick += DgvScore_CellClick;

            // Gán sự kiện cho chức năng Lọc
            cbFilter.SelectedIndexChanged += CbFilter_SelectedIndexChanged;
            btnShowAll.Click += (s, e) => {
                cbFilter.SelectedIndex = -1; // Bỏ chọn combobox
                LoadScores(); // Tải lại tất cả
            };
        }

        // --- LOAD DATA ---
        private void LoadSubjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SubjectID, SubjectName FROM Subject", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 1. Gán cho ComboBox nhập liệu (cbSubject)
                    cbSubject.DataSource = dt;
                    cbSubject.DisplayMember = "SubjectName";
                    cbSubject.ValueMember = "SubjectID";

                    // 2. Gán cho ComboBox lọc (cbFilter) - Dùng bản sao của DataTable để tránh xung đột
                    cbFilter.DataSource = dt.Copy();
                    cbFilter.DisplayMember = "SubjectName";
                    cbFilter.ValueMember = "SubjectID";
                    cbFilter.SelectedIndex = -1; // Mặc định không chọn gì
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải môn học: " + ex.Message); }
        }

        // Hàm LoadScores được nâng cấp để hỗ trợ lọc
        private void LoadScores(string filterSubjectID = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT Score.StudentID, Student.Name, Score.SubjectID, Subject.SubjectName, Score.ScoreValue 
                        FROM Score 
                        JOIN Student ON Score.StudentID = Student.ID
                        JOIN Subject ON Score.SubjectID = Subject.SubjectID";

                    // Nếu có yêu cầu lọc theo môn
                    if (!string.IsNullOrEmpty(filterSubjectID))
                    {
                        sql += " WHERE Score.SubjectID = @fid";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (!string.IsNullOrEmpty(filterSubjectID))
                    {
                        cmd.Parameters.AddWithValue("@fid", filterSubjectID);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvScore.DataSource = dt;

                    // Định dạng cột
                    dgvScore.Columns["StudentID"].HeaderText = "Mã SV";
                    dgvScore.Columns["Name"].HeaderText = "Tên Sinh Viên";
                    dgvScore.Columns["SubjectName"].HeaderText = "Môn Học";
                    dgvScore.Columns["ScoreValue"].HeaderText = "Điểm Số";
                    dgvScore.Columns["SubjectID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải điểm: " + ex.Message); }
        }

        // --- SỰ KIỆN LỌC ---
        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != -1 && cbFilter.SelectedValue != null)
            {
                // Lấy ID môn học đang chọn và gọi hàm LoadScores với bộ lọc
                string selectedSubID = cbFilter.SelectedValue.ToString();
                LoadScores(selectedSubID);
            }
        }

        // --- CÁC CHỨC NĂNG CRUD (GIỮ NGUYÊN) ---
        private void ExecuteQuery(string query, string action)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sid", txtStudentID.Text);
                    cmd.Parameters.AddWithValue("@subid", cbSubject.SelectedValue);

                    float score = 0;
                    if (!float.TryParse(txtScore.Text, out score) || score < 0 || score > 10)
                    {
                        MessageBox.Show("Điểm phải là số từ 0 đến 10!"); return;
                    }
                    cmd.Parameters.AddWithValue("@score", score);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show(action + " thành công!");
                        // Sau khi thêm/sửa/xóa, load lại theo bộ lọc hiện tại (nếu có)
                        string currentFilter = (cbFilter.SelectedValue != null) ? cbFilter.SelectedValue.ToString() : null;
                        LoadScores(currentFilter);
                    }
                    else MessageBox.Show("Không tìm thấy sinh viên hoặc dữ liệu!");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("Sinh viên này đã có điểm môn này rồi!");
                else MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text)) return;
            string query = "INSERT INTO Score (StudentID, SubjectID, ScoreValue) VALUES (@sid, @subid, @score)";
            ExecuteQuery(query, "Nhập điểm");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Score SET ScoreValue=@score WHERE StudentID=@sid AND SubjectID=@subid";
            ExecuteQuery(query, "Cập nhật điểm");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa điểm môn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Score WHERE StudentID=@sid AND SubjectID=@subid";
                ExecuteQuery(query, "Xóa điểm");
            }
        }

        private void DgvScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvScore.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtScore.Text = row.Cells["ScoreValue"].Value.ToString();
                cbSubject.SelectedValue = row.Cells["SubjectID"].Value;
            }
        }
    }
}