using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerAddressDTO
    {
        public ulong Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public string Address { get; set; }
    }
}
