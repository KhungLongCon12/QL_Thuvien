using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class MainQLThuVien : Form
    {
        public MainQLThuVien()
        {
            InitializeComponent();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien f = new QuanLyNhanVien();
            f.Show();
            this.Hide();
        }

        private void btnQLDocGia_Click(object sender, EventArgs e)
        {
            QuanLyDocGia f = new QuanLyDocGia();
            f.Show();
            this.Hide();
        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            QuanLySach f = new QuanLySach();
            f.Show();
            this.Hide();
        }

        private void btnQLMuonSach_Click(object sender, EventArgs e)
        {
            QuanLyMuonSach f = new QuanLyMuonSach();
            f.Show();
            this.Hide();
        }
    }
}
