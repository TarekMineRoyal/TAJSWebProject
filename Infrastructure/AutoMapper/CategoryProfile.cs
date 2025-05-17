using Application.DTOs.Category;
using Domain.Entities;
using AutoMapper;
using Application.DTOs;

namespace Infrastructure.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
        }
    }
}