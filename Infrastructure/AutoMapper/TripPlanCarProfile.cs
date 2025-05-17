// Infrastructure/AutoMapper/TripPlanCarProfile.cs
using Application.DTOs.TripPlanCar;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class TripPlanCarProfile : Profile
    {
        public TripPlanCarProfile()
        {
            CreateMap<TripPlanCar, TripPlanCarDTO>();
            CreateMap<CreateTripPlanCarDTO, TripPlanCar>();
            CreateMap<UpdateTripPlanCarDTO, TripPlanCar>();
        }
    }
}