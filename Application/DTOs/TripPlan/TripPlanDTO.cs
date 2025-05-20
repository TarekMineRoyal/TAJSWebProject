using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.DTOs.Region;

namespace Application.DTOs.TripPlan
{
    public class TripPlanDTO
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        [StringLength(100)]
        public string DurationSummary => $"{Duration} Days"; // Derived field
        public List<string> IncludedServices { get; set; }
        public RegionDTO Region { get; set; }

        // Hidden from serialization
        [JsonIgnore]
        public int Duration { get; set; }
    }
}
