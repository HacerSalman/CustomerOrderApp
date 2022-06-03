using CustomerOrderApp.Data.Entities;
using CustomerOrderApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Data.Contexts
{
    public class CustomerOrderDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderProduct> CustomerOrderProducts { get; set; }
        public DbSet<CustomerPermission> CustomerPermissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public CustomerOrderDbContext(DbContextOptions<CustomerOrderDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(9000);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var statusConverter = EntityStatus.FluentInitAndSeed(modelBuilder);
            var permissionConverter = Permission.FluentInitAndSeed(modelBuilder);

            Customer.FluentInitAndSeed(modelBuilder, statusConverter);
            Product.FluentInitAndSeed(modelBuilder, statusConverter);
            CustomerAddress.FluentInitAndSeed(modelBuilder, statusConverter);
            CustomerOrder.FluentInitAndSeed(modelBuilder, statusConverter);
            CustomerOrderProduct.FluentInitAndSeed(modelBuilder, statusConverter);
            CustomerPermission.FluentInitAndSeed(modelBuilder, statusConverter, permissionConverter);
        }

       
    }
}
