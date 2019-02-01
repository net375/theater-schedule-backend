using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class PerformanceCreativeTeamMemberTrConfiguration
        : IEntityTypeConfiguration<PerformanceCreativeTeamMemberTr>
    {
        public void Configure(EntityTypeBuilder<PerformanceCreativeTeamMemberTr> builder)
        {
            builder.ToTable("PerformanceCreativeTeamMember_TR");

            builder.Property(e => e.PerformanceCreativeTeamMemberTrid).HasColumnName("PerformanceCreativeTeamMember_TRId");

            builder.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.Language)
                .WithMany(p => p.PerformanceCreativeTeamMemberTr)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceCreativeTeamMember_TR_Language");

            builder.HasOne(d => d.PerformanceCreativeTeamMember)
                .WithMany(p => p.PerformanceCreativeTeamMemberTr)
                .HasPrincipalKey(p => p.PerformanceCreativeTeamMemberId)
                .HasForeignKey(d => d.PerformanceCreativeTeamMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceCreativeTeamMember_TR_PerformanceCreativeTeamMember");
        }
    }
}
