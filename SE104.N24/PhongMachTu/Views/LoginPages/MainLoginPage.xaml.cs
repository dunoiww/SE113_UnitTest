using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PhongMachTu.Database;
using PhongMachTu.Utilities;

namespace PhongMachTu.LoginPages
{
    /// <summary>
    /// Interaction logic for MainLoginPage.xaml
    /// </summary>
    public partial class MainLoginPage : Page
    {
        LoginWindow login = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
        public MainLoginPage()
        {
            //InitializeComponent();

        }
    }
}
