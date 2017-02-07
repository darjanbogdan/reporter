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

namespace Reporter.Service.Security
{
    public class PermissionPolicyResolver : IPermissionPolicyResolver
    {
        private readonly IApplicationContext applicationContext;
        private readonly IRoleLookup roleLookup;
        private readonly IPermissionLookup permissionLookup;
        private readonly IPermissionSectionLookup permissionSectionLookup;

        public PermissionPolicyResolver(IApplicationContext applicationContext, IRoleLookup roleLookup, IPermissionLookup permissionLookup, IPermissionSectionLookup permissionSectionLookup)
        {
            this.applicationContext = applicationContext;
            this.roleLookup = roleLookup;
            this.permissionLookup = permissionLookup;
            this.permissionSectionLookup = permissionSectionLookup;
        }

        public async Task<IEnumerable<PermissionPolicy>> ResolveAsync<TCommand>(TCommand command) where TCommand : IAuthorizationCommand
        {
            List<PermissionPolicy> permissionPolicies = new List<PermissionPolicy>();

            var userPermissionPolicy = await GetUserPermissionPolicyAsync(command);
            permissionPolicies.Add(userPermissionPolicy);

            var rolePermissionPolicies = await GetRolePermissionPoliciesAsync(command);
            permissionPolicies.AddRange(rolePermissionPolicies);

            return permissionPolicies;
        }

        private async Task<PermissionPolicy> GetUserPermissionPolicyAsync<TCommand>(TCommand command) where TCommand : IAuthorizationCommand
        {
            return new PermissionPolicy()
            {
                UserId = this.applicationContext.UserInfo.UserId,
                PermissionId = (await this.permissionLookup.GetAsync(command.Permission)).Id,
                PermissionSectionId = (await this.permissionSectionLookup.GetAsync(command.PermissionSection)).Id
            };
        }

        private async Task<IEnumerable<PermissionPolicy>> GetRolePermissionPoliciesAsync<TCommand>(TCommand command) where TCommand : IAuthorizationCommand
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
