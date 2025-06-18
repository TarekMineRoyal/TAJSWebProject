// Application/DTOs/Car/CarQueryModels.cs

using System.Collections.Generic;

namespace Application.DTOs.Car
{
    public class PaginatedCarResponseDTO
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IEnumerable<CarDTO> Cars { get; set; }
    }
}