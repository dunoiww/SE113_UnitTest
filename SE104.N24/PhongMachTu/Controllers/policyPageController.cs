using PhongMachTu.Database;
using PhongMachTu.Utilities;
using PhongMachTu.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PhongMachTu.Controllers
{
    public partial class policyPageController : Page
    {
        NhanVien loginUser = null;
        public policyPageController()
        {
            InitializeComponent();

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
            Pageload();
        }

        public void Pageload()
        {
            List<QuyDinh> quyDinh = DataProvider.Instance.DB.QuyDinh.ToList();
            ObservableCollection<QuyDinh> quyDinhs = new ObservableCollection<QuyDinh>(quyDinh);
            lv.ItemsSource = quyDinhs;
            if (loginUser.ChucVu != "Quản lý")
            {
                //Chỉ cho phép truy cập trang nếu chức vụ là "Quản lý"
                btnAdd.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Hidden;
            }
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedQuyDinh = lv.SelectedItem as QuyDinh;
            if (selectedQuyDinh != null)
            {
                var id = selectedQuyDinh.MaQD;

                txtID.Text = id.ToString();
                txtName.Text = selectedQuyDinh.TenQD.ToString();
                txtValue.Text = selectedQuyDinh.GiaTri;

                if (txtName.Text == selectedQuyDinh.TenQD.ToString() && txtValue.Text == selectedQuyDinh.GiaTri)
                {
                    btnDelete.IsEnabled = true;
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            policyClass pc = new policyClass();
            int x = pc.editPolicy(txtID.Text, txtName.Text, txtValue.Text);
            if (x == 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin quy định!");
                return;
            }
            else if (x == 2)
            {
                MessageBox.Show("Thông tin không hợp lệ");
                return;
            }
            else
            {
                Pageload();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            policyClass pc = new policyClass();
            int x = pc.addPolicy(txtName.Text, txtValue.Text);

            if (x == 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin quy định!");
                return;
            }
            else if (x == 2)
            {
                MessageBox.Show("Thông tin không hợp lệ!");
                return;
            }
            else
            {
                Pageload();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    QuyDinh qd = DataProvider.Instance.DB.QuyDinh.Where(q => q.MaQD == txtID.Text && q.TenQD == txtName.Text && q.GiaTri == txtValue.Text).FirstOrDefault();
                    if (qd != null)
                    {
                        DataProvider.Instance.DB.QuyDinh.Remove(qd);
                        DataProvider.Instance.DB.SaveChanges();
                        System.Windows.MessageBox.Show("Xóa thành công !");

                        Pageload();
                    }
                    else { System.Windows.MessageBox.Show("Không thể xóa!!"); }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
