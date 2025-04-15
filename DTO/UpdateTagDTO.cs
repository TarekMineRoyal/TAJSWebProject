using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UpdateTagDTO
    {
        [StringLength(50, ErrorMessage = "Tag name cannot exceed 50 characters")]
        public string? Name { get; set; } // Nullable for partial updates
    }
}
