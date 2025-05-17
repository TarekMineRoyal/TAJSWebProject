// Infrastructure/AutoMapper/TripProfile.cs
using Application.DTOs.Trip;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripDTO>();
            CreateMap<CreateTripDTO, Trip>();
            CreateMap<UpdateTripDTO, Trip>();
        }
    }
}