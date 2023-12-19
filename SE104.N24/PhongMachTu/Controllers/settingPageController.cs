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
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhongMachTu.Controllers
{
    public partial class settingPageController : Page
    {
        NhanVien loginUser = null;
        public settingPageController()
        {
            InitializeComponent();
            loginUser = GlobleVariable.LoginUser;
            InitNhanVien();

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

        private void InitNhanVien()
        {
            txtName.Text = loginUser.TenNV;
            txtBirthday.SelectedDate = loginUser.Birthday;
            cmbSex.Text = loginUser.Sex;
            txtAddress.Text = loginUser.DiaChi;
            txtJob.Text = loginUser.ChucVu;
            txtPhone.Text = loginUser.SDT;
            txtUserName.Text = loginUser.UserName;
            txtPass.Text = loginUser.Password;
            txtNewPassword.Text = "";
            txtReNewPassword.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewPassword.Text == txtReNewPassword.Text)
            {
                if (txtNewPassword.Text == "")
                {
                    loginUser.TenNV = txtName.Text;
                    loginUser.Birthday = txtBirthday.SelectedDate;
                    loginUser.Sex = cmbSex.Text;
                    loginUser.DiaChi = txtAddress.Text;
                    loginUser.SDT = txtJob.Text;
                    loginUser.SDT = txtPhone.Text;
                    loginUser.UserName = txtUserName.Text;
                    loginUser.Password = txtPass.Text;
                }
                else
                {
                    loginUser.TenNV = txtName.Text;
                    loginUser.Birthday = txtBirthday.SelectedDate;
                    loginUser.Sex = cmbSex.Text;
                    loginUser.DiaChi = txtAddress.Text;
                    loginUser.SDT = txtJob.Text;
                    loginUser.SDT = txtPhone.Text;
                    loginUser.Password = txtNewPassword.Text;
                }

                DataProvider.Instance.DB.NhanVien.AddOrUpdate(loginUser);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Cập nhật thành công !");
                InitNhanVien();
            }
            else
                MessageBox.Show("Mật khẩu xác nhận sai!");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            InitNhanVien();
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                // Nếu không phải số, hủy bỏ sự kiện để ngăn người dùng nhập chữ
                e.Handled = true;
            }
        }
    }
}
