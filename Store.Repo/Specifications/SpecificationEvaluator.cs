using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;

namespace Store.Repo.Specifications
{
    public class SpecificationEvaluator <TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable <TEntity> GetQuery(IQueryable<TEntity> inputquery ,ISpecification<TEntity> specs )
        {
            var query = inputquery;
            if (specs.Criteria is not null)
                query = query.Where(specs.Criteria);

            if (specs.Criteria is not null)
                query = query.OrderBy(specs.OrderBy);

            if (specs.OrderByDsec is not null)
                query = query.OrderByDescending(specs.OrderByDsec);

            if (specs.IsPaginated)
                query = query.Skip(specs.Skip).Take(specs.Take);


            query = specs.Includes.Aggregate(query, (current, Next) => current.Include(Next));
            return query;

        }
    }
}
