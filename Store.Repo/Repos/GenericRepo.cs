using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.Repos
{
    public class GenericRepo<TEntity, TKey> : IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepo(StoreDbContext context)
        {
            _context = context;
        }

        public async Task addAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTracking()
             => await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();


        public async Task<TEntity> GetByIdAsync(TKey? id)
            => await _context.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity)
            =>  _context.Update(entity);

        //public async Task<TEntity> GetByIdAsNoTracking(TKey? id)
        //    => await _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id);

      
    }
}
