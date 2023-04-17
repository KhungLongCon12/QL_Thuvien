using QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class QuanLyNhanVien : Form
    {

       
        
        public QuanLyNhanVien()
        {
            InitializeComponent();
            busNv = new Bus_NhanVien();
        }
        Bus_NhanVien busNv;

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            busNv.LayDSNhanVien(gvNhanVien);
            gvNhanVien.Columns[0].Visible = false;
            gvNhanVien.Columns[1].Width = (int)(gvNhanVien.Width * 0.25);
            gvNhanVien.Columns[2].Width = (int)(gvNhanVien.Width * 0.15);
            gvNhanVien.Columns[3].Width = (int)(gvNhanVien.Width * 0.4); 
            gvNhanVien.Columns[4].Width = (int)(gvNhanVien.Width * 0.15);
        }

        private void gvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int numRow;
            numRow = e.RowIndex;
            try
            {
                if (gvNhanVien.SelectedCells.Count > 0)
                {
                    txtMaNV.Text= gvNhanVien.Rows[numRow].Cells[0].Value.ToString();
                    txtHoTen.Text = gvNhanVien.Rows[numRow].Cells[1].Value.ToString();
                    dtpNgaySinh.Text = gvNhanVien.Rows[numRow].Cells[2].Value.ToString();
                    txtDiaChi.Text = gvNhanVien.Rows[numRow].Cells[3].Value.ToString();
                    txtDienThoai.Text = gvNhanVien.Rows[numRow].Cells[4].Value.ToString();
                    btnThem.Enabled = false;
                    btnThem.BackColor = Color.Gray;
                }
            } catch (Exception)
            {
                MessageBox.Show("Bạn phải click vào thông tin muốn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           


        }
 

        public void SetNull()
        {
            DateTime date = DateTime.Now;
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            dtpNgaySinh.Value = date;
            txtMaNV.Text = "";
        }

        public bool IsNumber(string pValue)
        {
                    foreach (Char c in pValue)
                    {
                        if (!Char.IsDigit(c))
                            return false;
                    }
                    return true;
        }
        public bool IsChar(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        //hàm kiểm tra kí tự đặc biệt
        public  bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,+";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtDienThoai.Text.Trim().Equals("") || txtHoTen.Text.Trim().Equals("") || txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông tin nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (IsNumber(txtDienThoai.Text.Trim()) == false)
            {
                MessageBox.Show("Số điện thoại không được chứa chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (IsChar(txtHoTen.Text.Trim()) == false)
            {
                MessageBox.Show("Tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtDienThoai.Text.Trim().Length<10 || txtDienThoai.Text.Trim().Length > 10)
            {
                MessageBox.Show("số điện thoại phải có 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!txtDienThoai.Text.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (hasSpecialChar(txtHoTen.Text))
            {
                MessageBox.Show("Tên không được chứa kí tự đặc biệt vd:. ,@,!,...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                try
                {
                    NHANVIEN n = new NHANVIEN();
                    n.HoTenNhanVien = txtHoTen.Text;
                    n.NgaySinh = dtpNgaySinh.Value;
                    n.DiaChi = txtDiaChi.Text;
                    n.DienThoai = txtDienThoai.Text;
                    busNv.ThemNhanVien(n);
                    busNv.LayDSNhanVien(gvNhanVien);
                    MessageBox.Show("Thêm nhân viên THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                    btnThem.Enabled = true;
                    btnThem.BackColor = Color.White;
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm nhân viên THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtDienThoai.Text.Trim().Equals("") || txtHoTen.Text.Trim().Equals("") || txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông tin nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (IsNumber(txtDienThoai.Text.Trim()) == false)
            {
                MessageBox.Show("Số điện thoại không được chứa chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (IsChar(txtHoTen.Text.Trim()) == false)
            {
                MessageBox.Show("Tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDienThoai.Text.Trim().Length < 10 || txtDienThoai.Text.Trim().Length > 10)
            {
                MessageBox.Show("số điện thoại phải có 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!txtDienThoai.Text.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (hasSpecialChar(txtHoTen.Text))
            {
                MessageBox.Show("Tên không được chứa kí tự đặc biệt vd:. ,@,!,...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    NHANVIEN n = new NHANVIEN();
                    n.MaNhanVien = int.Parse(txtMaNV.Text);
                    n.HoTenNhanVien = txtHoTen.Text;
                    n.NgaySinh = dtpNgaySinh.Value;
                    n.DiaChi = txtDiaChi.Text;
                    n.DienThoai = txtDienThoai.Text;
                    busNv.SuaTTNhanVien(n);
                    busNv.LayDSNhanVien(gvNhanVien);
                    MessageBox.Show("Cập nhật thông tin nhân viên THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNull();
                    btnThem.Enabled = true;
                    btnThem.BackColor = Color.White;
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim().Equals("")){
                MessageBox.Show("Bạn phải chọn nhân viên muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                try
                {
                    DialogResult res = MessageBox.Show("Bạn có muốn xóa không?", "Câu Hỏi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {

                        NHANVIEN n = new NHANVIEN();
                        n.MaNhanVien = int.Parse(txtMaNV.Text);
                        busNv.XoaNhanVien(n);
                        busNv.LayDSNhanVien(gvNhanVien);
                        MessageBox.Show("Xóa thông tin nhân viên THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetNull();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thông tin nhân viên THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

