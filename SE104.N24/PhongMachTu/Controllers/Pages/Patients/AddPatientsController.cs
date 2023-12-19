using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhongMachTu.Controllers.Pages.Patients
{
    public partial class AddPatientsController :Page
    {
        PhongMach db = new PhongMach();
        public AddPatientsController()
        {
            InitializeComponent();
        }
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }
        public void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PatientClass pc = new PatientClass();

                int flag = pc.addPatient(txt_FullName.Text, cmbSex.Text, DatepickerEmployee.SelectedDate.Value.Date.ToString("dd/MM/yyyy"), txt_DiaChi.Text, txt_SDT.Text);

                if (flag == 0)
                {
                    MessageBox.Show("Đã thêm bệnh nhân mới");

                    dashboard.fContainer.GoBack();
                } 
                else if (flag == 1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                else if (flag == 2)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng");
                    return;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng ngày tháng");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        

        private void DatepickerEmployee_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
