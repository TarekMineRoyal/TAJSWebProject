using Application.DTOs.CarBooking;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Infrastructure.AutoMapper
{
    public class CarBookingProfile : Profile
    {
        public CarBookingProfile()
        {
            CreateMap<CarBooking, CarBookingDTO>();
            CreateMap<CreateCarBookingDTO, CarBooking>().ReverseMap();
            CreateMap<AddCarBookingRequest, CarBooking>().ReverseMap();
            CreateMap<AddCarBookingResponse, CarBooking>().ReverseMap();
            CreateMap<UpdateCarBookingDTO, CarBooking>();
        }
    }
}