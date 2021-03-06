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
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IMapper _mapper;
        public CustomerOrderController(ICustomerOrderService customerOrderService, IMapper mapper)
        {
            _customerOrderService = customerOrderService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("customers/{customerId}/customerOrders")]
        [CustomerOrderAuthorize(UP.CUSTOMER_ORDER_MANAGE)]
        public async Task<ActionResult<CustomerOrderDTO>> CreateCustomerOrder(ulong customerId, [FromBody] CustomerOrderCreateDTO customerOrderDTO)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerToCreate = _mapper.Map<CustomerOrderCreateDTO, CustomerOrder>(customerOrderDTO);
            return _mapper.Map<CustomerOrder, CustomerOrderDTO>(await _customerOrderService.CreateCustomerOrder(customerToCreate));
           
        }

        [HttpGet]
        [Route("customers/{customerId}/customerOrders/{id}")]
        [CustomerOrderAuthorize(UP.CUSTOMER_ORDER_MANAGE)]
        public async Task<ActionResult<CustomerOrderDTO>> GetCustomerOrderById(ulong customerId, ulong id)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerOrder = await _customerOrderService.GetCustomerOrderById(id);
            return _mapper.Map<CustomerOrder, CustomerOrderDTO>(customerOrder);
        }


        [HttpGet]
        [Route("customers/{customerId}customerOrders")]
        [CustomerOrderAuthorize(UP.CUSTOMER_ORDER_MANAGE)]
        public async Task<ActionResult<List<CustomerOrderDTO>>> GetCustomerOrderList(ulong customerId)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerOrderList = await _customerOrderService.GetAllCustomerOrdersByCustomerId(customerId);
            return _mapper.Map<IEnumerable<CustomerOrder>, List<CustomerOrderDTO>>(customerOrderList);
        }

        [HttpPut]
        [Route("customers/{customerId}/customerOrders")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerOrderDTO>> UpdateCustomerOrder(ulong customerId, [FromBody] CustomerOrderUpdateDTO customerOrderUpdateDTO)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customer = _mapper.Map<CustomerOrderUpdateDTO, CustomerOrder>(customerOrderUpdateDTO);
            var newCustomer = await _customerOrderService.UpdateCustomerOrder(customer);
            return _mapper.Map<CustomerOrder, CustomerOrderDTO>(newCustomer);
        }

        [HttpDelete]
        [Route("customers/{customerId}/customerOrders/{id}")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerOrderDTO>> DeleteCustomerOrder(ulong customerId, ulong id)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerOrder = await _customerOrderService.GetCustomerOrderById(id);
            return _mapper.Map<CustomerOrder, CustomerOrderDTO>(await _customerOrderService.DeleteCustomerOrder(customerOrder));
        }
    }
}
