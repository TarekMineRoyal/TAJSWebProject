// Infrastructure/AutoMapper/ImageShotProfile.cs
using Application.DTOs.ImageShot;
using Domain.Entities;
using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public class ImageShotProfile : Profile
    {
        public ImageShotProfile()
        {
            CreateMap<ImageShot, ImageShotDTO>();
            CreateMap<CreateImageShotDTO, ImageShot>().ReverseMap();
            CreateMap<UpdateImageShotDTO, ImageShot>();
        }
    }
}