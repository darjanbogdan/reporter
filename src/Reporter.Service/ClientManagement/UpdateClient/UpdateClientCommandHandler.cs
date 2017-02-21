using AutoMapper;
using Reporter.Core.Command;
using Reporter.Model;
using Reporter.Repository.Clients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.UpdateClient
{
    public class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
        }

        public Task ExecuteAsync(UpdateClientCommand command)
        {
            var client = this.mapper.Map<Client>(command);

            //TODO: relocate/extract
            client.DateUpdated = DateTime.UtcNow;

            return this.clientRepository.UpdateAsync(client);
        }
    }
}
