using AutoMapper;
using CustomerOrderApp.Core.DTO;
using CustomerOrderApp.Core.Services;
using CustomerOrderApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UP = CustomerOrderApp.Data.Enums.Permission.Values;

namespace CustomerOrderApp.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("products/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(ulong id)
        {
            return _mapper.Map<Product, ProductDTO>(await _productService.GetProductById(id));
        }


        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<ProductDTO>>> GetProductList()
        {

            return _mapper.Map<IEnumerable<Product>, List<ProductDTO>>(await _productService.GetAllProducts());
        }
    }
}
