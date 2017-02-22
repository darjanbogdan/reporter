using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.DAL.Maps;
using Reporter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Context
{
    public partial class ApplicationDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<ClientEntity> Client { get; set; }
        public IDbSet<ClientPermissionPolicyEntity> ClientPermissionPolicy { get; set; }
        public IDbSet<ClientProjectEntity> ClientProject { get; set; }
        public IDbSet<PermissionEntity> Permission { get; set; }
        public IDbSet<PermissionPolicyEntity> PermissionPolicy { get; set; }
        public IDbSet<PermissionSectionEntity> PermissionSection { get; set; }
        public IDbSet<ProjectEntity> Project { get; set; }
        public IDbSet<ProjectMemberEntity> ProjectMember { get; set; }
        public IDbSet<ProjectPermissionPolicyEntity> ProjectPermissionPolicy { get; set; }
        public IDbSet<ReportEntity> Report { get; set; }
        public IDbSet<ReportPermissionPolicyEntity> ReportPermissionPolicy { get; set; }
        public IDbSet<ReportTypeEntity> ReportType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClientEntityMap());
            modelBuilder.Configurations.Add(new ClientPermissionPolicyEntityMap());
            modelBuilder.Configurations.Add(new ClientProjectEntityMap());
            modelBuilder.Configurations.Add(new PermissionEntityMap());
            modelBuilder.Configurations.Add(new PermissionPolicyEntityMap());
            modelBuilder.Configurations.Add(new PermissionSectionEntityMap());
            modelBuilder.Configurations.Add(new ProjectEntityMap());
            modelBuilder.Configurations.Add(new ProjectMemberEntityMap());
            modelBuilder.Configurations.Add(new ProjectPermissionPolicyEntityMap());
            modelBuilder.Configurations.Add(new ReportEntityMap());
            modelBuilder.Configurations.Add(new ReportPermissionPolicyEntityMap());
            modelBuilder.Configurations.Add(new ReportTypeEntityMap());
        }
    }
}