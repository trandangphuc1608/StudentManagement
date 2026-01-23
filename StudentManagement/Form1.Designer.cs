namespace StudentManagement
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnScore = new System.Windows.Forms.Button(); // Nút mới: Quản lý điểm
            this.btnExcel = new System.Windows.Forms.Button(); // Nút mới: Xuất Excel
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();

            // --- CẤU HÌNH GIAO DIỆN ---

            // GroupBox 1: Thông tin (Neo: Trên, Trái, Phải)
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtID); this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName); this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAge); this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMajor); this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAdd); this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete);
            // Thêm 2 nút chức năng mới vào GroupBox
            this.groupBox1.Controls.Add(this.btnScore);
            this.groupBox1.Controls.Add(this.btnExcel);

            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Size = new System.Drawing.Size(760, 160); // Tăng chiều cao chút
            this.groupBox1.Text = "Thông tin";

            // Các Label và TextBox (Giữ nguyên vị trí)
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(25, 35); this.label1.Text = "Mã SV:";
            this.txtID.Location = new System.Drawing.Point(100, 32); this.txtID.Size = new System.Drawing.Size(100, 22);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(25, 75); this.label2.Text = "Họ Tên:";
            this.txtName.Location = new System.Drawing.Point(100, 72); this.txtName.Size = new System.Drawing.Size(100, 22);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(300, 35); this.label3.Text = "Tuổi:";
            this.txtAge.Location = new System.Drawing.Point(380, 32); this.txtAge.Size = new System.Drawing.Size(100, 22);

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(300, 75); this.label4.Text = "Ngành:";
            this.txtMajor.Location = new System.Drawing.Point(380, 72); this.txtMajor.Size = new System.Drawing.Size(100, 22);

            // BUTTONS (Neo: Trên, Phải - Để luôn bám sang phải)
            System.Windows.Forms.AnchorStyles anchorRight = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);

            this.btnAdd.Anchor = anchorRight;
            this.btnAdd.Location = new System.Drawing.Point(630, 20); this.btnAdd.Size = new System.Drawing.Size(100, 30); this.btnAdd.Text = "Thêm SV";

            this.btnEdit.Anchor = anchorRight;
            this.btnEdit.Location = new System.Drawing.Point(630, 55); this.btnEdit.Size = new System.Drawing.Size(100, 30); this.btnEdit.Text = "Sửa SV";

            this.btnDelete.Anchor = anchorRight;
            this.btnDelete.Location = new System.Drawing.Point(630, 90); this.btnDelete.Size = new System.Drawing.Size(100, 30); this.btnDelete.Text = "Xóa SV";

            // Nút Mới: Quản lý điểm
            this.btnScore.Anchor = anchorRight;
            this.btnScore.Location = new System.Drawing.Point(510, 20);
            this.btnScore.Size = new System.Drawing.Size(100, 30);
            this.btnScore.Text = "Nhập Điểm";
            this.btnScore.BackColor = System.Drawing.Color.LightCyan;

            // Nút Mới: Xuất Excel
            this.btnExcel.Anchor = anchorRight;
            this.btnExcel.Location = new System.Drawing.Point(510, 55);
            this.btnExcel.Size = new System.Drawing.Size(100, 30);
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.BackColor = System.Drawing.Color.LightGreen;

            // GroupBox 2: Tìm kiếm (Neo: Trên, Trái, Phải)
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSearch); this.groupBox2.Controls.Add(this.txtSearch); this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 178); this.groupBox2.Size = new System.Drawing.Size(760, 56);
            this.groupBox2.Text = "Tìm kiếm";

            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(20, 25); this.label5.Text = "Tìm tên:";
            this.txtSearch.Location = new System.Drawing.Point(100, 22); this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.btnSearch.Location = new System.Drawing.Point(420, 18); this.btnSearch.Size = new System.Drawing.Size(100, 30); this.btnSearch.Text = "Tìm kiếm";

            // DataGridView (Neo: Bốn phía - Để co giãn toàn bộ)
            this.dgvStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudent.Location = new System.Drawing.Point(12, 240);
            this.dgvStudent.Size = new System.Drawing.Size(760, 210);
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Form
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvStudent);
            this.Name = "Form1";
            this.Text = "Quản Lý Sinh Viên";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Mở lên ở giữa màn hình
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false); this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1, label2, label3, label4, label5;
        private System.Windows.Forms.TextBox txtID, txtName, txtAge, txtMajor, txtSearch;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDelete, btnSearch, btnScore, btnExcel;
        private System.Windows.Forms.GroupBox groupBox1, groupBox2;
    }
}