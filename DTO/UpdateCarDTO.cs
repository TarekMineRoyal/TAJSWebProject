using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UpdateCarDTO
    {
        [StringLength(50)] public string? Model { get; set; }
        [Range(1, 40)] public int? Seats { get; set; }
        [Required][StringLength(30)] public string? Color { get; set; }
        [Required] public string? Image { get; set; }
        [Required][Range(0.01, 1000)] public decimal? Mbw { get; set; }
        [Required] public decimal? Pph { get; set; }
        [Required] public decimal? Ppd { get; set; }
        public int? CategoryId { get; set; }
    }
}
