using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Car
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Seats { get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; }
        public decimal Mbw { get; set; }
        public decimal Pph { get; set; }
        public decimal Ppd { get; set; }
        public int? CategoryId { get; set; }
    }
}
