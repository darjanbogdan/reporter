using FluentValidation;
using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Threading;

namespace Reporter.Service.Membership.Registration
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>, ICommandValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(registerUser => registerUser.UserName).NotEmpty().WithMessage("{PropertyName}: {0}", registerUser => "Value is required.");

            RuleFor(registerUser => registerUser.Email).NotEmpty().WithMessage("{PropertyName}: {0}", registerUser => "Value is required.");

            RuleFor(registerUser => registerUser.FirstName).NotEmpty().WithMessage("{PropertyName}: {0}", registerUser => "Value is required.");

            RuleFor(registerUser => registerUser.LastName).NotEmpty().WithMessage("{PropertyName}: {0}", registerUser => "Value is required.");

            RuleFor(registerUser => registerUser.Password).NotEmpty().WithMessage("{PropertyName}: {0}", registerUser => "Value is required.");

            RuleFor(registerUser => registerUser.ConfirmPassword).NotEmpty().WithMessage("{PropertyName}: {0}", registerUser => "Value is required.");
        }

        public Task ValidateAsync(RegisterUserCommand command)
        {
            if (command == null) throw new ArgumentNullException("registerUser");

            this.Validate(command);

            return Task.FromResult(true);
        }


    }
}
