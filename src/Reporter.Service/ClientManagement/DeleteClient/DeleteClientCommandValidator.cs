using Reporter.Core.Validation;
using Reporter.Repository.Clients.Contracts;
using Reporter.Service.Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.DeleteClient
{
    public class DeleteClientCommandValidator : IValidator<DeleteClientCommand>
    {
        private readonly IClientRepository clientRepository;

        public DeleteClientCommandValidator(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task ValidateAsync(DeleteClientCommand parameter)
        {
            var clientToDelete = await this.clientRepository.GetAsync(parameter.ClientId);
            if (clientToDelete == null)
            {
                throw new ValidatorException(nameof(clientToDelete));
            }
        }
    }
}
