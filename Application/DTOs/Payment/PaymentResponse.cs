using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class PaymentResponse
    {
        // Auto-generated unique identifier
        public int Id { get; set; }

        //booking reference
        public int? BookingId { get; set; }

        // Current payment status (Pending, Complete, Refund)
        public StatusEnum Status { get; set; }

        // Total amount due for the payment
        public decimal AmountDue { get; set; }

        // Amount already paid
        public decimal AmountPaid { get; set; }

        // Date when the payment was made
        public DateTime PaymentDate { get; set; }

        //notes or additional information
        public string? Notes { get; set; }

    }
}
