using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Reporter.Core.Command;
using Reporter.Core.Command.Validation;
using Reporter.Core.Command.Authorization;
using System.Reflection;
using Reporter.Core.Query;

namespace Reporter.Core
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            var applicationAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.GetName().Name.StartsWith("Reporter")).ToArray();

            RegisterCommandHandlerPipeline(container, applicationAssemblies);
            RegisterQueryHandlerPipeline(container, applicationAssemblies);
        }

        private void RegisterCommandHandlerPipeline(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(ICommandHandler<>), assemblies);
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthorizationCommandHandlerDecorator<>));
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthenticationCommandHandlerDecorator<>));

            container.Register(typeof(ICommandValidator<>), assemblies);
        }

        private void RegisterQueryHandlerPipeline(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(IQueryHandler<,>), assemblies);
        }
    }
}
