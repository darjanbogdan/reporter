using Reporter.DAL.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Entities
{
    public partial class ProjectEntity : IEntity
    {
        public ProjectEntity()
        {
            ProjectMembers = new HashSet<ProjectMemberEntity>();
            ProjectPermissionPolicies = new HashSet<ProjectPermissionPolicyEntity>();
            Reports = new HashSet<ReportEntity>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProjectManagerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual UserEntity ProjectManager { get; set; }

        public virtual ICollection<ProjectMemberEntity> ProjectMembers { get; set; }

        public virtual ICollection<ProjectPermissionPolicyEntity> ProjectPermissionPolicies { get; set; }

        public virtual ICollection<ReportEntity> Reports { get; set; }
    }
}
