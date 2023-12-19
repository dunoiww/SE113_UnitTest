using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhongMachTu.Controllers.Pages.Statistics
{
    public partial class Statistic_MainController : Page
    {
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        public Statistic_MainController()
        {
            InitializeComponent();
            SumOfData();
        }
        private void SumOfData()
        {
            txtSumNV.Text = DataProvider.Instance.DB.NhanVien.ToList().Count.ToString();
            txtSumBenhNhan.Text = DataProvider.Instance.DB.BenhNhan.ToList().Count.ToString();
            txtSumThuoc.Text = DataProvider.Instance.DB.Thuoc.ToList().Count.ToString();
            //txtSumDoanhThu.Text = DataProvider.Instance.DB.HoaDon.Sum(hd => hd.TongTienThanhToan).ToString() + " VND";
            txtSumDoanhThu.Text = DataProvider.Instance.DB.HoaDon.Where(hd => hd.TrangThai == 1).Sum(hd => hd.TongTienThanhToan).ToString() + " VND";
        }

        private void Card_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            dashboard.fContainer.Navigate(new System.Uri("Views/Pages/Statistics/DoanhThuPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
