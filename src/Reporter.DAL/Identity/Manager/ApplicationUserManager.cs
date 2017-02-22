using Microsoft.AspNet.Identity;
using Reporter.DAL.Identity.Manager.Security;
using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Identity.Manager
{
    public class ApplicationUserManager : UserManager<UserEntity, Guid>
    {
        public ApplicationUserManager(IUserStore<UserEntity, Guid> store)
            : base(store)
        {
            this.UserValidator = new UserValidator<UserEntity, Guid>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            this.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6
            };

            this.PasswordHasher = new PlainPasswordHasher();
        }
    }
}