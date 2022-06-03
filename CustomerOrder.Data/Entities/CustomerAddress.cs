using CustomerOrderApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Data.Entities
{
    [Table("customer_address")]
    public class CustomerAddress :BaseEntity
    {
        [Column("address")]
        [StringLength(512)]
        public string Address { get; set; }

        [Column("customer_id")]
        public ulong CustomerId { get; set; }

        public Customer Customer { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<CustomerAddress>(modelBuilder, statusConverter);
            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasOne(e => e.Customer).WithMany().HasForeignKey(e => e.CustomerId).HasPrincipalKey(c => c.Id).OnDelete(DeleteBehavior.Restrict); ;
            });
        }
    }
}
