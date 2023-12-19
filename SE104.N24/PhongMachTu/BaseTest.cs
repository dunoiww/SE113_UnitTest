using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhongMachTu
{
    public class BaseTest
    {
        public BaseTest()
        {
            /* Preparing test start */
            Assembly assembly = Assembly.GetCallingAssembly();

            AppDomainManager manager = new AppDomainManager();
            FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            entryAssemblyfield.SetValue(manager, assembly);

            AppDomain domain = AppDomain.CurrentDomain;
            FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
            domainManagerField.SetValue(domain, manager);
            /* Preparing test end */
        }
    }
}
