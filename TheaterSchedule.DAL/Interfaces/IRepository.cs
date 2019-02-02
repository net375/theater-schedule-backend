using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public interface IPerformanceRepository : IRepository<Performance>
    {
    }

    public interface IGalleryImageRepository : IRepository<GalleryImage>
    {
    }

    public interface IRepositoryInclude<T> where T : class
    {
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    }
}
