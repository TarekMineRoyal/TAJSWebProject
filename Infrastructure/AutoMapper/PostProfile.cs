using Application.DTOs.Post;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostResponse>();
<<<<<<< HEAD
=======

        CreateMap<AddPostRequest, Post>();
>>>>>>> Add-Post-Service
    }
}
