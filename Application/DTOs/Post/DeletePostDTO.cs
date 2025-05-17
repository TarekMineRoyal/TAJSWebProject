using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Post
{
    // Typically just requires ID (passed via route), but for audit purposes:
    public class DeletePostDTO
    {

        [Required(ErrorMessage = "Deletion reason is required")]
        [StringLength(100, ErrorMessage = "Reason cannot exceed 100 characters")]
        public string DeletionReason { get; set; }
    }
}
