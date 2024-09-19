using Aizen.Core.EFCore;
using Aizen.Modules.DataStore.Domain.Wallet;
using Microsoft.EntityFrameworkCore;

namespace Aizen.Modules.DataStore.Repository.Context;

public class DataStoreDbContext : AizenDbContext
{
    public DbSet<WalletEntity> Wallets { get; set; }
    public DbSet<BenefitCategoryEntity> BenefitCategories { get; set; }
    public DbSet<WalletTransactionEntity> WalletTransactions { get; set; }
    public DbSet<WalletOrderEntity> WalletOrders { get; set; }
    public DbSet<WalletOrderBenefitEntity> WalletOrderEligibleBenefits { get; set; }
    public DbSet<BenefitOptionEntity> BenefitOptions { get; set; }

    public DataStoreDbContext(DbContextOptions<DataStoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("flxw"); // Replace with your schema name


        base.OnModelCreating(modelBuilder);
    }
}