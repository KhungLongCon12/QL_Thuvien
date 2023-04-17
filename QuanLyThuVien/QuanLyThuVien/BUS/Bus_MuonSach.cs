using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BUS
{
    class Bus_MuonSach
    {
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        DAO_MuonSach da;

        public Bus_MuonSach()
        {
            da = new DAO_MuonSach();
        }
        public void LayDSThongTinSach(DataGridView g)
        {
            g.DataSource = da.GetDSThongTinSach();
        }

        public void LayTTDocGiaMuonSach(DataGridView g)
        {
            g.DataSource = da.GetThongTinDocGiaMuonSach();
        }

        public PHIEUMUONSACH ThemPhieuMuonSach(string maDocGia)
        {
            PHIEUMUONSACH p = new PHIEUMUONSACH();
            p.MaDocGia = Int32.Parse(maDocGia);
            p.NgayMuon = DateTime.Now;
            db.PHIEUMUONSACHes.InsertOnSubmit(p);
            db.SubmitChanges();
            return p;

        }

        //public object LayTTDocGia()
        //{
        //    return da.GetTenDocGia();
        //}
    }
}
