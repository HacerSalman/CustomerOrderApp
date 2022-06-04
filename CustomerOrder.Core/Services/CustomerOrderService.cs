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
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerOrder> CreateCustomerOrder(CustomerOrder newCustomerOrder)
        {
            //First create customer order
            await _unitOfWork.CustomerOrders.AddAsync(newCustomerOrder);

            //Then create customer order products
            await _unitOfWork.CustomerOrderProducts.AddRangeAsync(newCustomerOrder.CustomerOrderProducts);

            _unitOfWork.Commit();
            return newCustomerOrder;
        }

        public async Task<CustomerOrder> DeleteCustomerOrder(CustomerOrder customerOrder)
        {
            customerOrder.Status = EntityStatus.Values.DELETED;
            await _unitOfWork.CustomerOrders.Update(customerOrder);
            _unitOfWork.Commit();
            return customerOrder;
        }

        public async Task<IEnumerable<CustomerOrder>> GetAllCustomerOrdersByCustomerId(ulong customerId)  //todo: include CustomerAddress
        {
            return await Task.FromResult(_unitOfWork.CustomerOrders.Find(_ => _.CustomerAddress.CustomerId == customerId).ToList());
        }

        public async Task<CustomerOrder> GetCustomerOrderById(ulong id)
        {
            return await _unitOfWork.CustomerOrders.GetByIdAsync(id);
        }

        public async Task<CustomerOrder> UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            await _unitOfWork.CustomerOrders.Update(customerOrder);
            _unitOfWork.Commit();
            return customerOrder;
        }
    }
}
