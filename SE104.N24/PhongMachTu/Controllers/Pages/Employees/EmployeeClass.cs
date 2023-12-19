using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhongMachTu.Controllers.Pages.Employees
{
    public class EmployeeClass
    {
        public int addNewEmployee(string name, string phone, string dob, string job, string sex, string username, string address, string pass)
        {
            if (string.IsNullOrEmpty(name) ||
                    string.IsNullOrEmpty(phone) ||
                    string.IsNullOrEmpty(dob) ||
                    string.IsNullOrEmpty(job) ||
                    string.IsNullOrEmpty(sex) ||
                    string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(address) ||
                    string.IsNullOrEmpty(pass))
            {
                
                return 1;
            }

            DateTime dateOfBirth;
            bool isValidDate = DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

            if (!isValidDate || dateOfBirth > DateTime.Now.Date)
            {
                return 2;
            }

            if (name.Length > 40 || address.Length > 40 || phone.Length != 10 || pass.Length > 20 || sex.Length > 3 || job.Length > 20 || username.Length > 15)
            {
                return 3;
            }

            using (var phongmach = new PhongMach())
            {
                // Tạo một đối tượng Employee mới
                var employee = new NhanVien
                {
                    TenNV = name,
                    SDT = phone,
                    Birthday = dateOfBirth,
                    ChucVu = job,
                    Sex = sex,
                    UserName = username,
                    DiaChi = address,
                    Password = pass
                };

                // Thêm đối tượng Employee vào DbSet của DbContext
                phongmach.NhanVien.Add(employee);

                // Lưu thay đổi vào cơ sở dữ liệu
                phongmach.SaveChanges();

                // Hiển thị thông báo khi thêm thành công
                return 0;
            }
        }

        public int editEmployee(string name, string phone, string dob, string job, string sex, string username, string address, string pass, string manv)
        {

            if (string.IsNullOrEmpty(name) ||
                    string.IsNullOrEmpty(phone) ||
                    string.IsNullOrEmpty(dob) ||
                    string.IsNullOrEmpty(job) ||
                    string.IsNullOrEmpty(sex) ||
                    string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(address) ||
                    string.IsNullOrEmpty(pass) ||
                    string.IsNullOrEmpty(manv))
            {
                return 1;
            }

            var nhanvien = DataProvider.Instance.DB.NhanVien.Where(p => p.MaNV == manv).SingleOrDefault();

            DateTime dateOfBirth;
            bool isValidDate = DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

            if (!isValidDate || dateOfBirth > DateTime.Now.Date)
            {
                return 2;
            }

            if (name.Length > 40 || address.Length > 40 || phone.Length != 10 || pass.Length > 20 || sex.Length > 3 || job.Length > 20 || username.Length > 15)
            {
                return 3;
            }

            nhanvien.TenNV = name;
            nhanvien.Birthday = dateOfBirth;
            nhanvien.Sex = sex;
            nhanvien.DiaChi = address;
            nhanvien.ChucVu = job;
            nhanvien.SDT = phone;
            nhanvien.UserName = username;
            nhanvien.Password = pass;
            DataProvider.Instance.DB.NhanVien.AddOrUpdate(nhanvien);
            DataProvider.Instance.DB.SaveChanges();

            return 0;
        }
    }
}
