namespace StudentManagement
{
    partial class ScoreForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();

            // 
            // groupBox1 (Khu vực Nhập liệu)
            // 
            this.groupBox1.Controls.Add(this.txtScore);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStudentID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Điểm Thi";

            // Các control nhập liệu (Giữ nguyên)
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 30); this.label1.Text = "Mã Sinh Viên:";
            this.txtStudentID.Location = new System.Drawing.Point(110, 27); this.txtStudentID.Size = new System.Drawing.Size(150, 20);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(30, 70); this.label2.Text = "Môn Học:";
            this.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubject.Location = new System.Drawing.Point(110, 67); this.cbSubject.Size = new System.Drawing.Size(200, 21);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 110); this.label3.Text = "Điểm (0-10):";
            this.txtScore.Location = new System.Drawing.Point(110, 107); this.txtScore.Size = new System.Drawing.Size(80, 20);

            // Các nút chức năng (Giữ nguyên)
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen; this.btnAdd.Location = new System.Drawing.Point(450, 25); this.btnAdd.Size = new System.Drawing.Size(100, 30); this.btnAdd.Text = "Lưu Điểm"; this.btnAdd.UseVisualStyleBackColor = false;
            this.btnEdit.BackColor = System.Drawing.Color.LightYellow; this.btnEdit.Location = new System.Drawing.Point(450, 65); this.btnEdit.Size = new System.Drawing.Size(100, 30); this.btnEdit.Text = "Sửa Điểm"; this.btnEdit.UseVisualStyleBackColor = false;
            this.btnDelete.BackColor = System.Drawing.Color.LightPink; this.btnDelete.Location = new System.Drawing.Point(450, 105); this.btnDelete.Size = new System.Drawing.Size(100, 30); this.btnDelete.Text = "Xóa Điểm"; this.btnDelete.UseVisualStyleBackColor = false;

            // 
            // pnlFilter (KHU VỰC LỌC MỚI)
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFilter.Controls.Add(this.btnShowAll);
            this.pnlFilter.Controls.Add(this.cbFilter);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 150);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(700, 50);
            this.pnlFilter.TabIndex = 1;

            // Label Lọc
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(30, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lọc theo môn:";

            // ComboBox Lọc
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(130, 15);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(200, 21);
            this.cbFilter.TabIndex = 1;

            // Nút Hiện tất cả
            this.btnShowAll.Location = new System.Drawing.Point(350, 13);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 25);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "Hiện tất cả";
            this.btnShowAll.UseVisualStyleBackColor = true;

            // 
            // dgvScore (Bảng điểm)
            // 
            this.dgvScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScore.Location = new System.Drawing.Point(0, 200); // Đẩy xuống dưới pnlFilter
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.Size = new System.Drawing.Size(700, 300);
            this.dgvScore.TabIndex = 2;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.pnlFilter); // Thêm Panel Lọc
            this.Controls.Add(this.groupBox1);
            this.Name = "ScoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Điểm Số";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1, label2, label3;
        private System.Windows.Forms.TextBox txtStudentID, txtScore;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDelete;
        private System.Windows.Forms.DataGridView dgvScore;
        // Các control mới cho chức năng lọc
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnShowAll;
    }
}