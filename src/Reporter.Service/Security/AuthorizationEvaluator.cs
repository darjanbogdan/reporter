using Reporter.Core.Authorization;
using Reporter.Core.Command.Authorization;
using Reporter.Repository.Security;
using Reporter.Repository.Security.Contracts;
using Reporter.Service.Security.Composition.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security
{
    public class AuthorizationEvaluator : IAuthorizationEvaluator
    {
        private readonly IPermissionPolicyComposer permissionPolicyComposer;
        private readonly IPermissionPolicyRepository permissionPolicyRepository;

        public AuthorizationEvaluator(IPermissionPolicyComposer permissionPolicyComposer, IPermissionPolicyRepository permissionPolicyRepository)
        {
            this.permissionPolicyComposer = permissionPolicyComposer;
            this.permissionPolicyRepository = permissionPolicyRepository;
        }

        public async Task EvaluateAsync(IAuthorize commandToAuthorize)
        {
            //TODO: create validation decorator

            //TODO: think about composed permision policy: permissionid - permissionsectionid - userid - roleids
            //Maybe filter factory will be more suitable
            var permissionPolicies = await this.permissionPolicyComposer.ComposeAsync(commandToAuthorize);

            var filter = new PermissionPolicyFilter();
            filter.RoleIds = permissionPolicies.Where(p => p.RoleId.HasValue).Select(p => p.RoleId.Value);
            filter.UserIds = permissionPolicies.Where(p => p.UserId.HasValue).Select(p => p.UserId.Value);
            filter.PermissionId = permissionPolicies.FirstOrDefault().PermissionId;
            filter.PermissionSectionId = permissionPolicies.FirstOrDefault().PermissionSectionId;

            var policies = await this.permissionPolicyRepository.FindAsync(filter);
            if (policies == null || !policies.Any())
            {
                throw new UnauthorizedAccessException("authorization...");
            }
        }
    }
}
