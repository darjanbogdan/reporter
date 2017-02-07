using Reporter.Core.Command.Authorization;
using Reporter.Model;
using Reporter.Service.Membership.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security.Contracts
{
    public interface IPermissionPolicyResolver
    {
        Task<IEnumerable<PermissionPolicy>> ResolveAsync<TCommand>(TCommand command) where TCommand : IAuthorizationCommand;
    }
}
