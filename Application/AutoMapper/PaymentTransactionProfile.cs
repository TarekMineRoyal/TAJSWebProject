using Application.DTOs.Payment;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class PaymentTransactionProfile : Profile
    {
        public PaymentTransactionProfile() 
        {
            // Ensures all properties, including the new Stripe and PayPal fields, are mapped.
            CreateMap<RequestPaymentTransactionDTO, PaymentTransaction>().ReverseMap();
            CreateMap<ResponsePaymentTransactionDTO, PaymentTransaction>().ReverseMap();
        }
    }
}
