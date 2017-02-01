﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Validation
{
    public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandValidator<TCommand> validator;
        private readonly ICommandHandler<TCommand> commandHandler; //decoratee

        public ValidationCommandHandlerDecorator(ICommandValidator<TCommand> validator, ICommandHandler<TCommand> commandHandler)
        {
            this.validator = validator;
            this.commandHandler = commandHandler;
        }

        public async Task HandleAsync(TCommand command)
        {
            await this.validator.ValidateAsync(command);

            await this.commandHandler.HandleAsync(command);
        }
    }
}
