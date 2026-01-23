namespace StudentManagement
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Định nghĩa màu sắc chủ đạo
        private System.Drawing.Color primaryColor = System.Drawing.Color.FromArgb(41, 128, 185); // Xanh dương đậm
        private System.Drawing.Color bgColor = System.Drawing.Color.White;
        private System.Drawing.Color textColor = System.Drawing.Color.FromArgb(64, 64, 64);

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlUserUnderline = new System.Windows.Forms.Panel();
            this.pnlPassUnderline = new System.Windows.Forms.Panel();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.labelRegisterPrompt = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop (Thanh tiêu đề tùy chỉnh)
            // 
            this.pnlTop.BackColor = this.primaryColor;
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(450, 40);
            this.pnlTop.TabIndex = 10;
            // 
            // btnClose (Nút X đóng form)
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(410, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // labelTitle (Tiêu đề lớn)
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = this.primaryColor;
            this.labelTitle.Location = new System.Drawing.Point(135, 60);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(184, 46);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "WELCOME";
            // 
            // label1 (Nhãn Tài khoản)
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = this.textColor;
            this.label1.Location = new System.Drawing.Point(50, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản:";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = this.bgColor;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUser.Location = new System.Drawing.Point(54, 156);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(340, 25);
            this.txtUser.TabIndex = 1;
            // 
            // pnlUserUnderline (Gạch chân cho User)
            // 
            this.pnlUserUnderline.BackColor = this.primaryColor;
            this.pnlUserUnderline.Location = new System.Drawing.Point(50, 183);
            this.pnlUserUnderline.Name = "pnlUserUnderline";
            this.pnlUserUnderline.Size = new System.Drawing.Size(350, 2);
            this.pnlUserUnderline.TabIndex = 12;
            // 
            // label2 (Nhãn Mật khẩu)
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = this.textColor;
            this.label2.Location = new System.Drawing.Point(50, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = this.bgColor;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPass.Location = new System.Drawing.Point(54, 236);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(340, 25);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // pnlPassUnderline (Gạch chân cho Pass)
            // 
            this.pnlPassUnderline.BackColor = this.primaryColor;
            this.pnlPassUnderline.Location = new System.Drawing.Point(50, 263);
            this.pnlPassUnderline.Name = "pnlPassUnderline";
            this.pnlPassUnderline.Size = new System.Drawing.Size(350, 2);
            this.pnlPassUnderline.TabIndex = 13;
            // 
            // chkShowPass (Hiện mật khẩu)
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPass.ForeColor = this.textColor;
            this.chkShowPass.Location = new System.Drawing.Point(275, 275);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(125, 24);
            this.chkShowPass.TabIndex = 4;
            this.chkShowPass.Text = "Hiện mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            // 
            // btnLogin (Nút Đăng nhập đẹp)
            // 
            this.btnLogin.BackColor = this.primaryColor;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(50, 320);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(350, 45);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // labelRegisterPrompt
            // 
            this.labelRegisterPrompt.AutoSize = true;
            this.labelRegisterPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelRegisterPrompt.ForeColor = this.textColor;
            this.labelRegisterPrompt.Location = new System.Drawing.Point(130, 385);
            this.labelRegisterPrompt.Name = "labelRegisterPrompt";
            this.labelRegisterPrompt.Size = new System.Drawing.Size(133, 20);
            this.labelRegisterPrompt.TabIndex = 14;
            this.labelRegisterPrompt.Text = "Chưa có tài khoản?";
            // 
            // btnRegister (Nút Đăng ký kiểu link)
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = this.primaryColor;
            this.btnRegister.Location = new System.Drawing.Point(260, 380);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(80, 30);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            this.BackColor = this.bgColor;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.labelRegisterPrompt);
            this.Controls.Add(this.chkShowPass);
            this.Controls.Add(this.pnlPassUnderline);
            this.Controls.Add(this.pnlUserUnderline);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUser, txtPass;
        private System.Windows.Forms.Button btnLogin, btnRegister, btnClose;
        private System.Windows.Forms.Label label1, label2, labelTitle, labelRegisterPrompt;
        private System.Windows.Forms.Panel pnlTop, pnlUserUnderline, pnlPassUnderline;
        private System.Windows.Forms.CheckBox chkShowPass;
    }
}