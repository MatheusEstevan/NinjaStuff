using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStuff.Data.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> List();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        int Delete(int id);
        void RemoveRange(ICollection<T> items);
    }
}
