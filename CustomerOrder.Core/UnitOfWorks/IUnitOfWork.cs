
using CustomerOrderApp.Core.Repositories;
using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }

        IRepository<Product> Products { get; }

        IRepository<CustomerOrder> CustomerOrders { get; }

        IRepository<CustomerAddress> CustomerAddresses { get; }

        IRepository<CustomerOrderProduct> CustomerOrderProducts { get; }

        IRepository<CustomerPermission> CustomerPermissions { get; }
        int Commit();
        void Dispose();
    }
}
