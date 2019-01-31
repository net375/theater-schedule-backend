using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.Models;

namespace TheaterSchedule.Configurations
{
    public class PerformanceCreativeTeamMemberConfiguration 
        : IEntityTypeConfiguration<PerformanceCreativeTeamMember>
    {
        public void Configure(EntityTypeBuilder<PerformanceCreativeTeamMember> builder)
        {
            builder.HasKey( e => new { e.CreativeTeamMemberId, e.PerformanceId } );

            builder.Property( e => e.Role )
                .IsRequired()
                .HasMaxLength( 30 );

            builder.HasOne( d => d.CreativeTeamMember )
                .WithMany( p => p.PerformanceCreativeTeamMember )
                .HasForeignKey( d => d.CreativeTeamMemberId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_PerformanceCreativeTeamMember_CreativeTeamMember" );

            builder.HasOne( d => d.Performance )
                .WithMany( p => p.PerformanceCreativeTeamMember )
                .HasForeignKey( d => d.PerformanceId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_PerformanceCreativeTeamMember_Performance" );
        }
    }
}
