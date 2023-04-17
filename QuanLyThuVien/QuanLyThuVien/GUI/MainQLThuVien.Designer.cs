namespace QuanLyThuVien.GUI
{
    partial class MainQLThuVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainQLThuVien));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQLDocGia = new System.Windows.Forms.Button();
            this.btnQLNhanVien = new System.Windows.Forms.Button();
            this.btnQLSach = new System.Windows.Forms.Button();
            this.btnQLMuonSach = new System.Windows.Forms.Button();
            this.btnQLTra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(476, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Thư Viện";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(341, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnQLDocGia
            // 
            this.btnQLDocGia.BackColor = System.Drawing.Color.White;
            this.btnQLDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDocGia.ForeColor = System.Drawing.Color.Teal;
            this.btnQLDocGia.Image = ((System.Drawing.Image)(resources.GetObject("btnQLDocGia.Image")));
            this.btnQLDocGia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDocGia.Location = new System.Drawing.Point(142, 340);
            this.btnQLDocGia.Name = "btnQLDocGia";
            this.btnQLDocGia.Padding = new System.Windows.Forms.Padding(0, 0, 80, 0);
            this.btnQLDocGia.Size = new System.Drawing.Size(345, 89);
            this.btnQLDocGia.TabIndex = 1;
            this.btnQLDocGia.Text = "Quản Lý Đọc Giả";
            this.btnQLDocGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLDocGia.UseVisualStyleBackColor = false;
            this.btnQLDocGia.Click += new System.EventHandler(this.btnQLDocGia_Click);
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.BackColor = System.Drawing.Color.White;
            this.btnQLNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLNhanVien.ForeColor = System.Drawing.Color.Teal;
            this.btnQLNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnQLNhanVien.Image")));
            this.btnQLNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhanVien.Location = new System.Drawing.Point(142, 196);
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.btnQLNhanVien.Size = new System.Drawing.Size(345, 89);
            this.btnQLNhanVien.TabIndex = 1;
            this.btnQLNhanVien.Text = "Quản Lý Nhân Viên";
            this.btnQLNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLNhanVien.UseVisualStyleBackColor = false;
            this.btnQLNhanVien.Click += new System.EventHandler(this.btnQLNhanVien_Click);
            // 
            // btnQLSach
            // 
            this.btnQLSach.BackColor = System.Drawing.Color.White;
            this.btnQLSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLSach.ForeColor = System.Drawing.Color.Teal;
            this.btnQLSach.Image = ((System.Drawing.Image)(resources.GetObject("btnQLSach.Image")));
            this.btnQLSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLSach.Location = new System.Drawing.Point(142, 474);
            this.btnQLSach.Name = "btnQLSach";
            this.btnQLSach.Padding = new System.Windows.Forms.Padding(0, 0, 95, 0);
            this.btnQLSach.Size = new System.Drawing.Size(345, 89);
            this.btnQLSach.TabIndex = 1;
            this.btnQLSach.Text = "Quản Lý Sách";
            this.btnQLSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLSach.UseVisualStyleBackColor = false;
            this.btnQLSach.Click += new System.EventHandler(this.btnQLSach_Click);
            // 
            // btnQLMuonSach
            // 
            this.btnQLMuonSach.BackColor = System.Drawing.Color.White;
            this.btnQLMuonSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMuonSach.ForeColor = System.Drawing.Color.Teal;
            this.btnQLMuonSach.Image = ((System.Drawing.Image)(resources.GetObject("btnQLMuonSach.Image")));
            this.btnQLMuonSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLMuonSach.Location = new System.Drawing.Point(581, 196);
            this.btnQLMuonSach.Name = "btnQLMuonSach";
            this.btnQLMuonSach.Padding = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.btnQLMuonSach.Size = new System.Drawing.Size(338, 145);
            this.btnQLMuonSach.TabIndex = 1;
            this.btnQLMuonSach.Text = "Quản Lý Mượn Sách";
            this.btnQLMuonSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLMuonSach.UseVisualStyleBackColor = false;
            this.btnQLMuonSach.Click += new System.EventHandler(this.btnQLMuonSach_Click);
            // 
            // btnQLTra
            // 
            this.btnQLTra.BackColor = System.Drawing.Color.White;
            this.btnQLTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTra.ForeColor = System.Drawing.Color.Teal;
            this.btnQLTra.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTra.Image")));
            this.btnQLTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTra.Location = new System.Drawing.Point(581, 418);
            this.btnQLTra.Name = "btnQLTra";
            this.btnQLTra.Padding = new System.Windows.Forms.Padding(0, 0, 65, 0);
            this.btnQLTra.Size = new System.Drawing.Size(338, 145);
            this.btnQLTra.TabIndex = 1;
            this.btnQLTra.Text = "Quản Lý Trả Sách";
            this.btnQLTra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLTra.UseVisualStyleBackColor = false;
            // 
            // MainQLThuVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1055, 635);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnQLTra);
            this.Controls.Add(this.btnQLMuonSach);
            this.Controls.Add(this.btnQLNhanVien);
            this.Controls.Add(this.btnQLSach);
            this.Controls.Add(this.btnQLDocGia);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainQLThuVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainQLThuVien";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnQLDocGia;
        private System.Windows.Forms.Button btnQLNhanVien;
        private System.Windows.Forms.Button btnQLSach;
        private System.Windows.Forms.Button btnQLMuonSach;
        private System.Windows.Forms.Button btnQLTra;
    }
}