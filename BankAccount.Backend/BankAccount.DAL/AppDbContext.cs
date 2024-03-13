using BankAccount.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<LegalClientEntity> LegalClients { get; set; }
        public DbSet<IndividualClientEntity> IndividualClients { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<InterestRateEntity> InterestRates { get; set; }
    }
}
