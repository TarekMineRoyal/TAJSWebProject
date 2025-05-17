using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Trip
{
    public class UpdateTripDTO
    {
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        public bool? IsAvailable { get; set; }

        public bool? IsPrivate { get; set; }

        // Explicitly excluded:
        // - Slug (immutable for SEO/stability)
        // - TripPlans (managed via dedicated endpoints)
    }
}
