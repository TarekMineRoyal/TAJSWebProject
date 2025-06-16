using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment
{
    public class ResponsePaymentMethod
    {
        public int Id { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Icon { get; set; }
    }
}
