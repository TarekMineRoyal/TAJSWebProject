using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Region
{
    public class ResponseRegionDTO
    {
        public int Id { get; set; }
<<<<<<< HEAD:Application/DTOs/Region/ResponseRegionDTO.cs
        
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
=======
>>>>>>> dd027430a6e70ec331f0186f2862cf9b59ad822a:Application/DTOs/Region/UpdateRegionDTO.cs
        public string? Name { get; set; }

    }
}
