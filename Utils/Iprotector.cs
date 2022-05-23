using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSB_Ofish_System.Utils
{
    public interface Iprotector
    {
        string encriptData(string clearText);
        string decriptData(string encodecText);
    }

    public  class Protector : Iprotector
    {
        private readonly IDataProtector _protector;
        public Protector(IDataProtectionProvider provider )
        {
            _protector = provider.CreateProtector("UsingCnn");
        }

        public string decriptData(string encodecText)
        {
          return  _protector.Unprotect(encodecText);
        }

        public string encriptData(string clearText)
        {
            return _protector.Protect(clearText);
        }
    }
}
