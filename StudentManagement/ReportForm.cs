using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class ReportForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        public ReportForm()
        {
            InitializeComponent();
            btnRefresh.Click += BtnRefresh_Click;
            LoadReport();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Câu lệnh SQL: Lấy Tên, Ngành và Tính điểm trung bình (AVG)
                    // GROUP BY là bắt buộc khi dùng hàm tổng hợp như AVG, COUNT, SUM
                    string sql = @"
                        SELECT 
                            st.ID AS 'Mã SV',
                            st.Name AS 'Họ Tên',
                            st.Major AS 'Ngành',
                            AVG(sc.ScoreValue) AS 'Điểm TB'
                        FROM Student st
                        LEFT JOIN Score sc ON st.ID = sc.StudentID
                        GROUP BY st.ID, st.Name, st.Major";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm cột Xếp loại vào DataTable (vì SQL chỉ trả về điểm số)
                    dt.Columns.Add("Xếp Loại", typeof(string));

                    // Duyệt từng dòng để xét loại
                    foreach (DataRow row in dt.Rows)
                    {
                        // Kiểm tra nếu sinh viên chưa có điểm nào (DBNull)
                        if (row["Điểm TB"] == DBNull.Value)
                        {
                            row["Điểm TB"] = 0;
                            row["Xếp Loại"] = "Chưa có điểm";
                        }
                        else
                        {
                            double avg = Convert.ToDouble(row["Điểm TB"]);
                            // Làm tròn 2 chữ số thập phân
                            row["Điểm TB"] = Math.Round(avg, 2);

                            if (avg >= 8.5) row["Xếp Loại"] = "Giỏi";
                            else if (avg >= 7.0) row["Xếp Loại"] = "Khá";
                            else if (avg >= 5.0) row["Xếp Loại"] = "Trung Bình";
                            else row["Xếp Loại"] = "Yếu";
                        }
                    }

                    dgvReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}