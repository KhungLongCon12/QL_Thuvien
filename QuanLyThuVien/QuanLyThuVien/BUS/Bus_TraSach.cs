using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BUS
{
    class Bus_TraSach
    {
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        DAO_TraSach da;
        public Bus_TraSach()
        {
            da = new DAO_TraSach();
        }
        public void LayDanhSachSDocGia(DataGridView g)
        {
            g.DataSource = da.LayTTDocGia();
        }
    }
}
