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
    [Table("customer_permission")]
    public class CustomerPermission :BaseEntity   
    {
        [Column("customer_id")]
        public ulong CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Column("permission", TypeName = "VARCHAR(32)")]
        public Permission.Values Permission { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter, EnumToStringConverter<Permission.Values> permissionConverter)
        {
            FluentInit<CustomerPermission>(modelBuilder, statusConverter);
            modelBuilder.Entity<CustomerPermission>(entity =>
            {
                entity.HasOne(e => e.Customer).WithMany().HasForeignKey(c => c.CustomerId).HasPrincipalKey(s => s.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.Permission, e.CustomerId }).IsUnique();
                entity.Property(e => e.Permission).HasConversion(permissionConverter);
                entity.HasOne<Permission>().WithMany().HasForeignKey(c => c.Permission).OnDelete(DeleteBehavior.Restrict);


            });
        }
    }
}
