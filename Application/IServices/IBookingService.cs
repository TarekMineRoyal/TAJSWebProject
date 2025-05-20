// Application/IServices/IBookingService.cs
using Application.DTOs.Booking;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IBookingService
    {
        Task<BookingDTO?> GetBookingByIdAsync(int id);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task<BookingDTO> AddBookingAsync(CreateBookingDTO dto);
        Task<BookingDTO?> UpdateBookingAsync(int id, CreateBookingDTO dto);
        Task<BookingDTO> DeleteBookingAsync(int id);
    }
}