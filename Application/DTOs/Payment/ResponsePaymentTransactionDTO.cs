using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class ResponsePaymentTransactionDTO
    {
        // Auto-generated unique identifier
        public int Id { get; set; }

        // Type of transaction (Deposit, Final, Refund)
        public TType TransactionType { get; set; }

        // Amount of the transaction
        public decimal Amount { get; set; }

        // Date of the transaction
        public DateTime TransactionDate { get; set; }

        // Foreign key to the associated Payment
        public int PaymentId { get; set; }

        // Foreign key to the payment method used
        public int PaymentMethodId { get; set; }
    }
}
