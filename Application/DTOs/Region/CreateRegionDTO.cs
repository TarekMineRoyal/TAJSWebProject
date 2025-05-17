using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Region
{
    public class CreateRegionDTO
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        [Required(ErrorMessage = "Region name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }
    }
}
