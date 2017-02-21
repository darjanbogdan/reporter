using FluentValidation;
using Reporter.Repository.Clients.Contracts;
using Reporter.Service.Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>, Core.Validation.IValidator<UpdateClientCommand>
    {
        private readonly IClientRepository clientRepository;

        public UpdateClientCommandValidator(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;

            RuleFor(updateClient => updateClient.Name)
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(updateClient => updateClient.ManagerId)
                .NotEmpty().WithMessage("Value is required.");
        }

        public async Task ValidateAsync(UpdateClientCommand parameter)
        {
            //No need for this check, parameter will always be != null
            //if (parameter == null) throw new ValidatorException(nameof(parameter));

            var clientToUpdate = await this.clientRepository.GetAsync(parameter.Id);
            if (clientToUpdate == null)
            {
                //TODO: extract into specific decorator(overkill?). Change Exception type -> needs to be mapped into 404
                throw new ValidatorException(nameof(clientToUpdate));
            }

            var validationResult = this.Validate(parameter);
            if (!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult.Errors);
            }
        }
    }
}
