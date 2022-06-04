using AutoMapper;
using CustomerOrderApp.Core.DTO;
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
    public class CustomerController : ControllerBase
    {
       
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("customers")]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] CustomerCreateDTO customerDTO)
        {
            var customerToCreate = _mapper.Map<CustomerCreateDTO, Customer>(customerDTO);
            var newCustomer = await _customerService.CreateCustomer(customerToCreate);
            await _customerService.CreateCustomerPermission(newCustomer.Id);
            return _mapper.Map<Customer, CustomerDTO>(newCustomer);
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(ulong id)
        {
            var customer = await _customerService.GetCustomerById(id);
            return _mapper.Map<Customer, CustomerDTO>(customer);
        }


        [HttpGet]     
        [Route("customers")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomerList()
        {
            var customerList = await _customerService.GetAllCustomers();
            return _mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(customerList);
        }

        [HttpPut]
        [Route("customers")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer([FromBody] CustomerUpdateDTO customerDTO)
        {
            var customer = _mapper.Map<CustomerUpdateDTO, Customer>(customerDTO);
            var newCustomer = await _customerService.UpdateCustomer(customer);
            return _mapper.Map<Customer, CustomerDTO>(newCustomer);
        }

        [HttpDelete]
        [Route("customers/{id}")]
        [CustomerOrderAuthorize(UP.CUSTOMER_MANAGE)]
        public async Task<ActionResult<CustomerDTO>> DeleteCustomer(ulong id)
        {
            var customer = await _customerService.GetCustomerById(id);
            return _mapper.Map<Customer, CustomerDTO>(await _customerService.DeleteCustomer(customer));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO)
        {
            return await _customerService.Login(loginDTO.Email, loginDTO.Password);
        }
    }
}
