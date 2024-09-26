using Store.Data.Entities;
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
        //Task<TEntity> GetByIdAsNoTracking(TKey? id);


        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllAsNoTracking();

        Task addAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);



    }
}
