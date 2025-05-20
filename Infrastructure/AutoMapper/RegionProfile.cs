// Infrastructure/AutoMapper/RegionProfile.cs
using Application.DTOs.Region;
using Domain.Entities;
using AutoMapper;

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