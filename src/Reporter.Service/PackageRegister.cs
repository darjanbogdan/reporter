using Reporter.Core.Auth;
using Reporter.Service.Infrastructure.Lookups;
using Reporter.Service.Security;
using Reporter.Service.Security.Filtering;
using Reporter.Service.Security.Filtering.Contracts;
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

            container.Register<IAuthorizationEvaluator, AuthorizationEvaluator>();
            container.Register<IPermissionPolicyFilterFactory, PermissionPolicyFilterFactory>();
        }

        private void RegisterLookups(Container container, Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();

            var lookupTypes = assemblyTypes.Where(type => !type.IsAbstract && !type.IsInterface 
                && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IResourceLookup<>)));
            
            container.Register(typeof(IResourceLookup<>), lookupTypes);

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
    }
}