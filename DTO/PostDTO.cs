using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public string? Image { get; set; }
        public string? Slug { get; set; }
        public int Views { get; set; }
        public PType? Status { get; set; }
        public int? PostTypeId { get; set; }
        public string? Summary { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
