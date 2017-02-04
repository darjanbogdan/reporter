using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command
{
    public interface ICommandHandler<TCommand>
    {
        /// <summary>
        /// Handle command.
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns></returns>
        Task ExecuteAsync(TCommand command);
    }
}
