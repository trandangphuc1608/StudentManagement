namespace StudentManagement
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Labels
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 30); this.label1.Text = "Mật khẩu cũ:";
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(30, 70); this.label2.Text = "Mật khẩu mới:";
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 110); this.label3.Text = "Nhập lại mới:";

            // Inputs (Ẩn ký tự)
            this.txtOldPass.Location = new System.Drawing.Point(140, 27); this.txtOldPass.Size = new System.Drawing.Size(200, 22);
            this.txtOldPass.UseSystemPasswordChar = true;

            this.txtNewPass.Location = new System.Drawing.Point(140, 67); this.txtNewPass.Size = new System.Drawing.Size(200, 22);
            this.txtNewPass.UseSystemPasswordChar = true;

            this.txtConfirmPass.Location = new System.Drawing.Point(140, 107); this.txtConfirmPass.Size = new System.Drawing.Size(200, 22);
            this.txtConfirmPass.UseSystemPasswordChar = true;

            // Buttons
            this.btnSave.Location = new System.Drawing.Point(140, 150); this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;

            this.btnCancel.Location = new System.Drawing.Point(250, 150); this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Text = "Hủy";

            // Form
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.btnCancel); this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirmPass); this.Controls.Add(this.txtNewPass); this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label3); this.Controls.Add(this.label2); this.Controls.Add(this.label1);
            this.Name = "ChangePasswordForm";
            this.Text = "Đổi Mật Khẩu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false); this.PerformLayout();
        }
        private System.Windows.Forms.Label label1, label2, label3;
        private System.Windows.Forms.TextBox txtOldPass, txtNewPass, txtConfirmPass;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}