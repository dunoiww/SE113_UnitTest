using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

namespace PhongMachTu.Controllers.Pages.Medicine
{
    public partial class MedicineMainController :Page
    {
        NhanVien loginUser = null;

        public MedicineMainController()
        {
            InitializeComponent();
            Page_load();

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
        public void Page_load()
        {
            List<Thuoc> thuoc = DataProvider.Instance.DB.Thuoc.ToList();
            ObservableCollection<Thuoc> thuocs = new ObservableCollection<Thuoc>(thuoc);
            lvMedicine.ItemsSource = thuocs;
        }

        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();

        private bool Filting(object obj)
        {
            var Filterobj = obj as Thuoc;
            return (Filterobj.TenThuoc.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.MaThuoc.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void txt_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Filter.Text == null)
            {
                lvMedicine.Items.Filter = null;
            }
            else
            {
                lvMedicine.Items.Filter = Filting;
            }
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.Navigate(new Uri("Views/Pages/Medicine/MedicineAdd.xaml", UriKind.RelativeOrAbsolute));
        }

        Thuoc thuocRemoved;
        private void lvMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvMedicine.SelectedItems != null)
            {
                btnXoa.IsEnabled = true;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lvMedicine.SelectedItems != null)
            {
                Thuoc selectedItem = (Thuoc)lvMedicine.SelectedItem;
                int selectedIndex = lvMedicine.SelectedIndex;

                if (selectedItem.MaThuoc != null)
                    thuocRemoved = DataProvider.Instance.DB.Thuoc.Find(selectedItem.MaThuoc);

                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DataProvider.Instance.DB.Thuoc.Remove(thuocRemoved);
                        DataProvider.Instance.DB.SaveChanges();
                        MessageBox.Show("Xóa Thuốc thành công !");
                        Page_load();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (lvMedicine.Items.Count > 0)
                {
                    int nextSelectedIndex = selectedIndex;
                    if (nextSelectedIndex >= lvMedicine.Items.Count)
                    {
                        nextSelectedIndex = lvMedicine.Items.Count - 1;
                    }
                    lvMedicine.SelectedIndex = nextSelectedIndex;
                }
            }
        }
    }
}
