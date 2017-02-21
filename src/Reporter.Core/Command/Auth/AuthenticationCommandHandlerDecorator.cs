using Reporter.Core.Auth;
using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Auth
{
    public class AuthenticationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IAuthenticate
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
                throw new UnauthorizedAccessException("authentication...");
            }

            return this.commandHandler.ExecuteAsync(command);
        }
    }
}
