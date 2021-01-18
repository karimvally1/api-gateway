using Common.Enums;
using Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Product.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedEnumValues<Entities.Category, CategoryEnum>(c => c);
        }
    }
}
