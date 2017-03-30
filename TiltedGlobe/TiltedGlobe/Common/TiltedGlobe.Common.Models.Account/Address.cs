using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    [Serializable]
    public class Address : IAddress
    {

        #region IAddress Members

        public int AddressID { get; set; }

        [Required(ErrorMessage = "Address line 1 is required")]
        public string Address1 { get; set; }
        
        public string Address2 { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        
        public string StateCode { get; set; }
        
        public string StateText { get; set; }
        
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        
        public string ZipPostalCode { get; set; }

        #endregion
    }
}
