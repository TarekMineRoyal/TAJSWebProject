namespace Application.DTOs.PostType;

public class UpdatePostTypeRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
