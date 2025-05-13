using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateTripPlanDTO
    {
        [Required(ErrorMessage = "Start date/time is required")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "End date/time is required")]
        [DataType(DataType.DateTime)]

        public DateTime EndDateTime { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 365, ErrorMessage = "Duration must be 1-365 days")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Included services are required")]
        [StringLength(1000, ErrorMessage = "Services list too long")]
        public string? IncludedServices { get; set; }

        [Required(ErrorMessage = "Stops information is required")]
        [StringLength(500)]
        public string? Stops { get; set; }

        [Required(ErrorMessage = "Meals plan is required")]
        [StringLength(500)]
        public string? MealsPlan { get; set; }

        [Required(ErrorMessage = "Hotel stays are required")]
        [StringLength(500)]
        public string? HotelsStays { get; set; }

        [Required(ErrorMessage = "Region ID is required")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Trip ID is required")]
        public int TripId { get; set; }

    }
}
