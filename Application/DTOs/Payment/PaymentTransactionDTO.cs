using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class PaymentTransactionDTO
    {
        public int Id {  get; set; }
        public TType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int PaymentId { get; set; }
        public int MethodId { get; set; }
    }
}
