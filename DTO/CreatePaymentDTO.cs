using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreatePaymentDTO
    {
        
        [Required] public decimal AmountDue { get; set; }
        [Required] public DateTime PaymentDate { get; set; }
    }
}
