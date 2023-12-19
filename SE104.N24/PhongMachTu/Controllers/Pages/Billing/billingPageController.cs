using PhongMachTu.Database;
using PhongMachTu.Pages.Billing;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhongMachTu.Controllers.Pages.Billing
{
    public partial class billingPageController : Page
    {
        NhanVien loginUser = null;
        public class Bill
        {
            public string MaHD { get; set; }
            public string FullName { get; set; }
            public DateTime NgayLap { get; set; }
            public int TongTienThanhToan { get; set; }
        }

        public billingPageController()
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

            //bản mới trong bill
            var queryBill = from hd in DataProvider.Instance.DB.HoaDon
                            join pk in DataProvider.Instance.DB.PhieuKhamBenh on hd.MaPK equals pk.MaPK
                            join bn in DataProvider.Instance.DB.BenhNhan on pk.MaBN equals bn.MaBN
                            where hd.TrangThai == 0
                            select new Bill
                            {
                                MaHD = hd.MaHD,
                                FullName = bn.FullName,
                                NgayLap = hd.NgayLap,
                                TongTienThanhToan = hd.TongTienThanhToan
                            };
            lvBill.ItemsSource = queryBill.ToList();
            //

            //Hiển thị bảng Paid
            var queryPaid = from hd in DataProvider.Instance.DB.HoaDon
                            join pk in DataProvider.Instance.DB.PhieuKhamBenh on hd.MaPK equals pk.MaPK
                            join bn in DataProvider.Instance.DB.BenhNhan on pk.MaBN equals bn.MaBN
                            where hd.TrangThai == 1
                            select new Bill
                            {
                                MaHD = hd.MaHD,
                                FullName = bn.FullName,
                                NgayLap = hd.NgayLap,
                                TongTienThanhToan = hd.TongTienThanhToan
                            };

            lvPaid.ItemsSource = queryPaid.ToList();

        }


        private void lvBill_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var bill = lvBill.SelectedItem as Bill;
            if (bill != null)
            {
                var id = bill.MaHD;
                // Sử dụng giá trị của cột ID ở đây
                DetailBillingController detailBilling = new DetailBillingController(id);

                this.NavigationService.Navigate(detailBilling);
            }
        }

        private bool Filting(object obj)
        {
            var Filterobj = obj as Bill;
            return (Filterobj.FullName.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (Filterobj.MaHD.IndexOf(txt_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void txt_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Filter.Text == null)
            {
                lvBill.Items.Filter = null;
            }
            else
            {
                lvBill.Items.Filter = Filting;
                lvPaid.Items.Filter = Filting;
            }
        }
    }
}
