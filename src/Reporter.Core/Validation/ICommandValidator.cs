using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Validation
{
    public interface ICommandValidator<TCommand>
    {
        Task ValidateAsync(TCommand command);
    }
}
