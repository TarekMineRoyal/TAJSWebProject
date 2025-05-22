using Application.DTOs.CarBooking;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class CarBookingProfile : Profile
    {
        public CarBookingProfile()
        {
            CreateMap<CarBooking, CarBookingDTO>();
            CreateMap<CreateCarBookingDTO, CarBooking>().ReverseMap();
            CreateMap<UpdateCarBookingDTO, CarBooking>();
        }
    }
}