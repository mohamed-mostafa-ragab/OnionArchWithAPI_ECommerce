using DomainLayer.Contracts;
using DomainLayer.Models;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repos
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> Repos = [];
        public IGenericRepo<TEntity, Tkey> GetRepo<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type = typeof(TEntity).Name;
            if (Repos.ContainsKey(type))
                return (IGenericRepo<TEntity, Tkey>) Repos[type];
            else
            {
                var repo = new GenericRepo<TEntity, Tkey>(_dbContext);
                Repos.Add(type, repo);
                return repo;
            }
        }

        public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
