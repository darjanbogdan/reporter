using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Authorization
{
    public class AuthenticationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly IApplicationContext context;
        private readonly ICommandHandler<TCommand> commandHandler;

        public AuthenticationCommandHandlerDecorator(IApplicationContext context, ICommandHandler<TCommand> commandHandler)
        {
            this.context = context;
            this.commandHandler = commandHandler;
        }

        public Task ExecuteAsync(TCommand command)
        {
            if (!this.context.UserInfo.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            return this.commandHandler.ExecuteAsync(command);
        }
    }
}
