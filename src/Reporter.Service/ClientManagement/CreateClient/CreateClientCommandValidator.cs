using FluentValidation;
using Reporter.Core.Command.Validation;
using Reporter.Service.Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>, ICommandValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(createClient => createClient.Name)
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(createClient => createClient.ManagerId)
                .NotEmpty().WithMessage("Value is required.");
        }

        public Task ValidateAsync(CreateClientCommand command)
        {
            if (command == null) throw new ValidatorException(nameof(command));

            var validationResult = this.Validate(command);
            if (!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult.Errors);
            }

            return Task.FromResult(true);
        }
    }
}
