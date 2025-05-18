using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Region
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BookingId { get; set; } // Nullable
    }
}
