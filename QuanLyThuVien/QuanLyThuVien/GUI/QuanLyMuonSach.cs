using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class QuanLyMuonSach : Form
    {
        public QuanLyMuonSach()
        {
            InitializeComponent();
            busMuonSach = new Bus_MuonSach();
            busCTPhieuMuon = new Bus_CTPhieuMuon();

        }
        Bus_MuonSach busMuonSach;
        Bus_CTPhieuMuon busCTPhieuMuon;

      

        private void QuanLyMuonSach_Load(object sender, EventArgs e)
        {
            busMuonSach.LayDSThongTinSach(gvThongTinSach);
            gvThongTinSach.Columns[0].Width = (int)(gvThongTinSach.Width * 0.1);
            gvThongTinSach.Columns[1].Width = (int)(gvThongTinSach.Width * 0.3);
            gvThongTinSach.Columns[2].Width = (int)(gvThongTinSach.Width * 0.3);
            gvThongTinSach.Columns[3].Width = (int)(gvThongTinSach.Width * 0.15);





            busMuonSach.LayTTDocGiaMuonSach(gvDocGiaMuonSach);
            gvDocGiaMuonSach.Columns[0].Width = (int)(gvDocGiaMuonSach.Width * 0.15);
            gvDocGiaMuonSach.Columns[1].Width = (int)(gvDocGiaMuonSach.Width * 0.5);
            gvDocGiaMuonSach.Columns[2].Width = (int)(gvDocGiaMuonSach.Width * 0.35);

            btnMuon.Enabled = false;
            btnMuon.BackColor = Color.Gray;








        }

        private void gvThongTinSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int numRow;
            numRow = e.RowIndex;
            try
            {
                if (gvThongTinSach.SelectedCells.Count > 0)
                {
                    txtMaSach.Text = gvThongTinSach.Rows[numRow].Cells[0].Value.ToString();
                    txtTenSach.Text = gvThongTinSach.Rows[numRow].Cells[1].Value.ToString();
                    txtTacGia.Text = gvThongTinSach.Rows[numRow].Cells[2].Value.ToString();

                    btnMuon.Enabled = true;
                    btnMuon.BackColor = Color.White;

                    

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải click vào thông tin muốn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gvDocGiaMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int numRow;
            numRow = e.RowIndex;
            try
            {
                if (gvDocGiaMuonSach.SelectedCells.Count > 0)
                {
                    txtmaDocGia.Text = gvDocGiaMuonSach.Rows[numRow].Cells[0].Value.ToString();
                    txtTenDocGia.Text = gvDocGiaMuonSach.Rows[numRow].Cells[1].Value.ToString();
                    dtpNgaySinh.Text = gvDocGiaMuonSach.Rows[numRow].Cells[2].Value.ToString();

                    //btnMuon.Enabled = true;
                    //btnMuon.BackColor = Color.White;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải click vào thông tin muốn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        void setNull()
        {
            DateTime date =  DateTime.Now;
            txtmaDocGia.Text = "";
            txtMaSach.Text = "";
            txtTacGia.Text = "";
            txtTenDocGia.Text = "";
            txtTenSach.Text = "";
            dtpNgaySinh.Value = date;
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtmaDocGia.Text))
            {
                MessageBox.Show("Vui lòng chọn thông tin độc giả ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (gvThongTinSach.SelectedCells.Count > 0)
                {
                    PHIEUMUONSACH p = busMuonSach.ThemPhieuMuonSach(txtmaDocGia.Text);
                    busCTPhieuMuon.ThemChiTietPhieuMuonSach(txtMaSach.Text, p.MaPhieuMuon);
                    MessageBox.Show("Mượn thành công sách " + txtTenSach.Text,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    setNull();

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách cần mượn","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Bạn có muốn thoát không?", "Câu Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MainQLThuVien f = new MainQLThuVien();
                f.Show();
                this.Hide();
            }
        }
    }    
}
