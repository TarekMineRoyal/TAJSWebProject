using Domain.Entities.AppEntities;

namespace Application.DTOs.Post;

public class UpdatePostRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Body { get; set; }
    public string? Image { get; set; }
    public string? Slug { get; set; }
<<<<<<< HEAD

=======
    public int Views { get; set; }
>>>>>>> parent of cd0f207 (Samrah Gay)
    public PostStatus? Status { get; set; }
    public int? PostTypeId { get; set; }
    public string? Summary { get; set; }
<<<<<<< HEAD
=======
    public DateTime PublishDate { get; set; }
>>>>>>> parent of cd0f207 (Samrah Gay)
}
