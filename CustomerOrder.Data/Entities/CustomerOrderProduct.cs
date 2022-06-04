using CustomerOrderApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Data.Entities
{
    [Table("customer_order_product")]
    public class CustomerOrderProduct : BaseEntity
    {
        [Column("customer_order_id")]
        public ulong CustomerOrderId { get; set; }

        public CustomerOrder CustomerOrder { get; set; }

        [Column("quantity")]
        public ulong Quantity { get; set; }

        [Column("product_id")]
        public ulong ProductId { get; set; }

        public Product Product { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<CustomerOrderProduct>(modelBuilder, statusConverter);
            modelBuilder.Entity<CustomerOrderProduct>(entity =>
            {
                entity.HasOne(e => e.CustomerOrder).WithMany(e => e.CustomerOrderProducts).HasForeignKey(e => e.CustomerOrderId).HasPrincipalKey(c => c.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId).HasPrincipalKey(c => c.Id).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
