using Application.DTOs.User;
using AutoMapper;
using Domain.Entities.Identity;

namespace Application.AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponse>();

        CreateMap<SignUpUserRequest, User>();
    }
}
