using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<TEntity,TKey> repo<TEntity, TKey>() where TEntity : BaseEntity<TKey> ;
        Task<int> CompleteAsync();
    }
}
