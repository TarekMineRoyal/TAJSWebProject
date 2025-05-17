// Application/IServices/ITripPlanCarService.cs
using Application.DTOs.TripPlanCar;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITripPlanCarService
    {
        Task<TripPlanCarDTO?> GetTripPlanCarByIdAsync(int id);
        Task<IEnumerable<TripPlanCarDTO>> GetAllTripPlanCarsAsync();
        Task<CreateTripPlanCarDTO> AddTripPlanCarAsync(CreateTripPlanCarDTO dto);
        Task<TripPlanCarDTO?> UpdateTripPlanCarAsync(int id, UpdateTripPlanCarDTO dto);
        Task<TripPlanCarDTO> DeleteTripPlanCarAsync(int id);
    }
}