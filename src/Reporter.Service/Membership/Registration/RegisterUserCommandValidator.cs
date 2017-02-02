using FluentValidation;
using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Threading;
using System.Collections;

namespace Reporter.Service.Membership.Registration
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>, ICommandValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(registerUser => registerUser.UserName).NotEmpty().WithMessage("Value is required.");

            RuleFor(registerUser => registerUser.Email).NotEmpty().WithMessage("Value is required.");

            RuleFor(registerUser => registerUser.FirstName).NotEmpty().WithMessage( "Value is required.");

            RuleFor(registerUser => registerUser.LastName).NotEmpty().WithMessage("Value is required.");

            RuleFor(registerUser => registerUser.Password).NotEmpty().WithMessage("Value is required.");

            RuleFor(registerUser => registerUser.ConfirmPassword).NotEmpty().WithMessage("Value is required.");
        }

        public Task ValidateAsync(RegisterUserCommand command)
        {
            if (command == null) throw ValidationExceptionFactory.Create<ArgumentNullException>();

            var validationResult = this.Validate(command);
            if (!validationResult.IsValid)
            {
                validationResult.RaiseFormattedException();
            }

            return Task.FromResult(true);
        }


    }
}
