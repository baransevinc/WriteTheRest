using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Story.Domain.Entities;

namespace Story.Data.Context.Builders
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Order)
                .IsRequired();

            builder.Property(c => c.IsCompleted)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.Summary)
                .HasMaxLength(1000);

            builder.HasOne(c => c.Story)
                .WithMany(s => s.Chapters)
                .HasForeignKey(c => c.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.StoryVersions)
                .WithOne(sv => sv.Chapter)
                .HasForeignKey(sv => sv.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => new { c.StoryId, c.Order }).IsUnique();
        }
    }
}