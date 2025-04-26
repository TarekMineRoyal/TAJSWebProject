using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreatePaymentDTO
    {

        [Required] public decimal AmountDue { get; set; }
        [Required] public string? Method { get; set; }
        [Required] public string? Icon { get; set; }
    }
}
