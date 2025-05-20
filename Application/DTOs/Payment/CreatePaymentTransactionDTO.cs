using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTOs.Payment
{
    public class CreatePaymentTransactionDTO
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        [Required] public decimal Amount { get; set; }

        public int MethodId { get; set; }
        [Required]public string TransactionType { get; set; }
    }
}
