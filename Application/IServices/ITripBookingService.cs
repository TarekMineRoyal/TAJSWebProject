using Application.DTOs.TripBooking;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITripBookingService
    {
        Task<TripBookingDTO?> GetTripBookingByIdAsync(int id);
        Task<IEnumerable<TripBookingDTO>> GetAllTripBookingsAsync();
        Task<CreateTripBookingDTO> AddTripBookingAsync(CreateTripBookingDTO dto);
        Task<TripBookingDTO?> UpdateTripBookingAsync(int id, UpdateTripBookingDTO dto);
        Task<TripBookingDTO> DeleteTripBookingAsync(int id);
    }
}