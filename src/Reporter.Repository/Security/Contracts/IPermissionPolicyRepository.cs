using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security.Contracts
{
    public interface IPermissionPolicyRepository
    {
        Task DeleteAsync(Guid entityId);

        Task<IList<PermissionPolicy>> GetAllAsync();

        Task<PermissionPolicy> GetAsync(Guid entityId);

        Task<IEnumerable<PermissionPolicy>> FindAsync();

        Task InsertAsync(PermissionPolicy entity);

        Task UpdateAsync(PermissionPolicy entity);
    }
}
