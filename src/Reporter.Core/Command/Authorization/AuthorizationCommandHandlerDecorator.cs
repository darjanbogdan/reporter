using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Authorization
{
    public class AuthorizationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IAuthorizationCommand
    {
        private readonly IPermissionManager<TCommand> permissionManager;
        private readonly ICommandHandler<TCommand> commandHandler;

        public AuthorizationCommandHandlerDecorator(IPermissionManager<TCommand> permissionManager, ICommandHandler<TCommand> commandHandler)
        {
            this.permissionManager = permissionManager;
            this.commandHandler = commandHandler;
        }

        public async Task ExecuteAsync(TCommand command)
        {
            await this.permissionManager.EvaluateAsync(command);

            await this.commandHandler.ExecuteAsync(command);
        }
    }
}
