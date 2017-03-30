using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TiltedGlobe.App;
using TiltedGlobe.App.User;
using TiltedGlobe.Common.Services;
using TiltedGlobe.Models;
using TiltedGlobe.Services;


namespace TiltedGlobe.Api
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController<ApplicationUser, ApplicationUser>
    {
	    public AccountsController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
	    {
	    }

	    [Route("users")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));

        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("users/isemailavailable", Name = "IsEmailAvailable")]
        [HttpGet]
        public async Task<IHttpActionResult> IsEmailAvailable(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);
            return Ok(new
            {
                IsAvailable = user == null
            });
        }

        [Route("user")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserByToken()
        {
            var user = await this.AppUserManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = createUserModel.Email,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                CompanyName = createUserModel.CompanyName,
                CompanyAddress = createUserModel.CompanyAddress,
                City = createUserModel.City,
                State = createUserModel.State,
                Country = createUserModel.Country,
                PostalCode = createUserModel.PostalCode,
                CompanyPhone = createUserModel.CompanyPhone
            };
            AppUserManager.UserValidator = new UserValidator<ApplicationUser>(AppUserManager){AllowOnlyAlphanumericUserNames = false,RequireUniqueEmail = true};
            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user);
            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }
            string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var callbackUrl = new StringBuilder();
            callbackUrl.Append(Request.RequestUri.Scheme);
            callbackUrl.Append("://");
            callbackUrl.Append(Request.RequestUri.Authority);
            callbackUrl.Append("/ConfirmEmail?userId=");
            callbackUrl.Append(user.Id);
            callbackUrl.Append("&code=");
            callbackUrl.Append(HttpUtility.UrlEncode(code));

            await
                this.AppUserManager.SendEmailAsync(user.Id, "Confirm your account",
                    "Please confirm your account by clicking " + callbackUrl);
            Uri locationHeader = new Uri(Url.Link("GetUserById", new {id = user.Id}));
            return Created(locationHeader, TheModelFactory.Create(user));
        }

        [Route("validatecaptcha")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult ValidateCaptcha(CaptchaValidator.Captcha captcha)
        {
            if (!CaptchaValidator.IsValid(captcha))
            {
                ModelState.AddModelError("Captcha", "Invalid Captcha");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPost]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ConfirmEmail(ConfirmSetPasswordModel confirmSetPasswordModel)
        {
            if (string.IsNullOrWhiteSpace(confirmSetPasswordModel.UserId) || string.IsNullOrWhiteSpace(confirmSetPasswordModel.Code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }
            if (confirmSetPasswordModel.Password != confirmSetPasswordModel.ConfirmPassword)
            {
                ModelState.AddModelError("", "Password and Confirm Password do not match.");
                return BadRequest(ModelState);
            }
            AppUserManager.UserValidator = new UserValidator<ApplicationUser>(AppUserManager) { AllowOnlyAlphanumericUserNames = false, RequireUniqueEmail = true };
            var result = await this.AppUserManager.ConfirmEmailAsync(confirmSetPasswordModel.UserId, confirmSetPasswordModel.Code);

            if (!result.Succeeded) return GetErrorResult(result);
            var resultPassword = await this.AppUserManager.AddPasswordAsync(confirmSetPasswordModel.UserId, confirmSetPasswordModel.Password);
            return resultPassword.Succeeded ? Redirect(Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority) : GetErrorResult(resultPassword);
        }

        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result =
                await
                    this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                        model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await this.AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }

        [Route("user/forgotpassword")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordModel username)
        {
            var user = await AppUserManager.FindByEmailAsync(username.UserName);
            if (user == null) return BadRequest("Invalid email address");
            var token = await AppUserManager.GeneratePasswordResetTokenAsync(user.Id);
            var callbackUrl = Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority +
                              "/ResetPassword?userId=" + user.Id + "&code=" + HttpUtility.UrlEncode(token);
            await
                AppUserManager.SendEmailAsync(user.Id, "Password Reset",
                    "Please reset your password by clicking " + callbackUrl);
            return Ok();
        }

        [Route("user/resetpassword")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ResetPassword(ResetPasswordModel resetModel)
        {
            AppUserManager.UserValidator = new UserValidator<ApplicationUser>(AppUserManager) { AllowOnlyAlphanumericUserNames = false, RequireUniqueEmail = true };
            var result =
                await AppUserManager.ResetPasswordAsync(resetModel.UserId, resetModel.Token, resetModel.Password);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }


        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("",
                    string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult =
                await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }

     

        protected override System.Collections.Generic.List<ApplicationUser> Entities
        {
            get { throw new NotImplementedException(); }
        }

        protected override IEnumerable<ApplicationUser> Save(IEnumerable<ApplicationUser> model)
        {
            throw new NotImplementedException();
        }
    }
}