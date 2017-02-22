using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Core.Auth;
using Reporter.Service.Security;

namespace Reporter.Service.ClientManagement.UpdateClient
{
    public partial class UpdateClientCommand : IAuthenticate, IAuthorize
    {
        Guid? IAuthorize.OwnerId { get { return this.ManagerId; } }

        string IAuthorize.Permission { get; } = PermissionMap.UpdateAbrv;

        string IAuthorize.PermissionSection { get; } = PermissionSectionMap.ClientSection;
    }
}
