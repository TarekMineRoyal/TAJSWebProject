using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TripPlan
{
    public class UpdateTripPlanDTO
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        //[CustomValidation(typeof(TripPlanValidator), nameof(ValidateEndAfterStart))]
        public DateTime? EndDateTime { get; set; }

        [Range(1, 365)]
        public int? Duration { get; set; }

        [StringLength(1000)]
        public string? IncludedServices { get; set; }

        [StringLength(500)]
        public string? Stops { get; set; }

        [StringLength(500)]
        public string? MealsPlan { get; set; }

        [StringLength(500)]
        public string? HotelsStays { get; set; }

        public int? RegionId { get; set; }

        // Explicitly excluded:
        // - TripId (immutable once set)
        // - Cars (managed via dedicated endpoints)
    }
}
