using AutoMapper;
using CustomerOrderApp.Core.DTO;
using CustomerOrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSuggestion.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
            CreateMap<CustomerOrder, CustomerOrderDTO>().ReverseMap();
            CreateMap<CustomerOrder, CustomerOrderUpdateDTO>().ReverseMap();
            CreateMap<CustomerOrder, CustomerOrderCreateDTO>().ReverseMap();

        }
    }
}
