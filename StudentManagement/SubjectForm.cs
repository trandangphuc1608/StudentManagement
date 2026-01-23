using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class SubjectForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";

        public SubjectForm()
        {
            InitializeComponent();
            LoadData();

            // Gán sự kiện
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
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text)) return;
            string sql = "INSERT INTO Subject VALUES (@id, @name, @credit)";
            ExecuteQuery(sql, "Thêm");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            string sql = "UPDATE Subject SET SubjectName=@name, Credits=@credit WHERE SubjectID=@id";
            ExecuteQuery(sql, "Sửa");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            // Cảnh báo: Nếu xóa môn học, điểm số liên quan sẽ bị lỗi hoặc mất
            if (MessageBox.Show("Xóa môn học sẽ xóa hết điểm của môn này. Tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        // Xóa điểm trước (để tránh lỗi khóa ngoại)
                        SqlCommand cmdScore = new SqlCommand("DELETE FROM Score WHERE SubjectID=@id", conn);
                        cmdScore.Parameters.AddWithValue("@id", txtID.Text);
                        cmdScore.ExecuteNonQuery();

                        // Sau đó xóa môn
                        SqlCommand cmdSub = new SqlCommand("DELETE FROM Subject WHERE SubjectID=@id", conn);
                        cmdSub.Parameters.AddWithValue("@id", txtID.Text);
                        cmdSub.ExecuteNonQuery();

                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        ClearInput();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void ExecuteQuery(string sql, string action)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@credit", (int)nudCredit.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(action + " thành công!");
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi SQL: " + ex.Message); }
        }

        private void DgvSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSubject.Rows[e.RowIndex];
                txtID.Text = row.Cells["SubjectID"].Value.ToString();
                txtName.Text = row.Cells["SubjectName"].Value.ToString();
                nudCredit.Value = int.Parse(row.Cells["Credits"].Value.ToString());
                txtID.ReadOnly = true;
            }
        }

        private void ClearInput()
        {
            txtID.Text = ""; txtName.Text = ""; nudCredit.Value = 1;
            txtID.ReadOnly = false;
        }
    }
}