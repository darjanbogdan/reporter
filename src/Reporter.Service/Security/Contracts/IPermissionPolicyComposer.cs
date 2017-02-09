using Reporter.Core.Authorization;
using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security.Contracts
{
    public interface IPermissionPolicyComposer
    {
        Task<IEnumerable<PermissionPolicy>> ComposeAsync(IAuthorize command);
    }
}
