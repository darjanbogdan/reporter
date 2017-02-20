using FluentValidation;
using Reporter.Service.Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.GetClient
{
    public class GetClientQueryValidator : AbstractValidator<GetClientQuery>, Core.Validation.IValidator<GetClientQuery>
    {
        public GetClientQueryValidator()
        {
            RuleFor(getClient => getClient.ClientId)
                .NotEmpty().WithMessage("Value is required.");
        }

        public Task ValidateAsync(GetClientQuery parameter)
        {
            if (parameter == null) throw new ValidatorException(nameof(parameter));

            var validatorResult = this.Validate(parameter);
            if (!validatorResult.IsValid)
            {
                throw new ValidatorException(validatorResult.Errors);
            }

            return Task.FromResult(true);
        }
    }
}
