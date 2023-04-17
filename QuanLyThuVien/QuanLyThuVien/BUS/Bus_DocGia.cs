using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BUS
{
    class Bus_DocGia
    {

        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        DAO_DocGia da;
        public Bus_DocGia()
        {
            da = new DAO_DocGia(); ;
        }
        public void LayDSDocGia(DataGridView g)
        {
            g.DataSource = da.GetDSDocGia();
        }


        public void ThemDocGia(DOCGIA d)
        {
            db.DOCGIAs.InsertOnSubmit(d);
            db.SubmitChanges();

        }
        public void SuaTTDocGia(DOCGIA d)
        {


            DOCGIA dg = (from sp in db.DOCGIAs where sp.MaDocGia == d.MaDocGia select sp).FirstOrDefault();
            dg.HoTenDocGia = d.HoTenDocGia;
            dg.DiaChi = d.DiaChi;
            dg.NgaySinh = d.NgaySinh;
            dg.TienNo = d.TienNo;
            dg.NgayLapThe = d.NgayLapThe;
            dg.NgayHetHan = d.NgayHetHan;
            
            db.SubmitChanges();

        }
        public void XoaDocGia(DOCGIA d)
        {
            DOCGIA dg = (from sp in db.DOCGIAs where sp.MaDocGia == d.MaDocGia select sp).FirstOrDefault();
            db.DOCGIAs.DeleteOnSubmit(dg);
            db.SubmitChanges();
        }
    }
}

