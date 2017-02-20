using System;
using System.Collections.Generic;

namespace Reporter.Model
{
    public class ClientPermissionPolicy
    {
        public Guid Id { get; set; }

        public Guid ParentId { get; set; }

        public Guid PermissionId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? RoleId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
