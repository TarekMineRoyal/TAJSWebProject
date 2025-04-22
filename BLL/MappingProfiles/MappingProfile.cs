using AutoMapper;
using DataAccess.Entities;
using DTO;

namespace BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Car → CarDTO (and reverse)
            CreateMap<Car, CarDTO>().ReverseMap();

            // CreateCarDTO → Car
            CreateMap<CreateCarDTO, Car>();

            // UpdateCarDTO → Car
            CreateMap<UpdateCarDTO, Car>();
        }
    }
}