using NinjaStuff.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStuff.Data.Generic
{
    public abstract class BaseRepository<T> where T : class
    {

        private readonly NinjaStuffContext _dbContext;
        public BaseRepository(NinjaStuffContext applicationDbContext)
        {
            _dbContext = applicationDbContext;

        }

        public virtual IQueryable<T> List() => _dbContext.Set<T>();

        public virtual T GetById(int id) => _dbContext.Set<T>().Find(id);

        public virtual T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }


        public virtual List<T> CreateRange(List<T> entity)
        {
            _dbContext.Set<T>().AddRange(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
        public virtual IQueryable<T> UpdateRange(IQueryable<T> entity)
        {
            _dbContext.Set<T>().UpdateRange(entity);
            _dbContext.SaveChanges();

            return entity;
        }
        public virtual int Delete(int id)
        {
            T entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                return _dbContext.SaveChanges();
            }
            return -1;

        }

        public virtual void RemoveRange(ICollection<T> items)
        {
            _dbContext.Set<T>().RemoveRange(items);
            _dbContext.SaveChanges();
        }
    }
}
