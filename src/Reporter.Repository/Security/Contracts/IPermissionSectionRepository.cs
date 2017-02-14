using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security.Contracts
{
    public interface IPermissionSectionRepository
    {
        Task DeleteAsync(Guid entityId);

        Task<IList<PermissionSection>> GetAllAsync();

        Task<PermissionSection> GetAsync(Guid entityId);

        Task<IEnumerable<PermissionSection>> FindAsync();

        Task InsertAsync(PermissionSection entity);

        Task UpdateAsync(PermissionSection entity);
    }
}
