using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMember>();
            ProjectPermissionPolicies = new HashSet<ProjectPermissionPolicy>();
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProjectManagerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual ApplicationUser ProjectManager { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }

        public virtual ICollection<ProjectPermissionPolicy> ProjectPermissionPolicies { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
