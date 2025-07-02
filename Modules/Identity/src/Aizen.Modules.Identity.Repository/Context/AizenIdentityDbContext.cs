using Aizen.Modules.Identity.Domain.Entities;
using Aizen.Core.EFCore.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aizen.Modules.Identity.Repository.Context
{
    public class AizenIdentityDbContext : IdentityDbContext<AizenUserEntity, AizenRoleEntity, long>
    {
        #region [APPLICATION]
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<ApplicationRuleEntity> ApplicationRules { get; set; }

        public DbSet<ApplicationCountryPriceEntity> ApplicationCountryPrices { get; set; }
        public DbSet<ApplicationPriceHistoryEntity> ApplicationPriceHistories { get; set; }
        public DbSet<ApplicationTaxesAndCommissionEntity> ApplicationTaxesAndCommissions { get; set; }



        public DbSet<ApplicationPackageEntity> ApplicationPackages { get; set; }
        public DbSet<ApplicationFeatureMappingEntity> ApplicationFeatureMappings { get; set; }
        public DbSet<ApplicationPackageFeatureEntity> ApplicationPackageFeatures { get; set; }
        public DbSet<ApplicationPackageFeatureBundleEntity> ApplicationPackageFeatureBundles { get; set; }
        #endregion

        public DbSet<TenantEntity> Tenants { get; set; }

        #region [USER]
        public DbSet<AizenUserEntity> AizenUsers { get; set; }
        public DbSet<AizenRoleEntity> AizenRoles { get; set; }
        public DbSet<AizenRoleTypeEntity> AizenRoleTypes { get; set; }
        public DbSet<UserApplicationDeviceEntity> UserApplicationDevices { get; set; }
        public DbSet<UserApplicationEmailConfirmEntity> UserApplicationEmailConfirms { get; set; }
        public DbSet<UserApplicationLoginTokenEntity> UserApplicationLoginTokens { get; set; }
        public DbSet<UserApplicationMessagePermissionEntity> UserApplicationMessagePermissions { get; set; }
        public DbSet<UserApplicationPackageEntity> UserApplicationPackages { get; set; }
        public DbSet<UserApplicationPackageFeatureEntity> UserApplicationPackageFeatures { get; set; }
        public DbSet<UserApplicationPackageFeatureUsedEntity> UserApplicationPackageFeatureUseds { get; set; }
        public DbSet<UserApplicationPackageFeatureBundleEntity> UserApplicationPackageFeatureBundles { get; set; }
        public DbSet<UserApplicationPasswordHistoryEntity> UserApplicationPasswordHistories { get; set; }
        public DbSet<UserApplicationProfileEntity> UserApplicationProfiles { get; set; }
        public DbSet<UserApplicationBlockEntity> UserApplicationBlocks { get; set; }
        public DbSet<UserApplicationReportEntity> UserApplicationReports { get; set; }
        public DbSet<UserApplicationReferenceEntity> UserApplicationReferences { get; set; }
        #endregion


        public AizenIdentityDbContext(DbContextOptions<AizenIdentityDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Identity");

            base.OnModelCreating(modelBuilder); // IdentityDbContext'in OnModelCreating methodunu çağır

            modelBuilder.ApplyIsNotDeletedFilter();
            modelBuilder.ConfigureDateTimeColumns();
            modelBuilder.AddRowVersionToAllEntities();
        }
    }
}