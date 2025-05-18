using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.TripPlan
{
    public class TripPlanSummaryDTO
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        [StringLength(100)]
        public string DurationSummary => $"{Duration} Days"; // Derived field

        [StringLength(150)]
        public string IncludedServicesPreview { get; set; } // First 3 services

        // Relationships
        public string RegionName { get; set; }
        public int CarCount { get; set; }

        // Hidden from serialization
        [JsonIgnore]
        public int Duration { get; set; }

        [JsonIgnore]
        public string FullIncludedServices { get; set; }
    }
}
