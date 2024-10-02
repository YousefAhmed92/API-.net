using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;

namespace Store.Repo.Specifications
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specs)
        {
            var query = inputQuery;

            // Apply filtering (Criteria)
            if (specs.Criteria is not null)
            {
                query = query.Where(specs.Criteria);
            }

            // Apply sorting (OrderBy and OrderByDescending)
            if (specs.OrderBy is not null)
            {
                query = query.OrderBy(specs.OrderBy);
            }
            else if (specs.OrderByDsec is not null)
            {
                query = query.OrderByDescending(specs.OrderByDsec);
            }

            // Apply pagination if required
            if (specs.IsPaginated)
            {
                query = query.Skip(specs.Skip).Take(specs.Take);
            }

            // Apply includes (eager loading)
            query = specs.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
