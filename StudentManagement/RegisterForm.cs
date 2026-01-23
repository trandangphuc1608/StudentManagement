using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class RegisterForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        public RegisterForm()
        {
            InitializeComponent();

            // Gán sự kiện
            btnSubmit.Click += BtnSubmit_Click;
            btnClose.Click += (s, e) => this.Close();
            btnBack.Click += (s, e) => this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // 1. Kiểm tra tài khoản tồn tại
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", conn);
                    checkCmd.Parameters.AddWithValue("@u", txtUser.Text);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    // 2. Thêm mới (MẶC ĐỊNH LÀ STUDENT)
                    string query = "INSERT INTO Users VALUES (@u, @p, @r)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", txtUser.Text);
                    cmd.Parameters.AddWithValue("@p", txtPass.Text);

                    // --- THAY ĐỔI Ở ĐÂY: Fix cứng quyền là 'Student' ---
                    cmd.Parameters.AddWithValue("@r", "Student");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}