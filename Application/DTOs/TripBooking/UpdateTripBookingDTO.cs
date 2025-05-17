using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TripBooking
{
    public class UpdateTripBookingDTO
    {
        public bool? WithGuide { get; set; } // Nullable for partial updates

        // Explicitly excluded:
        // - BookingId (immutable once set)
        // - TripPlanId (immutable to prevent reassignment)
    }
}
