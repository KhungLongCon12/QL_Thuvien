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
    public partial class QuanLyDocGia : Form
    {
        public QuanLyDocGia()
        {
            InitializeComponent();
            busDG = new Bus_DocGia();
            dtpNgayLapThe.Value = date;
            dtpNgayLapThe.MaxDate = date;
            dtpNgaySinh.MaxDate = date;
            
        }
        Bus_DocGia busDG;

        private void QuanLyDocGia_Load(object sender, EventArgs e)
        {
            

            busDG.LayDSDocGia(gvDocGia);
            gvDocGia.Columns[0].Visible = false;
            gvDocGia.Columns[1].Width = (int)(gvDocGia.Width * 0.15);
            gvDocGia.Columns[2].Width = (int)(gvDocGia.Width * 0.3);
            gvDocGia.Columns[3].Width = (int)(gvDocGia.Width * 0.13);
            gvDocGia.Columns[4].Width = (int)(gvDocGia.Width * 0.1);
            gvDocGia.Columns[5].Width = (int)(gvDocGia.Width * 0.13);
            gvDocGia.Columns[6].Width = (int)(gvDocGia.Width * 0.13);
            
            
        }
        DateTime date = DateTime.Now;
        public void SetNull()
        {
            
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtTienNo.Text = "";
            dtpNgaySinh.Value = date;
            dtpNgayLapThe.Value = date;
            dtpNgayHetHan.Value = date;
        }
        QuanLyNhanVien qlNv = new QuanLyNhanVien();
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtHoTen.Text.Trim().Equals("") || txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông tin đọc giả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qlNv.IsNumber(txtTienNo.Text.Trim()) == false)
            {
                MessageBox.Show("Tiền nợ được chứa kí tự khác số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (qlNv.IsChar(txtHoTen.Text.Trim()) == false)
            {
                MessageBox.Show("Tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            else if (qlNv.hasSpecialChar(txtHoTen.Text))
            {
                MessageBox.Show("Tên không được chứa kí tự đặc biệt vd:. ,@,!,...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else if (dtpNgayLapThe.Value.CompareTo(dtpNgayHetHan.Value) >= 0)
            {
                MessageBox.Show("Ngày lập thẻ phải trước ngày hết hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    DOCGIA d = new DOCGIA();
                    d.HoTenDocGia = txtHoTen.Text;
                    d.DiaChi = txtDiaChi.Text;
                    d.NgaySinh = dtpNgaySinh.Value;
                    d.TienNo = int.Parse(txtTienNo.Text);
                    d.NgayLapThe = dtpNgayLapThe.Value;
                    d.NgayHetHan = dtpNgayHetHan.Value;
                    busDG.ThemDocGia(d);
                    busDG.LayDSDocGia(gvDocGia);
                    MessageBox.Show("Thêm đọc giả THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm đọc giả THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn phải chọn nhân viên muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("Bạn có muốn xóa không?", "Câu Hỏi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {

                        DOCGIA d = new DOCGIA();
                        d.MaDocGia = int.Parse(txtMaDG.Text);
                        busDG.XoaDocGia(d);
                        busDG.LayDSDocGia(gvDocGia);
                        MessageBox.Show("Xóa thông tin đọc giả THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetNull();
                        btnThem.Enabled = true;
                        btnThem.BackColor = Color.White;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thông tin đọc giả THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {


            if (txtHoTen.Text.Trim().Equals("") || txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông tin đọc giả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qlNv.IsNumber(txtTienNo.Text.Trim()) == false)
            {
                MessageBox.Show("Tiền nợ không được chứa kí tự khác số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (qlNv.IsChar(txtHoTen.Text.Trim()) == false)
            {
                MessageBox.Show("Tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (qlNv.hasSpecialChar(txtHoTen.Text))
            {
                MessageBox.Show("Tên không được chứa kí tự đặc biệt vd:. ,@,!,...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qlNv.hasSpecialChar(txtTienNo.Text))
            {
                MessageBox.Show("Tiền nợ  không được chứa kí tự đặc biệt vd:,@,!,...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (dtpNgayLapThe.Value.CompareTo(dtpNgayHetHan.Value) >= 0)
            {
                MessageBox.Show("Ngày lập thẻ phải trước ngày hết hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    DOCGIA d = new DOCGIA();
                    d.MaDocGia = int.Parse(txtMaDG.Text);
                    d.HoTenDocGia = txtHoTen.Text;
                    d.DiaChi = txtDiaChi.Text;
                    d.NgaySinh = dtpNgaySinh.Value;
                    d.NgayLapThe = dtpNgayLapThe.Value;
                    d.NgayHetHan = dtpNgayHetHan.Value;
                    busDG.SuaTTDocGia(d);
                    busDG.LayDSDocGia(gvDocGia);
                    MessageBox.Show("Cập nhật thông tin đọc giả THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                    btnThem.Enabled = true;
                    btnThem.BackColor = Color.White;
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật thông tin đọc giả THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int numRow;
            numRow = e.RowIndex;
            try
            {
                if (gvDocGia.SelectedCells.Count > 0)
                {
                    txtMaDG.Text = gvDocGia.Rows[numRow].Cells[0].Value.ToString();
                    txtHoTen.Text = gvDocGia.Rows[numRow].Cells[1].Value.ToString();
                    txtDiaChi.Text = gvDocGia.Rows[numRow].Cells[2].Value.ToString();
                    dtpNgaySinh.Text = gvDocGia.Rows[numRow].Cells[3].Value.ToString();
                    txtTienNo.Text = gvDocGia.Rows[numRow].Cells[4].Value.ToString();
                    dtpNgayLapThe.Text = gvDocGia.Rows[numRow].Cells[5].Value.ToString();
                    dtpNgayHetHan.Text = gvDocGia.Rows[numRow].Cells[6].Value.ToString();
                    btnThem.Enabled = false;
                    btnThem.BackColor = Color.Gray;
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải click vào thông tin muốn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
