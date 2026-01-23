using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // Alias cho Excel

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối (Sửa lại tên Server nếu cần)
        string connectionString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        // Biến để lưu quyền của người dùng hiện tại
        string currentRole;

        // Constructor nhận tham số 'role' từ LoginForm
        public Form1(string role)
        {
            InitializeComponent();
            currentRole = role; // Lưu quyền lại để dùng sau
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu

            // --- XỬ LÝ PHÂN QUYỀN ---
            if (currentRole == "Student")
            {
                btnAdd.Enabled = false;   // Làm mờ nút Thêm
                btnEdit.Enabled = false;  // Làm mờ nút Sửa
                btnDelete.Enabled = false;// Làm mờ nút Xóa

                this.Text = "Quản lý sinh viên (Chế độ Xem - Sinh viên)";
            }
            else
            {
                this.Text = "Quản lý sinh viên (Quyền Admin)";

                // Thêm nút "Cấp/Reset Tài khoản" (Chỉ Admin thấy)
                Button btnAccount = new Button();
                btnAccount.Text = "Cấp TK / Reset Pass";
                btnAccount.Size = new System.Drawing.Size(120, 30);
                btnAccount.Location = new System.Drawing.Point(510, 90);
                btnAccount.BackColor = System.Drawing.Color.Orange;
                btnAccount.Click += BtnAccount_Click;
                groupBox1.Controls.Add(btnAccount);
            }

            // Thêm nút mở form "Môn Học"
            Button btnSubject = new Button();
            btnSubject.Text = "QL Môn Học";
            btnSubject.Size = new System.Drawing.Size(100, 30);
            btnSubject.Location = new System.Drawing.Point(510, 125);
            btnSubject.BackColor = System.Drawing.Color.LightYellow;
            btnSubject.Click += (s, ev) => { new SubjectForm().ShowDialog(); }; // Sự kiện mở form

            // Nếu là sinh viên thì ẩn nút QL Môn học đi
            if (currentRole == "Student") btnSubject.Enabled = false;

            groupBox1.Controls.Add(btnSubject);

            // Gán sự kiện cho các nút
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            dgvStudent.CellClick += DgvStudent_CellClick;
            btnScore.Click += BtnScore_Click;
            btnExcel.Click += BtnExcel_Click;
        }

        // --- CÁC HÀM CHỨC NĂNG ---

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Student", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStudent.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message); }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            string query = "INSERT INTO Student VALUES (@ID, @Name, @Age, @Major)";
            ExecuteQuery(query, "Thêm");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            string query = "UPDATE Student SET Name=@Name, Age=@Age, Major=@Major WHERE ID=@ID";
            ExecuteQuery(query, "Cập nhật");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Bạn muốn xóa sinh viên này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Xóa điểm và tài khoản trước để tránh lỗi khóa ngoại
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        new SqlCommand($"DELETE FROM Score WHERE StudentID='{txtID.Text}'", conn).ExecuteNonQuery();
                        new SqlCommand($"DELETE FROM Users WHERE Username='{txtID.Text}'", conn).ExecuteNonQuery();
                    }
                }
                catch { }

                string query = "DELETE FROM Student WHERE ID=@ID";
                ExecuteQuery(query, "Xóa");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) { LoadData(); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Student WHERE Name LIKE @Keyword";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + txtSearch.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStudent.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }

        private void ExecuteQuery(string query, string action)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", txtID.Text);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    int age = 0; int.TryParse(txtAge.Text, out age);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Major", txtMajor.Text);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show(action + " thành công!");
                        LoadData();
                        ClearInput();
                    }
                    else MessageBox.Show(action + " thất bại.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("Mã sinh viên đã tồn tại!");
                else MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void DgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtMajor.Text = row.Cells["Major"].Value.ToString();
                txtID.ReadOnly = true;
            }
        }

        // --- SỬA LỖI Ở ĐÂY: Truyền currentRole vào ScoreForm ---
        private void BtnScore_Click(object sender, EventArgs e)
        {
            ScoreForm f = new ScoreForm(currentRole); // <--- Đã sửa: Thêm currentRole
            f.ShowDialog();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count == 0) return;

            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                for (int i = 0; i < dgvStudent.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvStudent.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgvStudent.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvStudent.Columns.Count; j++)
                    {
                        if (dgvStudent.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvStudent.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                worksheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        // Chức năng Cấp/Reset tài khoản
        private void BtnAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Vui lòng chọn một sinh viên!"); return; }

            string svID = txtID.Text;
            if (MessageBox.Show($"Bạn muốn cấp lại mật khẩu (123) cho {svID}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", conn);
                        check.Parameters.AddWithValue("@u", svID);
                        int exists = (int)check.ExecuteScalar();

                        if (exists > 0) // Reset
                            new SqlCommand($"UPDATE Users SET Password='123' WHERE Username='{svID}'", conn).ExecuteNonQuery();
                        else // Tạo mới
                            new SqlCommand($"INSERT INTO Users VALUES ('{svID}', '123', 'Student')", conn).ExecuteNonQuery();

                        MessageBox.Show("Thành công! Mật khẩu là 123");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên!"); return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtID.Text = ""; txtName.Text = ""; txtAge.Text = ""; txtMajor.Text = "";
            txtID.ReadOnly = false;
        }
    }
}