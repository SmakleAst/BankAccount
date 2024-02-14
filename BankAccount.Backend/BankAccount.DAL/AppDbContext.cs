using BankAccount.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CheckAccountEntity> CheckAccounts { get; set; }
        public DbSet<SaveAccountEntity> SaveAccounts { get; set; }
        public DbSet<LegalEntity> Legals { get; set; }
        public DbSet<IndividualEntity> Individuals { get; set; }
    }
}
