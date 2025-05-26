using Application.DTOs.Permission;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class PermissionProfile : Profile
{
    public PermissionProfile()
    {
        CreateMap<Permission, PermissionResponse>();

        CreateMap<UpdatePermissionRequest, Permission>();

        CreateMap<AddPermissionRequest, Permission>();
    }
}
