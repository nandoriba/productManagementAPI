using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }

        public DbSet<AssociateProductWithCategory> AssociateProductWithCategory { get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AssociateProductWithCategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
