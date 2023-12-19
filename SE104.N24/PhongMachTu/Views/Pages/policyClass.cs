using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhongMachTu.Views.Pages
{
    public class policyClass
    {
        public int addPolicy(string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                return 1;
            }

            if (name.Length > 100 || value.Length > 50)
            {
                return 2;
            }

            var qd = new QuyDinh
            {
                TenQD = name,
                GiaTri = value,
            };

            DataProvider.Instance.DB.QuyDinh.Add(qd);
            DataProvider.Instance.DB.SaveChanges();

            return 0;
        }

        public int editPolicy(string id, string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                return 1;
            }

            if (name.Length > 100 || value.Length > 50)
            {
                return 2;
            }

            QuyDinh qd = DataProvider.Instance.DB.QuyDinh.Where(x => x.MaQD == id).FirstOrDefault();

            qd.TenQD = name;
            qd.GiaTri = value;

            DataProvider.Instance.DB.QuyDinh.AddOrUpdate(qd);
            DataProvider.Instance.DB.SaveChanges();

            return 0;
        }
    }
}
