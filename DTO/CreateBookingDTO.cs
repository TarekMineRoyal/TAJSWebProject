using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreateBookingDTO
    {
        [Required] public bool BookingType { get; set; }
        [Required] public DateTime StartDateTime { get; set; }
        [Required] public DateTime EndDateTime { get; set; }
        [Required][Range(1, int.MaxValue)] public int NumberOfPassengers { get; set; }
        
    }
}
