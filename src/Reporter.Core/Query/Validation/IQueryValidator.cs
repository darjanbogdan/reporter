﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Query.Validation
{
    public interface IQueryValidator<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
