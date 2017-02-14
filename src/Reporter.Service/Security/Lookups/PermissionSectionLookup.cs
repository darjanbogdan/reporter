using Reporter.Service.Security.Lookups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Model;
using Reporter.Repository.Security.Contracts;

namespace Reporter.Service.Security.Lookups
{
    public class PermissionSectionLookup : IPermissionSectionLookup
    {
        private readonly IPermissionSectionRepository permissionSectionRepository;

        public PermissionSectionLookup(IPermissionSectionRepository permissionSectionRepository)
        {
            this.permissionSectionRepository = permissionSectionRepository;
        }

        //TODO: Cache
        public async Task<IEnumerable<PermissionSection>> GetAllAsync()
        {
            return await this.permissionSectionRepository.GetAllAsync();
        }

        public async Task<PermissionSection> GetAsync(string abrv)
        {
            var permissionSections = await GetAllAsync();
            return permissionSections.FirstOrDefault(ps => ps.Abrv == abrv);
        }
    }
}