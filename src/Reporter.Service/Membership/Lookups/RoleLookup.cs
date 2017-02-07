using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Membership.Lookups
{
    public class RoleLookup : IRoleLookup
    {
        private readonly IRoleRepository roleRepository;

        public RoleLookup(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        //TODO: Implement caching
        public Task<IEnumerable<Role>> GetAllAsync()
        {
            return this.roleRepository.FindAsync();
        }

        public async Task<Role> GetAsync(string abrv)
        {
            var roles = await this.GetAllAsync();
            return roles.FirstOrDefault(r => r.Name == abrv);
        }

        public Task<Role> GetUserRoleAsync()
        {
            return GetAsync(RoleMap.User);
        }

        public Task<Role> GetAdminRoleAsync()
        {
            return GetAsync(RoleMap.Administrator);
        }

        
    }
}