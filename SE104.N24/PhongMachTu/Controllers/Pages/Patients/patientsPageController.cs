using PhongMachTu.Database;
using PhongMachTu.Pages.Patients;
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

namespace PhongMachTu.Controllers.Pages.Patients
{
    public partial class patientsPageController : Page
    {
        BenhNhan benhnhan;
        NhanVien loginUser = null;

        public ObservableCollection<BenhNhan> DsBenhNhan { get; set; }
       
        public patientsPageController()
        {
            InitializeComponent();

            List<BenhNhan> benhNhan = DataProvider.Instance.DB.BenhNhan.ToList();


            DsBenhNhan = new ObservableCollection<BenhNhan>(benhNhan);
            dsBenhNhan.ItemsSource = DsBenhNhan;
            dsBenhNhan.Items.Refresh();

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
            var Filterobj = obj as BenhNhan;
            return (Filterobj.FullName.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.MaBN.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.SDT.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void txt_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Filter.Text == null)
            {
                dsBenhNhan.Items.Filter = null;
            }
            else
            {
                dsBenhNhan.Items.Filter = Filting;
            }
        }
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.Navigate(new System.Uri("Views/Pages/Patients/AddPatients.xaml", UriKind.RelativeOrAbsolute));
        }



        private void dsBenhNhan_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BenhNhan selectedPatient = (BenhNhan)dsBenhNhan.SelectedItem;

            // Tạo đối tượng trang chi tiết
            DetailPatientsController detailPatients = new DetailPatientsController(selectedPatient);


            // Chuyển sang trang chi tiết
            this.NavigationService.Navigate(detailPatients);
        }
    }
}
