using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhongMachTu.Controllers.Pages.Medicine
{
    public partial class MedicineAddController :Page
    {
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        public MedicineAddController()
        {
            InitializeComponent();
            var items = DataProvider.Instance.DB.DonViThuoc.Select(x => x.DienGiai).ToList();
            cmbDonVi.ItemsSource = items;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MedicineClass mc = new MedicineClass();
            int x = mc.addMedicine(txtName.Text, txtCount.Text, txtPrice.Text, cmbDonVi.Text);
            if (x == 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else if (x == 2)
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!");
                return;
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                dashboard.fContainer.GoBack();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtCount.Text = string.Empty;
            cmbDonVi.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }
    }
}
