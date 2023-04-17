using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    class DAO_MuonSach
    {
        public DAO_MuonSach()
        {
            conString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            sqlConn = new SqlConnection(conString);
        }
        //Linq
        #region LinQ
        SqlConnection sqlConn;
        String conString = "";
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        
        public dynamic GetDSThongTinSach()
        {
            var s = db.SACHes.Select(n => new { n.MaSach, n.TenSach, n.TacGia,n.TriGia }).ToList();
            return s;
        }
        public dynamic  GetThongTinDocGiaMuonSach()
        {
            var s = db.DOCGIAs.Select(n => new { n.MaDocGia, n.HoTenDocGia,n.NgaySinh }).ToList();
            return s;
        }

        

        class DocGiaModel
        {
            public int MaDocGia { get; set; }

            public string _HoTenDocGia { get; set; }

            public System.Nullable<System.DateTime> _NgaySinh { get; set; }

            public string _DiaChi { get; set; }

            public string _Email { get; set; }

            public System.Nullable<System.DateTime> _NgayLapThe { get; set; }

            public System.Nullable<System.DateTime> _NgayHetHan { get; set; }

            public System.Nullable<int> _TienNo { get; set; }

        }


        #endregion

    }
}
