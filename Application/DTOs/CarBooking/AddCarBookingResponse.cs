using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CarBooking
{
    public class AddCarBookingResponse
    {
        public int BookingId { get; set; }
        public string? PickupLocation { get; set; }
        public string? DropoffLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NumberOfPassengers { get; set; }
        public int CarId { get; set; }
        public string? Model { get; set; }
        public int Seats { get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; }
        public decimal Mbw { get; set; }
        public decimal Pph { get; set; }
        public decimal Ppd { get; set; }
    }
}
