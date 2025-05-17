using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ImageShot
{
    public class ImageShotDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public int? CarBookingId { get; set; }
    }
}
