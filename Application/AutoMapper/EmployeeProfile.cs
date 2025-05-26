using Application.DTOs.Employee;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.AppEntities;

namespace Application.AutoMapper;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeResponse>();

        CreateMap<AddEmployeeRequest, Employee>();

        CreateMap<UpdateEmployeeRequest, Employee>();
    }
}
