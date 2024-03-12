using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class TransactionRepository : IBaseRepository<TransactionEntity>
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(TransactionEntity entity)
        {
            await _appDbContext.Transactions.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(TransactionEntity entity)
        {
            _appDbContext.Transactions.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<TransactionEntity> GetAll()
        {
            return _appDbContext.Transactions;
        }

        public async Task<TransactionEntity> Update(TransactionEntity entity)
        {
            _appDbContext.Transactions.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(TransactionEntity entity)
        {
            _appDbContext.Transactions.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
