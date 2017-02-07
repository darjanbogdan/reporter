using Reporter.Model;
using Reporter.Service.Infrastructure.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Lookups
{
    public interface IRoleLookup : IResourceLookup<Role>
    {
        Task<Role> GetUserRoleAsync();

        Task<Role> GetAdminRoleAsync();
    }
}