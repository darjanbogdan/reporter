using AutoMapper;
using Reporter.DAL;
using Reporter.DAL.Entities;
using Reporter.Model;
using Reporter.Repository.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Security
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DbContext context;
        private readonly IGenericRepository<PermissionEntity> genericRepository;
        private readonly IMapper mapper;

        public PermissionRepository(DbContext context, IGenericRepository<PermissionEntity> genericRepository, IMapper mapper)
        {
            this.context = context;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> FindAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Permission>> GetAllAsync()
        {
            var entites = await this.genericRepository.GetAllAsync();
            return this.mapper.Map<List<Permission>>(entites);
        }

        public async Task<Permission> GetAsync(Guid entityId)
        {
            var entity = await this.genericRepository.GetAsync(entityId);
            return this.mapper.Map<Permission>(entity);
        }

        public Task InsertAsync(Permission entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Permission entity)
        {
            throw new NotImplementedException();
        }
    }
}
