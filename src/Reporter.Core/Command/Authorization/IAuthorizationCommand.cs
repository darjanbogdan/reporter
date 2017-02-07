using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Core.Command.Authorization
{
    public interface IAuthorizationCommand
    {
        string PermissionSection { get; set; }

        string Permission { get; set; }

        Guid? OwnerId { get; set; }
    }
}