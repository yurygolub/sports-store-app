using Microsoft.EntityFrameworkCore;
using SportsStore.Repository.EntityFramework.Entities;

namespace SportsStore.Repository.EntityFramework
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }

        public virtual DbSet<OrderEntity> Orders { get; set; }

        public virtual DbSet<CartLineEntity> CartLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SportsStore;MultipleActiveResultSets=true");
            }
        }
    }
}
