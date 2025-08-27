using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Story.Domain.Entities;

namespace Story.Data.Context.Builders
{
    public class StoryVersionConfiguration : IEntityTypeConfiguration<StoryVersion>
    {
        public void Configure(EntityTypeBuilder<StoryVersion> builder)
        {
            builder.HasKey(sv => sv.Id);

            builder.Property(sv => sv.Title)
                .HasMaxLength(200);

            builder.Property(sv => sv.Content)
                .IsRequired()
             .HasMaxLength(4000); 

            builder.Property(sv => sv.CreatedAt)
                .IsRequired();

            builder.Property(sv => sv.IsPublishedVersion)
                .IsRequired();

            builder.Property(sv => sv.TotalScore)
                .IsRequired();

            builder.Property(sv => sv.RatingCount)
                .IsRequired();

            builder.HasOne(sv => sv.Chapter)
                .WithMany(c => c.StoryVersions)
                .HasForeignKey(sv => sv.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sv => sv.User)
                .WithMany(u => u.StoryVersions)
                .HasForeignKey(sv => sv.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sv => sv.Ratings)
                .WithOne(r => r.StoryVersion)
                .HasForeignKey(r => r.StoryVersionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}