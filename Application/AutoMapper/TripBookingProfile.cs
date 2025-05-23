using Application.DTOs.TripBooking;
using AutoMapper;
using Domain.Entities.AppEntities;

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