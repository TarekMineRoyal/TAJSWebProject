using AutoMapper;
using DataAccess.Entities;
using DTO;

namespace BLL.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDTO>().ReverseMap();

        CreateMap<CreateCarDTO, Car>().ReverseMap();

        CreateMap<UpdateCarDTO, Car>().ReverseMap();
    }
}
