using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Post;

public class UpdateSeoMetaDataToPostRequest
{
    public string? UrlSlug { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }
}
