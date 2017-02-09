using Reporter.Core.Authorization;
using Reporter.Core.Command.Authorization;
using Reporter.Repository.Security.Contracts;
using Reporter.Service.Security.Contracts;
using Reporter.Service.Security.Lookups.Contracts;
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
            //TODO: think about composed permision policy: permissionid - permissionsectionid - userid - roleids
            var permissionPolicies = await this.permissionPolicyComposer.ComposeAsync(commandToAuthorize);

            //TODO: check in repository
        }
    }
}
