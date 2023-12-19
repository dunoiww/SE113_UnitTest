using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhongMachTu.Controllers.Pages.Employees
{
    public partial class NewEmployeeController :Page
    {
        PhongMach db = new PhongMach();
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        DateTime dateTimeBirth = DateTime.Now;
        public NewEmployeeController()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeClass ec = new EmployeeClass();
                int x = ec.addNewEmployee(txtName.Text, txtPhone.Text, DatepickerEmployee.SelectedDate.Value.Date.ToString("dd/MM/yyyy"), cmbJob.Text, cmbSex.Text, txtUserName.Text, txtAddress.Text, txtPass.Text);

                if (x == 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    dashboard.fContainer.GoBack();
                } 
                else if (x == 1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!");
                    return;
                }
                else if (x == 2)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!");
                    return;
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên : " + ex);
            }
        }

        private void DatepickerEmployee_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Kiểm tra ký tự nhập vào có phải là số hay không
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                // Nếu không phải số, hủy bỏ sự kiện để ngăn người dùng nhập chữ
                e.Handled = true;
            }
        }
    }
}
