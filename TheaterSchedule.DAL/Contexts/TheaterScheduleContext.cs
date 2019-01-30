using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Contexts
{
    public class TheaterScheduleContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Performance> Perfomances { get; set; }

        public TheaterScheduleContext(DbContextOptions<TheaterScheduleContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public TheaterScheduleContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            if (!modelBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                modelBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
