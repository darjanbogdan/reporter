using Reporter.Core.Command;
using Reporter.Core.Command.Validation;
using Reporter.Core.Query;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            var asmList = new[] { this.GetType().Assembly };
            
            container.Register(typeof(ICommandHandler<>), asmList);
            container.RegisterDecorator(typeof(ICommandHandler<>),typeof(ValidationCommandHandlerDecorator<>));
            container.Register(typeof(ICommandValidator<>), asmList);

            container.Register(typeof(IQueryHandler<,>), asmList);
        }
    }
}
