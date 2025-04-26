using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateCarBookingDTO
    {
        [StringLength(100, ErrorMessage = "Pickup location cannot exceed 100 characters")]
        public string? PickupLocation { get; set; }

        [StringLength(100, ErrorMessage = "Drop-off location cannot exceed 100 characters")]
        public string? DropoffLocation { get; set; }

        public bool? WithDriver { get; set; } // Nullable to allow partial updates

        // Explicitly exclude immutable fields:
        // - CarId (cannot change the vehicle after booking)
        // - BookingId (tied to the original booking)
    }
}
