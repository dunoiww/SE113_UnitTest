using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhongMachTu;
using PhongMachTu.Controllers.LoginPages;
using PhongMachTu.Controllers.Pages.Employees;
using PhongMachTu.Controllers.Pages.Medicine;
using PhongMachTu.Controllers.Pages.Patients;
using PhongMachTu.Database;
using PhongMachTu.Views.Pages;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.RightsManagement;
using System.Windows;

namespace UnitTest_PhongMachTu
{
    [TestClass]
    public class UnitTestLogin:BaseTest
    {
        [TestMethod]
        [DataRow("ngquanly1", "123456", true)]
        [DataRow("admin", "admin", false)]
        public void TestLogin(string username, string password, bool expectedFlag)
        {
            LoginClass lc = new LoginClass();

            bool actualFlag = lc.Login(username, password);

            Assert.AreEqual(expectedFlag, actualFlag, $"Đăng nhập {(expectedFlag ? "thành công" : "thất bại")}");
        }
    }

    [TestClass]
    public class UnitTestAddPatient : BaseTest
    {
        [TestMethod]
        //valid
        [DataRow("nguyen van a", "nam", "01/12/2023", "ABCDEFGH", "0123456789", 0)]

        //missing name
        [DataRow("", "nam", "01/12/2023", "ABCDEFGH", "0123456789", 1)]
        //invalid name
        [DataRow("aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa", "nam", "01/12/2023", "ABCDEFGH", "0123456789", 2)]
        //boundary name
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "nam", "01/12/2023", "ABCDEFGH", "0123456789", 0)] //40 a
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "nam", "01/12/2023", "ABCDEFGH", "0123456789", 2)] //41 a
        [DataRow("a", "nam", "01/12/2023", "ABCDEFGH", "0123456789", 0)]

        //missing dob
        [DataRow("nguyen van a", "nam", "", "ABCDEFGH", "0123456789", 3)]
        //invalid dob
        [DataRow("nguyen van a", "nam", "32/12/2023", "ABCDEFGH", "0123456789", 3)]

        //missing sex
        [DataRow("nguyen van a", "", "01/12/2023", "ABCDEFGH", "0123456789", 1)]
        //invalid sex
        [DataRow("nguyen van a", "nammmmmm", "01/12/2023", "ABCDEFGH", "0123456789", 2)]

        //missing address
        [DataRow("nguyen van a", "nam", "01/12/2023", "", "0123456789", 1)]
        //invalid address
        [DataRow("nguyen van a", "nam", "01/12/2023", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "0123456789", 2)]

        //missing phone
        [DataRow("nguyen van a", "nam", "01/12/2023", "ABCDEFGH", "", 1)]
        //invalid phone
        [DataRow("nguyen van a", "nam", "01/12/2023", "ABCDEFGH", "01234567891", 2)]

        public void TestAddPatient(string name, string sex, string dob, string address, string phone, int expected)
        {
            PatientClass pc = new PatientClass();
            int x = pc.addPatient(name, sex, dob, address, phone);
            Assert.AreEqual(expected, x);
        }

        [TestMethod]
        [DataRow("nguyen van a", "nam", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 0)]

        //missing name
        [DataRow("", "nam", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 1)]
        //invalid name
        [DataRow("aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa", "nam", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 2)]
        //boundary name
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "nam", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 0)] //40 a
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "nam", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 2)] //41 a
        [DataRow("a", "nam", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 0)]

        //missing dob
        [DataRow("nguyen van a", "nam", "", "ABCDEFGH", "0123456789", "BN005", 3)]
        //invalid dob
        [DataRow("nguyen van a", "nam", "32/12/2023", "ABCDEFGH", "0123456789", "BN005", 3)]

        //missing sex
        [DataRow("nguyen van a", "", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 1)]
        //invalid sex
        [DataRow("nguyen van a", "nammmmmm", "01/12/2023", "ABCDEFGH", "0123456789", "BN005", 2)]

        //missing address
        [DataRow("nguyen van a", "nam", "01/12/2023", "", "0123456789", "BN005", 1)]
        //invalid address
        [DataRow("nguyen van a", "nam", "01/12/2023", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "0123456789", "BN005", 2)]

        //missing phone
        [DataRow("nguyen van a", "nam", "01/12/2023", "ABCDEFGH", "", "BN005", 1)]
        //invalid phone
        [DataRow("nguyen van a", "nam", "01/12/2023", "ABCDEFGH", "012345678911", "BN005", 2)]

        public void TestEditEmployee(string name, string sex, string dob, string address, string phone, string mabn, int expected)
        {
            PatientClass pc = new PatientClass();
            int x = pc.editPatient(name, sex, dob, address, phone, mabn);
            Assert.AreEqual(expected, x);
        }
    }

    [TestClass]
    public class UnitTestEmployee
    {
        //Thêm nhân viên
        [TestMethod]
        //valid
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "xxxxx", "abcdefgh", "pass", 0)]

        //missing name
        [DataRow("", "0909090909", "01/12/2023", "Quản lý", "nam", "username", "abcdefgh", "pass", 1)]
        //invalid name
        [DataRow("aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaaaa", "0909090909", "01/12/2023", "Quản lý", "nam", "username", "abcdefgh", "pass", 3)]
        //boundary name
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "0909090909", "01/12/2023", "Quan ly", "nam", "xxxxxx", "abcdefgh", "pass", 0)]
        [DataRow("a", "0909090909", "01/12/2023", "Quan ly", "nam", "xxxxxxx", "abcdefgh", "pass", 0)]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "0909090909", "01/12/2023", "Quan ly", "nam", "usernameAdd", "abcdefgh", "pass", 3)]


        //missing phone
        [DataRow("nguyen van a", "", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "pass", 1)]
        //invalid phone
        [DataRow("nguyen van a", "01234567890", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "pass", 3)]

        //missing dob
        [DataRow("nguyen van a", "0909090909", "", "Quan ly", "nam", "username", "abcdefgh", "pass", 1)]
        //invalid dob
        [DataRow("nguyen van a", "0909090909", "32/12/2023", "Quan ly", "nam", "username", "abcdefgh", "pass", 2)]

        //missing job
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "", "nam", "username", "abcdefgh", "pass", 1)]
        //invalid job
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "aaaaaaaaaa aaaaaaaaaa a", "nam", "username", "abcdefgh", "pass", 3)]

        //missing sex
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "", "username", "abcdefgh", "pass", 1)]
        //invalid sex
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nammmmm", "username", "abcdefgh", "pass", 3)]

        //missing username
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "", "abcdefgh", "pass", 1)]
        //invalid username
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "aaaaaaaaaaaaaaaaaaaaa", "abcdefgh", "pass", 3)]
        //boundary username
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "a", "abcdefgh", "pass", 0)]
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "aaaaaaaaaaaaaaa", "abcdefgh", "pass", 0)]
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "aaaaaaaaaaaaaaaa", "abcdefgh", "pass", 3)]



        //missing address
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "", "pass", 1)]
        //invalid address
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "pass", 3)]

        //missing pass
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "", 1)]
        //invalid pass
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "aaaaaaaaaaaaaaaaaaaaa", 3)]
        public void TestAddEmployee(string name, string phone, string dob, string job, string sex, string username, string address, string pass, int expected)
        {
            EmployeeClass ec = new EmployeeClass();
            int x = ec.addNewEmployee(name, phone, dob, job, sex, username, address, pass);
            Assert.AreEqual(expected, x);
        }

        //Sửa nhân viên
        [TestMethod]
        //valid
        [DataRow("nguyen thi a", "0909090909", "01/12/2022", "nhan vien", "Nữ", "usernameEdit", "address", "pass", "NV005", 0)]

        //missing name
        [DataRow("", "0909090909", "01/12/2023", "Quản lý", "nam", "username", "abcdefgh", "pass", "NV005", 1)]
        //invalid name
        [DataRow("aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaaaa", "0909090909", "01/12/2023", "Quản lý", "nam", "username", "abcdefgh", "pass", "NV005", 3)]

        //missing phone
        [DataRow("nguyen van a", "", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "pass", "NV005", 1)]
        //invalid phone
        [DataRow("nguyen van a", "01234567890", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "pass", "NV005", 3)]

        //missing dob
        [DataRow("nguyen van a", "0909090909", "", "Quan ly", "nam", "username", "abcdefgh", "pass", "NV005", 1)]
        //invalid dob
        [DataRow("nguyen van a", "0909090909", "32/12/2023", "Quan ly", "nam", "username", "abcdefgh", "pass", "NV005", 2)]

        //missing job
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "", "nam", "username", "abcdefgh", "pass", "NV005", 1)]
        //invalid job
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "aaaaaaaaaa aaaaaaaaaa a", "nam", "username", "abcdefgh", "pass", "NV005", 3)]

        //missing sex
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "", "username", "abcdefgh", "pass", "NV005", 1)]
        //invalid sex
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nammmmm", "username", "abcdefgh", "pass", "NV005", 3)]

        //missing username
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "", "abcdefgh", "pass", "NV005", 1)]
        //invalid username
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "aaaaaaaaaaaaaaaaaaaaa", "abcdefgh", "pass", "NV005", 3)]
        //boundary username
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "b", "abcdefgh", "pass", "NV005", 0)]
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "bbbbbbbbbbbbbbb", "abcdefgh", "pass", "NV005", 0)]
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "aaaaaaaaaaaaaaaa", "abcdefgh", "pass", "NV005", 3)]

        //missing address
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "", "pass", "NV005", 1)]
        //invalid address
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "pass", "NV005", 3)]
        //boundary address
        [DataRow("nguyen thi a", "0909090909", "01/12/2022", "nhan vien", "Nữ", "usernameEdit", "a", "pass", "NV005", 0)]
        [DataRow("nguyen thi a", "0909090909", "01/12/2022", "nhan vien", "Nữ", "usernameEdit", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "pass", "NV005", 0)]
        [DataRow("nguyen thi a", "0909090909", "01/12/2022", "nhan vien", "Nữ", "usernameEdit", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "pass", "NV005", 3)]

        //missing pass
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "", "NV005", 1)]
        //invalid pass
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "NV005", 3)]
        //boundary pass
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "usernameEdit1", "abcdefgh", "a", "NV005", 0)]
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "usernameEdit2", "abcdefgh", "aaaaaaaaaaaaaaaaaaaa", "NV005", 0)]
        [DataRow("nguyen van a", "0909090909", "01/12/2023", "Quan ly", "nam", "username", "abcdefgh", "aaaaaaaaaaaaaaaaaaaaa", "NV005", 3)]



        public void TestEditEmployee(string name, string phone, string dob, string job, string sex, string username, string address, string pass, string manv, int expected)
        {
            EmployeeClass ec = new EmployeeClass();
            int x = ec.editEmployee(name, phone, dob, job, sex, username, address, pass, manv);
            Assert.AreEqual(expected, x);
        }
    }

    [TestClass]
    public class UnitTestQuyDinh
    {
        //Thêm policy
        [TestMethod]
        [DataRow("QD007", "1", 0)]

        //missing name
        [DataRow("", "2", 1)]
        //boundary name
        [DataRow("x", "3", 0)]
        [DataRow("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "3", 0)] //100
        [DataRow("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "3", 2)] //101

        //missing value
        [DataRow("QD004", "", 1)]
        // boundary value
        [DataRow("QD005", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 0)] //50 charss
        [DataRow("QD005", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 2)] //51 chars

        public void TestAddQuyDinh(string name, string value, int expected)
        {
            policyClass pc = new policyClass();
            int x = pc.addPolicy(name, value);
            Assert.AreEqual(expected, x);
        }

        //Sửa policy
        [TestMethod]
        [DataRow("QD005", "suaqd", "1", 0)]

        //missing name
        [DataRow("QD007", "", "2", 1)]
        //boundary name
        [DataRow("QD005", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "3", 0)]
        [DataRow("QD007", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "3", 2)]


        //missing value
        [DataRow("QD007", "suaqd", "", 1)]
        //boundary value
        [DataRow("QD005", "QD004", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 0)] //50 chars
        [DataRow("QD007", "QD004", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 2)] //51 chars

        public void TestEditQuyDinh(string id, string name, string value, int expected)
        {
            policyClass pc = new policyClass();
            int x = pc.editPolicy(id, name, value);
            Assert.AreEqual(expected, x);
        }
    }

    [TestClass]
    public class UnitTestAddMedicine
    {
        //Thêm thuốc
        [TestMethod]
        [DataRow("Paraxetamol", "12", "100000", "Hộp", 0)]
        //missing name
        [DataRow("", "12", "100000", "Hộp", 1)]
        //invalid name
        [DataRow("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "12", "10000", "Hộp", 2)] //40
        // boundary name
        [DataRow("x", "12", "10000", "Hộp", 0)]
        [DataRow("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "12", "10000", "Hộp", 0)] //40
        [DataRow("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "12", "10000", "Hộp", 2)] //41


        //missing quantitiy
        [DataRow("Paraxetamol", "", "100000", "hộp", 1)]

        //missing price
        [DataRow("Paraxetamol", "12", "", "hộp", 1)]

        //missing type
        [DataRow("Paraxetamol", "12", "100000", "", 1)]
        //invalid type
        [DataRow("Paraxetamol", "12", "100000", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 2)]

        //boundary type
        [DataRow("Paraxetamol", "12", "100000", "x", 0)] //40 chars
        [DataRow("Paraxetamol", "12", "100000", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 0)] //40 chars
        [DataRow("Paraxetamol", "12", "100000", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 2)] //41 chars


        public void TestAddMedicine(string name, string quantity, string price, string type, int expected)
        {
            MedicineClass mc = new MedicineClass();
            int x = mc.addMedicine(name, quantity, price, type);
            Assert.AreEqual(expected, x);
        }
    }
}
