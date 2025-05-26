using Domain.Entities;

namespace Application.DTOs.Post;

public class UpdatePostRequest
{
    public string Title { get; set; }

    public string? Body { get; set; }

    public string? Image { get; set; }

    public string? Slug { get; set; }

    public int Views { get; set; }

    public PostStatus? Status { get; set; }

    public int? PostTypeId { get; set; }

    public string? Summary { get; set; }

    public DateTime PublishDate { get; set; }

    public string? EmployeeId { get; set; }
}
