using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    public class Status
    {


        public enum StatusEnum
        {
            Active=1,
            Inactive=2,
            PendingReview=3
        }
    }
}
