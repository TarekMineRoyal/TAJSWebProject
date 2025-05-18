using Application.DTOs.TripBooking;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class TripBookingProfile : Profile
    {
        public TripBookingProfile()
        {
            CreateMap<TripBooking, TripBookingDTO>();
            CreateMap<CreateTripBookingDTO, TripBooking>().ReverseMap();
            CreateMap<UpdateTripBookingDTO, TripBooking>();
        }
    }
}