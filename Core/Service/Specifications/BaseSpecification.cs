using DomainLayer.Contracts;
using DomainLayer.Models;
using System.Linq.Expressions;

namespace Service.Specifications
{
    abstract public class BaseSpecification<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        protected BaseSpecification(Expression<Func<TEntity, bool>>? CriteriaExpression)
        {
            Criteria = CriteriaExpression;
        }
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

        #region Includes
        public List<Expression<Func<TEntity, object>>> Includes { get; } = [];


        protected void AddInclude(Expression<Func<TEntity, object>> Include)
        => Includes.Add(Include);
        #endregion

        #region Sorting

        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression) => OrderBy = OrderByExpression;
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExpression) => OrderByDesc = OrderByDescExpression;

        #endregion
    }
}
