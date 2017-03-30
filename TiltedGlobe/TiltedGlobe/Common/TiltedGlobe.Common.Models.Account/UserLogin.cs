using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    [Serializable]
    public class UserLogin
    {
        public string EmailAddress { get; set; }
        public UserType UserType { get; set; }
        public DateTime LastLoginDateTime { get; set; }

    }
}
