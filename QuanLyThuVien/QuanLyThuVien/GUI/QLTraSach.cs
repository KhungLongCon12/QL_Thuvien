using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class QLTraSach : Form
    {
        public QLTraSach()
        {
            InitializeComponent();
            busTraSach = new Bus_TraSach();
            busMuonSach = new Bus_MuonSach();
            busCTPhieuMuon = new Bus_CTPhieuMuon();
            da = new DAO_TraSach();

        }
        Bus_TraSach busTraSach;
        Bus_MuonSach busMuonSach;
        Bus_CTPhieuMuon busCTPhieuMuon;
        DAO_TraSach da;

        private void QLTraSach_Load(object sender, EventArgs e)
        {

            busTraSach.LayDanhSachSDocGia(gvDocGiaMuonSach);
            gvDocGiaMuonSach.Columns[0].Width = (int)(gvDocGiaMuonSach.Width * 0.15);
            gvDocGiaMuonSach.Columns[1].Width = (int)(gvDocGiaMuonSach.Width * 0.2);
            gvDocGiaMuonSach.Columns[2].Width = (int)(gvDocGiaMuonSach.Width * 0.3);
            gvDocGiaMuonSach.Columns[2].Width = (int)(gvDocGiaMuonSach.Width * 0.33);
            txtMaDocGia.Enabled = false;
            txtTenDocGia.Enabled = false;
            txtDiaChi.Enabled = false;
            dtpNgaySinhDocGia.Enabled = false;


            lvSach.FullRowSelect = true; //cho phép chọn 1 dòng
            lvSach.View = View.Details; //cho phép hiển thị thông tin chi tiết dạng bảng


            lvSach.View = View.Details;
            //so cot cua LV
            lvSach.Columns.Add("Mã sách", 100);
            lvSach.Columns.Add("Tên sách", 200);
            lvSach.Columns.Add("Ngày mượn", 100);
        }

        private void gvDocGiaMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int numRow;
            numRow = e.RowIndex;
            try
            {
                if (gvDocGiaMuonSach.SelectedCells.Count > 0)
                {
                    txtMaDocGia.Text = gvDocGiaMuonSach.Rows[numRow].Cells[0].Value.ToString();
                    txtTenDocGia.Text = gvDocGiaMuonSach.Rows[numRow].Cells[1].Value.ToString();
                    txtDiaChi.Text = gvDocGiaMuonSach.Rows[numRow].Cells[2].Value.ToString();
                    dtpNgaySinhDocGia.Text = gvDocGiaMuonSach.Rows[numRow].Cells[3].Value.ToString();


                    int res = int.Parse(txtMaDocGia.Text);

                    PHIEUMUONSACH phieu = da.TimPhieuMuonSachCuaDocGia(res);
                    txtMaPhieu.Text = phieu.MaPhieuMuon.ToString();

                    //MessageBox.Show(phieu.MaPhieuMuon.ToString());

                    List<int> list = da.dsMaSachDocGiaMuon(phieu.MaPhieuMuon);

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Độc giả hiện đang không mượn cuốn sách nào!!!");
                        txtMaPhieu.Text = "";
                    }
                    else
                    {
                        foreach (int i in list)
                        {
                            SACH sach = da.timSachTheoMa(i);
                            ListViewItem lvi = new ListViewItem(sach.MaSach.ToString());

                            lvi.SubItems.Add(sach.TenSach);

                            lvi.SubItems.Add(phieu.NgayMuon.ToString());
                            lvSach.Items.Add(lvi);
                            txtTenSach.Text = sach.TenSach;
                            txtMaSach.Text = sach.MaSach.ToString();
                            dtpNgayMuon.Text = phieu.NgayMuon.ToString();
                        }
                    }

                }


            
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải click vào thông tin muốn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (lvSach.SelectedIndices.Count > 0)
            {
                da.CapNhatTraSach(txtMaSach.Text, Int32.Parse(txtMaPhieu.Text));
                lvSach.Items.RemoveAt(lvSach.SelectedIndices[0]);
                MessageBox.Show("Trả sách thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách cần trả");
            }
        }
    }
}
