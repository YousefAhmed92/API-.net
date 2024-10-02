using Store.Data.Entities;
using Store.Repo.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.Interfaces
{
    public interface IGenericRepo <TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey? id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();




        Task<TEntity> GetByIdAsyncWithSpecification(ISpecification<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllAsyncWithSpecification(ISpecification<TEntity> specs);

        Task <int> GetCountSpecificationAsync(ISpecification<TEntity> specs);

        Task<IReadOnlyList<TEntity>> GetAllAsNoTracking();

        Task addAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);



    }
}
