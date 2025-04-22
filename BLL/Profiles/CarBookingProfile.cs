using AutoMapper;
using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Profiles
{
    public class CarBookingProfile : Profile
    {
        public CarBookingProfile() 
        { 
            CreateMap<CreateCarBookingDTO,  CarBooking>().ReverseMap();
            CreateMap<CreateBookingDTO, CarBooking>().ReverseMap();
        }
    }
}
