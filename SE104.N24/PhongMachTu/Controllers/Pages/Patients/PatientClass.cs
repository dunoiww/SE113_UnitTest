using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhongMachTu.Controllers.Pages.Patients
{
    public class PatientClass
    {
        public int addPatient(string name, string sex, string dob, string address, string phone)
        {
            if ( string.IsNullOrWhiteSpace(name) || dob == null || string.IsNullOrWhiteSpace(sex) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                return 1;
            }

            if (phone.Length != 10 || name.Length > 40 || sex.Length > 3 || address.Length > 40)
            {
                return 2;
            }
            DateTime dateOfBirth;
            bool isValidDate = DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

            if (!isValidDate)
            {
                return 3;
            }

            var patient = new BenhNhan
            {          
                FullName = name,
                Sex = sex,
                Birthday = dateOfBirth,
                DiaChi = address,
                SDT = phone
            };
      
            DataProvider.Instance.DB.BenhNhan.Add(patient);
      
            DataProvider.Instance.DB.SaveChanges();
      

            return 0;
            
        }

        public int editPatient(string name, string sex, string dob, string address, string phone, string mabn)
        {
            if (string.IsNullOrEmpty(name) || dob == null || string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
            {
                return 1;
            }

            var patient = DataProvider.Instance.DB.BenhNhan.Where(x => x.MaBN == mabn).FirstOrDefault();

            if (phone.Length != 10 || name.Length > 40 || sex.Length > 3 || address.Length > 40)
            {
                return 2;
            }
            DateTime dateOfBirth;
            bool isValidDate = DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

            if (!isValidDate)
            {
                return 3;
            }

            patient.FullName = name;
            patient.Birthday = dateOfBirth;
            patient.Sex = sex;
            patient.DiaChi = address;
            patient.SDT = phone;
            DataProvider.Instance.DB.BenhNhan.AddOrUpdate(patient);
            DataProvider.Instance.DB.SaveChanges();

            return 0;
        }
    }
}
