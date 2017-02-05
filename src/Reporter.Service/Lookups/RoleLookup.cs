using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Lookups
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
            return this.roleRepository.GetAllAsync();
        }

        public async Task<Role> GetUserRoleAsync()
        {
            var roles = await this.GetAllAsync();
            return roles.FirstOrDefault(r => r.Name == "User");
        }

        public async Task<Role> GetAdminRoleAsync()
        {
            var roles = await this.GetAllAsync();
            return roles.FirstOrDefault(r => r.Name == "Administrator");
        }
    }
}