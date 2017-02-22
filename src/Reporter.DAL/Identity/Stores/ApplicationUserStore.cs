using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Identity.Stores
{
    public class ApplicationUserStore : UserStore<UserEntity, RoleEntity, Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }
}