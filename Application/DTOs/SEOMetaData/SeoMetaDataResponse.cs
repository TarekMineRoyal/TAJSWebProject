using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.SEOMetaData;

public class SEOMetaDataResponse
{
    public int Id { get; set; }
    public string? UrlSlug { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
    public int? PostId { get; set; }
}
