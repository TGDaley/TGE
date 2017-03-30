using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TiltedGlobe.Common.Models.Account;
using TiltedGlobe.Common.Models.ThirdParty.TINCheck;

namespace TiltedGlobe.api.Account
{
    public class ProducerRegistrationController : ApiController
    {
        private bool TINCheck(ProducerUser pUser)
        {
            //TODO Actually do it w/ valid creds
            return true;

            var tinResponse = TiltedGlobe.ThirdParty.TINCheck.TINChecker.CheckTIN(pUser);

            return tinResponse.NameResponse.DMFCode == (int)NameResponse.DMFCodeEnum.NoDMFRecordFound &&
                    tinResponse.AddressResponse.AddressCode == (int)AddressResponse.AddressResponseEnum.USPSMatchFound &&
                    (
                        tinResponse.NameResponse.TINNameCode == (int)NameResponse.TINNameCodeEnum.CombinationMatchesIRSRecords ||
                        tinResponse.NameResponse.TINNameCode == (int)NameResponse.TINNameCodeEnum.CombinationMatchesEINRecords ||
                        tinResponse.NameResponse.TINNameCode == (int)NameResponse.TINNameCodeEnum.CombinationMatchesSSNandEINRecords ||
                        tinResponse.NameResponse.TINNameCode == (int)NameResponse.TINNameCodeEnum.CombinationMatchesSSNRecords
                    );
        }


    }
}