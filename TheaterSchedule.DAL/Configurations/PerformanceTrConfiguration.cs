using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class PerformanceTrConfiguration : IEntityTypeConfiguration<PerformanceTr>
    {
        public void Configure(EntityTypeBuilder<PerformanceTr> builder)
        {
            builder.ToTable("Performance_TR");

            builder.Property(e => e.PerformanceTrid).HasColumnName("Performance_TRId");

            builder.Property(e => e.Description).HasColumnType("text");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.Language)
                .WithMany(p => p.PerformanceTr)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Performance_TR_Language");

            builder.HasOne(d => d.Performance)
                .WithMany(p => p.PerformanceTr)
                .HasForeignKey(d => d.PerformanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Performance_TR_Performance");
        }
    }
}
