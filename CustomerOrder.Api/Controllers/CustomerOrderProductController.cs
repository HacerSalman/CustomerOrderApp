using AutoMapper;
using CustomerOrderApp.Core.DTO;
using CustomerOrderApp.Core.Resources;
using CustomerOrderApp.Core.Services;
using CustomerOrderApp.Core.Utils;
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
    public class CustomerOrderProductProductController : ControllerBase
    {
        private readonly ICustomerOrderProductService _customerOrderProductService;
        private readonly IMapper _mapper;
        public CustomerOrderProductProductController(ICustomerOrderProductService customerOrderProductService, IMapper mapper)
        {
            _customerOrderProductService = customerOrderProductService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("customers/{customerId}/customerOrderProducts")]
        [CustomerOrderAuthorize(UP.CUSTOMER_ORDER_MANAGE)]
        public async Task<ActionResult<CustomerOrderProductDTO>> CreateCustomerOrder(ulong customerId, [FromBody] CustomerOrderProductCreateDTO customerOrderProductCreateDTO)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerOrderProduct = _mapper.Map<CustomerOrderProductCreateDTO, CustomerOrderProduct>(customerOrderProductCreateDTO);
            return _mapper.Map<CustomerOrderProduct, CustomerOrderProductDTO>(await _customerOrderProductService.CreateCustomerOrderProduct(customerOrderProduct));

        }

        [HttpGet]
        [Route("customers/{customerId}/customerOrderProducts/{id}")]
        [CustomerOrderAuthorize(UP.CUSTOMER_ORDER_MANAGE)]
        public async Task<ActionResult<CustomerOrderProductDTO>> GetCustomerOrderProductById(ulong customerId, ulong id)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            return _mapper.Map<CustomerOrderProduct, CustomerOrderProductDTO>(await _customerOrderProductService.GetCustomerOrderProductById(id));
        }


        [HttpGet]
        [Route("customers/{customerId}/customerOrders/{customerOrderId}/customerOrderProducts")]
        [CustomerOrderAuthorize(UP.CUSTOMER_ORDER_MANAGE)]
        public async Task<ActionResult<List<CustomerOrderProductDTO>>> GetCustomerOrderProductList(ulong customerId, ulong customerOrderId)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            return _mapper.Map<IEnumerable<CustomerOrderProduct>, List<CustomerOrderProductDTO>>(await _customerOrderProductService.GetAllCustomerOrderProducts(customerOrderId));
        }

        [HttpPut]
        [Route("customers/{customerId}/customerOrderProducts")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerOrderProductDTO>> UpdateCustomerOrderProduct(ulong customerId, [FromBody] CustomerOrderProductUpdateDTO CustomerOrderProductUpdateDTO)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerOrderProduct = _mapper.Map<CustomerOrderProductUpdateDTO, CustomerOrderProduct>(CustomerOrderProductUpdateDTO);
            return _mapper.Map<CustomerOrderProduct, CustomerOrderProductDTO>(await _customerOrderProductService.UpdateCustomerOrderProduct(customerOrderProduct));
     
        }

        [HttpDelete]
        [Route("customers/{customerId}/customerOrderProducts/{id}")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerOrderProductDTO>> DeleteCustomerOrderProduct(ulong customerId, ulong id)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerOrderProduct = await _customerOrderProductService.GetCustomerOrderProductById(id);
            return _mapper.Map<CustomerOrderProduct, CustomerOrderProductDTO>(await _customerOrderProductService.DeleteCustomerOrderProduct(customerOrderProduct));
        }
    }
}
