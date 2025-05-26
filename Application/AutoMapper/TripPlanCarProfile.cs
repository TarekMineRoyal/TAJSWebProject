// Infrastructure/AutoMapper/TripPlanCarProfile.cs
using Application.DTOs.TripPlanCar;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Infrastructure.AutoMapper
{
    public class TripPlanCarProfile : Profile
    {
        public TripPlanCarProfile()
        {
            CreateMap<TripPlanCar, TripPlanCarDTO>();
            CreateMap<CreateTripPlanCarDTO, TripPlanCar>().ReverseMap();
            CreateMap<UpdateTripPlanCarDTO, TripPlanCar>();
        }
    }
}