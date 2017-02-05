using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Lookups
{
    public interface IRoleLookup : ILookup<Role>
    {
        Task<Role> GetUserRoleAsync();

        Task<Role> GetAdminRoleAsync();
    }
}