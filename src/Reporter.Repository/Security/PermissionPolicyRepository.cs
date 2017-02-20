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

        public async Task<IEnumerable<PermissionPolicy>> FindAsync(PermissionPolicyFilter filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var query = this.context.Set<DAL.Models.PermissionPolicy>().AsQueryable();

            //TODO: Find a better way to handle slightly complex queries...
            //query = query.Where(pp => pp.PermissionId == filter.PermissionId && pp.PermissionSectionId == filter.PermissionSectionId);

            //if (filter.RoleIds?.Any() == true)
            //{
            //    query = query.Where(pp => pp.RoleId.HasValue && filter.RoleIds.Contains(pp.RoleId.Value));
            //}

            //if (filter.UserIds?.Any() == true)
            //{
            //    query = query.Where(pp => pp.UserId.HasValue && filter.UserIds.Contains(pp.UserId.Value));
            //}

            query = query.Where(pp => pp.PermissionId == filter.PermissionId && pp.PermissionSectionId == filter.PermissionSectionId
                && (
                    (pp.RoleId.HasValue && filter.RoleIds.Contains(pp.RoleId.Value))
                    ||
                    (pp.UserId.HasValue && filter.UserIds.Contains(pp.UserId.Value))
                ));

            var entities = await query.ToListAsync();
            return this.mapper.Map<List<PermissionPolicy>>(entities);
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

    public class PermissionPolicyFilter
    {
        public Guid PermissionSectionId { get; set; }

        public Guid PermissionId { get; set; }

        public IEnumerable<Guid> RoleIds { get; set; }

        public IEnumerable<Guid> UserIds { get; set; }
    }
}
