using PhongMachTu.Database;
using PhongMachTu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity.Migrations;

namespace PhongMachTu.Controllers.Pages.Employees
{
    public partial class Employee_InformationController :Page
    {
        NhanVien nhanvien;
        bool IsEdit = true;
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        public Employee_InformationController()
        {
            InitializeComponent();
            InitNhanVien();
        }
        private void InitNhanVien()
        {
            nhanvien = GlobleVariable.selectedNhanVien;
            txtName.Text = nhanvien.TenNV;
            txtBirthday.SelectedDate = nhanvien.Birthday;
            cmbSex.Text = nhanvien.Sex;
            txtAddress.Text = nhanvien.DiaChi;
            cmbJob.Text = nhanvien.ChucVu;
            txtPhone.Text = nhanvien.SDT;
            txtUserName.Text = nhanvien.UserName;
            txtPass.Text = nhanvien.Password;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }
        private void SetEnable()
        {
            txtName.IsEnabled = true;
            txtBirthday.IsEnabled = true;
            cmbSex.IsEnabled = true;
            txtAddress.IsEnabled = true;
            cmbJob.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtUserName.IsEnabled = true;
            txtPass.IsEnabled = true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
            {
                SetEnable();
                btnEdit.Content = "Save";
                IsEdit = false;
            }
            else
            {
                EmployeeClass ec = new EmployeeClass();
                int x = ec.editEmployee(txtName.Text, txtPhone.Text, txtBirthday.SelectedDate.Value.Date.ToString("dd/MM/yyyy"), cmbJob.Text, cmbSex.Text, txtUserName.Text, txtAddress.Text, txtPass.Text, nhanvien.MaNV);
                //nhanvien.TenNV = txtName.Text;
                //nhanvien.Birthday = txtBirthday.SelectedDate;
                //nhanvien.Sex = cmbSex.Text;
                //nhanvien.DiaChi = txtAddress.Text;
                //nhanvien.ChucVu = cmbJob.Text;
                //nhanvien.SDT = txtPhone.Text;
                //nhanvien.UserName = txtUserName.Text;
                //nhanvien.Password = txtPass.Text;
                //DataProvider.Instance.DB.NhanVien.AddOrUpdate(nhanvien);
                //DataProvider.Instance.DB.SaveChanges();
                if (x == 0)
                {
                    MessageBox.Show("Update Nhân viên thành công !");
                }
                else if (x == 1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                    return;
                }
                else if (x == 2)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ");
                    return;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin hợp lệ !");
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    NhanVien nhanvienRemoved = DataProvider.Instance.DB.NhanVien.Find(nhanvien.MaNV);
                    DataProvider.Instance.DB.NhanVien.Remove(nhanvienRemoved);
                    DataProvider.Instance.DB.SaveChanges();
                    MessageBox.Show("Xóa Nhân viên thành công !");
                    dashboard.fContainer.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtBirthday_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
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
