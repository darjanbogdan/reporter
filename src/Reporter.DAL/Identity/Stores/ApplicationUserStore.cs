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
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }
}