﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CarBookingDTO
    {
        public int CarId { get; set; }
        public string? PickupLocation { get; set; }
        public string? DropoffLocation { get; set; }
        public bool WithDriver { get; set; }

        // Booking Timeline
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        // Payment Status
        public string? PaymentStatus { get; set; }

    }
}
