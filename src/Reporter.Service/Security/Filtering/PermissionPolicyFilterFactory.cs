using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Model;
using Reporter.Service.Membership.Lookups;
using Reporter.Service.Security.Lookups.Contracts;
using Reporter.Core.Context;
using Reporter.Service.Infrastructure.Lookups;
using Reporter.Core.Auth;
using Reporter.Service.Security.Filtering.Contracts;
using Reporter.Repository.Security;

namespace Reporter.Service.Security.Filtering
{
    public class PermissionPolicyFilterFactory : IPermissionPolicyFilterFactory
    {
        private readonly IApplicationContext applicationContext;
        private readonly IResourceLookup<Role> roleLookup;
        private readonly IResourceLookup<Permission> permissionLookup;
        private readonly IResourceLookup<PermissionSection> permissionSectionLookup;

        public PermissionPolicyFilterFactory(
            IApplicationContext applicationContext, 
            IResourceLookup<Role> roleLookup,
            IResourceLookup<Permission> permissionLookup, 
            IResourceLookup<PermissionSection> permissionSectionLookup)
        {
            this.applicationContext = applicationContext;
            this.roleLookup = roleLookup;
            this.permissionLookup = permissionLookup;
            this.permissionSectionLookup = permissionSectionLookup;
        }

        public async Task<PermissionPolicyFilter> CreateAsync(IAuthorize command)
        {
            PermissionPolicyFilter filter = new PermissionPolicyFilter();
            filter.PermissionId = (await this.permissionLookup.GetAsync(command.Permission)).Id;
            filter.PermissionSectionId = (await this.permissionSectionLookup.GetAsync(command.PermissionSection)).Id;
            filter.UserId = this.applicationContext.UserInfo.UserId;

            var roleIds = new List<Guid>();
            foreach (var role in this.applicationContext.UserInfo.Roles)
            {
                var roleId = (await this.roleLookup.GetAsync(role)).Id;
                roleIds.Add(roleId);
            }
            filter.RoleIds = roleIds;

            return filter;
        }
    }
}
