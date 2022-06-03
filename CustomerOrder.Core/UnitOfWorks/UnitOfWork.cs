using CustomerOrderApp.Core.Repositories;
using CustomerOrderApp.Data.Contexts;
using CustomerOrderApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerOrderDbContext _context;
        private Repository<Customer> _customerRepository;
        private Repository<Product> _productRepository;
        private Repository<CustomerOrder> _customerOrderRepository;
        private Repository<CustomerAddress> _customerAddressRepository;
        private Repository<CustomerOrderProduct> _customerOrderProductRepository;
        private Repository<CustomerPermission> _customerPermissionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(CustomerOrderDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IRepository<Customer> Customers => _customerRepository = _customerRepository ?? new Repository<Customer>(_context, _httpContextAccessor);

        public IRepository<Product> Products => _productRepository = _productRepository ?? new Repository<Product>(_context, _httpContextAccessor);

        public IRepository<CustomerOrder> CustomerOrders => _customerOrderRepository = _customerOrderRepository ?? new Repository<CustomerOrder>(_context, _httpContextAccessor);

        public IRepository<CustomerAddress> CustomerAddresses => _customerAddressRepository = _customerAddressRepository ?? new Repository<CustomerAddress>(_context, _httpContextAccessor);

        public IRepository<CustomerOrderProduct> CustomerOrderProducts => _customerOrderProductRepository = _customerOrderProductRepository ?? new Repository<CustomerOrderProduct>(_context, _httpContextAccessor);

        public IRepository<CustomerPermission> CustomerPermissions => _customerPermissionRepository = _customerPermissionRepository ?? new Repository<CustomerPermission>(_context, _httpContextAccessor);

        public int Commit()
        {                 
            return  _context.SaveChanges();
        }
 
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
