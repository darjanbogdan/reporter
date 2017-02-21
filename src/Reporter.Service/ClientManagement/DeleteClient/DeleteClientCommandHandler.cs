using Reporter.Core.Command;
using Reporter.Repository.Clients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.DeleteClient
{
    public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand>
    {
        private readonly IClientRepository clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Task ExecuteAsync(DeleteClientCommand command)
        {
            return this.clientRepository.DeleteAsync(command.ClientId);
        }
    }
}
