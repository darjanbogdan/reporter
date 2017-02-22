using Reporter.Core.Auth;
using Reporter.Model;
using Reporter.Repository.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Security.Filtering.Contracts
{
    public interface IPermissionPolicyFilterFactory
    {
        Task<PermissionPolicyFilter> CreateAsync(IAuthorize command);
    }
}
