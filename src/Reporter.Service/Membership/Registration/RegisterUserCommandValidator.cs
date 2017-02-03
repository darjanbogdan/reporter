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
using Reporter.Service.Infrastructure.Validator;

namespace Reporter.Service.Membership.Registration
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>, ICommandValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(registerUser => registerUser.UserName)
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(registerUser => registerUser.Email)
                .NotEmpty().WithMessage("Value is required.")
                .EmailAddress().WithMessage("Value has wrong format.")
                .Length(3, 256).WithMessage("Value is out of range.");

            RuleFor(registerUser => registerUser.FirstName)
                .NotEmpty().WithMessage( "Value is required.")
                .Length(1, 100).WithMessage("Value is out of range.");

            RuleFor(registerUser => registerUser.LastName)
                .NotEmpty().WithMessage("Value is required.")
                .Length(1, 100).WithMessage("Value is out of range.");

            RuleFor(registerUser => registerUser.Password)
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(registerUser => registerUser.ConfirmPassword)
                .NotEmpty().WithMessage("Value is required.")
                .Must((model, field) =>
                {
                    return field == model.Password;
                }).WithMessage("Confirm password isn't correct.");
                
        }   

        public Task ValidateAsync(RegisterUserCommand command)
        {
            if (command == null) throw new ValidatorException("command");

            var validationResult = this.Validate(command);
            if (!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult.Errors);
            }

            return Task.FromResult(true);
        }


    }
}
