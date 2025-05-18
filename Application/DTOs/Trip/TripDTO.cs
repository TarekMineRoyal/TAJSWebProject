using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Trip
{
    public class TripDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; } // Immutable identifier

        public bool IsAvailable { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsPrivate { get; set; }
    }
}
