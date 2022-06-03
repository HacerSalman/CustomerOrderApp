

using CustomerOrderApp.Core.Services;
using CustomerOrderApp.Core.UnitOfWorks;
using CustomerOrderApp.Data.Contexts;
using CustomerOrderApp.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerOrderApp.Core.Utils
{
    public static class DIRegister
    {
        public static void AddDIRegister(this IServiceCollection services)
        {
            var connString = EnvironmentVariable.GetConfiguration().DbConnection;
            ServerVersion sv = ServerVersion.AutoDetect(connString);
            services.AddDbContext<CustomerOrderDbContext>(options => options.UseMySql(connString, sv), ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerOrderService, CustomerOrderService>();
        }
    }
}
