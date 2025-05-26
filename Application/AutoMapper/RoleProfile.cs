using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;

namespace Application.AutoMapper;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleResponse>();

        CreateMap<AddRoleRequest, Role>();

        CreateMap<UpdateRoleRequest, Role>();
    }
}
