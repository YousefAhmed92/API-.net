using System.Linq.Expressions;

namespace Store.Repo.Specifications
{
    public interface ISpecification <T>
    {

        Expression<Func<T,bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDsec { get; }

        int Take {  get; }
        int Skip { get; }
        bool IsPaginated { get; }

    }
}
