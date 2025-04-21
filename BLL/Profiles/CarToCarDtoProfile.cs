using AutoMapper;
using DataAccess.Entities;
using DTO;

namespace BLL.Profiles;

public class CarToCarDtoProfile : Profile
{
    public CarToCarDtoProfile()
    {
        CreateMap<Car, CarDTO>().ReverseMap();
    }
}
