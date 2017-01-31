using Reporter.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            ToTable("Project");

            HasKey(e => e.Id);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(e => e.ProjectManager)
                .WithMany()
                .HasForeignKey(e => e.ProjectManagerId);

            HasMany(e => e.ProjectMembers)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.ProjectId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ProjectPermissionPolicies)
                .WithRequired()
                .HasForeignKey(e => e.ParentId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Reports)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.ProjectId)
                .WillCascadeOnDelete(false);
        }
    }
}
