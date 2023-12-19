using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhongMachTu.Controllers.Pages.Billing
{
    public partial class DetailBillingController :Page
    {
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        NhanVien loginUser = null;
        public class PrescriptionItem
        {
            public string TenThuoc { get; set; }
            public int SoLuong { get; set; }
            public decimal GiaThuoc { get; set; }
            public decimal ThanhTien { get { return SoLuong * GiaThuoc; } }
        }
        public DetailBillingController(string maHD)
        {
            InitializeComponent();

            txt_MaHD.Text = maHD;
            loginUser = GlobleVariable.LoginUser;

            Pageload();
        }

        public void Pageload()
        {
            txt_MaBN.Text = (from hd in DataProvider.Instance.DB.HoaDon
                             join pk in DataProvider.Instance.DB.PhieuKhamBenh on hd.MaPK equals pk.MaPK
                             where hd.MaHD == txt_MaHD.Text
                             select pk.MaBN).FirstOrDefault();
            txt_FullName.Text = (from bn in DataProvider.Instance.DB.BenhNhan
                                 where bn.MaBN == txt_MaBN.Text
                                 select bn.FullName).FirstOrDefault();
            txt_GioiTinh.Text = (from bn in DataProvider.Instance.DB.BenhNhan
                                 where bn.MaBN == txt_MaBN.Text
                                 select bn.Sex).FirstOrDefault();
            txt_TrieuChung.Text = (from hd in DataProvider.Instance.DB.HoaDon
                                   join pk in DataProvider.Instance.DB.PhieuKhamBenh on hd.MaPK equals pk.MaPK
                                   where hd.MaHD == txt_MaHD.Text
                                   select pk.TrieuChung).FirstOrDefault();
            txt_Doan.Text = (from hd in DataProvider.Instance.DB.HoaDon
                             join pk in DataProvider.Instance.DB.PhieuKhamBenh on hd.MaPK equals pk.MaPK
                             where hd.MaHD == txt_MaHD.Text
                             select pk.DuDoan).FirstOrDefault();

            var query = from cddt in DataProvider.Instance.DB.ChiDinhDungThuoc
                        join pk in DataProvider.Instance.DB.PhieuKhamBenh on cddt.MaPK equals pk.MaPK
                        join hd in DataProvider.Instance.DB.HoaDon on pk.MaPK equals hd.MaPK
                        join thuoc in DataProvider.Instance.DB.Thuoc on cddt.MaThuoc equals thuoc.MaThuoc
                        where hd.MaHD == txt_MaHD.Text // maHD là giá trị của MaHD cần tìm
                        select new PrescriptionItem
                        {
                            TenThuoc = thuoc.TenThuoc,
                            SoLuong = cddt.SoLuong ?? 0,
                            GiaThuoc = thuoc.GiaThuoc
                        };
            lvThuoc.ItemsSource = query.ToList();

        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hoaDon = DataProvider.Instance.DB.HoaDon.Where(x => x.MaHD == txt_MaHD.Text).FirstOrDefault();
            hoaDon.TrangThai = 1;
            DataProvider.Instance.DB.HoaDon.AddOrUpdate(hoaDon);
            DataProvider.Instance.DB.SaveChanges();

            MessageBox.Show("Thanh toán thành công!");
            NavigationService.GoBack();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }
    }
}
