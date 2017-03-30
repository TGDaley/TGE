using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    public interface IAddress
    {
        int AddressID { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string StateCode { get; set; }
        string StateText { get; set; }
        string Country { get; set; }
        string ZipPostalCode { get; set; }
    }
}
