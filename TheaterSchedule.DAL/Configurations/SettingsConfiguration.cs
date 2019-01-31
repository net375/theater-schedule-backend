using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.Property( e => e.Language ).HasMaxLength( 25 );
        }
    }
}
