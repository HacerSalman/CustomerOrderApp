using CustomerOrderApp.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Data.Contexts
{
    public class CustomerOrderDbContextFactory : IDesignTimeDbContextFactory<CustomerOrderDbContext>
    {
        public CustomerOrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerOrderDbContext>();
            var connString = EnvironmentVariable.GetConfiguration().DbConnection;
            ServerVersion sv = ServerVersion.AutoDetect(connString);
            optionsBuilder.UseMySql(connString, sv);
            optionsBuilder.EnableSensitiveDataLogging();

            return new CustomerOrderDbContext(optionsBuilder.Options);
        }
    }
}
