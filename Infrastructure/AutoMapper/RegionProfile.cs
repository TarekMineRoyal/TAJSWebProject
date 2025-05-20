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
            CreateMap<Region, RegionDTO>();
            CreateMap<RequestRegionDTO, Region>().ReverseMap();
            CreateMap<ResponseRegionDTO, Region>();
        }
    }
}