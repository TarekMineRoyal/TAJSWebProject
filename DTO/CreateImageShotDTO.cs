using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreateImageShotDTO
    {
        [Required][StringLength(255)] public string? Path { get; set; }
        [Required][StringLength(50)] public string? Type { get; set; }
        
    }
}
