using PhongMachTu.Database;
using PhongMachTu.Pages.Appointments;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhongMachTu.Controllers.Pages.Appointments
{
    public partial class appointmentsPageController : Page
    {
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        NhanVien loginUser = null;
        public ObservableCollection<PhieuKhamBenh> DsPhieuKhamBenh { get; set; }
        public appointmentsPageController()
        {

            InitializeComponent();
            List<PhieuKhamBenh> phieuKhamBenh = DataProvider.Instance.DB.PhieuKhamBenh.ToList();
            DsPhieuKhamBenh = new ObservableCollection<PhieuKhamBenh>(phieuKhamBenh);
            dsPhieuKhamBenh.ItemsSource = DsPhieuKhamBenh;

            loginUser = GlobleVariable.LoginUser;
            txtCurrentUser.Text = loginUser.TenNV;
            txtCurrentUserRole.Text = loginUser.ChucVu;
            if (loginUser.Sex == "Nam")
            {
                imgCurrentUser.Source = new BitmapImage(new Uri("/Resources/EmployeeNam.png", UriKind.Relative));
            }
            else
            {
                imgCurrentUser.Source = new BitmapImage(new Uri("/Resources/Employee.png", UriKind.Relative));
            }
        }
        private bool Filting(object obj)
        {
            var Filterobj = obj as PhieuKhamBenh;
            return (Filterobj.MaPK.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.BenhNhan.FullName.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.BenhNhan.DiaChi.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txt_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Filter.Text == null)
            {
                dsPhieuKhamBenh.Items.Filter = null;
            }
            else
            {
                dsPhieuKhamBenh.Items.Filter = Filting;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_LayMaBN.Text))

            {
                MessageBox.Show("Vui lòng nhập mã Bệnh Nhân!");
                return;
            }

            BenhNhan benhNhan = DataProvider.Instance.DB.BenhNhan.Find(txt_LayMaBN.Text);

            if (benhNhan != null)
            {
                var phieuKhamBenh = new PhieuKhamBenh
                {
                    MaBN = benhNhan.MaBN,
                    NgayLap = DateTime.Now,
                    TrieuChung = "Triệu Chứng",
                    DuDoan = "Dự Đoán",

                };
                // Thêm đối tượng Employee vào DbSet của DbContext
                DataProvider.Instance.DB.PhieuKhamBenh.Add(phieuKhamBenh);
                // Lưu thay đổi vào cơ sở dữ liệu
                DataProvider.Instance.DB.SaveChanges();
                // Hiển thị thông báo khi thêm thành công
                MessageBox.Show("Thêm thành công!");

                txt_LayMaBN.Text = null;
                dashboard.fContainer.Refresh();


                HoaDon hoaDon = new HoaDon()
                {
                    MaPK = phieuKhamBenh.MaPK,
                    NgayLap = DateTime.Now,
                    TienKham = int.Parse(DataProvider.Instance.DB.QuyDinh.Where(x => x.TenQD == "Tiền khám").Select(x => x.GiaTri).FirstOrDefault()),
                    TienThuoc = 0,
                    TongTienThanhToan = int.Parse(DataProvider.Instance.DB.QuyDinh.Where(x => x.TenQD == "Tiền khám").Select(x => x.GiaTri).FirstOrDefault()),
                    TrangThai = 0,
                };

                DataProvider.Instance.DB.HoaDon.Add(hoaDon);

                // Lưu thay đổi vào cơ sở dữ liệu
                DataProvider.Instance.DB.SaveChanges();
            }
            else MessageBox.Show("Không tìm thấy bệnh nhân!");

        }

        private void dsPhieuKhamBenh_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PhieuKhamBenh selectedPKB = (PhieuKhamBenh)dsPhieuKhamBenh.SelectedItem;

            // Tạo đối tượng trang chi tiết
            DetailAppointmentController detailAppointment = new DetailAppointmentController(selectedPKB);


            // Chuyển sang trang chi tiết
            this.NavigationService.Navigate(detailAppointment);
        }
    }
}
