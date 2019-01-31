using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class GalleryImageConfiguration : IEntityTypeConfiguration<GalleryImage>
    {
        public void Configure(EntityTypeBuilder<GalleryImage> builder)
        {
            builder.Property( e => e.Image ).IsRequired();

            builder.HasOne( d => d.Performance )
                .WithMany( p => p.GalleryImage )
                .HasForeignKey( d => d.PerformanceId )
                .HasConstraintName( "FK_GalleryImage_Performance" );
        }
    }
}
