using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public decimal AmountPaid { get; set; }
        public BookingDTO Booking { get; set; }
    }
}
