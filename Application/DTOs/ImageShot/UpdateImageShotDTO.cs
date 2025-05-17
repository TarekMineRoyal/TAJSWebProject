using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ImageShot
{
    public class UpdateImageShotDTO
    {
        [StringLength(255)] public string? Path { get; set; }
        [StringLength(50)] public string? Type { get; set; }
        // CarBookingId excluded (immutable once set)
    }
}
