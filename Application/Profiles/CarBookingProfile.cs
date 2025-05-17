using Application.DTOs.Booking;
using Application.DTOs.CarBooking;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class CarBookingProfile : Profile
    {
        public CarBookingProfile()
        {
            CreateMap<CreateCarBookingDTO, CarBooking>().ReverseMap();
            CreateMap<CreateBookingDTO, CarBooking>().ReverseMap();
        }
    }
}
