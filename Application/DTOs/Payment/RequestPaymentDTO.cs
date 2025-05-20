using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class RequestPaymentDTO
    {
        public int? BookingId { get; set; }

        // Enum for payment status (Pending, Complete, Refund)
        [Required(ErrorMessage = "Status is required")]
        public StatusEnum Status { get; set; }

        // Total amount due for the payment
        [Required(ErrorMessage = "AmountDue is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "AmountDue must be positive")]
        public decimal AmountDue { get; set; }

        // Amount already paid (initial value, e.g., 0)
        [Required(ErrorMessage = "AmountPaid is required")]
        [Range(0, double.MaxValue, ErrorMessage = "AmountPaid cannot be negative")]
        public decimal AmountPaid { get; set; }

        // Date when the payment was made
        [Required(ErrorMessage = "PaymentDate is required")]
        public DateTime PaymentDate { get; set; }
    }
}
