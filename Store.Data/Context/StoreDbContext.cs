using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using System.Reflection;

namespace Store.Data.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        // modelBuilder.Entity<Product>()
        //.Property(p => p.Price)
        //.HasColumnType("decimal(18,2)");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet <ProductType> productTypes { get; set; }
        public DbSet<DeliveryMethod> deliveryMethods { get; set; }




    }
}
