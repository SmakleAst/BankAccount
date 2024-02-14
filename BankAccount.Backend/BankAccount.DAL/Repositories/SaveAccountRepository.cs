using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class SaveAccountRepository : IBaseRepository<SaveAccountEntity>
    {
        private readonly AppDbContext _appDbContext;

        public SaveAccountRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(SaveAccountEntity entity)
        {
            await _appDbContext.SaveAccounts.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(SaveAccountEntity entity)
        {
            _appDbContext.SaveAccounts.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<SaveAccountEntity> GetAll()
        {
            return _appDbContext.SaveAccounts;
        }

        public async Task<SaveAccountEntity> Update(SaveAccountEntity entity)
        {
            _appDbContext.SaveAccounts.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(SaveAccountEntity entity)
        {
            _appDbContext.SaveAccounts.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
