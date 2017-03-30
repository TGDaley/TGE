using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TiltedGlobe.Api
{
    public class AwsController : ApiController
    {
        public IHttpActionResult Get(string awsKey)
        {
            var config = new AwsConfig(awsKey);
            return Ok(config);
        }
    }

    public class AwsConfig
    {
        public string Policy { get; set; }
        public string Signature { get; set; }

        public AwsConfig(string awsKey)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var policyBytes =
                System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new AwsPolicy(awsKey),
                    Formatting.None, settings));
            Policy = Convert.ToBase64String(policyBytes);
            var policyBase64Bytes =
                System.Text.Encoding.UTF8.GetBytes(Convert.ToBase64String(policyBytes));
            var hmac = new HMACSHA1(System.Text.Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["awsSecretKey"]));
            using (var cryptoStream = new CryptoStream(Stream.Null, hmac, CryptoStreamMode.Write))
            {
                cryptoStream.Write(policyBase64Bytes, 0, policyBase64Bytes.Length);
                cryptoStream.Close();
            }
            Signature = Convert.ToBase64String(hmac.Hash);
        }
    }

    public class AwsPolicy
    {
        private string _awsKey;
        public AwsPolicy(string awsKey)
        {
            _awsKey = awsKey;
        }
        public string Expiration {
            get { return DateTime.UtcNow.AddMinutes(1).ToString("yyyy-MM-ddTHH:mm:ssZ"); }
        }

        public List<object> Conditions
        {
            get
            {
                return  new List<object>
                {
                    new Dictionary<string, string> {{"bucket", "surge-tiltedglobe"}},
                    new List<string> {"starts-with", "$key", _awsKey},
                    new Dictionary<string, string> {{"acl", "public-read"}},
                    new Dictionary<string, string> {{"success_action_status", "201"}},
                    new List<string> {"starts-with", "$Content-Type", ""},
                    new List<object> {"content-length-range", 0,int.Parse(ConfigurationManager.AppSettings["awsFileSizeLimit"])}
                };
            }
        }

    }
}
