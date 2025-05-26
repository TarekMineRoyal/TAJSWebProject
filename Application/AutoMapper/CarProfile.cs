using Application.DTOs.Booking;
using Application.DTOs.Car;
using Application.DTOs.CarBooking;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Application.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDTO>().ReverseMap();

        CreateMap<CreateCarDTO, Car>().ReverseMap();

        CreateMap<UpdateCarDTO, Car>().ReverseMap();
        CreateMap<AddCarBookingRequest, Car>().ReverseMap();
    }
}
