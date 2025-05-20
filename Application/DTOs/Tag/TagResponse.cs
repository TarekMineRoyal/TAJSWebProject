using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Tag;

public class TagResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
