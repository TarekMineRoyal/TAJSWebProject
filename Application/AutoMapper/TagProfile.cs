using Application.DTOs.Tag;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagResponse>().ReverseMap();

        CreateMap<AddTagRequest, Tag>().ReverseMap();

        CreateMap<UpdateTagRequest, Tag>().ReverseMap();
    }
}
