using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Story.Domain.Entities;

namespace Story.Data.Context.Builders
{
    public class StoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Story>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Story> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Theme)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .HasMaxLength(1000);

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.Property(s => s.IsPublished)
                .IsRequired();

            builder.Property(s => s.PublishedAt);

            builder.HasMany(s => s.Chapters)
                .WithOne(c => c.Story)
                .HasForeignKey(c => c.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => s.Title);
        }
    }
}