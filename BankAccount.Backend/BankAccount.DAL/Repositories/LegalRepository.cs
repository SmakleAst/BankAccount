using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class LegalRepository : IBaseRepository<LegalEntity>
    {
        private readonly AppDbContext _appDbContext;

        public LegalRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(LegalEntity entity)
        {
            await _appDbContext.Legals.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(LegalEntity entity)
        {
            _appDbContext.Legals.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<LegalEntity> GetAll()
        {
            return _appDbContext.Legals;
        }

        public async Task<LegalEntity> Update(LegalEntity entity)
        {
            _appDbContext.Legals.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(LegalEntity entity)
        {
            _appDbContext.Legals.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
