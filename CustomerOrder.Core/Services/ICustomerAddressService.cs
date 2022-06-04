using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public interface ICustomerAddressService
    {
        Task<IEnumerable<CustomerAddress>> GetAllCustomerAddressesByCustomerId(ulong customerId);
        Task<CustomerAddress> GetCustomerAddressById(ulong id);
        Task<CustomerAddress> CreateCustomerAddress(CustomerAddress newCustomerAddress);
        Task<CustomerAddress> UpdateCustomerAddress(CustomerAddress customerAddress);
        Task<CustomerAddress> DeleteCustomerAddress(CustomerAddress customerAddress);
    }
}
