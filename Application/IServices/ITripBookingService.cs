using Application.DTOs.TripBooking;

namespace Application.IServices
{
    public interface ITripBookingService
    {
        Task<TripBookingDTO?> GetTripBookingByIdAsync(int id);
        Task<IEnumerable<TripBookingDTO>> GetAllTripBookingsAsync();
        Task<TripBookingDTO> AddTripBookingAsync(CreateTripBookingRequestDTO dto);
        Task<TripBookingDTO?> UpdateTripBookingAsync(int id, UpdateTripBookingDTO dto);
        Task<TripBookingDTO> DeleteTripBookingAsync(int id);
    }
}