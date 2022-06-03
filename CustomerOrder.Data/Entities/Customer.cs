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
    [Table("customer")]
    public class Customer : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        [StringLength(36)]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(512)]
        public string Password { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<Customer>(modelBuilder, statusConverter);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => e.Email).IsUnique(true);
            });
        }
    }
}
