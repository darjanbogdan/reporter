using AutoMapper;
using Reporter.DAL;
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
    public class PermissionPolicyRepository : IPermissionPolicyRepository
    {
        private readonly DbContext context;
        private readonly IGenericRepository<DAL.Models.Permission> genericRepository;
        private readonly IMapper mapper;

        public PermissionPolicyRepository(DbContext context, IGenericRepository<DAL.Models.Permission> genericRepository, IMapper mapper)
        {
            this.context = context;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PermissionPolicy>> FindAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PermissionPolicy>> GetAllAsync()
        {
            var entites = await this.genericRepository.GetAllAsync();
            return this.mapper.Map<List<PermissionPolicy>>(entites);
        }

        public async Task<PermissionPolicy> GetAsync(Guid entityId)
        {
            var entity = await this.genericRepository.GetAsync(entityId);
            return this.mapper.Map<PermissionPolicy>(entity);
        }

        public Task InsertAsync(PermissionPolicy entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PermissionPolicy entity)
        {
            throw new NotImplementedException();
        }
    }
}
