using TiltedGlobe.Services;

namespace TiltedGlobe.Models
{
    public class CreateUserBindingModel
    {
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string CompanyPhone { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

    }

    public class ResetPasswordModel
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }
    }

    public class ForgotPasswordModel
    {
        public string UserName { get; set; }
    }
    public class ConfirmSetPasswordModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}