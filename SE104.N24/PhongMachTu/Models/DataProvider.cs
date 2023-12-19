using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongMachTu.Database
{
    public class DataProvider
    {

        //ap dung singleton de khoi tao va su dung duy nhat 1 db trong suot vong doi he thong
        private static DataProvider _instance;

        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataProvider();
                return _instance;
            }
            set => _instance = value;
        }

        public PhongMach DB { get; set; }

        private DataProvider()
        {
            DB = new PhongMach();
        }

    }
}