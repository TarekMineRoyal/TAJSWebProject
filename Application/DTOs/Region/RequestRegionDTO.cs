using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Region
{
    public class RequestRegionDTO
    {
<<<<<<< HEAD:Application/DTOs/Region/RequestRegionDTO.cs
       
        
        [Required(ErrorMessage = "Region name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
=======
        public int Id { get; set; }
>>>>>>> dd027430a6e70ec331f0186f2862cf9b59ad822a:Application/DTOs/Region/CreateRegionDTO.cs
        public string? Name { get; set; }
    }
}
