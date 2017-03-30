using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    public class UserType
    {
        int UserTypeID {  get; set; }
        string UserTypeDesc { get; set; }


        public enum UserTypeEnum
        {
            Producer=1,
            Viewer=2,
            CommercialViewer=3
        }
    }
}
