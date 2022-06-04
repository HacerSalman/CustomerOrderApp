using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Data.Enums
{
    [Table("permission")]
    public class Permission
    {
        [Column("v", TypeName = "VARCHAR(32)")]
        public Values V { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Values
        {
            CUSTOMER_MANAGE,
            CUSTOMER_ORDER_MANAGE,
            PRODUCT_MANAGE,
            SYSTEM_MANAGE
        }

        internal static EnumToStringConverter<Values> FluentInitAndSeed(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<Values>();
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.V);
                entity.Property(e => e.V).HasConversion(converter);
            });
            var values = Enum.GetValues(typeof(Values)).Cast<Values>();
            foreach (var v in values)
            {
                modelBuilder.Entity<Permission>(entity =>
                {
                    entity.HasData(new Permission() { V = v });
                });
            }
            return converter;
        }
    }
}
