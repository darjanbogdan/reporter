using Reporter.Core.Auth;
using Reporter.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.CreateClient
{
    public partial class CreateClientCommand : IAuthenticate, IAuthorize
    {
        Guid? IAuthorize.OwnerId { get; } = null;

        string IAuthorize.Permission { get; } = PermissionMap.CreateAbrv;

        string IAuthorize.PermissionSection { get; } = PermissionSectionMap.ClientSection;
    }
}