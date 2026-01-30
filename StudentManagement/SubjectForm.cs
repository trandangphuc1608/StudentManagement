using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class SubjectForm : Form
    {
        // Chuỗi kết nối (Giống Form1)
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        public SubjectForm()
        {
            InitializeComponent();
            LoadData(); // Load danh sách ngay khi mở form

            // Đăng ký sự kiện (Nối dây thủ công cho chắc chắn)
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvSubject.CellClick += DgvSubject_CellClick;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Subject", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSubject.DataSource = dt;

                    // Đặt tên cột tiếng Việt cho đẹp
                    dgvSubject.Columns["SubjectID"].HeaderText = "Mã Môn";
                    dgvSubject.Columns["SubjectName"].HeaderText = "Tên Môn Học";
                    dgvSubject.Columns["Credits"].HeaderText = "Số Tín Chỉ";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void ExecuteQuery(string query, string action)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@credits", numCredits.Value);

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
                if (ex.Number == 2627) MessageBox.Show("Mã môn học đã tồn tại!");
                else MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên môn!"); return;
            }
            string query = "INSERT INTO Subject (SubjectID, SubjectName, Credits) VALUES (@id, @name, @credits)";
            ExecuteQuery(query, "Thêm");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            string query = "UPDATE Subject SET SubjectName=@name, Credits=@credits WHERE SubjectID=@id";
            ExecuteQuery(query, "Cập nhật");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;

            if (MessageBox.Show("Xóa môn học này sẽ xóa tất cả điểm số liên quan. Tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Subject WHERE SubjectID=@id";
                // Xóa điểm trước để tránh lỗi khóa ngoại (nếu chưa set Cascade trong SQL)
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        new SqlCommand($"DELETE FROM Score WHERE SubjectID='{txtID.Text}'", conn).ExecuteNonQuery();
                    }
                }
                catch { }

                ExecuteQuery(query, "Xóa");
            }
        }

        private void DgvSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSubject.Rows[e.RowIndex];
                txtID.Text = row.Cells["SubjectID"].Value.ToString();
                txtName.Text = row.Cells["SubjectName"].Value.ToString();
                numCredits.Value = Convert.ToDecimal(row.Cells["Credits"].Value);
                txtID.ReadOnly = true; // Không cho sửa Mã khi đang chọn
            }
        }

        private void ClearInput()
        {
            txtID.Text = ""; txtName.Text = ""; numCredits.Value = 3;
            txtID.ReadOnly = false;
        }
    }
}