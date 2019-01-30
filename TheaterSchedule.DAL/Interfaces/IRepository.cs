using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    }
}
