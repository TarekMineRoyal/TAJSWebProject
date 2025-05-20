using Application.DTOs.Post;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostResponse>().ReverseMap();

        CreateMap<AddPostRequest, Post>();

        CreateMap<UpdatePostRequest, Post>();
        CreateMap<AddPostRequest, Post>().ReverseMap();
    }
}
