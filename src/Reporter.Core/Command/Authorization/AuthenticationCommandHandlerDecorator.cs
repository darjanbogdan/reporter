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
        private readonly IApplicationContext applicationContext;
        private readonly ICommandHandler<TCommand> commandHandler;

        public AuthenticationCommandHandlerDecorator(IApplicationContext applicationContext, ICommandHandler<TCommand> commandHandler)
        {
            this.applicationContext = applicationContext;
            this.commandHandler = commandHandler;
        }

        public Task ExecuteAsync(TCommand command)
        {
            if (!this.applicationContext.UserInfo.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            return this.commandHandler.ExecuteAsync(command);
        }
    }
}
