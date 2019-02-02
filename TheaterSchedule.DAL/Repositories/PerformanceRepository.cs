using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Repositories
{
    class PerformanceRepository : IPerformanceRepository
    {
        private TheaterScheduleContext db;

        public PerformanceRepository(TheaterScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Performance> GetAll()
        {
            return db.Performance;
        }

        public Performance Get(int id)
        {
            return db.Performance.Find(id);
        }

        public void Create(Performance performance)
        {
            db.Performance.Add(performance);
        }

        public void Update(Performance performance)
        {
            db.Entry(performance).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Performance performance = db.Performance.Find(id);
            if (performance != null)
                db.Performance.Remove(performance);
        }
    }
}
