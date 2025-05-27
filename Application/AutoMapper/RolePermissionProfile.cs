using Application.DTOs.RolePermission;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class RolePermissionProfile : Profile
{
    public RolePermissionProfile()
    {
        CreateMap<RolePermission, RolePermissionResponse>();

        CreateMap<AddRolePermissionRequest, RolePermission>();
    }
}
