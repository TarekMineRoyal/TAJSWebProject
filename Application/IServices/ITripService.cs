// Application/IServices/ITripService.cs
using Application.DTOs.Trip;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITripService
    {
        Task<TripDTO?> GetTripByIdAsync(int id);
        Task<IEnumerable<TripDTO>> GetAllTripsAsync();
        Task<CreateTripDTO> AddTripAsync(CreateTripDTO dto);
        Task<TripDTO?> UpdateTripAsync(int id, UpdateTripDTO dto);
        Task<TripDTO> DeleteTripAsync(int id);
    }
}