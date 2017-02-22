using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class PermissionPolicyEntity : IEntity
    {
        public Guid Id { get; set; }

        public Guid PermissionId { get; set; }

        public Guid PermissionSectionId { get; set; }

        public Guid? RoleId { get; set; }

        public Guid? UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
