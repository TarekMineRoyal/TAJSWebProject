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
            CreateMap<CarBooking, AddCarBookingResponse>()
               .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.Booking.StartDateTime))
               .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.Booking.EndDateTime))
               .ForMember(dest => dest.NumberOfPassengers, opt => opt.MapFrom(src => src.Booking.NumberOfPassengers))
               
               .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
               .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Car.Seats))
               .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Car.Color))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Car.Image))
               .ForMember(dest => dest.Mbw, opt => opt.MapFrom(src => src.Car.Mbw))
               .ForMember(dest => dest.Pph, opt => opt.MapFrom(src => src.Car.Pph))
               .ForMember(dest => dest.Ppd, opt => opt.MapFrom(src => src.Car.Ppd));
            
            CreateMap<UpdateCarBookingDTO, CarBooking>();
        }
    }
}