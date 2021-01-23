using Microsoft.EntityFrameworkCore;

namespace Review.Data
{
    public class ReviewDbContext : DbContext
    {
        public DbSet<Entities.Review> Reviews { get; set; }

        public DbSet<Entities.Rating> Ratings { get; set; }


        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
       : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
