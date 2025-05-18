using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Trip
{
    public class TripSummaryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(200)]
        public string ShortDescription { get; set; } // Truncated from full description

        public bool IsPrivate { get; set; }

        // Aggregated stats
        public int TotalPlans { get; set; }
        public string? FeaturedRegion { get; set; }
    }
}
