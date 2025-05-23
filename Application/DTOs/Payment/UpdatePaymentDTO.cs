using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class UpdatePaymentDTO
    {
        [EnumDataType(typeof(StatusEnum), ErrorMessage = "Invalid payment status")]
        public StatusEnum? Status { get; set; }

        [Range(0.01, 10000000, ErrorMessage = "Amount paid must be between 0.01 and 10,000,000")]
        public decimal? AmountPaid { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PaymentDate { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; }

        // Explicitly excluded fields:
        // - BookingId (immutable after creation)
        // - AmountDue (calculated field, not directly updatable)
        // - PaymentTransactions (managed through dedicated endpoints)
    }
}
