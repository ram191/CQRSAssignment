using System;
using Microsoft.EntityFrameworkCore;

namespace DecoratorPattern.Model
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPaymentCard> CustomerPaymentCards { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CustomerPaymentCard>()
                .HasOne(k => k.Customer)
                .WithMany()
                .HasForeignKey(k => k.Customer_id);

            modelBuilder
                .Entity<Product>()
                .HasOne(k => k.Merchant)
                .WithMany()
                .HasForeignKey(k => k.Merchant_id);
        }
    }
}
