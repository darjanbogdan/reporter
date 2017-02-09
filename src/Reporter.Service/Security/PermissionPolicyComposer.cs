using Reporter.Service.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Model;
using Reporter.Service.Membership.Lookups;
using Reporter.Service.Security.Lookups.Contracts;
using Reporter.Core.Command.Authorization;
using Reporter.Core.Context;
using Reporter.Service.Infrastructure.Lookups;

namespace Reporter.Service.Security
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

        public async Task<IEnumerable<PermissionPolicy>> ComposeAsync(IAuthorizationCommand command)
        {
            List<PermissionPolicy> permissionPolicies = new List<PermissionPolicy>();

            var userPermissionPolicy = await GetUserPermissionPolicyAsync(command);
            permissionPolicies.Add(userPermissionPolicy);

            var rolePermissionPolicies = await GetRolePermissionPoliciesAsync(command);
            permissionPolicies.AddRange(rolePermissionPolicies);

            return permissionPolicies;
        }

        private async Task<PermissionPolicy> GetUserPermissionPolicyAsync(IAuthorizationCommand command)
        {
            return new PermissionPolicy()
            {
                UserId = this.applicationContext.UserInfo.UserId,
                PermissionId = (await this.permissionLookup.GetAsync(command.Permission)).Id,
                PermissionSectionId = (await this.permissionSectionLookup.GetAsync(command.PermissionSection)).Id
            };
        }

        private async Task<IEnumerable<PermissionPolicy>> GetRolePermissionPoliciesAsync(IAuthorizationCommand command)
        {
            List<PermissionPolicy> permissionPolicies = new List<PermissionPolicy>();
            foreach (var role in this.applicationContext.UserInfo.Roles)
            {
                permissionPolicies.Add(new PermissionPolicy()
                {
                    RoleId = (await this.roleLookup.GetAsync(role)).Id,
                    PermissionId = (await this.permissionLookup.GetAsync(command.Permission)).Id,
                    PermissionSectionId = (await this.permissionSectionLookup.GetAsync(command.PermissionSection)).Id
                });
            }
            return permissionPolicies;
        }
    }
}
