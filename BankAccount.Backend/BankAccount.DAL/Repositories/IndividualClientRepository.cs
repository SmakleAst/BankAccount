using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class IndividualClientRepository : IBaseRepository<IndividualClientEntity>
    {
        private readonly AppDbContext _appDbContext;

        public IndividualClientRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(IndividualClientEntity entity)
        {
            await _appDbContext.IndividualClients.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(IndividualClientEntity entity)
        {
            _appDbContext.IndividualClients.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<IndividualClientEntity> GetAll()
        {
            return _appDbContext.IndividualClients;
        }

        public async Task<IndividualClientEntity> Update(IndividualClientEntity entity)
        {
            _appDbContext.IndividualClients.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(IndividualClientEntity entity)
        {
            _appDbContext.IndividualClients.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
