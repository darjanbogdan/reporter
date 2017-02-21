using Reporter.Core.Auth;
using Reporter.Model;
using Reporter.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.GetClient
{
    public partial class GetClientQuery : IAuthenticate, IAuthorize
    {
        Guid? IAuthorize.OwnerId { get; } = null;

        string IAuthorize.Permission { get; } = PermissionMap.ReadAbrv;

        string IAuthorize.PermissionSection { get; } = PermissionSectionMap.ClientSection;
    }
}
