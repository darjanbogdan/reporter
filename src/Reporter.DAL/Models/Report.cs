using Reporter.DAL.Models.Contracts;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Models
{
    public partial class Report : IDbModel
    {
        public Report()
        {
            ReportPermissionPolicies = new HashSet<ReportPermissionPolicy>();
        }

        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

        public string Content { get; set; }

        public Guid ReportTypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<ReportPermissionPolicy> ReportPermissionPolicies { get; set; }
    }
}
