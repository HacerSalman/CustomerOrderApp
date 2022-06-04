
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            await _unitOfWork.Products.AddAsync(newProduct);
            _unitOfWork.Commit();
            return newProduct;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            product.Status = EntityStatus.Values.DELETED;
            await _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetProductById(ulong id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            await _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
            return product;
        }
    }
}
