using Microsoft.EntityFrameworkCore;
using NinjaStuff.Entities.Model;

namespace NinjaStuff.Data.Context
{
    public class NinjaStuffContext : DbContext
    {
        public NinjaStuffContext()
        {

        }

        public NinjaStuffContext(DbContextOptions<NinjaStuffContext> Options)
            :base(Options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NinjaStuff");

            ConfigureCustomer(modelBuilder);
            ConfigureOrder(modelBuilder);
            ConfigureOrderProduct(modelBuilder);
            ConfigureProduct(modelBuilder);
        }

        public DbSet<Customer> Customer { get; set; }

        #region ModelBuilder

        private void ConfigureCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Email);
                entity.Property(c => c.Name);
                entity.Property(c => c.Village);
            });
        }

        private void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Description);
                entity.Property(p => p.Picture);
                entity.Property(p => p.Price);
                entity.HasMany(p => p.OrderProducts).WithOne(o => o.Product);
            });
        }

        private void ConfigureOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).ValueGeneratedOnAdd();
                entity.Property(o => o.Date);
                entity.Property(o => o.Discount);
                entity.Property(o => o.Price);
                entity.Property(o => o.TotalPrice);
                entity.HasOne(c => c.Customer).WithMany(o => o.Orders);
                entity.HasMany(o => o.OrderProducts).WithOne(o => o.Order);
                
            });
        }

        private void ConfigureOrderProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>( entity =>
            {
                entity.HasKey(o => new { o.OrderId, o.ProductId });
                entity.Property(o => o.Amount);
                entity.HasOne(p => p.Product).WithMany(o => o.OrderProducts);
                entity.HasOne(o => o.Order).WithMany(o => o.OrderProducts);

            });

        }
        #endregion
    }
}
