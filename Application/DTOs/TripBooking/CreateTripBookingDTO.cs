using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TripBooking
{
    public class CreateTripBookingDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Booking ID is required")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Guide inclusion status is required")]
        public bool WithGuide { get; set; }

        [Required(ErrorMessage = "Trip Plan ID is required")]
        public int TripPlanId { get; set; }
    }
}
