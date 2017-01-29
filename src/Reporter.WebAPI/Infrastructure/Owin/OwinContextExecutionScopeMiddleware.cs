using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporter.WebAPI.Infrastructure.Owin
{
    public static class OwinContextExecutionScopeMiddleware
    {
        public static void UseOwinContextExecutionScope(this IAppBuilder app, Container container)
        {
            // Create an OWIN middleware to create an execution context scope
            app.Use(async (context, next) =>
            {
                using (var scope = container.BeginExecutionContextScope())
                {
                    await next.Invoke();
                }
            });
        }
    }
}