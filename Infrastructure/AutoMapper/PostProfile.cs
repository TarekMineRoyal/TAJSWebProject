using Application.DTOs.Post;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostResponse>().ReverseMap();

<<<<<<< HEAD
        CreateMap<AddPostRequest, Post>();

        CreateMap<UpdatePostRequest, Post>();
=======
        CreateMap<AddPostRequest, Post>().ReverseMap();
>>>>>>> ad3e403a4d2663c54fb813ed9e3a8cf874d8b22e
    }
}
