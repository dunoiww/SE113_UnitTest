using PhongMachTu.Database;
using System;
using System.Collections.Generic;
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
using static PhongMachTu.Pages.patientsPage;

namespace PhongMachTu.LoginPages
{
    /// <summary>
    /// Interaction logic for PageQuenMK.xaml
    /// </summary>
    /// 
    public partial class PageQuenMK : Page
    {
        LoginWindow login = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
        PhongMach phongmach = new PhongMach();
        public PageQuenMK()
        {
            //InitializeComponent();
        }
    }
}
