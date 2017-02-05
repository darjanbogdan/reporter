using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Lookups
{
    public interface ILookup<TResource>
    {
        Task<IEnumerable<TResource>> GetAllAsync();
    }
}