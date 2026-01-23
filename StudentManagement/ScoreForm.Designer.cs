namespace StudentManagement
{
    partial class ScoreForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.SuspendLayout();

            // Label
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 30); this.label1.Text = "Sinh viên:";
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(30, 70); this.label2.Text = "Môn học:";
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 110); this.label3.Text = "Điểm số:";

            // Inputs
            this.cboStudent.Location = new System.Drawing.Point(100, 27); this.cboStudent.Size = new System.Drawing.Size(200, 24);
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Chỉ chọn, ko gõ

            this.cboSubject.Location = new System.Drawing.Point(100, 67); this.cboSubject.Size = new System.Drawing.Size(200, 24);
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.txtScore.Location = new System.Drawing.Point(100, 107); this.txtScore.Size = new System.Drawing.Size(100, 22);

            // Button
            this.btnSave.Location = new System.Drawing.Point(100, 150); this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Lưu Điểm";
            this.btnSave.BackColor = System.Drawing.Color.LightBlue;

            // Grid xem điểm
            this.dgvScore.Location = new System.Drawing.Point(330, 27); this.dgvScore.Size = new System.Drawing.Size(440, 400);
            this.dgvScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.cboSubject);
            this.Controls.Add(this.cboStudent);
            this.Controls.Add(this.label3); this.Controls.Add(this.label2); this.Controls.Add(this.label1);
            this.Name = "ScoreForm";
            this.Text = "Quản lý Điểm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cboStudent, cboSubject;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1, label2, label3;
        private System.Windows.Forms.DataGridView dgvScore;
    }
}