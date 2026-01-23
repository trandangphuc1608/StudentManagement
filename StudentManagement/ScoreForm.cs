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
        string currentID; // Biến lưu mã sinh viên (nếu là sinh viên đăng nhập)

        // --- CẬP NHẬT CONSTRUCTOR NHẬN 2 THAM SỐ ---
        public ScoreForm(string role, string username = "")
        {
            InitializeComponent();
            currentRole = role;
            currentID = username; // Lưu username (Mã SV) được truyền từ Dashboard

            LoadComboBoxes(); // Tải danh sách SV, Môn học vào ComboBox
            LoadScoreData();  // Tải dữ liệu điểm lên bảng

            // --- PHÂN QUYỀN GIAO DIỆN ---
            if (currentRole == "Student")
            {
                // Nếu là Sinh viên: Ẩn các chức năng nhập liệu, chỉ cho xem
                btnSave.Enabled = false;
                btnSave.Visible = false;
                cboStudent.Enabled = false;
                cboSubject.Enabled = false;
                txtScore.Enabled = false;
                this.Text = "Xem Bảng Điểm Cá Nhân";
            }

            btnSave.Click += BtnSave_Click;
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Load danh sách Sinh viên
                    SqlDataAdapter daSV = new SqlDataAdapter("SELECT ID, Name FROM Student", conn);
                    DataTable dtSV = new DataTable();
                    daSV.Fill(dtSV);
                    cboStudent.DataSource = dtSV;
                    cboStudent.DisplayMember = "Name";
                    cboStudent.ValueMember = "ID";

                    // Load danh sách Môn học
                    SqlDataAdapter daMH = new SqlDataAdapter("SELECT SubjectID, SubjectName FROM Subject", conn);
                    DataTable dtMH = new DataTable();
                    daMH.Fill(dtMH);
                    cboSubject.DataSource = dtMH;
                    cboSubject.DisplayMember = "SubjectName";
                    cboSubject.ValueMember = "SubjectID";
                }
            }
            catch { }
        }

        private void LoadScoreData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = @"SELECT st.Name AS 'Tên SV', sb.SubjectName AS 'Môn', sc.ScoreValue AS 'Điểm'
                                   FROM Score sc
                                   JOIN Student st ON sc.StudentID = st.ID
                                   JOIN Subject sb ON sc.SubjectID = sb.SubjectID";

                    // --- QUAN TRỌNG: LỌC DỮ LIỆU ---
                    // Nếu là sinh viên, chỉ lấy những dòng có ID trùng với currentID
                    if (currentRole == "Student" && !string.IsNullOrEmpty(currentID))
                    {
                        sql += $" WHERE st.ID = '{currentID}'";
                    }
                    // -------------------------------

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvScore.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải điểm: " + ex.Message); }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtScore.Text)) { MessageBox.Show("Vui lòng nhập điểm!"); return; }

            float score;
            // Kiểm tra điểm phải là số và nằm trong khoảng 0-10
            if (!float.TryParse(txtScore.Text, out score) || score < 0 || score > 10)
            {
                MessageBox.Show("Điểm phải là số từ 0 đến 10!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string svID = cboStudent.SelectedValue.ToString();
                    string mhID = cboSubject.SelectedValue.ToString();

                    // Kiểm tra xem điểm này đã tồn tại chưa
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Score WHERE StudentID=@s AND SubjectID=@m", conn);
                    check.Parameters.AddWithValue("@s", svID);
                    check.Parameters.AddWithValue("@m", mhID);

                    // Nếu có rồi thì UPDATE, chưa có thì INSERT
                    string query = ((int)check.ExecuteScalar() > 0)
                        ? "UPDATE Score SET ScoreValue=@p WHERE StudentID=@s AND SubjectID=@m"
                        : "INSERT INTO Score VALUES (@s, @m, @p)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@s", svID);
                    cmd.Parameters.AddWithValue("@m", mhID);
                    cmd.Parameters.AddWithValue("@p", score);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công!");
                    LoadScoreData(); // Tải lại bảng điểm sau khi lưu
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}