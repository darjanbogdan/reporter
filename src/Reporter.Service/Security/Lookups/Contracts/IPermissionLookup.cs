using Reporter.Model;
using Reporter.Service.Infrastructure.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security.Lookups.Contracts
{
    public interface IPermissionLookup : IResourceLookup<Permission>
    {
        //Task<Permission> GetCreatePermissionAsync();

        //Task<Permission> GetReadPermissionAsync();

        //Task<Permission> GetUpdatePermissionAsync();

        //Task<Permission> GetDeletePermissionAsync();

        //Task<Permission> GetFullPermissionAsync();
    }
}
