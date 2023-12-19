using PhongMachTu.Database;
using PhongMachTu.Utilities;
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
    public partial class MainLoginPageController : Page
    {
        LoginWindow login = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
        public MainLoginPageController()
        {
            InitializeComponent();

        }
        static public bool isValid = false;

        private void btnForgot_Click(object sender, RoutedEventArgs e)
        {
            login.LoginFrame.Navigate(new System.Uri("Views/LoginPages/PageQuenMK.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            LoginClass lc = new LoginClass();
            bool flag = lc.Login(txtUserName.Text, txtPassWord.Password);
            if (flag)
            {
                var getWd = Window.GetWindow(this);  //Lấy Window của cái Trang này(PageChinh)
                getWd.Close(); //Đăng Nhập thành công => đóng Form Đăng Nhập
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Lỗi");
            }

            //if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassWord.Password))
            //{
            //    MessageBox.Show("Please fill Username and Password.", "Error");
            //    return;
            //}
            //else
            //{
            //    string userName = txtUserName.Text;
            //    string password = txtPassWord.Password;

            //    using (var context = new PhongMach())
            //    {
            //        var user = context.NhanVien.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            //        if (user != null)
            //        {
            //            // Đăng nhập thành công
            //            GlobleVariable.LoginUser = user;
            //            Dashboard dashboard = new Dashboard();
            //            dashboard.Show();
            //            var getWd = Window.GetWindow(this);  //Lấy Window của cái Trang này(PageChinh)
            //            getWd.Close(); //Đăng Nhập thành công => đóng Form Đăng Nhập

            //        }
            //        else
            //        {
            //            // Đăng nhập thất bại
            //            MessageBox.Show("Invalid username or password, Please enter again!", "Error!");
            //        }
            //    }
            //}
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter || e.Key == System.Windows.Input.Key.Return)
                btnLogin_Click(sender, e);
        }
    }
}
