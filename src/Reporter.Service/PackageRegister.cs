using Reporter.Core.Command;
using Reporter.Core.Command.Validation;
using Reporter.Core.Query;
using Reporter.Service.Membership;
using Reporter.Service.Membership.Contracts;
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
            container.Register<IUserService, UserService>();
            container.RegisterSingleton<Func<IUserService>>(() => container.GetInstance<IUserService>());

            container.Register<IAccountService, AccountService>();
            container.RegisterSingleton<Func<IAccountService>>(() => container.GetInstance<IAccountService>());


            var asmList = new[] { this.GetType().Assembly };
            
            container.Register(typeof(ICommandHandler<>), asmList);
            container.RegisterDecorator(typeof(ICommandHandler<>),typeof(ValidationCommandHandlerDecorator<>));
            container.Register(typeof(ICommandValidator<>), asmList);

            container.Register(typeof(IQueryHandler<,>), asmList);
        }
    }
}
