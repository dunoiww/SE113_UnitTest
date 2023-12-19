using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhongMachTu.Controllers.Pages.Appointments
{
    public partial class DetailAppointmentController :Page
    {
        public ObservableCollection<ChiDinhDungThuoc> DsChiDinh { get; set; }
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();

        NhanVien loginUser = null;

        public DetailAppointmentController(PhieuKhamBenh selectedPKB)
        {
            InitializeComponent();
            txt_MaBN.Text = selectedPKB.MaBN.ToString();
            txt_FullName.Text = selectedPKB.BenhNhan.FullName.ToString();
            txt_GioiTinh.Text = selectedPKB.BenhNhan.Sex;
            txt_Doan.Text = selectedPKB.DuDoan.ToString();
            txt_TrieuChung.Text = selectedPKB.TrieuChung.ToString();
            txt_MaPK.Text = selectedPKB.MaPK;

            var items = DataProvider.Instance.DB.Thuoc.Select(x => x.TenThuoc).ToList();
            cmbTenThuoc.ItemsSource = items;
            loginUser = GlobleVariable.LoginUser;
            pageload();
        }

        public void pageload()
        {

            using (var context = new PhongMach())
            {
                var table1List = context.ChiDinhDungThuoc.ToList();
                var table2List = context.Thuoc.ToList();

                var combinedTable = new DataTable();
                combinedTable.Columns.Add("MaThuoc", typeof(string));
                combinedTable.Columns.Add("TenThuoc", typeof(string));
                combinedTable.Columns.Add("MaPK", typeof(string));
                combinedTable.Columns.Add("SoLuong", typeof(string));
                combinedTable.Columns.Add("GhiChu", typeof(string));

                foreach (var table1 in table1List)
                {
                    var table2 = table2List.FirstOrDefault(t2 => t2.MaThuoc == table1.MaThuoc);
                    if (table2 != null)
                    {
                        var row = combinedTable.NewRow();
                        row["MaThuoc"] = table1.MaThuoc;
                        row["MaPK"] = table1.MaPK;
                        row["TenThuoc"] = table2.TenThuoc;
                        row["SoLuong"] = table1.SoLuong;
                        row["GhiChu"] = table1.GhiChu;

                        combinedTable.Rows.Add(row);
                    }
                }
                DataRow[] filteredRows = combinedTable.Select("MaPK = '" + txt_MaPK.Text + "'");
                if (filteredRows.Length > 0)
                {
                    DataTable filteredTable = filteredRows.CopyToDataTable();
                    dsChiDinh.ItemsSource = filteredTable.DefaultView;
                }
                else
                {
                    dsChiDinh.ItemsSource = null;
                }

                dsChiDinh.Items.Refresh();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (
                string.IsNullOrWhiteSpace(cmbTenThuoc.Text) ||
                string.IsNullOrWhiteSpace(txt_SoLuong.Text) ||
                string.IsNullOrWhiteSpace(txt_GhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Tạo một đối tượng Employee mới
            var chiDinhDungThuoc = new ChiDinhDungThuoc
            {

                MaThuoc = DataProvider.Instance.DB.Thuoc.Where(x => x.TenThuoc == cmbTenThuoc.Text).Select(t => t.MaThuoc).FirstOrDefault(),
                MaPK = txt_MaPK.Text,
                SoLuong = int.Parse(txt_SoLuong.Text),
                GhiChu = txt_GhiChu.Text,
                MaDonVi = "DV001",
                MaCachDung = "CD001",

            };

            // Thêm đối tượng Employee vào DbSet của DbContext
            DataProvider.Instance.DB.ChiDinhDungThuoc.Add(chiDinhDungThuoc);

            // Lưu thay đổi vào cơ sở dữ liệu
            DataProvider.Instance.DB.SaveChanges();

            // Hiển thị thông báo khi thêm thành công
            MessageBox.Show("Thêm thành công!");
            pageload();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Confirmation", MessageBoxButton.YesNo);


            if (result == MessageBoxResult.Yes)
            {
                PhieuKhamBenh phieuKhamBenhRemoved = DataProvider.Instance.DB.PhieuKhamBenh.Find(txt_MaPK.Text);

                HoaDon hoaDon = DataProvider.Instance.DB.HoaDon.Where(x => x.MaPK == txt_MaPK.Text).FirstOrDefault();

                // Xóa bệnh nhân khỏi danh sách bệnh nhân
                DataProvider.Instance.DB.HoaDon.Remove(hoaDon);
                DataProvider.Instance.DB.PhieuKhamBenh.Remove(phieuKhamBenhRemoved);
                //try
                //{
                DataProvider.Instance.DB.SaveChanges();
                NavigationService.GoBack();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message, "Error");
                //}
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PhieuKhamBenh phieuKhamBenh = DataProvider.Instance.DB.PhieuKhamBenh.Find(txt_MaPK.Text);
            phieuKhamBenh.DuDoan = txt_Doan.Text;
            phieuKhamBenh.TrieuChung = txt_TrieuChung.Text;
            DataProvider.Instance.DB.SaveChanges();

            var cddt = DataProvider.Instance.DB.ChiDinhDungThuoc.Where(x => x.MaPK == txt_MaPK.Text).ToList();

            var query = from cd in DataProvider.Instance.DB.ChiDinhDungThuoc
                        join pk in DataProvider.Instance.DB.PhieuKhamBenh on cd.MaPK equals pk.MaPK
                        join th in DataProvider.Instance.DB.Thuoc on cd.MaThuoc equals th.MaThuoc
                        where pk.MaPK == txt_MaPK.Text
                        select new
                        {
                            ThanhTien = cd.SoLuong * th.GiaThuoc
                        };
            var tongTien = query.Sum(x => x.ThanhTien);

            HoaDon hoaDon = DataProvider.Instance.DB.HoaDon.Where(x => x.MaPK == txt_MaPK.Text).FirstOrDefault();
            hoaDon.TienThuoc = tongTien ?? 0;
            hoaDon.TongTienThanhToan = hoaDon.TienKham + hoaDon.TienThuoc;

            DataProvider.Instance.DB.HoaDon.AddOrUpdate(hoaDon);
            DataProvider.Instance.DB.SaveChanges();

            MessageBox.Show("Đã lưu!");
            NavigationService.GoBack();

            //dashboard.fContainer.GoBack();
        }
    }
}
