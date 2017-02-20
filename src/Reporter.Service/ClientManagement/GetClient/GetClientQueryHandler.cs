using AutoMapper;
using Reporter.Core.Query;
using Reporter.Model;
using Reporter.Repository.Clients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.GetClient
{
    public class GetClientQueryHandler : IQueryHandler<GetClientQuery, Client>
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public GetClientQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<Client> RunAsync(GetClientQuery query)
        {
            var client = await this.clientRepository.GetAsync(query.ClientId);
            return this.mapper.Map<Client>(client);
        }
    }
}
