using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TheaterSchedule.Configurations;

namespace TheaterSchedule.Models
{
    public partial class TheaterScheduleContext: DbContext
    {
        public TheaterScheduleContext()
        {
        }

        public TheaterScheduleContext( DbContextOptions<TheaterScheduleContext> options )
            : base( options )
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<CreativeTeamMember> CreativeTeamMember { get; set; }
        public virtual DbSet<GalleryImage> GalleryImage { get; set; }
        public virtual DbSet<HashTag> HashTag { get; set; }
        public virtual DbSet<HashTagPerformance> HashTagPerformance { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            if ( !optionsBuilder.IsConfigured )
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings ["DefaultConnection"]
                    .ConnectionString;
                optionsBuilder.UseSqlServer( connectionString );
            }
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.HasAnnotation( "ProductVersion", "2.2.1-servicing-10028" );

            modelBuilder.ApplyConfiguration( new AccountConfiguration() );
            modelBuilder.ApplyConfiguration( new CreativeTeamMemberConfiguration() );
            modelBuilder.ApplyConfiguration( new GalleryImageConfiguration() );
            modelBuilder.ApplyConfiguration( new HashTagConfiguration() );
            modelBuilder.ApplyConfiguration( new HashTagPerformanceConfiguration() );
            modelBuilder.ApplyConfiguration( new PerformanceConfiguration() );
            modelBuilder.ApplyConfiguration( new PerformanceCreativeTeamMemberConfiguration() );
            modelBuilder.ApplyConfiguration( new ScheduleConfiguration() );
            modelBuilder.ApplyConfiguration( new SettingsConfiguration() );
            modelBuilder.ApplyConfiguration( new WatchlistConfiguration() );
        }
    }
}
