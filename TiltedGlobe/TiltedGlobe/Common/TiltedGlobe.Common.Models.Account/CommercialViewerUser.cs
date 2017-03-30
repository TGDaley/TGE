using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.Account
{
    [Serializable]
    public class CommercialViewerUser : IUser
    {
        #region IUser Members

        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string PasswordHash { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public int BadLoginCount { get; set; }
        
        [Required]
        public string EmailAddress { get; set; }

        public int StatusID { get; set; }
        public Address Address { get; set; }

        #endregion


        #region Commercial Viewer Specific Members
        
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Ein { get; set; }

        public BillingInfo BillingInfo { get; set; }

        #endregion
    }
}
