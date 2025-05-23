// Infrastructure/AutoMapper/ImageShotProfile.cs
using Application.DTOs.ImageShot;
using AutoMapper;
using Domain.Entities.AppEntities;

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