using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class ReportEntity : IEntity
    {
        public ReportEntity()
        {
            ReportPermissionPolicies = new HashSet<ReportPermissionPolicyEntity>();
        }

        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

        public string Content { get; set; }

        public Guid ReportTypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual ProjectEntity Project { get; set; }

        public virtual ICollection<ReportPermissionPolicyEntity> ReportPermissionPolicies { get; set; }
    }
}
