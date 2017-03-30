using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    public interface IBillingInfo
    {
        int BillingID { get; set; }
        CommercialViewerUser User { get; set; }
        string CCNum_Enc { get; set; }
        string CVV_Enc { get; set; }
        string Expiry_Enc { get; set; }
        string CardHolder_Enc { get; set; }
        Address Address { get; set; }
    }
}
