using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateTripDTO
    {
        [Required] public string? Slug { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public bool IsPrivate { get; set; }
    }
}
