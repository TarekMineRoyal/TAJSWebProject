// Infrastructure/AutoMapper/TripPlanProfile.cs
using Application.DTOs.TripPlan;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class TripPlanProfile : Profile
    {
        public TripPlanProfile()
        {
            CreateMap<TripPlan, TripPlanDTO>();
            CreateMap<CreateTripPlanDTO, TripPlan>().ReverseMap();
            CreateMap<UpdateTripPlanDTO, TripPlan>();
        }
    }
}