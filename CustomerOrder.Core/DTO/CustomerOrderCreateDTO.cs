using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerOrderCreateDTO
    {
        public ulong CustomerAddressId { get; set; }
        public ulong Quantity { get; set; }
    }
}
