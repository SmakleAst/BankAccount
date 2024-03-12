using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class LegalClientRepository : IBaseRepository<LegalClientEntity>
    {
        private readonly AppDbContext _appDbContext;

        public LegalClientRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(LegalClientEntity entity)
        {
            await _appDbContext.LegalClients.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(LegalClientEntity entity)
        {
            _appDbContext.LegalClients.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<LegalClientEntity> GetAll()
        {
            return _appDbContext.LegalClients;
        }

        public async Task<LegalClientEntity> Update(LegalClientEntity entity)
        {
            _appDbContext.LegalClients.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(LegalClientEntity entity)
        {
            _appDbContext.LegalClients.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
