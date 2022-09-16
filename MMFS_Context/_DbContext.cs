using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MMFS_Context.Security;
using MMFS_Context.UserManagementMapping;
using MMFS_Context.UserProfile;
using MMFS_POCO;
using MMFS_POCO.UserManagement;
using MMFS_POCO.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Context
{
    public class _DbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region 
            // new ApplicationUserMap(modelBuilder.Entity<ApplicationUser>());
            new UserPersonalProfileMapper(modelBuilder.Entity<PersonalProfile>());
            new UserBusinessProfileMapper(modelBuilder.Entity<BusinessProfile>());
            new UserEmergencyProfileMapper(modelBuilder.Entity<UserEmergencyProfile>());
            new UserChequeProfileMapper(modelBuilder.Entity<UserChequeProfile>());
            new CityMapper(modelBuilder.Entity<City>());
            new BankMapper(modelBuilder.Entity<Bank>());
            new RaceMapper(modelBuilder.Entity<Race>());
            new ReligionMapper(modelBuilder.Entity<Religion>());
            new StateMapper(modelBuilder.Entity<State>());
            new PaymentMethodMapper(modelBuilder.Entity<PaymentMethod>());
            new FirstTimeLoginMapping(modelBuilder.Entity<FirstTimeLogin>());
            new AccessingComponentMapping(modelBuilder.Entity<AccessingComponent>());
            new PermissionMapping(modelBuilder.Entity<Permission>());

            #endregion
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<PersonalProfile> UserPersonalProfile { get; set; }
        public virtual DbSet<BusinessProfile> UserBusinessProfile { get; set; }
        public virtual DbSet<UserEmergencyProfile> UserEmergencyProfile { get; set; }
        public virtual DbSet<UserChequeProfile> UserChequeProfile { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<FirstTimeLogin> FirstTimeLogin { get; set; }
        public virtual DbSet<AccessingComponent> AccessingComponents { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
    }


}
