using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Query.Authorization
{
    public class AuthenticationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IQueryHandler<TQuery, TResult> queryHandler;

        public AuthenticationQueryHandlerDecorator(IApplicationContext applicationContext, IQueryHandler<TQuery, TResult> queryHandler)
        {
            this.applicationContext = applicationContext;
            this.queryHandler = queryHandler;
        }

        public async Task<TResult> RunAsync(TQuery query)
        {
            if (!this.applicationContext.UserInfo.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("authentication...");
            }

            return await this.queryHandler.RunAsync(query);
        }
    }
}
