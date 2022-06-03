
using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(ulong id);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task<Customer> UpdateCustomer(Customer Customer);
        Task<Customer> DeleteCustomer(Customer Customer);

        Task<string> Login(string Email, string password);
        Task<bool> CreateCustomerPermission(ulong id);
    }
}
