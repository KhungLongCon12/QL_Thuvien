using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    class Bus_CTPhieuMuon
    {
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        DAO_MuonSach da;
        public Bus_CTPhieuMuon()
        {
            da = new DAO_MuonSach();
        }
        public void ThemChiTietPhieuMuonSach(string maSach, int maPhieu)
        {
            CHITIETPHIEUMUON p = new CHITIETPHIEUMUON();
            p.MaSach = Int32.Parse(maSach);
            p.MaPhieuMuon = maPhieu;
            db.CHITIETPHIEUMUONs.InsertOnSubmit(p);
            db.SubmitChanges();
        }
    }
}
