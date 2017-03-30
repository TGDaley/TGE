using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    public interface IUser
    {
        int UserID { get; set; }
        int UserTypeID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PasswordHash { get; set; }
        DateTime? LastLoginDateTime { get; set; }
        int BadLoginCount { get; set; }
        string EmailAddress { get; set; }
        int StatusID { get; set; }
        Address Address { get; set; }
        string Ein { get; set; }
    }
}
