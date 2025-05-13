using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TripPlanCarDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        // Simplified references
        public int TripPlanId { get; set; }
        public int CarId { get; set; }



    }
}
