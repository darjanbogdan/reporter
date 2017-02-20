using Reporter.Core.Authorization;
using Reporter.Core.Command.Authorization;
using Reporter.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Query.Authorization
{
    public class AuthorizationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>, IAuthorize
    {
        private readonly IAuthorizationEvaluator authorizationEvaluator;
        private readonly IQueryHandler<TQuery, TResult> queryHandler;

        public AuthorizationQueryHandlerDecorator(IAuthorizationEvaluator authorizationEvaluator, IQueryHandler<TQuery, TResult> queryHandler)
        {
            this.authorizationEvaluator = authorizationEvaluator;
            this.queryHandler = queryHandler;
        }

        public async Task<TResult> RunAsync(TQuery query)
        {
            await this.authorizationEvaluator.EvaluateAsync(query);

            return await this.queryHandler.RunAsync(query);
        }
    }
}
