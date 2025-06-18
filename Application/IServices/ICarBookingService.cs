using Application.DTOs.CarBooking;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICarBookingService
    {
        Task<AddCarBookingResponse?> GetCarBookingByIdAsync(int id);
        Task<IEnumerable<AddCarBookingResponse>> GetAllCarBookingsAsync();
        Task<AddCarBookingResponse> AddCarBookingAsync(AddCarBookingRequest dto);
        Task<AddCarBookingResponse?> UpdateCarBookingAsync(int id, UpdateCarBookingDTO dto);
        Task<AddCarBookingResponse> DeleteCarBookingAsync(int id);
    }
}