using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    class DAO_Sach
    {
        public DAO_Sach()
        {
            conString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            sqlConn = new SqlConnection(conString);
        }
        //Linq
        #region LinQ
        SqlConnection sqlConn;
        String conString = "";
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();

        public dynamic GetDSSach()
        {
            var s = db.SACHes.Select(n => new { n.MaSach,n.TenSach, n.TacGia, n.NhaXuatBan, n.TriGia, n.NgayNhap,n.NamXuatBan }).ToList();
            return s;
        }


        #endregion



    }
}

