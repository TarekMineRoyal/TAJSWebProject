using Application.DTOs.Payment;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class PaymentMethodProfile :Profile
    {
        public PaymentMethodProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            // Request DTO → Entity
            CreateMap<RequestPaymentMethod, PaymentMethod>()
                .ForMember(dest => dest.Method, opt => opt.MapFrom(src => src.Method));

            // Entity → Response DTO
            CreateMap<PaymentMethod, ResponsePaymentMethod>()
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.Method))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
        }

    }
}
