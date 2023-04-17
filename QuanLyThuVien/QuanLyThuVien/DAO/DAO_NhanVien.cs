using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyThuVien
{
    class DAO_NhanVien
    {

        public DAO_NhanVien()
        {
            conString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            sqlConn = new SqlConnection(conString);
        }
        //Linq
        #region LinQ
        SqlConnection sqlConn;
        String conString = "";
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();

        public dynamic GetDSNhanVien()
        {
            var s = db.NHANVIENs.Select(n => new {n.MaNhanVien, n.HoTenNhanVien, n.NgaySinh, n.DiaChi, n.DienThoai }).ToList();
            return s;
        }


        #endregion



    }
}
