using Reporter.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ReportPermissionPolicyMap : EntityTypeConfiguration<ReportPermissionPolicy>
    {
        public ReportPermissionPolicyMap()
        {
            ToTable("ReportPermissionPolicy");

            HasKey(e => e.Id);
        }
    }
}
