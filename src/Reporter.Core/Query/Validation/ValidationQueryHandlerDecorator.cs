using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Query.Validation
{
    public class ValidationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>, IValidate
    {
        private readonly IValidator<TQuery> validator;
        private readonly IQueryHandler<TQuery, TResult> queryHandler;

        public ValidationQueryHandlerDecorator(IValidator<TQuery> validator, IQueryHandler<TQuery, TResult> queryHandler)
        {
            this.validator = validator;
            this.queryHandler = queryHandler;
        }

        public async Task<TResult> RunAsync(TQuery query)
        {
            await this.validator.ValidateAsync(query);

            return await this.queryHandler.RunAsync(query);
        }
    }
}
