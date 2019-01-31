using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.Models;

namespace TheaterSchedule.Configurations
{
    public class HashTagPerformanceConfiguration: IEntityTypeConfiguration<HashTagPerformance>
    {
        public void Configure( EntityTypeBuilder<HashTagPerformance> builder )
        {
            builder.HasKey( e => e.HashTagPerformanceId )
                     .HasName( "PK_HashTagPerformanceID" )
                     .ForSqlServerIsClustered( false );

            builder.ToTable( "HashTag_Performance" );

            builder.HasIndex( e => e.HashTagPerformanceId )
                .HasName( "UQ__HashTag___121A2E9639586659" )
                .IsUnique()
                .ForSqlServerIsClustered();

            builder.Property( e => e.HashTagPerformanceId ).HasColumnName( "HashTagPerformanceID" );

            builder.HasOne( d => d.HashTag )
                .WithMany( p => p.HashTagPerformance )
                .HasForeignKey( d => d.HashTagId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_HashTag_Performance_HashTag" );

            builder.HasOne( d => d.Performance )
                .WithMany( p => p.HashTagPerformance )
                .HasForeignKey( d => d.PerformanceId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_HashTag_Performance_Performance" );
        }
    }
}
