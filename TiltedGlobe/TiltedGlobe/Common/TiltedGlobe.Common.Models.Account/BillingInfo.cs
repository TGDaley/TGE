using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    [Serializable]
    public class BillingInfo : IBillingInfo
    {

        #region IBillingInfo Members

        public int BillingID { get; set; }
        public CommercialViewerUser User { get; set; }
        public string CCNum_Enc { get; set; }
        public string CVV_Enc { get; set; }
        public string Expiry_Enc { get; set; }
        public string CardHolder_Enc { get; set; }
        public Address Address { get; set; }

        #endregion
    }
}
