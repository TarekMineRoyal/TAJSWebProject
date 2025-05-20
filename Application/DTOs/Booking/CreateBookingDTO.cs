using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Booking
{
    public class CreateBookingDTO
    {
        //public int Id { get; set; }
        [Required] public DateTime StartDateTime { get; set; }
        [Required] public DateTime EndDateTime { get; set; }
        [Required][Range(1, int.MaxValue)] public int NumberOfPassengers { get; set; }

    }
}
