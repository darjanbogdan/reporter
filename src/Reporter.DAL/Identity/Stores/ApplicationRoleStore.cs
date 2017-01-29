using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Identity.Stores
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, Guid, ApplicationUserRole>
    {
        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}