﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdatePostDTO
    {
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string? Title { get; set; }

        public string? Body { get; set; }

        [StringLength(50, ErrorMessage = "Slug cannot exceed 50 characters")]
        public string? Slug { get; set; }

        [EnumDataType(typeof(PType))]
        public PType? Status { get; set; }

        [StringLength(50, ErrorMessage = "Summary cannot exceed 50 characters")]
        public string? Summary { get; set; }

        // Explicitly excluded:
        // - PostTypeId (immutable after creation)
        // - Views (auto-managed by system)
        // - PublishDate (set on initial publish)
    }
}
