using System;
using System.IO;
using System.Net;

namespace TiltedGlobe.Services
{
		//public class CaptchaValidator
		//{
		//		private const string PrivateKey = "6LcWbQUTAAAAAKc3yJoddEzrsTtf-lV0fe9ZHU6A";
		//		private const string VerifyApi = "https://www.google.com/recaptcha/api/verify";
		//		private const string RemoteIp = "127.0.0.1";
		//		public static bool IsValid(Captcha captcha)
		//		{
		//				var postParams = string.Format("privatekey={0}&remoteip={1}&challenge={2}&response={3}", PrivateKey,
		//RemoteIp, captcha.Challenge, captcha.Response);
		//				var request = (HttpWebRequest)WebRequest.Create(new Uri(VerifyApi));
		//				request.Accept = "application/json";
		//				request.ContentType = "application/x-www-form-urlencoded";
		//				request.Method = "POST";
		//				request.ContentLength = postParams.Length;
		//				using (var stream = new StreamWriter(request.GetRequestStream()))
		//				{
		//						stream.Write(postParams);
		//						stream.Close();
		//				}
		//				var webResponse = request.GetResponse();
		//				using (var responseStream = webResponse.GetResponseStream())
		//				{
		//						if (responseStream == null) return false;
		//						var sr = new StreamReader(responseStream);
		//						var content = sr.ReadToEnd();
		//						var contentResponse = content.Split('\n');
		//						responseStream.Close();
		//						return contentResponse.Length > 0 && contentResponse[0] == "true" && contentResponse[1] == "success";
		//				}
		//		}

		//		public class Captcha
		//		{
		//				public string Challenge { get; set; }

		//				public string Response { get; set; }
		//		}
		//}
}