using Reporter.DAL.Models.Contracts;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Models
{
    public partial class PermissionPolicy : IDbModel
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
