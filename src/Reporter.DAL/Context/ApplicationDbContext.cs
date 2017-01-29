using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}