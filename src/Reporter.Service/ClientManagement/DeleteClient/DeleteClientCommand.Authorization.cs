using Reporter.Core.Auth;
using Reporter.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.DeleteClient
{
    public partial class DeleteClientCommand : IAuthenticate, IAuthorize
    {
        Guid? IAuthorize.OwnerId { get; } = null;

        string IAuthorize.Permission { get; } = PermissionMap.DeleteAbrv;

        string IAuthorize.PermissionSection { get; } = PermissionSectionMap.ClientSection;
    }
}
