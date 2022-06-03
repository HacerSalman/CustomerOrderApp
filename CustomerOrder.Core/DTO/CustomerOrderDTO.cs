using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerOrderDTO
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public ulong Quantity { get; set; }

        List<CustomerOrderProductDTO> ProductList{ get; set; }
}
}
