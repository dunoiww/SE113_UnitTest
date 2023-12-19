using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PhongMachTu.Controllers
{
    public partial class dashBoardPageController : Page
    {
        NhanVien loginUser = null;
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();

        public ObservableCollection<BenhNhan> DsBenhNhan { get; set; }
        public dashBoardPageController()
        {
            InitializeComponent();
            List<NhanVien> nhanVien = DataProvider.Instance.DB.NhanVien.ToList();
            ObservableCollection<NhanVien> nhanViens = new ObservableCollection<NhanVien>(nhanVien);
            lvDoctorOnDashboard.ItemsSource = nhanViens;
            loginUser = GlobleVariable.LoginUser;

            txtSumEmployee.Text = DataProvider.Instance.DB.NhanVien.ToList().Count.ToString();
            txtSumPatients.Text = DataProvider.Instance.DB.BenhNhan.ToList().Count.ToString();



            List<BenhNhan> benhNhan = DataProvider.Instance.DB.BenhNhan.ToList();
            DsBenhNhan = new ObservableCollection<BenhNhan>(benhNhan);
            dsBenhNhan.ItemsSource = DsBenhNhan;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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
    }
}
