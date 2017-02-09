using Reporter.Core.Query.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Query
{
    public interface IQuery<TResult>
    {
        IQueryFilter Filter { get; set; }

        IQuerySorter Sorter { get; set; }

        IQueryPager Pager { get; set; }

        IQueryOptions Options { get; set;}
    }
}
