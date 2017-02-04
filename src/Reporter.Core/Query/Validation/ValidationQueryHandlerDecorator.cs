using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Query.Validation
{
    public class ValidationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> 
        where TQuery: IQuery<TResult>
        where TResult : IValidationQuery
    {
        public Task<TResult> RunAsync( TQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
