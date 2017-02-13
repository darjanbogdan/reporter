using Reporter.Model;
using Reporter.Repository.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security
{
    public class PermissionSectionRepository : IPermissionSectionRepository
    {
        public Task<IEnumerable<PermissionSection>> FindAsync()
        {
            throw new NotImplementedException();
        }
    }
}
