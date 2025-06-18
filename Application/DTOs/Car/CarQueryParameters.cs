// Application/DTOs/Car/CarQueryModels.cs

using System.Collections.Generic;

namespace Application.DTOs.Car
{
    public class CarQueryParameters
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        // Filtering
        public string? Model { get; set; }
        public string? Color { get; set; }
        public int? Seats { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MaxPricePerDay { get; set; }
        public decimal? MinPricePerDay { get; set; }
        public decimal? MaxPricePerHour { get; set; }
        public decimal? MinPricePerHour { get; set; }

        // Sorting
        public string? SortBy { get; set; } // e.g., "model", "price"
        public string? SortOrder { get; set; } = "asc"; // "asc" or "desc"
    }
}