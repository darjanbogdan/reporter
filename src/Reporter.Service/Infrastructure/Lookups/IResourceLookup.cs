using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.Infrastructure.Lookups
{
    public interface IResourceLookup<TResource>
    {
        Task<IEnumerable<TResource>> GetAllAsync();

        Task<TResource> GetAsync(string abrv);
    }
}
