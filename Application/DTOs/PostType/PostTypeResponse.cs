using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PostType;

public class PostTypeResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
