using Application.DTOs.Post;
using Application.DTOs.SEOMetaData;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class SEOMetaDataProfile : Profile
{
    public SEOMetaDataProfile()
    {
        CreateMap<SeoMetadata, SEOMetaDataResponse>();

        CreateMap<AddSEOMetaDataToPostRequest, SeoMetadata>();

        CreateMap<UpdateSeoMetaDataToPostRequest, SeoMetadata>();
    }
}
