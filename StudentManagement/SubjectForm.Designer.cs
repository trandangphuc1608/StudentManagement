namespace StudentManagement
{
    partial class SubjectForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.nudCredit = new System.Windows.Forms.NumericUpDown();
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // GroupBox
            this.groupBox1.Controls.Add(this.txtID); this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName); this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudCredit); this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdd); this.groupBox1.Controls.Add(this.btnEdit); this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Size = new System.Drawing.Size(560, 150);
            this.groupBox1.Text = "Thông tin Môn học";

            // Labels
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 30); this.label1.Text = "Mã MH:";
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 70); this.label2.Text = "Tên Môn:";
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 110); this.label3.Text = "Số tín chỉ:";

            // Inputs
            this.txtID.Location = new System.Drawing.Point(100, 27); this.txtID.Size = new System.Drawing.Size(150, 22);
            this.txtName.Location = new System.Drawing.Point(100, 67); this.txtName.Size = new System.Drawing.Size(200, 22);

            // NumericUpDown (Dùng cho số tín chỉ để tránh nhập chữ)
            this.nudCredit.Location = new System.Drawing.Point(100, 107);
            this.nudCredit.Size = new System.Drawing.Size(60, 22);
            this.nudCredit.Minimum = 1; this.nudCredit.Maximum = 10;

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(400, 25); this.btnAdd.Size = new System.Drawing.Size(90, 30); this.btnAdd.Text = "Thêm";
            this.btnEdit.Location = new System.Drawing.Point(400, 65); this.btnEdit.Size = new System.Drawing.Size(90, 30); this.btnEdit.Text = "Sửa";
            this.btnDelete.Location = new System.Drawing.Point(400, 105); this.btnDelete.Size = new System.Drawing.Size(90, 30); this.btnDelete.Text = "Xóa";

            // Grid
            this.dgvSubject.Location = new System.Drawing.Point(12, 180);
            this.dgvSubject.Size = new System.Drawing.Size(560, 250);
            this.dgvSubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Form
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSubject);
            this.Name = "SubjectForm";
            this.Text = "Quản lý Môn Học";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nudCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).EndInit();
            this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1, label2, label3;
        private System.Windows.Forms.TextBox txtID, txtName;
        private System.Windows.Forms.NumericUpDown nudCredit;
        private System.Windows.Forms.DataGridView dgvSubject;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}