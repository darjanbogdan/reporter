using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Validation
{
    public interface ICommandValidator<TCommand> where TCommand : IValidationCommand
    {
        Task ValidateAsync(TCommand command);
    }
}
