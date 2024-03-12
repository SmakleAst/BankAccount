using BankAccount.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<LegalClientEntity> LegalClients { get; set; }
        public DbSet<IndividualClientEntity> IndividualClients { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<InterestRateEntity> InterestRates { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<LegalClientEntity>()
        //        .HasMany(t => t.SaveAccounts)
        //        .WithOne(t => t.LegalClient)
        //        .HasForeignKey(e => e.LegalClientId);

        //    modelBuilder.Entity<LegalClientEntity>()
        //        .HasMany(t => t.CheckAccounts)
        //        .WithOne(t => t.LegalClient)
        //        .HasForeignKey(e => e.LegalClientId);

        //    modelBuilder.Entity<IndividualClientEntity>()
        //        .HasMany(t => t.SaveAccounts)
        //        .WithOne(t => t.IndividualClient)
        //        .HasForeignKey(e => e.IndividualClientId);

        //    modelBuilder.Entity<IndividualClientEntity>()
        //        .HasMany(t => t.CheckAccounts)
        //        .WithOne(t => t.IndividualClient)
        //        .HasForeignKey(e => e.IndividualClientId);
        //}
    }
}
