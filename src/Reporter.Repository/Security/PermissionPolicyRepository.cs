using Reporter.Model;
using Reporter.Repository.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security
{
    public class PermissionPolicyRepository : IPermissionPolicyRepository
    {
        public Task<IEnumerable<PermissionPolicy>> FindAsync()
        {
            throw new NotImplementedException();
        }
    }
}
