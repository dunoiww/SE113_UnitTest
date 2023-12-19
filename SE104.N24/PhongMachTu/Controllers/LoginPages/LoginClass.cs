using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongMachTu.Controllers.LoginPages
{
    public class LoginClass
    {
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {

                using (var context = new PhongMach())
                {
                    var user = context.NhanVien.FirstOrDefault(u => u.UserName == username && u.Password == password);
                    if (user != null)
                    {
                        // Đăng nhập thành công
                        GlobleVariable.LoginUser = user;
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        return true;
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        return false;
                    }
                }
            }
        }
    }
}
