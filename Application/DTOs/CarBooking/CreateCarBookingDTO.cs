﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CarBooking
{
    public class CreateCarBookingDTO
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        [Required] public int CarId { get; set; }  // check later
        [Required][StringLength(100)] public string? PickupLocation { get; set; }
        [Required][StringLength(100)] public string? DropoffLocation { get; set; }
        [Required] public bool WithDriver { get; set; }
        [Required] public DateTime StartDateTime { get; set; }
        [Required] public DateTime EndDateTime { get; set; }
        [Required] public string? PaymentMethod { get; set; }
    }
}
