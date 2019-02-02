using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class CreativeTeamMemberTrConfiguration : IEntityTypeConfiguration<CreativeTeamMemberTr>
    {
        public void Configure(EntityTypeBuilder<CreativeTeamMemberTr> builder)
        {
            builder.ToTable("CreativeTeamMember_TR");

            builder.Property(e => e.CreativeTeamMemberTrid).HasColumnName("CreativeTeamMember_TRId");

            builder.Property(e => e.FistName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.CreativeTeamMember)
                .WithMany(p => p.CreativeTeamMemberTr)
                .HasForeignKey(d => d.CreativeTeamMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreativeTeamMember_TR_CreativeTeamMembeR");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.CreativeTeamMemberTr)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreativeTeamMember_TR_Language");
        }
    }
}
