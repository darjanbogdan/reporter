using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Authorization
{
    public interface IPermissionManager<TCommand> where TCommand : IAuthorizationCommand
    {
        Task EvaluateAsync(TCommand command);
    }
}
