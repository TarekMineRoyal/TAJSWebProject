using Application.DTOs.Booking;
using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public decimal AmountPaid { get; set; }
        public BookingResponse Booking { get; set; }
    }
}
