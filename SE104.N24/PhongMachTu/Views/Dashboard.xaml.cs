using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhongMachTu
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        NhanVien loginUser = null;

        public Dashboard()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            loginUser = GlobleVariable.LoginUser;
        }

        private void MyWindowLoadedHandler(object sender, RoutedEventArgs e)
        {
            btnDashboard.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            if (loginUser.ChucVu != "Quản lý")
            {
                //Chỉ cho phép truy cập trang nếu chức vụ là "Quản lý"
                btnDoctor.Visibility = Visibility.Collapsed;
            }
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/dashBoardPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = Brushes.Blue;
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnPatients_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/Patients/patientsPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = Brushes.Blue;
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/Appointments/appointmentsPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = Brushes.Blue;
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnDoctor_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/Employees/Employee_MainPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = Brushes.Blue;
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnBilling_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/Billing/billingPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = Brushes.Blue;
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnMedicine_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/Medicine/MedicineMain.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = Brushes.Blue;
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/settingPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = Brushes.Blue;
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/reportPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnMedicine.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = Brushes.Blue;
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/Statistics/Statistic_Main.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = Brushes.Blue;
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = new SolidColorBrush(color);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Kiểm tra kết quả của hộp thoại MessageBox
            if (result == MessageBoxResult.Yes)
            {
                // Mở cửa sổ mới
                var newWindow = new LoginWindow();
                newWindow.Show();

                // Đóng cửa sổ hiện tại
                Window.GetWindow(this).Close();
            }
        }

        private void btnPolicy_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Views/Pages/policyPage.xaml", UriKind.RelativeOrAbsolute));
            fContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Thay doi mau 
            Color color = (Color)ColorConverter.ConvertFromString("#969795");
            btnDashboard.Foreground = new SolidColorBrush(color);
            btnPatients.Foreground = new SolidColorBrush(color);
            btnAppointment.Foreground = new SolidColorBrush(color);
            btnDoctor.Foreground = new SolidColorBrush(color);
            btnBilling.Foreground = new SolidColorBrush(color);
            btnStatistic.Foreground = new SolidColorBrush(color);
            btnSetting.Foreground = new SolidColorBrush(color);
            btnReport.Foreground = new SolidColorBrush(color);
            btnPolicy.Foreground = Brushes.Blue;
        }
    }
}
