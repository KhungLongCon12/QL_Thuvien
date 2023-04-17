using QuanLyThuVien.BUS;
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
    public partial class QuanLySach : Form
    {
        public QuanLySach()
        {

            InitializeComponent();
            busSach = new Bus_Sach();
            dtpNgayNhap.Value = date;
            dtpNgayNhap.MaxDate = date;
            dtpNamXuatBan.Value = date;
            dtpNamXuatBan.MaxDate = date;
              
        }
        Bus_Sach busSach;
        QuanLyNhanVien qlNv = new QuanLyNhanVien();

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            busSach.LayDSSach(gvSach);
            gvSach.Columns[0].Visible = false;
            gvSach.Columns[1].Width = (int)(gvSach.Width * 0.2);
            gvSach.Columns[2].Width = (int)(gvSach.Width * 0.2);
            gvSach.Columns[3].Width = (int)(gvSach.Width * 0.19);
            gvSach.Columns[4].Width = (int)(gvSach.Width * 0.19);
            gvSach.Columns[4].Width = (int)(gvSach.Width * 0.13);
            gvSach.Columns[4].Width = (int)(gvSach.Width * 0.13);
        }
        public void SetNull()
        {
            
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtTriGia.Text = "0";
            dtpNgayNhap.Value = date;
            txtNhaXuatBan.Text = "";
            dtpNamXuatBan.Value = date;
            
        }
        DateTime date = DateTime.Now;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text.Trim().Equals("") || txtTacGia.Text.Trim().Equals("") || txtNhaXuatBan.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông tin sách không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtpNamXuatBan.Value.CompareTo(dtpNgayNhap.Value) > 0)
            {
                MessageBox.Show("Ngày xuất bản phải trước ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (qlNv.IsNumber(txtTriGia.Text)==false)
            {
                MessageBox.Show("Trị giá không được chứa kí tự khác số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (qlNv.IsChar(txtTacGia.Text.Trim()) == false  || qlNv.hasSpecialChar(txtTacGia.Text))
            {
                MessageBox.Show("Tên tác giả không được chứa số hoặc kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    SACH s = new SACH();
                    s.TenSach = txtTenSach.Text;
                    s.TacGia = txtTacGia.Text;
                    s.NhaXuatBan = txtNhaXuatBan.Text;
                    s.NamXuatBan = dtpNamXuatBan.Value;
                    s.TriGia = txtTriGia.Text;
                    s.NgayNhap = dtpNgayNhap.Value;
                    busSach.ThemSach(s);
                    busSach.LayDSSach(gvSach);
                    MessageBox.Show("Thêm sách THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                    btnThem.Enabled = true;
                    btnThem.BackColor = Color.White;
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm sách THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Bạn có muốn xóa không?", "Câu Hỏi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {

                    SACH s = new SACH();
                    s.MaSach = int.Parse(txtMaSach.Text);
                    busSach.XoaSach(s);
                    busSach.LayDSSach(gvSach);
                    MessageBox.Show("Xóa thông tin sách THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin sách THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text.Trim().Equals("") || txtTacGia.Text.Trim().Equals("") || txtNhaXuatBan.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông tin sách không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtpNamXuatBan.Value.CompareTo(dtpNgayNhap.Value) > 0)
            {
                MessageBox.Show("Ngày xuất bản phải trước ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (qlNv.IsNumber(txtTriGia.Text) == false)
            {
                MessageBox.Show("Trị giá không được chứa kí tự khác số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (qlNv.IsChar(txtTacGia.Text.Trim()) == false || qlNv.hasSpecialChar(txtTacGia.Text))
            {
                MessageBox.Show("Tên tác giả không được chứa số hoặc kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    SACH s = new SACH();
                    s.MaSach = int.Parse(txtMaSach.Text);
                    s.TenSach = txtTenSach.Text;
                    s.TacGia = txtTacGia.Text;
                    s.NhaXuatBan = txtNhaXuatBan.Text;
                    s.TriGia = txtTriGia.Text;
                    s.NgayNhap = dtpNgayNhap.Value;
                    s.NamXuatBan = dtpNamXuatBan.Value;
                    busSach.SuaTTSach(s);
                    busSach.LayDSSach(gvSach);
                    MessageBox.Show("Cập nhật thông tin sách THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                    btnThem.Enabled = true;
                    btnThem.BackColor = Color.White;
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật thông tin sách THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void gvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numRow;
            numRow = e.RowIndex;
            try
            {
                if (gvSach.SelectedCells.Count > 0)
                {
                    txtMaSach.Text = gvSach.Rows[numRow].Cells[0].Value.ToString();
                    txtTenSach.Text = gvSach.Rows[numRow].Cells[1].Value.ToString();
                    txtTacGia.Text = gvSach.Rows[numRow].Cells[2].Value.ToString();
                    txtNhaXuatBan.Text = gvSach.Rows[numRow].Cells[3].Value.ToString();
                    txtTriGia.Text = gvSach.Rows[numRow].Cells[4].Value.ToString();
                    dtpNamXuatBan.Text = gvSach.Rows[numRow].Cells[5].Value.ToString();
                    dtpNgayNhap.Text = gvSach.Rows[numRow].Cells[6].Value.ToString();
                    btnThem.Enabled = false;
                    btnThem.BackColor = Color.Gray;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải click vào thông tin muốn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
