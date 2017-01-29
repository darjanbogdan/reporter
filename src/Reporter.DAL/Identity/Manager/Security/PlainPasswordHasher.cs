using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Identity.Manager.Security
{
    public class PlainPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword.Equals(providedPassword))
                return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }
    }
}