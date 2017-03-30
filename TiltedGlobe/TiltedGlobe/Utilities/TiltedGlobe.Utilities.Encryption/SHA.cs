using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Utilities.Encryption
{
    public class SHA
    {
        public static string SHAEncryptString(string incoming) 
        {
            var prov = new SHA1CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            var hash = prov.ComputeHash(encoding.GetBytes(incoming));

            return Convert.ToBase64String(hash);
        }
    }
}
