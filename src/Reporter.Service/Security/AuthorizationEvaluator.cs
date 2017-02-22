using Reporter.Core.Auth;
using Reporter.Core.Context;
using Reporter.Model;
using Reporter.Repository.Security;
using Reporter.Repository.Security.Contracts;
using Reporter.Service.Security.Filtering.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security
{
    public class AuthorizationEvaluator : IAuthorizationEvaluator
    {
        private readonly IApplicationContext applicationContext;
        private readonly IPermissionPolicyFilterFactory permissionPolicyComposer;
        private readonly IPermissionPolicyRepository permissionPolicyRepository;

        public AuthorizationEvaluator(
              IApplicationContext applicationContext, 
            IPermissionPolicyFilterFactory permissionPolicyComposer, 
            IPermissionPolicyRepository permissionPolicyRepository)
        {
            this.applicationContext = applicationContext;
            this.permissionPolicyComposer = permissionPolicyComposer;
            this.permissionPolicyRepository = permissionPolicyRepository;
        }

        public async Task EvaluateAsync(IAuthorize command)
        {
            //TODO: create validation decorator - authorize args...

            //owner
            var isValid = this.applicationContext.UserInfo.UserId.Equals(command.OwnerId.GetValueOrDefault());

            //policies
            if (!isValid)
            {
                var filter = await this.permissionPolicyComposer.CreateAsync(command);

                var policies = await this.permissionPolicyRepository.FindAsync(filter);
                if (policies == null || !policies.Any())
                {
                    throw new UnauthorizedAccessException("authorization...");
                }
            }
        }
    }
}
