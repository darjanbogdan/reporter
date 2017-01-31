using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.DAL.Maps;
using Reporter.DAL.Models;
using Reporter.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.DAL.Context
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Client> Client { get; set; }
        public IDbSet<ClientPermissionPolicy> ClientPermissionPolicy { get; set; }
        public IDbSet<ClientProject> ClientProject { get; set; }
        public IDbSet<Permission> Permission { get; set; }
        public IDbSet<PermissionPolicy> PermissionPolicy { get; set; }
        public IDbSet<PermissionSection> PermissionSection { get; set; }
        public IDbSet<Project> Project { get; set; }
        public IDbSet<ProjectMember> ProjectMember { get; set; }
        public IDbSet<ProjectPermissionPolicy> ProjectPermissionPolicy { get; set; }
        public IDbSet<Report> Report { get; set; }
        public IDbSet<ReportPermissionPolicy> ReportPermissionPolicy { get; set; }
        public IDbSet<ReportType> ReportType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ClientPermissionPolicyMap());
            modelBuilder.Configurations.Add(new ClientProjectMap());
            modelBuilder.Configurations.Add(new PermissionMap());
            modelBuilder.Configurations.Add(new PermissionPolicyMap());
            modelBuilder.Configurations.Add(new PermissionSectionMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectMemberMap());
            modelBuilder.Configurations.Add(new ProjectPermissionPolicyMap());
            modelBuilder.Configurations.Add(new ReportMap());
            modelBuilder.Configurations.Add(new ReportPermissionPolicyMap());
            modelBuilder.Configurations.Add(new ReportTypeMap());
        }
    }
}