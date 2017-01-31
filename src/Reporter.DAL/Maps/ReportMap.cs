using Reporter.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ReportMap : EntityTypeConfiguration<Report>
    {
        public ReportMap()
        {
            ToTable("Report");

            HasKey(e => e.Id);

            Property(e => e.Content)
                .IsRequired()
                .HasColumnType("text")
                .IsUnicode(false);

            HasRequired(e => e.Project)
                .WithMany(e => e.Reports)
                .HasForeignKey(e => e.ProjectId);

            HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            HasMany(e => e.ReportPermissionPolicies)
                .WithRequired()
                .HasForeignKey(e => e.ParentId)
                .WillCascadeOnDelete(false);

        }
    }
}
