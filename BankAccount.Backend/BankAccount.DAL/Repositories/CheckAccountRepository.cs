using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class CheckAccountRepository : IBaseRepository<CheckAccountEntity>
    {
        private readonly AppDbContext _appDbContext;

        public CheckAccountRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(CheckAccountEntity entity)
        {
            await _appDbContext.CheckAccounts.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(CheckAccountEntity entity)
        {
            _appDbContext.CheckAccounts.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<CheckAccountEntity> GetAll()
        {
            return _appDbContext.CheckAccounts;
        }

        public async Task<CheckAccountEntity> Update(CheckAccountEntity entity)
        {
            _appDbContext.CheckAccounts.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(CheckAccountEntity entity)
        {
            _appDbContext.CheckAccounts.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
