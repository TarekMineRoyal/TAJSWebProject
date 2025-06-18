using Application.DTOs.Car;
using Application.IRepositories;
using Domain.Entities.AppEntities;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICarRepository for interacting with Car entities in the database.
    /// </summary>
    public class SqlCarRepository : SqlGenericRepository<Car>, ICarRepository
    {
        public SqlCarRepository(TourAgencyDbContext tourAgencyDbContext) : base(tourAgencyDbContext)
        {
        }

        /// <summary>
        /// Asynchronously retrieves a paginated list of cars based on specified query parameters.
        /// </summary>
        public async Task<(IEnumerable<Car> Cars, int TotalCount)> GetFilteredCars(CarQueryParameters queryParameters, IEnumerable<int> excludeCarIds = null)
        {
            var query = _dbSet.AsQueryable();

            // Exclude specified car IDs if any are provided
            if (excludeCarIds != null && excludeCarIds.Any())
            {
                query = query.Where(c => !excludeCarIds.Contains(c.Id));
            }

            // --- Apply Filtering ---
            if (!string.IsNullOrEmpty(queryParameters.Model))
            {
                // Corrected line: Add a null check on the database field.
                string modelFilter = queryParameters.Model.ToLower();
                query = query.Where(c => c.Model != null && c.Model.ToLower().Contains(modelFilter));
            }
            if (!string.IsNullOrEmpty(queryParameters.Color))
            {
                // Corrected line: Add a null check on the database field.
                string colorFilter = queryParameters.Color.ToLower();
                query = query.Where(c => c.Color != null && c.Color.ToLower().Contains(colorFilter));
            }
            if (queryParameters.Seats.HasValue)
                query = query.Where(c => c.Seats >= queryParameters.Seats.Value);
            if (queryParameters.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId == queryParameters.CategoryId.Value);
            if (queryParameters.MinPricePerDay.HasValue)
                query = query.Where(c => c.Ppd >= queryParameters.MinPricePerDay.Value);
            if (queryParameters.MaxPricePerDay.HasValue)
                query = query.Where(c => c.Ppd <= queryParameters.MaxPricePerDay.Value);
            if (queryParameters.MinPricePerHour.HasValue)
                query = query.Where(c => c.Pph >= queryParameters.MinPricePerHour.Value);
            if (queryParameters.MaxPricePerHour.HasValue)
                query = query.Where(c => c.Pph <= queryParameters.MaxPricePerHour.Value);

            // --- Apply Sorting ---
            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                bool isDescending = queryParameters.SortOrder?.ToLower() == "desc";
                query = queryParameters.SortBy.ToLower() switch
                {
                    "model" => isDescending ? query.OrderByDescending(c => c.Model) : query.OrderBy(c => c.Model),
                    "ppd" => isDescending ? query.OrderByDescending(c => c.Ppd) : query.OrderBy(c => c.Ppd),
                    "pph" => isDescending ? query.OrderByDescending(c => c.Pph) : query.OrderBy(c => c.Pph),
                    "seats" => isDescending ? query.OrderByDescending(c => c.Seats) : query.OrderBy(c => c.Seats),
                    _ => query.OrderBy(c => c.Id)
                };
            }
            else
            {
                query = query.OrderBy(c => c.Id); // Default sort
            }

            // Get the total count of items that match the filter before applying pagination
            var totalCount = await query.CountAsync();

            // Apply pagination to the query
            var paginatedCars = await query
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToListAsync();

            return (paginatedCars, totalCount);
        }
    }
}