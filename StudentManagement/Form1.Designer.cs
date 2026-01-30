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
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDeleteImg = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();

            // groupBox1
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpDOB); this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClass); this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCourse); this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnPrint); this.groupBox1.Controls.Add(this.btnDeleteImg);
            this.groupBox1.Controls.Add(this.btnUpload); this.groupBox1.Controls.Add(this.picAvatar);
            this.groupBox1.Controls.Add(this.txtID); this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName); this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMajor); this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAdd); this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete); this.groupBox1.Controls.Add(this.btnScore);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 240);
            this.groupBox1.Text = "Thông tin chi tiết";

            // Avatar & Buttons
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(20, 30);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(120, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.btnUpload.Location = new System.Drawing.Point(150, 30); this.btnUpload.Size = new System.Drawing.Size(75, 30); this.btnUpload.Text = "Chọn Ảnh";
            this.btnDeleteImg.Location = new System.Drawing.Point(150, 65); this.btnDeleteImg.Size = new System.Drawing.Size(75, 30); this.btnDeleteImg.Text = "Gỡ Ảnh";
            this.btnPrint.Location = new System.Drawing.Point(150, 150); this.btnPrint.Size = new System.Drawing.Size(75, 30); this.btnPrint.Text = "In Thẻ"; this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;

            // Inputs
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(250, 35); this.label1.Text = "Mã SV:";
            this.txtID.Location = new System.Drawing.Point(310, 32); this.txtID.Size = new System.Drawing.Size(120, 20);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(250, 75); this.label2.Text = "Họ Tên:";
            this.txtName.Location = new System.Drawing.Point(310, 72); this.txtName.Size = new System.Drawing.Size(180, 20);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(250, 115); this.label3.Text = "Ngày sinh:";
            this.dtpDOB.Location = new System.Drawing.Point(310, 112); this.dtpDOB.Size = new System.Drawing.Size(180, 20); this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(250, 155); this.label4.Text = "Ngành:";
            this.txtMajor.Location = new System.Drawing.Point(310, 152); this.txtMajor.Size = new System.Drawing.Size(180, 20);

            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(510, 35); this.label6.Text = "Lớp:";
            this.txtClass.Location = new System.Drawing.Point(570, 32); this.txtClass.Size = new System.Drawing.Size(100, 20);

            this.label7.AutoSize = true; this.label7.Location = new System.Drawing.Point(510, 75); this.label7.Text = "Khóa học:";
            this.txtCourse.Location = new System.Drawing.Point(570, 72); this.txtCourse.Size = new System.Drawing.Size(100, 20);

            // Buttons Chức năng (Góc phải)
            int btnX = 720;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(btnX, 25); this.btnAdd.Size = new System.Drawing.Size(100, 30); this.btnAdd.Text = "Thêm SV";

            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(btnX, 60); this.btnEdit.Size = new System.Drawing.Size(100, 30); this.btnEdit.Text = "Sửa SV";

            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(btnX, 95); this.btnDelete.Size = new System.Drawing.Size(100, 30); this.btnDelete.Text = "Xóa SV";

            this.btnScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScore.Location = new System.Drawing.Point(btnX, 130); this.btnScore.Size = new System.Drawing.Size(100, 30); this.btnScore.Text = "Nhập Điểm";

            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(btnX, 165); this.btnExcel.Size = new System.Drawing.Size(100, 30); this.btnExcel.Text = "Xuất Excel";

            // Tìm kiếm & Grid
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSearch); this.groupBox2.Controls.Add(this.txtSearch); this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 260); this.groupBox2.Size = new System.Drawing.Size(860, 56); this.groupBox2.Text = "Tìm kiếm";
            this.label5.Location = new System.Drawing.Point(20, 25); this.label5.Text = "Tìm tên:";
            this.txtSearch.Location = new System.Drawing.Point(100, 22); this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.btnSearch.Location = new System.Drawing.Point(420, 18); this.btnSearch.Size = new System.Drawing.Size(100, 30); this.btnSearch.Text = "Tìm kiếm";

            this.dgvStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudent.Location = new System.Drawing.Point(12, 330); this.dgvStudent.Size = new System.Drawing.Size(860, 220); this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Form
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox2); this.Controls.Add(this.groupBox1); this.Controls.Add(this.dgvStudent);
            this.Name = "Form1"; this.Text = "Quản Lý Sinh Viên"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.groupBox2.ResumeLayout(false); this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7;
        private System.Windows.Forms.TextBox txtID, txtName, txtMajor, txtSearch, txtClass, txtCourse;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDelete, btnSearch, btnScore, btnExcel;
        private System.Windows.Forms.GroupBox groupBox1, groupBox2;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnUpload, btnDeleteImg, btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}