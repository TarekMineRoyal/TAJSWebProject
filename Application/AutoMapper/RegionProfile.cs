// Infrastructure/AutoMapper/RegionProfile.cs
using Application.DTOs.Region;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Infrastructure.AutoMapper
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<RequestRegionDTO, Region>().ReverseMap();
            CreateMap<ResponseRegionDTO, Region>().ReverseMap();
        }
    }
}