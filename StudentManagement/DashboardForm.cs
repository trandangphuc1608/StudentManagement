using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
// Thư viện biểu đồ (Quan trọng)
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentManagement
{
    public partial class DashboardForm : Form
    {
        // Chuỗi kết nối
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        // Lưu thông tin người dùng hiện tại
        string currentRole;
        string currentUser; // Mã SV (Username)

        public DashboardForm(string role, string username)
        {
            InitializeComponent();
            currentRole = role;
            currentUser = username;

            // Load số liệu và Biểu đồ
            LoadStatistics();

            // Đăng ký sự kiện Click cho menu
            btnStudent.Click += (s, e) => OpenForm(new Form1(currentRole));
            btnSubject.Click += (s, e) => OpenForm(new SubjectForm());

            // QUAN TRỌNG: Truyền cả Role và Username sang ScoreForm để bảo mật
            btnScore.Click += (s, e) => OpenForm(new ScoreForm(currentRole, currentUser));

            btnLogout.Click += BtnLogout_Click;

            // --- XỬ LÝ GIAO DIỆN THEO QUYỀN ---
            if (role == "Student")
            {
                // Lấy tên thật hiển thị cho thân thiện
                string realName = GetStudentName(username);
                lblTitle.Text = $"CHÀO SINH VIÊN: {realName.ToUpper()}";

                // Sinh viên không được quản lý môn học
                btnSubject.Enabled = false;
            }
            else
            {
                lblTitle.Text = $"DASHBOARD ADMIN: {username.ToUpper()}";
            }

            // --- THÊM NÚT MENU (DYNAMIC) ---

            // 1. Nút Thống kê & Xếp loại
            Button btnReport = CreateMenuButton("  Thống kê & Xếp loại");
            pnlMenu.Controls.Add(btnReport);
            pnlMenu.Controls.SetChildIndex(btnReport, 2); // Đặt vị trí
            btnReport.Click += (s, e) => OpenForm(new ReportForm());

            // 2. Nút Đổi mật khẩu
            Button btnChangePass = CreateMenuButton("  Đổi Mật Khẩu");
            pnlMenu.Controls.Add(btnChangePass);
            pnlMenu.Controls.SetChildIndex(btnChangePass, 3);
            btnChangePass.Click += (s, e) => {
                ChangePasswordForm frm = new ChangePasswordForm(currentUser);
                frm.ShowDialog();
            };

            if (currentRole == "Admin")
            {
                Button btnUser = CreateMenuButton("  Quản lý Người dùng");
                pnlMenu.Controls.Add(btnUser);
                pnlMenu.Controls.SetChildIndex(btnUser, 4); // Đặt vị trí dưới cùng
                btnUser.Click += (s, e) => OpenForm(new UserForm());
            }
        }

        // --- HÀM 1: LẤY TÊN SINH VIÊN TỪ ID ---
        private string GetStudentName(string studentID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT Name FROM Student WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", studentID);
                    object result = cmd.ExecuteScalar();
                    if (result != null) return result.ToString();
                }
            }
            catch { }
            return studentID; // Nếu lỗi thì trả về ID
        }

        // --- HÀM 2: LOAD SỐ LIỆU & BIỂU ĐỒ ---
        private void LoadStatistics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // 1. Cập nhật các thẻ số liệu (Cards)
                    lblNumStudent.Text = new SqlCommand("SELECT COUNT(*) FROM Student", conn).ExecuteScalar().ToString();
                    lblNumSubject.Text = new SqlCommand("SELECT COUNT(*) FROM Subject", conn).ExecuteScalar().ToString();
                    lblNumScore.Text = new SqlCommand("SELECT COUNT(DISTINCT StudentID) FROM Score", conn).ExecuteScalar().ToString();

                    // 2. Vẽ biểu đồ tròn (Pie Chart) - Thống kê học lực
                    LoadChart(conn);
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi database chưa có bảng...
                lblNumStudent.Text = "0";
            }
        }

        private void LoadChart(SqlConnection conn)
        {
            // Query: Tính điểm TB -> Xếp loại -> Đếm số lượng từng loại
            string sql = @"
                SELECT XepLoai, COUNT(*) AS SoLuong FROM (
                    SELECT 
                        CASE 
                            WHEN AVG(ScoreValue) >= 8.5 THEN N'Giỏi'
                            WHEN AVG(ScoreValue) >= 7.0 THEN N'Khá'
                            WHEN AVG(ScoreValue) >= 5.0 THEN N'Trung Bình'
                            ELSE N'Yếu'
                        END AS XepLoai
                    FROM Score
                    GROUP BY StudentID
                ) AS Tmp
                GROUP BY XepLoai";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trên biểu đồ
            chartHocLuc.Series["HocLuc"].Points.Clear();

            // Đổ dữ liệu mới vào
            while (reader.Read())
            {
                string loai = reader["XepLoai"].ToString();
                int soluong = Convert.ToInt32(reader["SoLuong"]);

                // Thêm điểm vào biểu đồ
                DataPoint point = new DataPoint();
                point.SetValueXY(loai, soluong);
                point.Label = $"{loai}: {soluong}"; // Hiện nhãn trên miếng bánh
                chartHocLuc.Series["HocLuc"].Points.Add(point);
            }
            reader.Close();
        }

        // --- CÁC HÀM HỖ TRỢ KHÁC ---

        private Button CreateMenuButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.Gainsboro;
            btn.Font = new Font("Segoe UI", 10F);
            btn.Height = 60;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            return btn;
        }

        private void OpenForm(Form childForm)
        {
            this.Hide();
            childForm.ShowDialog();
            this.Show();
            LoadStatistics(); // Refresh lại dữ liệu khi đóng form con
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}