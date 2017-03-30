using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiltedGlobe.Common.Models.ThirdParty.TINCheck;

namespace TiltedGlobe.ThirdParty.TINCheck
{
    public class TINChecker
    {
        private const string _tinCheckUserName = "jose@tiltedglobe.com";
        private const string _tinCheckUserPassword = "password";

        public static TiltedGlobe.Common.Models.ThirdParty.TINCheck.TINCheckResponse CheckTIN(TiltedGlobe.Common.Models.Account.IUser pUser)
        {
            TINCheckResponse response = new TINCheckResponse();

            var tinNameToCheck = new TINCheck.com.TinNameClass();
            tinNameToCheck.FName = pUser.FirstName;
            tinNameToCheck.LName = pUser.LastName;
            tinNameToCheck.TIN = pUser.Ein;

            var tinAddressToCheck = new TINCheck.com.USPSAddressClass();
            tinAddressToCheck.Address1 = pUser.Address.Address1;
            tinAddressToCheck.Address2 = pUser.Address.Address2;
            tinAddressToCheck.City = pUser.Address.City;
            tinAddressToCheck.State = pUser.Address.StateCode;
            tinAddressToCheck.Zip5 = pUser.Address.ZipPostalCode;

            var tinUser = new TINCheck.com.UserClass();
            tinUser.UserLogin = _tinCheckUserName;
            tinUser.UserPassword = _tinCheckUserPassword;

            try
            {
                using (var client = new TINCheck.com.PVSServiceSoapClient())
                {
                    var result = client.ValidateTinNameAddressListMatch(tinNameToCheck, tinAddressToCheck, tinUser);

                    var nameResponse = new NameResponse();
                    nameResponse.DMFCode = result.TINNAME_RESULT.DMF_CODE;
                    nameResponse.DMFData = result.TINNAME_RESULT.DMF_DATA;
                    nameResponse.DMFDetails = result.TINNAME_RESULT.DMF_DETAILS;
                    nameResponse.TINNameCode = result.TINNAME_RESULT.TINNAME_CODE;
                    nameResponse.TINNameDetails = result.TINNAME_RESULT.TINNAME_DETAILS;
                    
                    var addressResponse = new AddressResponse();
                    addressResponse.AddressCode = result.ADDRESS_RESULT.ADDRESS_CODE;
                    addressResponse.AddressDetails = result.ADDRESS_RESULT.ADDRESS_DETAILS;

                    response.AddressResponse = addressResponse;
                    response.NameResponse = nameResponse;
                }
            }
            catch (Exception ex)
            {
                //TODO
            }

            return response;
        }
    }
}
