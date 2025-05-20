using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class RequestPaymentTransactionDTO
    {
        // Type of transaction (Deposit, Final, Refund)
        [Required(ErrorMessage = "TransactionType is required")]
        public TType TransactionType { get; set; }

        // Amount of the transaction
        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }

        // Date of the transaction
        [Required(ErrorMessage = "TransactionDate is required")]
        public DateTime TransactionDate { get; set; }

        // Foreign key to the associated Payment
        [Required(ErrorMessage = "PaymentId is required")]
        public int PaymentId { get; set; }

        // Foreign key to the payment method used
        [Required(ErrorMessage = "PaymentMethodId is required")]
        public int PaymentMethodId { get; set; }
    }
}
