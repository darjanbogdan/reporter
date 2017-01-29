using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporter.WebAPI.Infrastructure.DependencyInjection
{
    public static class SimpleInjectorContainerFactory
    {
        public static Container Create()
        {
            var container = new Container();
            Initialize(container);
            return container;
        }

        private static void Initialize(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
        }
    }
}