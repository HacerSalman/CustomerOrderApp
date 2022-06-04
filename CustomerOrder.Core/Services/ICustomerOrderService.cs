using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public interface ICustomerOrderService
    {
        Task<IEnumerable<CustomerOrder>> GetAllCustomerOrdersByCustomerId(ulong CustomerId);
        Task<CustomerOrder> GetCustomerOrderById(ulong id);
        Task<CustomerOrder> CreateCustomerOrder(CustomerOrder newCustomerOrder);
        Task<CustomerOrder> UpdateCustomerOrder(CustomerOrder customerOrder);
        Task<CustomerOrder> DeleteCustomerOrder(CustomerOrder customerOrder);
    }
}
