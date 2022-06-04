using CustomerOrderApp.Core.UnitOfWorks;
using CustomerOrderApp.Data.Entities;
using CustomerOrderApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public class CustomerOrderProductService : ICustomerOrderProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerOrderProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerOrderProduct> CreateCustomerOrderProduct(CustomerOrderProduct newCustomerOrderProduct)
        {
            await _unitOfWork.CustomerOrderProducts.AddAsync(newCustomerOrderProduct);
            _unitOfWork.Commit();
            return newCustomerOrderProduct;
        }

        public async Task<CustomerOrderProduct> DeleteCustomerOrderProduct(CustomerOrderProduct customerOrderProduct)
        {
            customerOrderProduct.Status = EntityStatus.Values.DELETED;
            await _unitOfWork.CustomerOrderProducts.Update(customerOrderProduct);
            _unitOfWork.Commit();
            return customerOrderProduct;
        }

        public async Task<IEnumerable<CustomerOrderProduct>> GetAllCustomerOrderProducts()
        {
            return await _unitOfWork.CustomerOrderProducts.GetAllAsync();
        }

        public async Task<CustomerOrderProduct> GetCustomerOrderProductById(ulong id)
        {
            return await _unitOfWork.CustomerOrderProducts.GetByIdAsync(id);
        }

        public async Task<CustomerOrderProduct> UpdateCustomerOrderProduct(CustomerOrderProduct customerOrderProduct)
        {
            await _unitOfWork.CustomerOrderProducts.Update(customerOrderProduct);
            _unitOfWork.Commit();
            return customerOrderProduct;
        }
    }
}
