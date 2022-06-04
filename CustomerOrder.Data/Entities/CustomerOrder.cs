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
    [Table("customer_order")]
    public class CustomerOrder : BaseEntity
    {
        [Column("customer_address_id")]
        public ulong CustomerAddressId { get; set; }

        public CustomerAddress CustomerAddress { get; set; }

        [Column("quantity")]
        public ulong Quantity { get; set; }

        public List<CustomerOrderProduct> CustomerOrderProducts { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<CustomerOrder>(modelBuilder, statusConverter);
            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasOne(e => e.CustomerAddress).WithMany().HasForeignKey(e => e.CustomerAddressId).HasPrincipalKey(c => c.Id).OnDelete(DeleteBehavior.Restrict); ;
            });
        }
    }
}
