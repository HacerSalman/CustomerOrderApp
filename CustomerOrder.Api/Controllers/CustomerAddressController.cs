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
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressService _customerAddressService;
        private readonly IMapper _mapper;
        public CustomerAddressController(ICustomerAddressService customerAddressService, IMapper mapper)
        {
            _customerAddressService = customerAddressService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("customers/{customerId}/customerAddresses")]
        public async Task<ActionResult<CustomerAddressDTO>> CreateCustomerAddress(ulong customerId, [FromBody] CustomerAddressCreateDTO customerAddressDTO)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerToCreate = _mapper.Map<CustomerAddressCreateDTO, CustomerAddress>(customerAddressDTO);
            return _mapper.Map<CustomerAddress, CustomerAddressDTO>(await _customerAddressService.CreateCustomerAddress(customerToCreate));          
        }

        [HttpGet]
        [Route("customers/{customerId}/customersAddresses/{id}")]
        public async Task<ActionResult<CustomerAddressDTO>> GetCustomerAddressById(ulong customerId, ulong id)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            return _mapper.Map<CustomerAddress, CustomerAddressDTO>(await _customerAddressService.GetCustomerAddressById(id));
        }


        [HttpGet]
        [Route("customers/{customerId}/customerAddresses")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<List<CustomerAddressDTO>>> GetCustomerAddressList(ulong customerId)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            return _mapper.Map<IEnumerable<CustomerAddress>, List<CustomerAddressDTO>>
                (await _customerAddressService.GetAllCustomerAddressesByCustomerId(customerId));
           
        }

        [HttpPut]
        [Route("customers/{customerId}/customerAddresses")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerAddressDTO>> UpdateCustomerAddress(ulong customerId, [FromBody] CustomerAddressUpdateDTO customerAddressUpdateDTO)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customerAddress = _mapper.Map<CustomerAddressUpdateDTO, CustomerAddress>(customerAddressUpdateDTO);
            return _mapper.Map<CustomerAddress, CustomerAddressDTO>(await _customerAddressService.UpdateCustomerAddress(customerAddress));
        }

        [HttpDelete]
        [Route("customers/{customerId}/customerAddresses/{id}")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerAddressDTO>> DeleteCustomerAddress(ulong customerId, ulong id)
        {
            var user = new ClaimPrincipal(HttpContext.User);
            if (user == null)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);
            var userId = user.NameIdentifier.ToULong();
            if (userId != customerId)
                throw new InvalidOperationException(Resource.UNAUTHORIZED);

            var customer = await _customerAddressService.GetCustomerAddressById(id);
            return _mapper.Map<CustomerAddress, CustomerAddressDTO>(await _customerAddressService.DeleteCustomerAddress(customer));
        }

    }
}
