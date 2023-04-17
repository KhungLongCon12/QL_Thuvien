using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BUS
{
    
    class Bus_Sach
    {
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        DAO_Sach da;
    
    public Bus_Sach()
    {
        da = new DAO_Sach();
    }
    public void LayDSSach(DataGridView g)
    {
        g.DataSource = da.GetDSSach();
    }


    public void ThemSach(SACH s)
    {
        db.SACHes.InsertOnSubmit(s);
        db.SubmitChanges();

    }
    public void SuaTTSach(SACH s)
    {


        SACH sa = (from sp in db.SACHes where sp.MaSach == s.MaSach select sp).FirstOrDefault();
        sa.MaSach = s.MaSach;
        sa.TenSach = s.TenSach;
        sa.TacGia = s.TacGia;
        sa.NhaXuatBan = s.NhaXuatBan;
        sa.TriGia = s.TriGia;
        sa.NgayNhap = s.NgayNhap;
        sa.NamXuatBan = s.NamXuatBan;

        db.SubmitChanges();

    }
    public void XoaSach(SACH s)
    {
        SACH sa = (from sp in db.SACHes where sp.MaSach == s.MaSach select sp).FirstOrDefault();
        db.SACHes.DeleteOnSubmit(sa);
        db.SubmitChanges();
    }
    }
}
