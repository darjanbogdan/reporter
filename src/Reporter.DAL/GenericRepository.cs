using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public Task DeleteAsync(Guid entityId)
        {
            TEntity entity = new TEntity();
            entity.Id = entityId;
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Deleted;
            return this.context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().AsNoTracking().Where(p => p != null).ToListAsync();
        }

        public Task<TEntity> GetAsync(Guid entityId)
        {
            return this.context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == entityId);
        }

        public Task InsertAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            return this.context.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;
            this.context.Entry<TEntity>(entity).Property(x => x.DateCreated).IsModified = false;
            return this.context.SaveChangesAsync();
        }
    }
}
