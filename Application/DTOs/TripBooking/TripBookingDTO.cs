using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TripBooking
{
    public class TripBookingDTO
    {
        public int Id { get; set; }
        public bool WithGuide { get; set; }

        // Simplified references to avoid circular dependencies
        public int BookingId { get; set; }
        public int TripPlanId { get; set; }



    }
}
