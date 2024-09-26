using Store.Data.Context;
using Store.Data.Entities;
using Store.Repo.Interfaces;
using System.Collections;

namespace Store.Repo.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public IGenericRepo<TEntity, TKey> repo<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if(_repositories is null) _repositories = new Hashtable();
            var EntityType = typeof(TEntity).Name;

            if(!_repositories.ContainsKey(EntityType))
            {
                var RepositoryType = typeof(GenericRepo<,>);
                var RepositoryInstance = Activator.CreateInstance(RepositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context);
                _repositories.Add(EntityType , RepositoryInstance);
            }
            return (IGenericRepo<TEntity, TKey>)_repositories[EntityType];
        } 
    }
}
