using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal static class QueryGenertor
    {
        public static IQueryable<TEntity> 
            CreateQuery<TEntity, TKey>(IQueryable<TEntity> BaseQuery,ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var Query = BaseQuery;
            if(specifications.Criteria is not null )
                Query = Query.Where(specifications.Criteria);

            if(specifications.Includes is not null && specifications.Includes.Any())
                foreach( var include in specifications.Includes )
                    Query = Query.Include(include);


            return Query;
        }
    }
}
