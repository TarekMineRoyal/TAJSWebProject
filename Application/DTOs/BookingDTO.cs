﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int CarBookingId { get; set; }
        public int TripBookingId { get; set; }
        public bool BookingType { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public BType Status { get; set; }
        public int NumberOfPassengers { get; set; }

    }
}
