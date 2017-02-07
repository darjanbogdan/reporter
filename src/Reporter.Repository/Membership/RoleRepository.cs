using AutoMapper;
using Microsoft.AspNet.Identity;
using Reporter.DAL.Models.Identity;
using Reporter.Model;
using Reporter.Repository.Membership.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Membership
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;
        private readonly IMapper mapper;

        public RoleRepository(DbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Role>> FindAsync()
        {
            var roles = await this.context.Set<ApplicationRole>().ToListAsync();

            return this.mapper.Map<List<Role>>(roles);
        }
    }
}