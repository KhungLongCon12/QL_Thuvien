using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    class DAO_TraSach
    {
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        
        public DAO_TraSach()
        {
            conString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            sqlConn = new SqlConnection(conString);
        }
        //Linq
        #region LinQ
        SqlConnection sqlConn;
        String conString = "";

        public dynamic LayTTDocGia()
        {
            var s = db.DOCGIAs.Select(n => new { n.MaDocGia, n.HoTenDocGia, n.DiaChi, n.NgaySinh }).ToList();
            return s;
        }

        public PHIEUMUONSACH TimPhieuMuonSachCuaDocGia(int maDocGia)
        {

            PHIEUMUONSACH p = db.PHIEUMUONSACHes.OrderByDescending(s => s.NgayMuon).FirstOrDefault(s => s.MaDocGia.Equals(maDocGia));
            return p;

        }

        public List<int> dsMaSachDocGiaMuon(int maPhieu)
        {
            List<int> kq = new List<int>();
            IEnumerable<CHITIETPHIEUMUON> p = db.GetTable<CHITIETPHIEUMUON>().
                Where(s => s.MaPhieuMuon.Equals(maPhieu)).Where(s => s.NgayTra.Equals(null));
            foreach (CHITIETPHIEUMUON i in p)
            {
                kq.Add(i.MaSach);
            }
            return kq;
        }
        public SACH timSachTheoMa(int ma)
        {
            SACH s = db.SACHes.FirstOrDefault(p => p.MaSach.Equals(ma));
            return s;
        }

        public void CapNhatTraSach(string maSach, int maPhieu)
        {
            CHITIETPHIEUMUON p1 = db.GetTable<CHITIETPHIEUMUON>().
                Where(s => s.MaPhieuMuon.Equals(maPhieu)).Where(s => s.MaSach.Equals(maSach)).First();
            //ChiTietPhieuMuon p = qltvDB.ChiTietPhieuMuons.
            //    FirstOrDefault(s => s.MaPhieuMuon.Equals(maPhieu) 
            //|| s.MaSach.Equals(maSach));
            p1.NgayTra = DateTime.Now;
            db.SubmitChanges();

        }
        #endregion

    }
}
