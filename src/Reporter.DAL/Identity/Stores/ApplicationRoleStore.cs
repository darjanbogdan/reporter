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
    public class ApplicationRoleStore : RoleStore<RoleEntity, Guid, UserRoleEntity>
    {
        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}