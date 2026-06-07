using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repos
{
    public class GenericRepo<TEntity, Tkey>(StoreDbContext _dbContext) :
        IGenericRepo<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public async Task AddAsync(TEntity entity)
            => await _dbContext.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbContext.Set<TEntity>().ToListAsync();



        public async Task<TEntity?> GetByIdAsync(Tkey Id)
        => await _dbContext.Set<TEntity>().FindAsync(Id);

        public void Remove(TEntity entity)
        => _dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity)
        => _dbContext.Set<TEntity>().Update(entity);

        #region Spec
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, Tkey> specifications)
        {
            return await QueryGenertor.CreateQuery(_dbContext.Set<TEntity>(), specifications).ToListAsync();

        }

        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, Tkey> specifications)
        {
            return await QueryGenertor.CreateQuery(_dbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();

        }
        #endregion
    }
}
