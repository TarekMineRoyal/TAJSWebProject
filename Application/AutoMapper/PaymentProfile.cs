﻿using Application.DTOs.Payment;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<RequestPaymentDTO, Payment>().ReverseMap();
            CreateMap<PaymentResponse, Payment>().ReverseMap();
        }
    }
}
