using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL
{
    public interface IGenericRepository<TEntity>
    {
        Task DeleteAsync(Guid entityId);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Guid entityId);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}
