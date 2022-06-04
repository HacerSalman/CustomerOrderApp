using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(ulong id);
        Task<Product> CreateProduct(Product newProduct);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Product product);
    }
}
