using System;

namespace Reporter.Model
{
    public partial class PermissionPolicy
    {
        public Guid PermissionId { get; set; }

        public Guid PermissionSectionId { get; set; }

        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
