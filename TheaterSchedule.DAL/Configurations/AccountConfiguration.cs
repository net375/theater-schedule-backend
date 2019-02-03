using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            

            builder.HasIndex(e => e.PhoneIdentifier)
                .HasName("UQ__Account__3D70EBFAC496CAC0")
                .IsUnique();

            builder.Property(e => e.AccountId).ValueGeneratedOnAdd();

            builder.Property(e => e.Birthdate).HasColumnType("date");

            builder.Property(e => e.Email).HasMaxLength(60);

            builder.Property(e => e.FirstName).HasMaxLength(25);

            builder.Property(e => e.LastName).HasMaxLength(25);

            builder.Property(e => e.Password).HasMaxLength(60);

            builder.Property(e => e.PhoneIdentifier)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.AccountNavigation)
                .WithOne(p => p.Account)
                .HasForeignKey<Account>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Settings");
        }
    }
}
