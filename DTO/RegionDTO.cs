using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BookingId { get; set; } // Nullable
    }
}
