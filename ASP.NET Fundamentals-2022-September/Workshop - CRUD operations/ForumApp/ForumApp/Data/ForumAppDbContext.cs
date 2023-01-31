using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {

        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();
            modelBuilder
                .Entity<Post>()
                .HasData(this.FirstPost, this.SecondPost, this.ThirdPost);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedPosts()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "First",
                Content = "First Content"
            };
            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "Second",
                Content = "Second Content"
            };
            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "Third",
                Content = "Third Content"
            };
        }
    }
}
