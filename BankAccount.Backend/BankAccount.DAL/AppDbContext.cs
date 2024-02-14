using BankAccount.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        DbSet<CheckAccountEntity> CheckAccounts { get; set; }
        DbSet<SaveAccountEntity> SaveAccounts { get; set; }
        DbSet<LegalEntity> Legals { get; set; }
        DbSet<IndividualEntity> Individuals { get; set; }
    }
}
