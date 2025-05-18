using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ImageShot
{
    public class CreateImageShotDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Image path is required")]
        [StringLength(255, ErrorMessage = "Path cannot exceed 255 characters")]
        public string Path { get; set; }

        [Required(ErrorMessage = "Image type is required")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        public string Type { get; set; }

        public int? CarBookingId { get; set; }
    }
}
