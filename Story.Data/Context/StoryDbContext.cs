using Microsoft.EntityFrameworkCore;
using Story.Domain.Entities;

namespace Story.Data.Context
{
    public class StoryDbContext : DbContext
    {
        public StoryDbContext(DbContextOptions<StoryDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.Story> Stories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<StoryVersion> StoryVersions { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // NO ACTION gibi davranır

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.StoryVersion)
                .WithMany(sv => sv.Ratings)
                .HasForeignKey(r => r.StoryVersionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.UserId, r.StoryVersionId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}
