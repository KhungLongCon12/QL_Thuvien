using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    
    class Bus_NhanVien
    {
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        DAO_NhanVien da;
        public Bus_NhanVien()
        {
            da = new DAO_NhanVien();
        }
        public void LayDSNhanVien(DataGridView g)
        {
            g.DataSource = da.GetDSNhanVien();
        }


        public void ThemNhanVien(NHANVIEN n)
        {
            db.NHANVIENs.InsertOnSubmit(n);
            db.SubmitChanges();
            
        }
        public void SuaTTNhanVien(NHANVIEN n)
        {


            NHANVIEN nv = (from sp in db.NHANVIENs where sp.MaNhanVien == n.MaNhanVien select sp).FirstOrDefault();
            nv.HoTenNhanVien = n.HoTenNhanVien;
            nv.NgaySinh = n.NgaySinh;
            nv.DiaChi = n.DiaChi;
            nv.DienThoai = n.DienThoai;
            db.SubmitChanges();

        }
        public void XoaNhanVien(NHANVIEN n)
        {
            NHANVIEN nv = (from sp in db.NHANVIENs where sp.MaNhanVien == n.MaNhanVien select sp).FirstOrDefault();
            db.NHANVIENs.DeleteOnSubmit(nv);
            db.SubmitChanges();
        }
    }
}
