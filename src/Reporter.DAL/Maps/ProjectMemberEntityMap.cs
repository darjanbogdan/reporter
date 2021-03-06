using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;

namespace Reporter.DAL.Maps
{
    public partial class ProjectMemberEntityMap : EntityTypeConfiguration<ProjectMemberEntity>
    {
        public ProjectMemberEntityMap()
        {
            ToTable("ProjectMember");

            HasKey(e => e.Id);

            HasRequired(e => e.Project)
                .WithMany(e => e.ProjectMembers)
                .HasForeignKey(e => e.ProjectId);

            HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

        }
    }
}
