using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class ProjectPermissionPolicyEntity : IEntity
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
