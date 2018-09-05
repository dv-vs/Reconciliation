using EvoCafe.DAL.Interfaces;
using EvoCafe.DAL.Models;
using EvoCafe.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoCafe.DAL
{
    public class UnitOfWork: IDisposable, IUnitOfWork
    {
        private BDContext _dbContext;

                
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();


        public UnitOfWork(BDContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        //public IDishes Dishes
        //{
        //    get
        //    {
        //        if (_dishes == null)
        //            _dishes = new DishRepository(_dbContext);

        //        return _dishes;
        //    }
        //}

        

        public IGeneralRepository<T> GeneralRepository<T>() where T : EntityBase
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGeneralRepository<T>;
            }
            IGeneralRepository<T> repo = new GeneralRepository<T>(_dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
