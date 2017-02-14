using Reporter.Model;
using Reporter.Repository.Security.Contracts;
using Reporter.Service.Security.Lookups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security.Lookups
{
    public class PermissionLookup : IPermissionLookup
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionLookup(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        //TODO: Cache
        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await this.permissionRepository.GetAllAsync();
        }

        public async Task<Permission> GetAsync(string abrv)
        {
            var permissions = await GetAllAsync();
            return permissions.FirstOrDefault(p => p.Abrv == abrv);
        }
    }
}