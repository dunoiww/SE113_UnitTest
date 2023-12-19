using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhongMachTu.Controllers.Pages.Patients
{
    public partial class DetailPatientsController :Page
    {
        BenhNhan benhnhan;
        bool IsEdit = true;
        PhongMach db = new PhongMach();
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        public DetailPatientsController(BenhNhan selectedPatient)
        {
            InitializeComponent();

            benhnhan = selectedPatient;
            txt_MaBN.Text = selectedPatient.MaBN.ToString();
            txt_FullName.Text = selectedPatient.FullName.ToString();
            txt_DiaChi.Text = selectedPatient.DiaChi.ToString();
            txt_Birthday.SelectedDate = selectedPatient.Birthday;
            txt_GioiTinh.Text = selectedPatient.Sex;
            txt_SDT.Text = selectedPatient.SDT.ToString();

        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.Navigate(new System.Uri("Views/Pages/Patients/patientsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            // Xác nhận xem người dùng có muốn xóa bệnh nhân này hay không
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the current patient?", "Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                BenhNhan benhnhanRemoved = DataProvider.Instance.DB.BenhNhan.Find(txt_MaBN.Text);
                PhieuKhamBenh phieuKhamBenh = DataProvider.Instance.DB.PhieuKhamBenh.Where(x => x.MaBN == txt_MaBN.Text).FirstOrDefault();
                if (phieuKhamBenh != null)
                {
                    HoaDon hoaDon = DataProvider.Instance.DB.HoaDon.Where(x => x.MaPK == phieuKhamBenh.MaPK).FirstOrDefault();

                    DataProvider.Instance.DB.HoaDon.Remove(hoaDon);
                    DataProvider.Instance.DB.PhieuKhamBenh.Remove(phieuKhamBenh);
                }

                // Xóa bệnh nhân khỏi danh sách bệnh nhân
                DataProvider.Instance.DB.BenhNhan.Remove(benhnhanRemoved);
                //try
                //{
                DataProvider.Instance.DB.SaveChanges();
                NavigationService.GoBack();
                MessageBox.Show("Đã xóa");
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message, "Error");
                //}
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            PatientClass pc = new PatientClass();
            int x = pc.editPatient(txt_FullName.Text, txt_GioiTinh.Text, txt_Birthday.SelectedDate.Value.Date.ToString("dd/MM/yyyy"), txt_DiaChi.Text, txt_SDT.Text, txt_MaBN.Text);

            if (x == 0)
            {
                MessageBox.Show("Update Bệnh nhân thành công !");
                NavigationService.GoBack();
            }
            else if (x == 1)
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                return;
            }
            else if (x == 2)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng");
                return;
            }
            else if (x == 3)
            {
                MessageBox.Show("vui lòng nhập đúng định dạng ngày tháng");
                return;
            }

            //benhnhan.FullName = txt_FullName.Text;
            //benhnhan.Birthday = txt_Birthday.SelectedDate;
            //benhnhan.Sex = txt_GioiTinh.Text;
            //benhnhan.DiaChi = txt_DiaChi.Text;
            //benhnhan.SDT = txt_SDT.Text;
            //DataProvider.Instance.DB.BenhNhan.AddOrUpdate(benhnhan);
            //DataProvider.Instance.DB.SaveChanges();
            //MessageBox.Show("Update Bệnh nhân thành công !");
            //NavigationService.GoBack();
        }
    }
}
