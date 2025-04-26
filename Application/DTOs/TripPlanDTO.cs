using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TripPlanDTO
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public List<string> IncludedServices { get; set; }
        public RegionDTO Region { get; set; }
    }
}
