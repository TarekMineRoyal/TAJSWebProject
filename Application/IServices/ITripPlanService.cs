// Application/IServices/ITripPlanService.cs
using Application.DTOs.TripPlan;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITripPlanService
    {
        Task<TripPlanDTO?> GetTripPlanByIdAsync(int id);
        Task<IEnumerable<TripPlanDTO>> GetAllTripPlansAsync();
        Task<CreateTripPlanDTO> AddTripPlanAsync(CreateTripPlanDTO dto);
        Task<TripPlanDTO?> UpdateTripPlanAsync(int id, UpdateTripPlanDTO dto);
        Task<TripPlanDTO> DeleteTripPlanAsync(int id);
    }
}