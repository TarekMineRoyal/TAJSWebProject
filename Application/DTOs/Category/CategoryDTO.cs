using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
    }
}
