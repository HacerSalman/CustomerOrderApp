using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerOrderProductCreateDTO
    {
        public ulong CustomerOrderId { get; set; }

        public ulong Quantity { get; set; }

        public ulong ProductId { get; set; }
    }
}
