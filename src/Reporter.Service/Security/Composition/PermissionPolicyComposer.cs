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
using Reporter.Service.Security.Composition.Contracts;

namespace Reporter.Service.Security.Compositon
{
    public class PermissionPolicyComposer : IPermissionPolicyComposer
    {
        private readonly IApplicationContext applicationContext;
        private readonly IResourceLookup<Role> roleLookup;
        private readonly IPermissionLookup permissionLookup;
        private readonly IPermissionSectionLookup permissionSectionLookup;

        public PermissionPolicyComposer(IApplicationContext applicationContext, IResourceLookup<Role> roleLookup, IPermissionLookup permissionLookup, IPermissionSectionLookup permissionSectionLookup)
        {
            this.applicationContext = applicationContext;
            this.roleLookup = roleLookup;
            this.permissionLookup = permissionLookup;
            this.permissionSectionLookup = permissionSectionLookup;
        }

        public async Task<IEnumerable<PermissionPolicy>> ComposeAsync(IAuthorize commandToAuthorize)
        {
            List<PermissionPolicy> permissionPolicies = new List<PermissionPolicy>();

            var userPermissionPolicy = await GetUserPermissionPolicyAsync(commandToAuthorize);
            permissionPolicies.Add(userPermissionPolicy);

            var rolePermissionPolicies = await GetRolePermissionPoliciesAsync(commandToAuthorize);
            permissionPolicies.AddRange(rolePermissionPolicies);

            return permissionPolicies;
        }

        private async Task<PermissionPolicy> GetUserPermissionPolicyAsync(IAuthorize commandToAuthorize)
        {
            //TODO: Exception handling?

            return new PermissionPolicy()
            {
                UserId = this.applicationContext.UserInfo.UserId,
                PermissionId = (await this.permissionLookup.GetAsync(commandToAuthorize.Permission)).Id,
                PermissionSectionId = (await this.permissionSectionLookup.GetAsync(commandToAuthorize.PermissionSection)).Id
            };
        }

        private async Task<IEnumerable<PermissionPolicy>> GetRolePermissionPoliciesAsync(IAuthorize commandToAuthorize)
        {
            //TODO: Exception handling

            List<PermissionPolicy> permissionPolicies = new List<PermissionPolicy>();
            foreach (var role in this.applicationContext.UserInfo.Roles)
            {
                permissionPolicies.Add(new PermissionPolicy()
                {
                    RoleId = (await this.roleLookup.GetAsync(role)).Id,
                    PermissionId = (await this.permissionLookup.GetAsync(commandToAuthorize.Permission)).Id,
                    PermissionSectionId = (await this.permissionSectionLookup.GetAsync(commandToAuthorize.PermissionSection)).Id
                });
            }
            return permissionPolicies;
        }
    }
}
