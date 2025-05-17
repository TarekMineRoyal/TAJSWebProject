using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostResponse>();
    }
}
