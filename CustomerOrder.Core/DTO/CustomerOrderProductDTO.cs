using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerOrderProductDTO
    {
        public ulong Id { get; set; }
        public ulong Quantity { get; set; }
        public CustomerOrderDTO CustomerOrder { get; set; }
        public ProductDTO Product { get; set; }
    }
}
