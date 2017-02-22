using Reporter.Repository.Clients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Model;
using Reporter.DAL;
using AutoMapper;
using System.Data.Entity;
using Reporter.DAL.Entities;

namespace Reporter.Repository.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbContext context;
        private readonly IGenericRepository<ClientEntity> genericRepository;
        private readonly IMapper mapper;

        public ClientRepository(DbContext context, IGenericRepository<ClientEntity> genericRepository, IMapper mapper)
        {
            this.context = context;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task DeleteAsync(Guid clientId)
        {
            return this.genericRepository.DeleteAsync(clientId);
        }

        public Task<IEnumerable<Client>> FindAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetAsync(Guid clientId)
        {
            var entity = await genericRepository.GetAsync(clientId);
            return this.mapper.Map<Client>(entity);
        }

        public async Task InsertAsync(Client client)
        {
            var entity = this.mapper.Map<ClientEntity>(client);
            this.context.Set<ClientEntity>().Add(entity);
            await this.context.SaveChangesAsync();
        }

        public Task UpdateAsync(Client client)
        {
            var entity = this.mapper.Map<ClientEntity>(client);
            return this.genericRepository.UpdateAsync(entity);
        }
    }
}
