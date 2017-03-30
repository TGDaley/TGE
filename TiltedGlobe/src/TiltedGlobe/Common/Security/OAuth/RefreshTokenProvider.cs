using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Infrastructure;

namespace TiltedGlobe.Common.Security.OAuth
{
	public class RefreshTokenProvider : IAuthenticationTokenProvider
	{
		public void Create(AuthenticationTokenCreateContext context)
		{
			throw new NotImplementedException();
		}

		public async Task CreateAsync(AuthenticationTokenCreateContext context)
		{
			var hashedToken = getHash(Guid.NewGuid().ToString());

			var userNameClaim = context.Ticket.Identity.FindFirst(ClaimTypes.Name);

			//using (var repo = new RefreshTokenRepository(new ApplicationDbContext()))
			//{
			//	int tokenExpireTime;

			//	if (!int.TryParse("", out tokenExpireTime))
			//	{
			//		tokenExpireTime = 12;
			//	}

			//	var token = new RefreshToken()
			//	{
			//		Id = hashedToken,
			//		ConsumingAppName = "webApp",
			//		UserName = userNameClaim.Value,
			//		IssuedUtc = DateTime.UtcNow,
			//		ExpiresUtc = DateTime.UtcNow.AddHours(tokenExpireTime)
			//	};

			//	context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
			//	context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

			//	if (!context.Ticket.Properties.Dictionary.ContainsKey("consumingAppName"))
			//	{
			//		context.Ticket.Properties.Dictionary.Add("consumingAppName", token.ConsumingAppName);
			//	}

			//	token.ProtectedTicket = context.SerializeTicket();

			//	var result = await repo.AddRefreshToken(token);

			//	if (result)
			//	{
			//		context.SetToken(hashedToken);
			//	}
			//}
		}

		public void Receive(AuthenticationTokenReceiveContext context)
		{
			throw new NotImplementedException();
		}

		public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
		{
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			var token = context.Token;

			//using (var repo = new RefreshTokenRepository(new ApplicationDbContext()))
			//{
			//	var refreshToken = await repo.FindRefreshToken(token);
			//	if (refreshToken != null)
			//	{
			//		context.DeserializeTicket(refreshToken.ProtectedTicket);

			//		await repo.RemoveRefreshToken(token);
			//	}
			//}
		}

		private string getHash(string input)
		{
			HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider();

			var byteValue = Encoding.UTF8.GetBytes(input);
			var byteHash = hashAlgorithm.ComputeHash(byteValue);

			return Convert.ToBase64String(byteHash);
		}
	}
}
