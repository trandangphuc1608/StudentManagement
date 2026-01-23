using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class ChangePasswordForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";
        string currentUsername; // Lưu tài khoản đang đăng nhập

        public ChangePasswordForm(string username)
        {
            InitializeComponent();
            currentUsername = username;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // 1. Kiểm tra mật khẩu cũ có đúng không
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p", conn);
                    checkCmd.Parameters.AddWithValue("@u", currentUsername);
                    checkCmd.Parameters.AddWithValue("@p", txtOldPass.Text);

                    if ((int)checkCmd.ExecuteScalar() == 0)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng!");
                        return;
                    }

                    // 2. Cập nhật mật khẩu mới
                    SqlCommand updateCmd = new SqlCommand("UPDATE Users SET Password=@new WHERE Username=@u", conn);
                    updateCmd.Parameters.AddWithValue("@new", txtNewPass.Text);
                    updateCmd.Parameters.AddWithValue("@u", currentUsername);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}