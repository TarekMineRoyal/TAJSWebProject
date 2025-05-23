// Infrastructure/AutoMapper/TripPlanProfile.cs
using Application.DTOs.TripPlan;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Infrastructure.AutoMapper
{
    public class TripPlanProfile : Profile
    {
        public TripPlanProfile()
        {
            CreateMap<TripPlan, TripPlanDTO>()
                .ForMember(
                    dest => dest.IncludedServices,
                    opt => opt.MapFrom(src => src.IncludedServices.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                                .Select(s => s.Trim())
                                                                .ToList())
                );
            CreateMap<CreateTripPlanDTO, TripPlan>().ReverseMap();
            CreateMap<UpdateTripPlanDTO, TripPlan>();
        }
    }
}