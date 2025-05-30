﻿using Application.DTOs.Customer;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.AppEntities;

namespace Application.AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerResponse>();

        CreateMap<AddCustomerRequest, Customer>();

        CreateMap<UpdateCustomerRequest, Customer>();
    }
}
