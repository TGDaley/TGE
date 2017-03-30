using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Queries.Account
{
    public class ProducerUser
    {
        #region Fields

        

        #endregion



        #region Select Queries

        //public static bool IsEmailInUse(string emailAddress)
        //{
        //    var result = false;
        //    return result;
        //    using (var db = new TiltedGlobe.Models.Account.Account())
        //    {
        //        result = db.users.Any(u => u.email == emailAddress);
        //    }

        //    return result;
        //}

        #endregion

        #region Private Methods

        private static string GenerateRandomPassword()
        {
            var password = GenerateRandomString();

            return TiltedGlobe.Utilities.Encryption.SHA.SHAEncryptString(password);
        }

        private static string GenerateRandomString()
        {
            var length = 16;
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXWYabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return result;
        }

        #endregion


    }
}
