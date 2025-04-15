using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreatePostDTO
    {
        [Required][StringLength(50)] public string? Title { get; set; }
        [Required] public string? Body { get; set; }
        [Required] public string? Slug { get; set; }
        
    }
}
