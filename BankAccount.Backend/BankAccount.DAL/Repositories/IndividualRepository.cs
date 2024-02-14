using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;

namespace BankAccount.DAL.Repositories
{
    public class IndividualRepository : IBaseRepository<IndividualEntity>
    {
        private readonly AppDbContext _appDbContext;

        public IndividualRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(IndividualEntity entity)
        {
            await _appDbContext.Individuals.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(IndividualEntity entity)
        {
            _appDbContext.Individuals.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<IndividualEntity> GetAll()
        {
            return _appDbContext.Individuals;
        }

        public async Task<IndividualEntity> Update(IndividualEntity entity)
        {
            _appDbContext.Individuals.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(IndividualEntity entity)
        {
            _appDbContext.Individuals.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
