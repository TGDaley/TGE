using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fulcrum.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using TiltedGlobe.App;
using TiltedGlobe.App.User;

namespace TiltedGlobe.Common.Security.OAuth
{
	public class AuthorizationServerProvider : OAuthAuthorizationServerProvider, ILoggingSource
	{
		private readonly Claim _defaultClaim = new Claim("MyProfile", "Read");

		public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
		{
			using (var repo = new ApplicationUserManager(new UserStore<ApplicationUser>()))
			{
				var user = repo.Users.SingleOrDefault(u => u.UserName == context.Ticket.Identity.Name);

				if (user == null)
				{
					// unlikely, but it's possible the account has been deleted
					context.SetError("invalid_grant", "Account does not exist.");

					return;
				}


				context.Validated();
				this.LogInfo("Successfully refreshed {0}'s auth token.", user.UserName);
			}
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			// all connections from mobile devices as well as web apps
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			var identity = new ClaimsIdentity(context.Options.AuthenticationType);

			var skipClaims = false;

			using (var repo = new ApplicationUserManager(new UserStore<ApplicationUser>()))
			using (var db = new ApplicationDbContext())
			{
				var identityUser = repo.Users.SingleOrDefault(u => u.UserName == context.Ticket.Identity.Name);

				var potentialId = "";

				if (identityUser != null)
				{
					potentialId = identityUser.Id;
				}
				
				this.LogInfo("Testing password.");

				var query = (from dbUser in db.Users
										 where dbUser.Id == potentialId
					select dbUser);

				var user = query.SingleOrDefault();

				if (user == null)
				{
					context.SetError("invalid_grant", "User name or password is incorrect.");

					repo.AccessFailed(user.Id);

					return;
				}

				if (!user.LockoutEnabled)
				{
					context.SetError("invalid_grant", "Account is disabled.");

					return;
				}

				identity.AddClaim(_defaultClaim);
				identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
				identity.AddClaim(new Claim("FirstName", user.FirstName));
				identity.AddClaim(new Claim("LastName", user.LastName));
				identity.AddClaim(new Claim("SessionLogId", Guid.NewGuid().ToString()));

				foreach (var claim in user.Claims)
				{
					identity.AddClaim(new Claim(claim.ClaimType, claim.ClaimValue));
				}

				if (user.LockoutEnabled)
				{
					await repo.ResetAccessFailedCountAsync(user.Id);
				}
			}

			this.LogInfo("Successfully authenticated {0}.", identity.Name);

			context.Validated(identity);
		}

		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			// TODO: ensure that client id is valid, etc

			context.Validated();
		}
	}
}
