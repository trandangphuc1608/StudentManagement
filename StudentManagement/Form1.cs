using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";
        string currentRole;

        public Form1(string role)
        {
            InitializeComponent();
            currentRole = role;

            LoadData(); // Gọi hàm load dữ liệu ngay lập tức

            // --- NỐI DÂY SỰ KIỆN (Đúng chuẩn) ---
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            dgvStudent.CellClick += DgvStudent_CellClick;

            btnScore.Click += BtnScore_Click;
            btnExcel.Click += BtnExcel_Click;
            btnUpload.Click += BtnUpload_Click;
            btnDeleteImg.Click += (s, ev) => { picAvatar.Image = null; };
            btnPrint.Click += BtnPrint_Click;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            SetupPermissions();
        }

        private void SetupPermissions()
        {
            if (currentRole == "Student")
            {
                // Ẩn các nút thao tác nếu là SV
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnUpload.Visible = false;
                btnDeleteImg.Visible = false;

                this.Text = "Quản lý sinh viên (Chế độ Xem - Sinh viên)";
            }
            else
            {
                // Admin: Thêm nút Cấp lại MK (Code động)
                Button btnAccount = new Button();
                btnAccount.Text = "Reset Pass";
                btnAccount.BackColor = Color.OrangeRed;
                btnAccount.ForeColor = Color.White;
                btnAccount.FlatStyle = FlatStyle.Flat;
                btnAccount.FlatAppearance.BorderSize = 0;
                btnAccount.Size = new Size(100, 30);

                // Đặt vị trí nút này vào groupBox1 (Dưới nút Xuất Excel)
                // btnExcel nằm ở vị trí (510, 60), ta đặt cái này xuống dưới
                btnAccount.Location = new Point(510, 95);

                btnAccount.Click += BtnAccount_Click;
                // SỬA LỖI Ở ĐÂY: Thêm vào groupBox1 chứ không phải pnlButtons
                groupBox1.Controls.Add(btnAccount);
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        // --- CÁC HÀM LOGIC (GIỮ NGUYÊN) ---

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
                    if (dgvStudent.Columns["AvatarImage"] != null) dgvStudent.Columns["AvatarImage"].Visible = false;

                    // Đặt tên cột tiếng Việt
                    dgvStudent.Columns["ID"].HeaderText = "Mã SV";
                    dgvStudent.Columns["Name"].HeaderText = "Họ Tên";
                    dgvStudent.Columns["DateOfBirth"].HeaderText = "Ngày Sinh";
                    dgvStudent.Columns["Major"].HeaderText = "Ngành";
                    dgvStudent.Columns["Class"].HeaderText = "Lớp";
                    dgvStudent.Columns["SchoolYear"].HeaderText = "Khóa";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message); }
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
                    cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
                    cmd.Parameters.AddWithValue("@Major", txtMajor.Text);
                    cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                    cmd.Parameters.AddWithValue("@Course", txtCourse.Text);

                    byte[] imgData = ImageToByteArray(picAvatar.Image);
                    if (imgData == null) cmd.Parameters.Add("@Img", SqlDbType.VarBinary).Value = DBNull.Value;
                    else cmd.Parameters.AddWithValue("@Img", imgData);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show(action + " thành công!");
                        LoadData(); ClearInput();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- EVENTS ---
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            string query = "INSERT INTO Student (ID, Name, DateOfBirth, Major, Class, SchoolYear, AvatarImage) VALUES (@ID, @Name, @DOB, @Major, @Class, @Course, @Img)";
            ExecuteQuery(query, "Thêm");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            string query = "UPDATE Student SET Name=@Name, DateOfBirth=@DOB, Major=@Major, Class=@Class, SchoolYear=@Course, AvatarImage=@Img WHERE ID=@ID";
            ExecuteQuery(query, "Cập nhật");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Xóa sinh viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string query = "DELETE FROM Student WHERE ID=@ID";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        new SqlCommand($"DELETE FROM Score WHERE StudentID='{txtID.Text}'", conn).ExecuteNonQuery();
                        new SqlCommand($"DELETE FROM Users WHERE Username='{txtID.Text}'", conn).ExecuteNonQuery();

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", txtID.Text);
                        cmd.ExecuteNonQuery();
                        LoadData(); ClearInput();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
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
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    dgvStudent.DataSource = dt;
                }
            }
            catch { }
        }

        private void DgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtMajor.Text = row.Cells["Major"].Value.ToString();

                if (row.Cells["DateOfBirth"].Value != DBNull.Value) dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                if (dgvStudent.Columns.Contains("Class") && row.Cells["Class"].Value != DBNull.Value) txtClass.Text = row.Cells["Class"].Value.ToString();
                if (dgvStudent.Columns.Contains("SchoolYear") && row.Cells["SchoolYear"].Value != DBNull.Value) txtCourse.Text = row.Cells["SchoolYear"].Value.ToString();

                txtID.ReadOnly = true;

                if (dgvStudent.Columns.Contains("AvatarImage") && row.Cells["AvatarImage"].Value != DBNull.Value)
                    picAvatar.Image = ByteArrayToImage((byte[])row.Cells["AvatarImage"].Value);
                else picAvatar.Image = null;
            }
        }

        // --- UTILS ---
        private bool CheckInput() { return !string.IsNullOrWhiteSpace(txtID.Text) && !string.IsNullOrWhiteSpace(txtName.Text); }
        private void ClearInput()
        {
            txtID.Text = ""; txtName.Text = ""; txtMajor.Text = ""; txtClass.Text = ""; txtCourse.Text = "";
            dtpDOB.Value = DateTime.Now; picAvatar.Image = null; txtID.ReadOnly = false;
        }
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.png;*.bmp" };
            if (open.ShowDialog() == DialogResult.OK) picAvatar.Image = Image.FromFile(open.FileName);
        }
        private byte[] ImageToByteArray(Image img)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream()) { img.Save(ms, System.Drawing.Imaging.ImageFormat.Png); return ms.ToArray(); }
        }
        private Image ByteArrayToImage(byte[] data)
        {
            if (data == null) return null;
            using (MemoryStream ms = new MemoryStream(data)) return Image.FromStream(ms);
        }

        // --- SUB FEATURES ---
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Vui lòng chọn sinh viên!"); return; }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // (Code vẽ thẻ giữ nguyên)
            Font schoolFont = new Font("Arial", 14, FontStyle.Bold);
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);
            Font contentFont = new Font("Arial", 11, FontStyle.Regular);
            Brush redBrush = Brushes.DarkRed; Brush blueBrush = Brushes.DarkBlue; Brush blackBrush = Brushes.Black;
            Pen borderPen = new Pen(Color.Black, 2);

            int x = 50, y = 50, w = 480, h = 300;
            Graphics g = e.Graphics;
            g.DrawRectangle(borderPen, x, y, w, h);
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString("TRƯỜNG CAO ĐẲNG CÔNG THƯƠNG", schoolFont, redBrush, new RectangleF(x, y + 20, w, 30), centerFormat);
            g.DrawString("THẺ SINH VIÊN", titleFont, blueBrush, new RectangleF(x, y + 50, w, 30), centerFormat);

            int imgX = x + 20, imgY = y + 90, imgW = 110, imgH = 140;
            if (picAvatar.Image != null) g.DrawImage(picAvatar.Image, imgX, imgY, imgW, imgH);
            else { g.DrawRectangle(Pens.Gray, imgX, imgY, imgW, imgH); g.DrawString("Ảnh 3x4", contentFont, Brushes.Gray, imgX + 25, imgY + 60); }
            g.DrawRectangle(Pens.Gray, imgX, imgY, imgW, imgH);

            int infoX = x + 150, infoY = y + 90, lineHeight = 25;
            void DrawLine(string label, string content, int index)
            {
                int currentY = infoY + (index * lineHeight);
                g.DrawString(label, labelFont, blackBrush, infoX, currentY);
                g.DrawString(content, contentFont, blackBrush, infoX + 85, currentY);
            }
            DrawLine("Họ tên:", txtName.Text.ToUpper(), 0);
            DrawLine("MSSV:", txtID.Text, 1);
            DrawLine("Ngày sinh:", dtpDOB.Value.ToString("dd/MM/yyyy"), 2);
            DrawLine("Ngành:", txtMajor.Text, 3);
            DrawLine("Lớp:", txtClass.Text, 4);
            DrawLine("Khóa học:", txtCourse.Text, 5);
            g.DrawString("* " + txtID.Text + " *", new Font("Consolas", 10), Brushes.Black, new RectangleF(x, y + h - 30, w, 20), centerFormat);
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count == 0) return;
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook wb = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
                for (int i = 0; i < dgvStudent.Columns.Count; i++) ws.Cells[1, i + 1] = dgvStudent.Columns[i].HeaderText;
                for (int i = 0; i < dgvStudent.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvStudent.Columns.Count; j++)
                    {
                        if (dgvStudent.Rows[i].Cells[j].Value != null && dgvStudent.Columns[j].Name != "AvatarImage")
                            ws.Cells[i + 2, j + 1] = dgvStudent.Rows[i].Cells[j].Value.ToString();
                    }
                }
                ws.Columns.AutoFit();
            }
            catch { MessageBox.Show("Cần cài đặt Excel!"); }
        }
        private void BtnScore_Click(object sender, EventArgs e)
        {
            // Truyền cả Role và ID sang ScoreForm (để sửa lỗi constructor và hỗ trợ điền sẵn)
            string selectedID = string.IsNullOrEmpty(txtID.Text) ? null : txtID.Text;
            new ScoreForm(currentRole, selectedID).ShowDialog();
        }
        private void BtnAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Vui lòng chọn một sinh viên!"); return; }
            string svID = txtID.Text;
            if (MessageBox.Show($"Cấp lại mật khẩu (123) cho {svID}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", conn);
                        check.Parameters.AddWithValue("@u", svID);
                        if ((int)check.ExecuteScalar() > 0) new SqlCommand($"UPDATE Users SET Password='123' WHERE Username='{svID}'", conn).ExecuteNonQuery();
                        else new SqlCommand($"INSERT INTO Users VALUES ('{svID}', '123', 'Student')", conn).ExecuteNonQuery();
                        MessageBox.Show("Thành công!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }
    }
}