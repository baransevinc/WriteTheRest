using Microsoft.EntityFrameworkCore;
using Story.Domain.Entities;
using WriteTheRest.Core.Repository.DbContexts;
using Story.Data.Context.Builders;


namespace Story.Data.Context
{
    public class StoryContext : DbContextBase
    {
        public StoryContext(DbContextOptions<StoryContext> options)
            : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.Story> Stories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<StoryVersion> StoryVersions { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new UserConfiguration());
           modelBuilder.ApplyConfiguration(new StoryVersionConfiguration());
           modelBuilder.ApplyConfiguration(new StoryConfiguration());
           modelBuilder.ApplyConfiguration(new RatingConfiguration());
           modelBuilder.ApplyConfiguration(new ChapterConfiguration());
           base.OnModelCreating(modelBuilder);

        }

    }
}
