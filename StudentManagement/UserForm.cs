using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class UserForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        public UserForm()
        {
            InitializeComponent();
            LoadUsers();

            dgvUsers.CellClick += (s, e) => {
                if (e.RowIndex >= 0) txtUsername.Text = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            };

            btnAddAdmin.Click += BtnAddAdmin_Click;
            btnResetPass.Click += BtnResetPass_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Không hiện cột mật khẩu vì lý do bảo mật
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Username, Role FROM Users", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BtnAddAdmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Mặc định pass admin mới là 'admin123'
                    string query = "INSERT INTO Users VALUES (@u, 'admin123', 'Admin')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm Admin thành công! Pass mặc định: admin123");
                    LoadUsers();
                }
            }
            catch { MessageBox.Show("Tài khoản đã tồn tại!"); }
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET Password='123' WHERE Username=@u";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Đã reset mật khẩu cho {txtUsername.Text} thành '123'");
                }
            }
            catch { }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;
            if (MessageBox.Show("Xóa tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        // Chặn xóa chính mình (nếu cần logic phức tạp hơn thì thêm vào)
                        if (txtUsername.Text.ToLower() == "admin") { MessageBox.Show("Không thể xóa Super Admin!"); return; }

                        string query = "DELETE FROM Users WHERE Username=@u";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                        cmd.ExecuteNonQuery();
                        LoadUsers();
                        txtUsername.Text = "";
                    }
                }
                catch { }
            }
        }
    }
}