using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.ThirdParty.TINCheck
{
    [Serializable]
    public class AddressResponse
    {
        public sbyte AddressCode { get; set; }
        public string AddressDetails { get; set; }

        public enum AddressResponseEnum
        {
            USPSMatchFound = 2
        }
    }
}
