using EvoCafe.DAL.Interfaces;
using EvoCafe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EvoCafe.DAL.Repositories
{
    public class BasicRepository<T> : IRepository<T> where T : EntityBase
    {
        protected DbSet<T> _dbSet;
        DbContext _dbContext;

        public BasicRepository(BDContext cafeContext)
        {
            _dbSet     = cafeContext.Set<T>();
            _dbContext = cafeContext;
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public async Task Delete(int id)
        {
            var entity = await GetSingleAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
        }

        public Task<T> GetSingleAsync(int id) => _dbSet.FindAsync(id);

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

        public IQueryable<T> GetAll() => _dbSet.AsNoTracking();

        public void Update(T item)
        {
            //_dbContext.Entry(item).State = EntityState.Modified;
            //_dbSet.Attach(item);
            _dbSet.AddOrUpdate(item);
        }
    }
}
