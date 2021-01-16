using Microsoft.EntityFrameworkCore;

namespace Product.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.ProductStatus> ProductStatuses { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
