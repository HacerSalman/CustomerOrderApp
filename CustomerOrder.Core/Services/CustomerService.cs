
using CustomerOrderApp.Core.Resources;
using CustomerOrderApp.Core.UnitOfWorks;
using CustomerOrderApp.Core.Utils;
using CustomerOrderApp.Data.Entities;
using CustomerOrderApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            //Get hash of the password
            newCustomer.Password = ClaimPrincipal.HashPassword(newCustomer.Password);
            await _unitOfWork.Customers.AddAsync(newCustomer);
            _unitOfWork.Commit();
            return newCustomer;
        }

        public async Task<bool> CreateCustomerPermission(ulong customerId)
        {
            try
            {
                await _unitOfWork.CustomerPermissions.AddRangeAsync(new List<CustomerPermission>
            {
                new CustomerPermission()
            {
                CustomerId = customerId,
                Status = EntityStatus.Values.ACTIVE,
                Permission = Permission.Values.CUSTOMER_MANAGE
            },
            new CustomerPermission()
            {
                CustomerId = customerId,
                Status = EntityStatus.Values.ACTIVE,
                Permission = Permission.Values.CUSTOMER_ORDER_MANAGE
            }
            });
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
 
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            customer.Status = EntityStatus.Values.DELETED;
            await _unitOfWork.Customers.Update(customer);
            _unitOfWork.Commit();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(ulong id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task<string> Login(string email, string password)
        {
          
            //Find the Customer
            var Customer = await Task.FromResult(_unitOfWork.Customers.Find(_ => _.Email == email ).FirstOrDefault());
            if (Customer == null)
                throw new InvalidOperationException(Resource.USERNAME_OR_PASSWORD_INCORRECT);

            //Verify password
            if (!ClaimPrincipal.VerifyPassword(password, Customer.Password))
                throw new InvalidOperationException(Resource.INCORRECT_PASSWORD);

            //Get Customer permissions
            var CustomerPermissions = _unitOfWork.CustomerPermissions.Find(_ => _.CustomerId == Customer.Id).Select(_ => _.Permission.ToString()).ToList();

            //Get Customer jwt token
            return await Task.FromResult(ClaimPrincipal.GenerateToken(Customer.Id.ToString(), CustomerPermissions));

        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            //Get hash of the password
            customer.Password = ClaimPrincipal.HashPassword(customer.Password);
            await _unitOfWork.Customers.Update(customer);
            _unitOfWork.Commit();
            return customer;
        }
    }
}
