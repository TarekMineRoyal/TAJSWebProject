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
            CreateMap<CreateRegionDTO, Region>();
            CreateMap<UpdateRegionDTO, Region>();
        }
    }
}