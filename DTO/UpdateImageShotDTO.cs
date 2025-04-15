using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UpdateImageShotDTO
    {
        [StringLength(255)] public string? Path { get; set; }
        [StringLength(50)] public string? Type { get; set; }
        // CarBookingId excluded (immutable once set)
    }
}
