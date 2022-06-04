using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public interface ICustomerOrderProductService
    {
        Task<IEnumerable<CustomerOrderProduct>> GetAllCustomerOrderProducts();
        Task<CustomerOrderProduct> GetCustomerOrderProductById(ulong id);
        Task<CustomerOrderProduct> CreateCustomerOrderProduct(CustomerOrderProduct newCustomerOrderProduct);
        Task<CustomerOrderProduct> UpdateCustomerOrderProduct(CustomerOrderProduct customerOrderProduct);
        Task<CustomerOrderProduct> DeleteCustomerOrderProduct(CustomerOrderProduct customerOrderProduct);
    }
}
