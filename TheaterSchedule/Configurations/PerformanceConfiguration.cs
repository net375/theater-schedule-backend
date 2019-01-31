﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.Models;

namespace TheaterSchedule.Configurations
{
    public class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            builder.Property( e => e.Description ).HasColumnType( "text" );

            builder.Property( e => e.MainImage ).IsRequired();
        }
    }
}
