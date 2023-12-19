using MaterialDesignThemes.Wpf;
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
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhongMachTu.Controllers.Pages.Employees
{
    public partial class Employee_MainPageController:Page
    {
        NhanVien loginUser = null;
        public Employee_MainPageController()
        {
            InitializeComponent();
            List<NhanVien> nhanVien = DataProvider.Instance.DB.NhanVien.ToList();
            ObservableCollection<NhanVien> nhanViens = new ObservableCollection<NhanVien>(nhanVien);
            dsNhanVien.ItemsSource = nhanViens;
            loginUser = GlobleVariable.LoginUser;
        }
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        private void btnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.Navigate(new System.Uri("Views/Pages/Employees/NewEmployee.xaml", UriKind.RelativeOrAbsolute));
        }
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedCard = sender as Card;

            // Truy cập đối tượng được chọn thông qua thuộc tính DataContext
            var nhanvien = selectedCard.DataContext as NhanVien;

            // Sử dụng selectedObject để xử lý các tác vụ khác

            GlobleVariable.selectedNhanVien = nhanvien;
            dashboard.fContainer.Navigate(new Uri("Views/Pages/Employees/Employee_Information.xaml?employee=", UriKind.RelativeOrAbsolute));
            // Truy cập đối tượng được truyền từ trang gốc thông qua thuộc tính NavigationContext

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
        private bool Filting(object obj)
        {
            var Filterobj = obj as NhanVien;
            return (Filterobj.TenNV.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.Sex.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.ChucVu.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtSearch.Text == null)
            {
                dsNhanVien.Items.Filter = null;
            }
            else
            {
                dsNhanVien.Items.Filter = Filting;
            }
        }
    }
}
