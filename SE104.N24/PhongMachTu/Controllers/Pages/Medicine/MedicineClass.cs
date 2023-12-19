using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhongMachTu.Controllers.Pages.Medicine
{
    public class MedicineClass
    {
        public int addMedicine(string tenthuoc, string tonkho, string giathuoc, string loaithuoc)
        {
            if (string.IsNullOrEmpty(tenthuoc) || string.IsNullOrEmpty(tonkho) || string.IsNullOrEmpty(giathuoc) || string.IsNullOrEmpty(loaithuoc))
            {
                return 1;
            }

            if (tenthuoc.Length > 40 || tonkho == null || giathuoc == null || loaithuoc.Length > 40)
            {
                return 2;
            }

            var thuoc = new Thuoc
            {
                TenThuoc = tenthuoc,
                TonKho = int.Parse(tonkho),
                GiaThuoc = int.Parse(giathuoc),
                LoaiThuoc = loaithuoc
            };

            DataProvider.Instance.DB.Thuoc.Add(thuoc);

            DataProvider.Instance.DB.SaveChanges();

            return 0;
        }
    }
}
