// Application/IServices/IBookingService.cs
using Application.DTOs.Booking;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IBookingService
    {
        Task<BookingResponse?> GetBookingByIdAsync(int id);
        Task<IEnumerable<BookingResponse>> GetAllBookingsAsync();
        Task<BookingResponse> AddBookingAsync(AddBookingRequest dto);
        Task<BookingResponse?> UpdateBookingAsync(int id, AddBookingRequest dto);
        Task<BookingResponse> DeleteBookingAsync(int id);
    }
}