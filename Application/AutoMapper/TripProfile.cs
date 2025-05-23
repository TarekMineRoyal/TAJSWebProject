// Infrastructure/AutoMapper/TripProfile.cs
using Application.DTOs.Trip;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Infrastructure.AutoMapper
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripDTO>();
            CreateMap<CreateTripDTO, Trip>().ReverseMap();
            CreateMap<UpdateTripDTO, Trip>();
        }
    }
}