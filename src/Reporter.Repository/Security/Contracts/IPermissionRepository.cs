using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security.Contracts
{
    public interface IPermissionRepository
    {
        Task DeleteAsync(Guid entityId);

        Task<IList<Permission>> GetAllAsync();

        Task<Permission> GetAsync(Guid entityId);

        Task<IEnumerable<Permission>> FindAsync();

        Task InsertAsync(Permission entity);

        Task UpdateAsync(Permission entity);
    }
}
