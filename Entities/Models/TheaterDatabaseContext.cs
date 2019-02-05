using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class TheaterDatabaseContext : DbContext
    {
        public TheaterDatabaseContext()
        {
        }

        public TheaterDatabaseContext(DbContextOptions<TheaterDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<CreativeTeamMember> CreativeTeamMember { get; set; }
        public virtual DbSet<CreativeTeamMemberTr> CreativeTeamMemberTr { get; set; }
        public virtual DbSet<GalleryImage> GalleryImage { get; set; }
        public virtual DbSet<HashTag> HashTag { get; set; }
        public virtual DbSet<HashTagPerformance> HashTagPerformance { get; set; }
        public virtual DbSet<HashTagTr> HashTagTr { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
        public virtual DbSet<PerformanceCreativeTeamMemberTr> PerformanceCreativeTeamMemberTr { get; set; }
        public virtual DbSet<PerformanceTr> PerformanceTr { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=TheaterConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UX_Email")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneIdentifier)
                    .HasName("UQ__Account__3D70EBFA7FBE8A81")
                    .IsUnique();

                entity.Property(e => e.AccountId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AccountNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Settings");
            });

            modelBuilder.Entity<CreativeTeamMemberTr>(entity =>
            {
                entity.HasOne(d => d.CreativeTeamMember)
                    .WithMany(p => p.CreativeTeamMemberTr)
                    .HasForeignKey(d => d.CreativeTeamMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreativeTeamMember_TR_CreativeTeamMembeR");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CreativeTeamMemberTr)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreativeTeamMember_TR_Language");
            });

            modelBuilder.Entity<GalleryImage>(entity =>
            {
                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.GalleryImage)
                    .HasForeignKey(d => d.PerformanceId)
                    .HasConstraintName("FK_GalleryImage_Performance");
            });

            modelBuilder.Entity<HashTagPerformance>(entity =>
            {
                entity.HasKey(e => e.HashTagPerformanceId)
                    .HasName("PK_HashTagPerformanceID")
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.HashTagPerformanceId)
                    .HasName("UQ__HashTag___121A2E9637EF569F")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.HasOne(d => d.HashTag)
                    .WithMany(p => p.HashTagPerformance)
                    .HasForeignKey(d => d.HashTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HashTag_Performance_HashTag");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.HashTagPerformance)
                    .HasForeignKey(d => d.PerformanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HashTag_Performance_Performance");
            });

            modelBuilder.Entity<HashTagTr>(entity =>
            {
                entity.HasOne(d => d.HashTag)
                    .WithMany(p => p.HashTagTr)
                    .HasForeignKey(d => d.HashTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HashTag_TR_HashTag");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.HashTagTr)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HashTag_TR_Language");
            });

            modelBuilder.Entity<PerformanceCreativeTeamMember>(entity =>
            {
                entity.HasKey(e => new { e.CreativeTeamMemberId, e.PerformanceId });

                entity.HasIndex(e => e.PerformanceCreativeTeamMemberId)
                    .HasName("UQ__Performa__6F0674664B7A4E89")
                    .IsUnique();

                entity.Property(e => e.PerformanceCreativeTeamMemberId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CreativeTeamMember)
                    .WithMany(p => p.PerformanceCreativeTeamMember)
                    .HasForeignKey(d => d.CreativeTeamMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformanceCreativeTeamMember_CreativeTeamMember");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.PerformanceCreativeTeamMember)
                    .HasForeignKey(d => d.PerformanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformanceCreativeTeamMember_Performance");
            });

            modelBuilder.Entity<PerformanceCreativeTeamMemberTr>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PerformanceCreativeTeamMemberTr)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformanceCreativeTeamMember_TR_Language");

                entity.HasOne(d => d.PerformanceCreativeTeamMember)
                    .WithMany(p => p.PerformanceCreativeTeamMemberTr)
                    .HasPrincipalKey(p => p.PerformanceCreativeTeamMemberId)
                    .HasForeignKey(d => d.PerformanceCreativeTeamMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformanceCreativeTeamMember_TR_PerformanceCreativeTeamMember");
            });

            modelBuilder.Entity<PerformanceTr>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PerformanceTr)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Performance_TR_Language");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.PerformanceTr)
                    .HasForeignKey(d => d.PerformanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Performance_TR_Performance");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.PerformanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Performance");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Settings_Language");
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.ScheduleId });

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Watchlist)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Watchlist_Account");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Watchlist)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Watchlist_Schedule");
            });
        }
    }
}
