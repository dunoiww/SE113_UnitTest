using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhongMachTu.Controllers.LoginPages
{
    public partial class PageQuenMKController : Page
    {
        LoginWindow login = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
        PhongMach phongmach = new PhongMach();
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            login.LoginFrame.Navigate(new System.Uri("Views/LoginPages/MainLoginPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public NhanVien GetUserByName(string userName)
        {
            return phongmach.NhanVien.FirstOrDefault(u => u.UserName == userName);
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text;

            using (PhongMach phongmach = new PhongMach())
            {

                var user = phongmach.NhanVien.FirstOrDefault(u => u.UserName == userName);

                if (user != null)
                {
                    // Tên người dùng đã xác thực, cho phép tạo mật khẩu mới
                    string newPassword = txtNewPassw.Password;
                    string confirmPassword = txtConfirm.Password;

                    if (newPassword == confirmPassword)
                    {
                        // Mật khẩu mới hợp lệ, lưu vào cơ sở dữ liệu
                        user.Password = newPassword;
                        phongmach.SaveChanges();
                        MessageBox.Show("Thay đổi Mật Khẩu thành công !");
                        login.LoginFrame.Navigate(new System.Uri("Views/LoginPages/MainLoginPage.xaml", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match");
                    }
                }
                else
                {
                    MessageBox.Show("User not found");
                }
            }
        }
    }
}
