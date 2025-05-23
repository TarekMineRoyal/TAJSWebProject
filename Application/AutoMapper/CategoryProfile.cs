using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Infrastructure.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>();
        }
    }
}