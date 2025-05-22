// Infrastructure/AutoMapper/BookingProfile.cs
using Application.DTOs.Booking;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingResponse>().ReverseMap();
            CreateMap<AddBookingRequest, Booking>().ReverseMap();
            CreateMap<UpdateBookingDTO, Booking>().ReverseMap();
        }
    }
}