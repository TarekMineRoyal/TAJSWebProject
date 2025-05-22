using Application.DTOs.PostType;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class PostTypeProfile : Profile
{
    public PostTypeProfile()
    {
        CreateMap<PostType, PostTypeResponse>().ReverseMap();

        CreateMap<AddPostTypeRequest, PostType>().ReverseMap();

        CreateMap<UpdatePostTypeRequest, PostType>().ReverseMap();
    }
}
