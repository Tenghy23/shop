using Domain.AggregatesModel.CartAggregate;
using Domain.AggregatesModel.CategoryAggregate;
using Domain.AggregatesModel.DiscountAggregate;
using Domain.AggregatesModel.InventoryAggregate;
using Domain.AggregatesModel.OrderAggregate;
using Domain.AggregatesModel.OrderDetailsAggregate;
using Domain.AggregatesModel.PaymentDetailsAggregate;
using Domain.AggregatesModel.ProductAggregate;
using Domain.AggregatesModel.UserAggregate;
using Domain.AggregatesModel.AddressAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Discount> Discount { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }


        // this overrides the original dbContext method for entityConfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}