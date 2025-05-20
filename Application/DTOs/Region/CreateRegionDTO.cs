using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Region
{
    public class CreateRegionDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
