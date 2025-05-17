using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Trip
{
    public class CreateTripDTO
    {
        public int Id { get; set; }
        [Required] public string? Slug { get; set; }
        [Required] public bool IsAvailable { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public bool IsPrivate { get; set; }
    }
}
