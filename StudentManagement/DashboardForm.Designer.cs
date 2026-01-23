namespace StudentManagement
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Xử lý dọn dẹp tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Khởi tạo các thành phần
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cardStudent = new System.Windows.Forms.Panel();
            this.lblNumStudent = new System.Windows.Forms.Label();
            this.lblTextStudent = new System.Windows.Forms.Label();
            this.cardSubject = new System.Windows.Forms.Panel();
            this.lblNumSubject = new System.Windows.Forms.Label();
            this.lblTextSubject = new System.Windows.Forms.Label();
            this.cardScore = new System.Windows.Forms.Panel();
            this.lblNumScore = new System.Windows.Forms.Label();
            this.lblTextScore = new System.Windows.Forms.Label();
            this.chartHocLuc = new System.Windows.Forms.DataVisualization.Charting.Chart(); // Biểu đồ

            this.pnlMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.cardStudent.SuspendLayout();
            this.cardSubject.SuspendLayout();
            this.cardScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHocLuc)).BeginInit();
            this.SuspendLayout();

            // --- 1. MENU BÊN TRÁI ---
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnScore);
            this.pnlMenu.Controls.Add(this.btnSubject);
            this.pnlMenu.Controls.Add(this.btnStudent);
            this.pnlMenu.Controls.Add(this.panelLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 500);
            this.pnlMenu.TabIndex = 0;

            // Logo Panel
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.LightGray;
            this.lblLogo.Location = new System.Drawing.Point(45, 30);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(117, 21);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "STUDENT APP";

            // Style nút bấm chung
            System.Drawing.Font btnFont = new System.Drawing.Font("Segoe UI", 10F);
            System.Drawing.Color btnText = System.Drawing.Color.Gainsboro;

            // btnStudent
            this.btnStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudent.Font = btnFont;
            this.btnStudent.ForeColor = btnText;
            this.btnStudent.Location = new System.Drawing.Point(0, 80);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnStudent.Size = new System.Drawing.Size(220, 60);
            this.btnStudent.TabIndex = 1;
            this.btnStudent.Text = "  Quản lý Sinh viên";
            this.btnStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudent.UseVisualStyleBackColor = true;

            // btnSubject
            this.btnSubject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubject.FlatAppearance.BorderSize = 0;
            this.btnSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubject.Font = btnFont;
            this.btnSubject.ForeColor = btnText;
            this.btnSubject.Location = new System.Drawing.Point(0, 140);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSubject.Size = new System.Drawing.Size(220, 60);
            this.btnSubject.TabIndex = 2;
            this.btnSubject.Text = "  Quản lý Môn học";
            this.btnSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubject.UseVisualStyleBackColor = true;

            // btnScore
            this.btnScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScore.FlatAppearance.BorderSize = 0;
            this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScore.Font = btnFont;
            this.btnScore.ForeColor = btnText;
            this.btnScore.Location = new System.Drawing.Point(0, 200);
            this.btnScore.Name = "btnScore";
            this.btnScore.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnScore.Size = new System.Drawing.Size(220, 60);
            this.btnScore.TabIndex = 3;
            this.btnScore.Text = "  Quản lý Điểm";
            this.btnScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScore.UseVisualStyleBackColor = true;

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Location = new System.Drawing.Point(0, 440);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 60);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;

            // --- 2. HEADER ---
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(580, 80);
            this.pnlHeader.TabIndex = 1;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DASHBOARD";

            // --- 3. CÁC THẺ THỐNG KÊ (CARDS) ---

            // Card 1: Sinh viên
            this.cardStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardStudent.Controls.Add(this.lblNumStudent);
            this.cardStudent.Controls.Add(this.lblTextStudent);
            this.cardStudent.Location = new System.Drawing.Point(240, 100);
            this.cardStudent.Name = "cardStudent";
            this.cardStudent.Size = new System.Drawing.Size(170, 100);
            this.cardStudent.TabIndex = 2;

            this.lblTextStudent.AutoSize = true;
            this.lblTextStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTextStudent.ForeColor = System.Drawing.Color.White;
            this.lblTextStudent.Location = new System.Drawing.Point(10, 10);
            this.lblTextStudent.Name = "lblTextStudent";
            this.lblTextStudent.Size = new System.Drawing.Size(99, 19);
            this.lblTextStudent.TabIndex = 0;
            this.lblTextStudent.Text = "Tổng Sinh Viên";

            this.lblNumStudent.AutoSize = true;
            this.lblNumStudent.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumStudent.ForeColor = System.Drawing.Color.White;
            this.lblNumStudent.Location = new System.Drawing.Point(10, 40);
            this.lblNumStudent.Name = "lblNumStudent";
            this.lblNumStudent.Size = new System.Drawing.Size(38, 45);
            this.lblNumStudent.TabIndex = 1;
            this.lblNumStudent.Text = "0";

            // Card 2: Môn học
            this.cardSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.cardSubject.Controls.Add(this.lblNumSubject);
            this.cardSubject.Controls.Add(this.lblTextSubject);
            this.cardSubject.Location = new System.Drawing.Point(430, 100);
            this.cardSubject.Name = "cardSubject";
            this.cardSubject.Size = new System.Drawing.Size(170, 100);
            this.cardSubject.TabIndex = 3;

            this.lblTextSubject.AutoSize = true;
            this.lblTextSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTextSubject.ForeColor = System.Drawing.Color.White;
            this.lblTextSubject.Location = new System.Drawing.Point(10, 10);
            this.lblTextSubject.Name = "lblTextSubject";
            this.lblTextSubject.Size = new System.Drawing.Size(100, 19);
            this.lblTextSubject.TabIndex = 0;
            this.lblTextSubject.Text = "Tổng Môn Học";

            this.lblNumSubject.AutoSize = true;
            this.lblNumSubject.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumSubject.ForeColor = System.Drawing.Color.White;
            this.lblNumSubject.Location = new System.Drawing.Point(10, 40);
            this.lblNumSubject.Name = "lblNumSubject";
            this.lblNumSubject.Size = new System.Drawing.Size(38, 45);
            this.lblNumSubject.TabIndex = 1;
            this.lblNumSubject.Text = "0";

            // Card 3: Điểm
            this.cardScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.cardScore.Controls.Add(this.lblNumScore);
            this.cardScore.Controls.Add(this.lblTextScore);
            this.cardScore.Location = new System.Drawing.Point(620, 100);
            this.cardScore.Name = "cardScore";
            this.cardScore.Size = new System.Drawing.Size(170, 100);
            this.cardScore.TabIndex = 4;

            this.lblTextScore.AutoSize = true;
            this.lblTextScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTextScore.ForeColor = System.Drawing.Color.White;
            this.lblTextScore.Location = new System.Drawing.Point(10, 10);
            this.lblTextScore.Name = "lblTextScore";
            this.lblTextScore.Size = new System.Drawing.Size(83, 19);
            this.lblTextScore.TabIndex = 0;
            this.lblTextScore.Text = "SV Có Điểm";

            this.lblNumScore.AutoSize = true;
            this.lblNumScore.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumScore.ForeColor = System.Drawing.Color.White;
            this.lblNumScore.Location = new System.Drawing.Point(10, 40);
            this.lblNumScore.Name = "lblNumScore";
            this.lblNumScore.Size = new System.Drawing.Size(38, 45);
            this.lblNumScore.TabIndex = 1;
            this.lblNumScore.Text = "0";

            // --- 4. BIỂU ĐỒ (CHART) ---
            chartArea1.Name = "ChartArea1";
            this.chartHocLuc.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartHocLuc.Legends.Add(legend1);
            this.chartHocLuc.Location = new System.Drawing.Point(240, 220); // Vị trí dưới các thẻ
            this.chartHocLuc.Name = "chartHocLuc";
            this.chartHocLuc.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "HocLuc";
            this.chartHocLuc.Series.Add(series1);
            this.chartHocLuc.Size = new System.Drawing.Size(550, 250);
            this.chartHocLuc.TabIndex = 5;
            this.chartHocLuc.Text = "Biểu đồ học lực";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.chartHocLuc);
            this.Controls.Add(this.cardScore);
            this.Controls.Add(this.cardSubject);
            this.Controls.Add(this.cardStudent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlMenu);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý";
            this.pnlMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.cardStudent.ResumeLayout(false);
            this.cardStudent.PerformLayout();
            this.cardSubject.ResumeLayout(false);
            this.cardSubject.PerformLayout();
            this.cardScore.ResumeLayout(false);
            this.cardScore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHocLuc)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu, panelLogo, pnlHeader;
        private System.Windows.Forms.Button btnStudent, btnSubject, btnScore, btnLogout;
        private System.Windows.Forms.Label lblLogo, lblTitle;
        private System.Windows.Forms.Panel cardStudent, cardSubject, cardScore;
        private System.Windows.Forms.Label lblNumStudent, lblTextStudent;
        private System.Windows.Forms.Label lblNumSubject, lblTextSubject;
        private System.Windows.Forms.Label lblNumScore, lblTextScore;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHocLuc;
    }
}