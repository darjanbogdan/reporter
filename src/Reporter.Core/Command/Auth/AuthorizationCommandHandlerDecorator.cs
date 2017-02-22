using Reporter.Core.Auth;
using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Auth
{
    public class AuthorizationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IAuthorize
    {

        private readonly IAuthorizationEvaluator authorizationEvaluator;
        private readonly ICommandHandler<TCommand> commandHandler;

        public AuthorizationCommandHandlerDecorator(
            IAuthorizationEvaluator authorizationEvaluator, 
            ICommandHandler<TCommand> commandHandler)
        {
            this.authorizationEvaluator = authorizationEvaluator;
            this.commandHandler = commandHandler;
        }

        public async Task ExecuteAsync(TCommand command)
        {
            await this.authorizationEvaluator.EvaluateAsync(command);

            await this.commandHandler.ExecuteAsync(command);
        }
    }
}
