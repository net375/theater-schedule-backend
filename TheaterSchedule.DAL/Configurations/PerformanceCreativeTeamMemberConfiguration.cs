using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class PerformanceCreativeTeamMemberConfiguration 
        : IEntityTypeConfiguration<PerformanceCreativeTeamMember>
    {
        public void Configure(EntityTypeBuilder<PerformanceCreativeTeamMember> builder)
        {
            builder.HasKey(e => new { e.CreativeTeamMemberId, e.PerformanceId });

            builder.HasIndex(e => e.PerformanceCreativeTeamMemberId)
                .HasName("UQ__Performa__6F067466AA9E9F09")
                .IsUnique();

            builder.Property(e => e.PerformanceCreativeTeamMemberId).ValueGeneratedOnAdd();

            builder.HasOne(d => d.CreativeTeamMember)
                .WithMany(p => p.PerformanceCreativeTeamMember)
                .HasForeignKey(d => d.CreativeTeamMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceCreativeTeamMember_CreativeTeamMember");

            builder.HasOne(d => d.Performance)
                .WithMany(p => p.PerformanceCreativeTeamMember)
                .HasForeignKey(d => d.PerformanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceCreativeTeamMember_Performance");
        }
    }
}
