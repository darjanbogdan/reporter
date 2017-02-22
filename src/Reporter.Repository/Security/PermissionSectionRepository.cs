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
    public class PermissionSectionRepository : IPermissionSectionRepository
    {
        private readonly DbContext context;
        private readonly IGenericRepository<PermissionSectionEntity> genericRepository;
        private readonly IMapper mapper;

        public PermissionSectionRepository(DbContext context, IGenericRepository<PermissionSectionEntity> genericRepository, IMapper mapper)
        {
            this.context = context;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PermissionSection>> FindAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PermissionSection>> GetAllAsync()
        {
            var entites = await this.genericRepository.GetAllAsync();
            return this.mapper.Map<List<PermissionSection>>(entites);
        }

        public async Task<PermissionSection> GetAsync(Guid entityId)
        {
            var entity = await this.genericRepository.GetAsync(entityId);
            return this.mapper.Map<PermissionSection>(entity);
        }

        public Task InsertAsync(PermissionSection entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PermissionSection entity)
        {
            throw new NotImplementedException();
        }
    }
}
