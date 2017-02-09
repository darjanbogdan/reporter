using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Authorization
{
    public interface IAuthorize
    {
        string PermissionSection { get; }

        string Permission { get; }

        Guid? OwnerId { get; }
    }
}
