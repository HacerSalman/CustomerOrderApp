using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class ProductDTO
    {
        public ulong Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }

        public ulong Quantity { get; set; }
        public double Price { get; set; }
    }
}
