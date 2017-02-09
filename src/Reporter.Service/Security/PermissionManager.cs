using Reporter.Core.Command.Authorization;
using Reporter.Service.Security.Contracts;
using Reporter.Service.Security.Lookups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security
{
    public class PermissionManager<TCommand> : IPermissionManager<TCommand> where TCommand : IAuthorizationCommand
    {
        private readonly IPermissionPolicyComposer permissionPolicyComposer;

        public PermissionManager(IPermissionPolicyComposer permissionPolicyComposer)
        {
            this.permissionPolicyComposer = permissionPolicyComposer;
        }

        public async Task EvaluateAsync(TCommand command)
        {
            //TODO: think about composed permision policy: permissionid - permissionsectionid - userid - roleids
            var permissionPolicies = await this.permissionPolicyComposer.ComposeAsync(command);

            //TODO: check in repository
        }
    }
}
