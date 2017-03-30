using System;
using System.Configuration;
using System.IO;
using System.Net;
using Akamai.EdgeGrid.Auth;

namespace TiltedGlobe.Services
{
    public class Akamai
    {
        public static string GetAllStreams()
        {
            /*
             * /config-media-live/v1/live/{domainName}/stream
             * /config-media-live/v1/live/{domainName}/stream/{streamID}
             */
            var accessToken = ConfigurationManager.AppSettings["akamaiAccessToken"];
            var clientToken = ConfigurationManager.AppSettings["akamaiClientToken"];
            var secret = ConfigurationManager.AppSettings["akamaiSecret"];
            var signer = new EdgeGridV1Signer();
            var credential = new ClientCredential(clientToken, accessToken, secret);
            var uri = new Uri(ConfigurationManager.AppSettings["akamaiBaseUrl"]);
            var request = WebRequest.Create(uri);
            signer.Sign(request, credential);
            using (var result = signer.Execute(request, credential))
            {
                using (result)
                {
                    using (var reader = new StreamReader(result))
                    {
                        return  reader.ReadToEnd();
                    }
                }
            }
        }
    }
}