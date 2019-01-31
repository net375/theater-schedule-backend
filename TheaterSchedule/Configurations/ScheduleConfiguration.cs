﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.Models;

namespace TheaterSchedule.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property( e => e.Beginning ).HasColumnType( "datetime" );

            builder.Property( e => e.Title )
                .IsRequired()
                .HasMaxLength( 25 );

            builder.HasOne( d => d.Performance )
                .WithMany( p => p.Schedule )
                .HasForeignKey( d => d.PerformanceId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_Schedule_Performance" );
        }
    }
}
