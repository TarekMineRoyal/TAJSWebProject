using Application.DTOs.Car;
using Domain.Entities.AppEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    /// <summary>
    /// Defines a repository specifically for Car entities, extending the generic repository.
    /// </summary>
    public interface ICarRepository : IGenericRepository<Car>
    {
        /// <summary>
        /// Gets a paginated, filtered, and sorted list of cars.
        /// </summary>
        /// <param name="queryParameters">The parameters for filtering, sorting, and pagination.</param>
        /// <param name="excludeCarIds">An optional list of car IDs to exclude from the result.</param>
        /// <returns>A tuple containing the list of cars for the current page and the total count of cars matching the filter.</returns>
        Task<(IEnumerable<Car> Cars, int TotalCount)> GetFilteredCars(CarQueryParameters queryParameters, IEnumerable<int> excludeCarIds = null);
    }
}
