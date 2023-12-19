using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhongMachTu.Controllers
{
    public partial class reportPageController : Page
    {
        public reportPageController()
        {
            InitializeComponent();
        }

        private async void btnSendIssue_Click(object sender, RoutedEventArgs e)
        {
            string toEmail = "21520739@gm.uit.edu.vn"; // Email người nhận
            string subject = "THƯ BÁO LỖI PHẦN MỀM QUẢN LÝ PHÒNG MẠCH TƯ: " + this.txtTitle.Text;
            string body = this.txtDescription.Text;

            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        SendEmail(toEmail, subject, body);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error sending email: " + ex.Message);

                    }
                });
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }
        public void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "lequocdung2983@gmail.com";
                string password = "ciuglinpcvmzfgcg";
                string smtpHost = "smtp.gmail.com"; //  SMTP host 

                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(smtpHost);
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(fromEmail, password);

                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }
    }
}
