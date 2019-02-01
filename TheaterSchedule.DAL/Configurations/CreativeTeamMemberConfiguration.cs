using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class CreativeTeamMemberConfiguration : IEntityTypeConfiguration<CreativeTeamMember>
    {
        public void Configure(EntityTypeBuilder<CreativeTeamMember> builder)
        {
           
        }
    }
}
