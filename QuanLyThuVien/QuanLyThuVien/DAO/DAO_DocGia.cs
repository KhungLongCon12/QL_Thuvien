using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    class DAO_DocGia
    {
        public DAO_DocGia()
        {
            conString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            sqlConn = new SqlConnection(conString);
        }
        //Linq
        #region LinQ
        SqlConnection sqlConn;
        String conString = "";
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();

        public dynamic GetDSDocGia()
        {
            var s = db.DOCGIAs.Select(n => new { n.MaDocGia,n.HoTenDocGia, n.DiaChi, n.NgaySinh, n.TienNo, n.NgayLapThe,n.NgayHetHan }).ToList();
            return s;
        }


        #endregion

    }
}
