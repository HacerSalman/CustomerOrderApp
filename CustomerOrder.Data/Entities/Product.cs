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
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("barcode")]
        [StringLength(256)]
        public string Barcode { get; set; }

        [Column("description")]
        [StringLength(256)]
        public string Description { get; set; }

        [Column("quantity")]
        public ulong Quantity { get; set; }

        [Column("price")]
        public double Price { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<Product>(modelBuilder, statusConverter);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Description);
                entity.HasData(new Product()
                {
                    Id = 1,
                    Owner = "EF",
                    Modifier = "EF",
                    CreateTime = 1654358265000,
                    UpdateTime = 1654358265000,
                    Status = EntityStatus.Values.ACTIVE,
                    Description = "New Product",
                    Barcode = "Barcode",
                    Price = 10,
                    Quantity = 5

                });
            });
        }   
    }
}
