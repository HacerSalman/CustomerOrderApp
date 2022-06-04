using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerOrderDTO
    {
        public ulong Id { get; set; }
        public CustomerAddressDTO CustomerAddress { get; set; }
        public ulong Quantity { get; set; }

        public List<CustomerOrderProductDTO> CustomerOrderProducts { get; set; }
}
}
