using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public long CreateTime { get; set; }
        public long UpdateTime { get; set; }
    }
}
