using AutoMapper;
using Reporter.Core.Command;
using Reporter.Model;
using Reporter.Repository.Clients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.CreateClient
{
    public class CreateClientCommandHandler : ICommandHandler<CreateClientCommand>
    {
        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
        }

        public Task ExecuteAsync(CreateClientCommand command)
        {
            var client = this.mapper.Map<Client>(command);

            //TODO: extract into base class or dedicated service -> should be on this layer, to avoid fetch from repository due to (at this time) unkown Id
            client.Id = Guid.NewGuid();
            client.DateCreated = DateTime.UtcNow;
            client.DateUpdated = DateTime.UtcNow;

            return this.clientRepository.InsertAsync(client);
        }
    }
}
