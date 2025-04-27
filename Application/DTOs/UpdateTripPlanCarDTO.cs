using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateTripPlanCarDTO
    {
        [Range(0.01, 10000000)]
        public decimal? Price { get; set; }

        // Explicitly excluded:
        // - TripPlanId (immutable)
        // - CarId (immutable)
    }
}
