﻿using Reporter.Core.Command;
using Reporter.Core.Command.Authorization;
using Reporter.Core.Command.Validation;
using Reporter.Core.Query;
using Reporter.Service.Infrastructure.Lookups;
using Reporter.Service.Membership.Lookups;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service
{
    public class PackageRegister : IPackage
    {
        public void RegisterServices(Container container)
        {
            var serviceAsm = this.GetType().Assembly;

            RegisterLookups(container, serviceAsm);
            RegisterCommandHandlerPipeline(container, serviceAsm);
            RegisterQueryHandlerPipeline(container, serviceAsm);
        }

        private void RegisterCommandHandlerPipeline(Container container, Assembly assembly)
        {
            var asmList = new[] { assembly };

            container.Register(typeof(ICommandHandler<>), asmList);
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthenticationCommandHandlerDecorator<>));

            container.Register(typeof(ICommandValidator<>), asmList);
        }

        private void RegisterLookups(Container container, Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();

            var lookupTypes = assemblyTypes.Where(type => !type.IsAbstract && !type.IsInterface 
                && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IResourceLookup<>)));
            
            container.Register(typeof(IResourceLookup<>), lookupTypes, Lifestyle.Singleton);
            foreach (var lookupType in lookupTypes)
            {
                //Each lookup type implements only one specific non-generic interface
                var lookupInterface = lookupType.GetInterfaces().FirstOrDefault(i => !i.IsGenericType);
                if (lookupInterface != null)
                {
                    container.Register(lookupInterface, lookupType);
                }
            }
        }

        private void RegisterQueryHandlerPipeline(Container container, Assembly assembly)
        {
            var asmList = new[] { assembly };

            container.Register(typeof(IQueryHandler<,>), asmList);
        }
    }
}