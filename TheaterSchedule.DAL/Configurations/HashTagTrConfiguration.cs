using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Configurations
{
    public class HashTagTrConfiguration : IEntityTypeConfiguration<HashTagTr>
    {
        public void Configure(EntityTypeBuilder<HashTagTr> builder)
        {
            builder.ToTable("HashTag_TR");

            builder.Property(e => e.HashTagTrid).HasColumnName("HashTag_TRId");

            builder.Property(e => e.Tag)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.HashTag)
                .WithMany(p => p.HashTagTr)
                .HasForeignKey(d => d.HashTagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HashTag_TR_HashTag");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.HashTagTr)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HashTag_TR_Language");
        }
    }
}
