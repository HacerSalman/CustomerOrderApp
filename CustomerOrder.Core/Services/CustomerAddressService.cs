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
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerAddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerAddress> CreateCustomerAddress(CustomerAddress newCustomerAddress)
        {
            await _unitOfWork.CustomerAddresses.AddAsync(newCustomerAddress);
            _unitOfWork.Commit();
            return newCustomerAddress;
        }

        public async Task<CustomerAddress> DeleteCustomerAddress(CustomerAddress customerAddress)
        {
            customerAddress.Status = EntityStatus.Values.DELETED;
            await _unitOfWork.CustomerAddresses.Update(customerAddress);
            _unitOfWork.Commit();
            return customerAddress;
        }

        public async Task<IEnumerable<CustomerAddress>> GetAllCustomerAddressesByCustomerId(ulong customerId)
        {
            return await Task.FromResult(_unitOfWork.CustomerAddresses.Find(_ => _.CustomerId == customerId, new string[] { "Customer" }).ToList());
        }

        public async Task<CustomerAddress> GetCustomerAddressById(ulong id)
        {
            return await _unitOfWork.CustomerAddresses.GetByIdAsync(id);
        }

        public async Task<CustomerAddress> UpdateCustomerAddress(CustomerAddress customerAddress)
        {
            await _unitOfWork.CustomerAddresses.Update(customerAddress);
            _unitOfWork.Commit();
            return customerAddress;
        }
    }
}
